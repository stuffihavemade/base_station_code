using System;
using System.Linq;
using Models;

namespace DataAccessLayer
{
    public interface IRepository
    {
        IQueryable<Student> All();
        IQueryable<Student> AllOfStudent(string firstName, string lastName);
        void Add(Student student);
        void Delete(Student student);
        void Commit();
        void Rollback();
    }
}
