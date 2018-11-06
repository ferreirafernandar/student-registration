using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.AutoMapper.Helpers;
using StudentRegistration.Models;
using StudentRegistration.ViewModels;

namespace StudentRegistration.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class StudentsController : ApiBaseController
    {
        private readonly IMapper _mapper;

        public StudentsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Add([FromBody] StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = new StudentMap(_mapper).Map(studentViewModel);

            if (!student.IsValid())
                return BadRequest(_mapper.Map(student, studentViewModel));

            using (var db = InitializeDb())
            {
                student = db.Students.Add(student).Entity;
                var ret = _mapper.Map(student, studentViewModel);
                db.SaveChanges();
                return Ok(ret);
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("Update")]
        public IActionResult Update([FromBody] StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = new StudentMap(_mapper).Map(studentViewModel);

            if (!student.IsValid())
                return BadRequest(_mapper.Map(student, studentViewModel));

            using (var db = InitializeDb())
            {
                studentViewModel = _mapper.Map(db.Students.Update(student).Entity, studentViewModel);
                db.SaveChanges();
            }

            return Ok(studentViewModel);
        }

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("GetAll")]
        public IEnumerable<StudentViewModel> GetAll()
        {
            var db = InitializeDb();
            var students = db.Students.Include(c => c.Phones).ToList();
            var ret = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(students);
            return ret;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("Remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var db = InitializeDb())
            {

                db.Students.Remove(db.Students.Find(id));
                db.SaveChanges();
            }
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(200), ProducesResponseType(204), ProducesResponseType(500)]
        [Route("GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var db = InitializeDb();

            var student = db.Students.Where(c => c.StudentId == id).Include(c => c.Phones).FirstOrDefault();

            var ret = _mapper.Map<StudentViewModel>(student);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }
    }
}