using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace ContosoUniversity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        protected CrudRepository<Course> _repositoryCourse;
        public CourseController()
        {
            _repositoryCourse =  new CrudRepository<Course>();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok (_repositoryCourse.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        
        public IActionResult Get(int id)
        {
            return Ok(_repositoryCourse.GetById(id));   
        }

        [HttpGet]
        [Route("findBy")]

        public IActionResult Get([FromQuery] Course course)
        {
            Func<Course, bool> filter = x => x.Name.Contains(course.Name);
            return Ok(_repositoryCourse.FindBy(filter));
        }


    }
}