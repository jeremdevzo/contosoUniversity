using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ContosoUniversity.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class  PersonController : ControllerBase
    {
        
        protected CrudRepository<Person> _repository;

        public PersonController()
        {
            _repository =  new CrudRepository<Person>();
        }

        [HttpGet]
        [Route("")]
        public  IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get( int id)
        {
            return Ok (_repository.GetById(id));
        }

        [HttpGet]
        [Route("findBy")]
        public IActionResult Get([FromQuery] Person person)
        {
            Func<Person, bool> filter = x => x.Address.Contains(person.Address) && x.Address !=null;
            
            return Ok(_repository.FindBy(filter));
        }


       


    }
}