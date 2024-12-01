using Microsoft.AspNetCore.Mvc;
using padm5.dal.Interfaces;
using padm5.models.Dtos;

namespace padm5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerRepo _workerRepo;
        public WorkersController(IWorkerRepo workerRepo)
        {
            _workerRepo = workerRepo;
        }

        [HttpGet("getOne/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var worker = await _workerRepo.GetOneAsync(id);
            if (worker == null)
                return NotFound();
            worker = await _workerRepo.LoadProperties(worker);
            worker.Teams.ForEach(t => t.Workers = null);
            return Ok(worker);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var workers = await _workerRepo.GetAllAsync();
            if (workers.Count == 0)
                return NoContent();
            return Ok(workers);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOne([FromBody] WorkerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = dto.ToModel();
            var result = await _workerRepo.AddAsync(model);
            if (result == 0)
                return StatusCode(500, new { Message = "Failed to add to the database" });
            return Ok(model);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, WorkerDto workerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _workerRepo.GetOneAsync(id);
            if (model == null)
                return NotFound();

            await _workerRepo.LoadProperties(model);
            model.FirstName = workerDto.FirstName;
            model.LastName = workerDto.LastName;
            model.Salary = workerDto.Salary;
            model.Position = workerDto.Position;
            await _workerRepo.UpdateOneAsync(model);
            model.Teams.ForEach(t => t.Workers = null);
            return Ok(model);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _workerRepo.DeleteOneAsync(id);
            if (deleted == 0)
                return NotFound();
            return NoContent();
        }
    }
}
