using SimpleStudentManagerApi.Dtos.Request;
using SimpleStudentManagerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace SimpleStudentManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static readonly IList<Student> _students = new List<Student>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_students);
        }
        [HttpGet("{id}")]
        public IActionResult GetOneById([FromRoute] int id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(new { student });
        }
        [HttpPost]
        public IActionResult Create([FromBody] StudentRequest request)
        {
            int maxId;
            if (_students.Count == 0) maxId = 0;
            else maxId = _students.Max(p => p.Id);
            var student = new Student()
            {
                Id = maxId + 1,
                Name = request.Name,
                Age = request.Age,
                Major = request.Major,
            };
            _students.Add(student);
            return CreatedAtAction(nameof(GetOneById), new { id = student.Id }, student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var student = _students.FirstOrDefault(p => p.Id == id);
            if (student is null)
            {
                return NotFound();
            }
            _students.Remove(student);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] StudentRequest studentRequest)
        {
            var student = _students.FirstOrDefault(p => p.Id == id);
            if (student is null)
            {
                return NotFound();
            }
            student.Name = studentRequest.Name;
            student.Age = studentRequest.Age;
            student.Major = studentRequest.Major;
            return NoContent();
        }
    }
}
