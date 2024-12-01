using Microsoft.AspNetCore.Mvc;
using padm5.dal.Interfaces;
using padm5.models.Dtos;

namespace padm5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentRepo;
        public DepartmentsController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        [HttpGet("getOne/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var department = await _departmentRepo.GetOneAsync(id);
            if (department == null)
                return NotFound();
            department = await _departmentRepo.LoadProperties(department);
            return Ok(department);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepo.GetAllAsync();
            if (departments.Count == 0)
                return NoContent();
            return Ok(departments);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOne([FromBody] DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var model = departmentDto.ToModel();
            await _departmentRepo.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var model = await _departmentRepo.GetOneAsync(id);
            if (model is null)
                return NotFound();
            model.Name = dto.Name;
            await _departmentRepo.UpdateOneAsync(model);
            return Ok(model);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentRepo.DeleteOneAsync(id);
            if (result == 0)
                return NotFound();
            return NoContent();
        }
    }
}
