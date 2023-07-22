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
    public class DepartamentController : ControllerBase
    {
        protected CrudRepository<Departaments> _repositoryDepartaments;
        public DepartamentController()
        {
            _repositoryDepartaments = new CrudRepository<Departaments>();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok (_repositoryDepartaments.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        
        public IActionResult Get(int id)
        {
            return Ok(_repositoryDepartaments.GetById(id));   
        }

        [HttpGet]
        [Route("findBy")]

        public IActionResult Get([FromQuery] Departaments departaments)
        {
            Func<Departaments, bool> filter = x => x.Name.Contains(departaments.Name);
            return Ok(_repositoryDepartaments.FindBy(filter));
        }


       
    }
}