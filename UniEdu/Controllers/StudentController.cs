using Microsoft.AspNetCore.Mvc;
using UniEdu.Dtos;
using UniEdu.Interfaces.IServices;
using UniEdu.Models;

namespace UniEdu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDto studentDto)
        {
            try
            {
                _service.Enroll(studentDto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] StudentUpdateDto studentDto)
        {
            try
            {
                _service.UpdateStudent(studentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var retorno = _service.GetAllStudents();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("id")]
        public IActionResult Get([FromQuery]Guid id)
        {
            try
            {
                var retorno = _service.GetStudentById(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]Guid id)
        {
            try
            {
                _service.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
