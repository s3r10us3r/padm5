using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using padm5.dal.Interfaces;
using padm5.models.Dtos;

namespace padm5.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerProfilesController : ControllerBase
    {
        private readonly IWorkerProfileRepo _profileRepo;

        public WorkerProfilesController(IWorkerProfileRepo profileRepo)
        {
            _profileRepo = profileRepo;
        }

        [HttpPut("update/{workerId}")]
        public async Task<IActionResult> Update(int workerId, [FromBody] WorkerProfileDto profile)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var model = await _profileRepo.GetOneWithWorkerId(workerId);
            bool isNew = true;
            if (model is null)
            {
                model = new() { WorkerId = workerId };
                isNew = false;
            }
            model.Address = profile.Address;
            model.PhoneNumber = profile.PhoneNumber;
            model.Mail = profile.Mail;
            try
            {
                if (isNew)
                    await _profileRepo.AddAsync(model);
                else
                    await _profileRepo.UpdateOneAsync(model);
                return Ok(model);
            }
            catch (DbUpdateException e)
            {
                Console.Error.WriteLine(e);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

    }
}
