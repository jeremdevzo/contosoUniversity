using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Domain.Entities.Base;
using ContosoUniversity.Infraestructure.Data;
using ContosoUniversity.Domain.Entities;
using ContosoUniversity.Domain.Interfaces;

namespace ContosoUniversity.Infraestructure.Repositories;

public class CrudRepository<T> : ICrudRepository<T> where T : baseEntity
{
    protected readonly DBLocalContosoUniversity _dbContext;
    protected IEnumerable<T>? _entities;


    private void SetEntity(Type T)
    {
        if(typeof(T) == typeof(Person)){
            _entities = (IEnumerable<T>)_dbContext.Persons;
        }else if(typeof(T) == typeof(Course))
        {
            _entities = (IEnumerable<T>)_dbContext.Courses;
        }else if(typeof(T) == typeof(Departaments)){

        _entities = (IEnumerable<T>)_dbContext.Departments;
        }
    }

    
    public CrudRepository()
    {
        _dbContext =  new DBLocalContosoUniversity();
        SetEntity(typeof(T));
    }

    public IEnumerable<T> GetAll()
    {
        return _entities!;
    }

    public T GetById(int id)
    {
        return _entities!.Single<T>(x=> x.Id == id);
    }

    public IEnumerable<T> FindBy(Func<T, bool> filters)
    {
        return _entities!.Where<T>(filters);
    }


}
