using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace workSpace.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("GetAllStudents", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<List<clsStudentsDOT>>> GetAllStudents()
        {
            var getStudents = clsBusinessData.GetAllStudents();
            if (getStudents == null)
            {
                return NotFound("Not found students!");
            }
            return Ok(getStudents);
        }

        [HttpGet("GetStudentByID/{id}", Name = "GetStudentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsStudentsDOT> GetStudentByID(int id)
        {
            if (id < 1)
                return BadRequest("id must be bigger then zero");
            var getStudent = clsBusinessData.GetStudentByID(id);
            if (getStudent == null)
            {
                return NotFound("Not found students with id = " + id);
            }
            return Ok(getStudent);
        }

        [HttpPost("AddNewStudent", Name = "AddNewStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsStudentsDOT> AddNewStudent(clsStudentsDOT DOT)
        {
            if (DOT == null || DOT.name == "" || DOT.age < 1 || DOT.address == "")
                return BadRequest("Data not vaild!");
            clsBusinessData student = new clsBusinessData(DOT, clsBusinessData.enType.Add);
            if(student.Save())
            {
                DOT.id = student.id;
                return CreatedAtRoute("GetStudentByID", new { id = DOT.id}, DOT);
            }
            return NotFound("not found student with id !");
        }

        [HttpPut("UpdateStudent/{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsStudentsDOT> UpdateStudent(int id, clsStudentsDOT DOT)
        {
            if (id < 1 || DOT == null || DOT.name == "" || DOT.age < 1 || DOT.address == "")
                return BadRequest("Data not vaild!");
            clsBusinessData? student = clsBusinessData.GetStudentByID(id);
            if (student == null)
            {
                return NotFound("Not found student with id = " + id);
            }
            student.name = DOT.name;
            student.age = DOT.age;
            student.address = DOT.address;
            student.Save();
            return Ok(student.StudentDOT);
        }

        [HttpDelete("DeleteStudent/{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteStudent(int id)
        {
            if (id < 1)
                return BadRequest("id must be bigger then zero");
            clsBusinessData? student = clsBusinessData.GetStudentByID(id);
            if (student == null)
            {
                return NotFound("Not found student with id = " + id);
            }
            student.DeleteStudent(id);
            return NoContent();
        }
    }
}
