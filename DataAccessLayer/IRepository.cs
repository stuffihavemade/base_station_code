using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IRepository
    {
        IQueryable<Student> AllStudents();
        void AddStudent(Student student);
        void DeleteStudent(Student student);
        void DeleteStudents(IEnumerable<Student> students);
        void Commit();
        void Rollback();
    }
}
