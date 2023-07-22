using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Domain;
using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Infraestructure.Data;
using ContosoUniversity.Domain.Entities.Base;

namespace ContosoUniversity.Domain.Entities
{
    public class Person : baseEntity
    {
       
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } =  string.Empty;
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDaet { get; set; }

        public String Address { get; set; } =  string.Empty;

        public bool? HasParkingLot {get; set;}
       
    }
}