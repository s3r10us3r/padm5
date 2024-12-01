using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using padm5.dal.Interfaces;
using padm5.models;
using padm5.models.Dtos;

namespace padm5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepo _teamRepo;
        private readonly IWorkerRepo _workerRepo;
        private readonly IQueryExecutor _queryExecutor;

        public TeamsController(ITeamRepo teamRepo, IWorkerRepo workerRepo, IQueryExecutor queryExecutor)
        {
            _teamRepo = teamRepo;
            _workerRepo = workerRepo;
            _queryExecutor = queryExecutor;
        }

        [HttpGet("getOne/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var team = await _teamRepo.GetOneAsync(id);
            if (team is null)
                return NotFound();
            team = await _teamRepo.LoadProperties(team);
            team.Workers.ForEach(w => w.Teams = null);
            team.Department = null;
            return Ok(team);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamRepo.GetAllAsync();
            if (teams.Count == 0)
                return NoContent();
            return Ok(teams);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOne([FromBody] TeamDto team)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
                return BadRequest(ModelState);
            }

            var model = team.ToModel();
            model.Workers = await _workerRepo.GetRangeAsync(team.Workers.Select(w => w.Id));
            int val = await _teamRepo.AddAsync(model);
            if (val == 0)
                return StatusCode(500, new { Message = "Failed to add new team" });
            return Ok(team);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,  [FromBody] TeamDto updatedTeam)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var team = await _teamRepo.GetOneAsync(id);
            if (team is null)
                return NotFound();

            await _teamRepo.LoadProperties(team);
            team.Name = updatedTeam.Name;

            var ogWorkerIds = team.Workers.Select(w => w.Id);
            var updatedWorkerIds = updatedTeam.Workers.Select(w => w.Id);

            var idsToRemove = ogWorkerIds.Where(id => !updatedWorkerIds.Contains(id)).ToList();
            var idsToAdd = updatedWorkerIds.Where(id => !ogWorkerIds.Contains(id)).ToList();

            try
            {
                foreach (var idToRemove in idsToRemove)
                {
                    await _queryExecutor.ExecuteQueryRaw(
                        $"DELETE FROM TeamWorker WHERE TeamsId = {id} AND WorkersId = {idToRemove}");
                }
                foreach (var idToAdd in idsToAdd)
                    await _queryExecutor.ExecuteQueryRaw(
                        $"INSERT INTO TeamWorker (TeamsId, WorkersId) VALUES (${id}, ${idToAdd})");
                return NoContent();
            }
            catch (DbUpdateException e)
            {
                Console.Error.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _teamRepo.DeleteOneAsync(id);
            if (result == 0)
                return NotFound();
            return NoContent();
        }
    }
}
