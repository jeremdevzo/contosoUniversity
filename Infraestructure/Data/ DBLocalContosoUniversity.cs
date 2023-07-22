using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Domain.Entities;
using System.Text.Json;

namespace ContosoUniversity.Infraestructure.Data
{
    public class  DBLocalContosoUniversity
    {
        private const string _fileNamePerson ="dbContosoUniversityPersons.json";
        private const string _fileNameCourses ="dbContosoUniversityCourses.json";
        private const string _fileNameDepartament ="dbContosoUniversityDepartments.json";
        private const string _dataPath ="Infraestructure\\Data";
        private IEnumerable<Person> _persons;
        private IEnumerable <Course> _courses;
        private IEnumerable <Departaments> _departments;
        

       

         private void LoadDataPerson()
        {
            var filePath = GetPathFile(_fileNamePerson);
            if (File.Exists(filePath))
            _persons = JsonDeserialize<IEnumerable<Person>>(filePath);
        }

       
        private string GetPathFile(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, _dataPath, fileName);
        }
      
        private T JsonDeserialize<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString)!;
        }

        private void LoadDataCourses()
        {
            var filePath = GetPathFile(_fileNameCourses);
            if (File.Exists(filePath))
            _courses = JsonDeserialize<IEnumerable<Course>>(filePath);
        }

        private void LoadDataDepartments()
        {
            var filePath = GetPathFile(_fileNameDepartament);
            if (File.Exists(filePath))
            _departments = JsonDeserialize<IEnumerable<Departaments>>(filePath);
        }

       
        public IEnumerable<Person> Persons
        {
            get
            {
                LoadDataPerson();
                return _persons;
            }
        }

        public IEnumerable<Course> Courses 
        {
            get{
                LoadDataCourses();
                return _courses;
            }
        }

        public IEnumerable<Departaments> Departments 
        {
            get
            {
                LoadDataDepartments();
                return _departments;
            }
        }

        public DBLocalContosoUniversity()
        {
            _persons = new List<Person>();
            _courses = new List<Course>();
            _departments = new List<Departaments>();
        }

     

    }
}