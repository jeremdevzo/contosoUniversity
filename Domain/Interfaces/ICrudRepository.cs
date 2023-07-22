using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Domain.Entities.Base;
using ContosoUniversity.Infraestructure.Repositories;

namespace ContosoUniversity.Domain.Interfaces;

public interface ICrudRepository<T> where T : baseEntity
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    IEnumerable<T> FindBy(Func<T, bool> fiters);
}
