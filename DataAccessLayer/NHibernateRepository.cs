using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using Models;

namespace DataAccessLayer
{
    public class NHibernateRepository: IRepository 
    {
        private ISessionFactory sessionFactory;
        private ISession session;

        public NHibernateRepository(ISessionFactory sessionFactory) {
            this.sessionFactory = sessionFactory;
            session = this.sessionFactory.OpenSession();
            session.BeginTransaction();
        }

        //This looks bad, but with NHibernate's lazy loading, even
        //if a student has 100000 behavior records(I checked), it
        //loads up pretty much instaneously, even calling ToList on the
        //result.
        public IQueryable<Student> AllStudents() {
            return session.CreateCriteria<Student>().Future<Student>().AsQueryable();
        }

        public IQueryable<Student> AllOfStudent(string firstName, string lastName) {
            return session.CreateCriteria<Student>()
                .Add(Restrictions.And(
                    Restrictions.Eq("FirstName", firstName),
                    Restrictions.Eq("LastName", lastName)))
                .Future<Student>().AsQueryable();
        }


        public void AddStudent(Student student) {
            session.Save(student);
        }

        public void DeleteStudent(Student student) {
            session.Delete(student);
        }

        public void DeleteStudents(IEnumerable<Student> students) {
            foreach (var s in students)
                this.DeleteStudent(s);
        }

        public void Commit() {
            session.Transaction.Commit();
            session.BeginTransaction();
        }

        public void Rollback() {
            session.Transaction.Rollback();
            session.BeginTransaction();
        }
    }
}
