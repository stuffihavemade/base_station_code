using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using Models;

namespace DataAccessLayer
{
    public class NHibernateRepository<T> where T: class, IStudent
    {
        private ISessionFactory sessionFactory;
        private ISession session;

        public NHibernateRepository(ISessionFactory sessionFactory) {
            this.sessionFactory = sessionFactory;
            session = this.sessionFactory.OpenSession();
            session.BeginTransaction();
        }

        public IQueryable<T> All() {
            return session.CreateCriteria<T>().Future<T>().AsQueryable();
        }

        public IQueryable<T> AllOfStudent(string firstName, string lastName) {
            return session.CreateCriteria<T>()
                .Add(Restrictions.And(
                    Restrictions.Eq("FirstName", firstName),
                    Restrictions.Eq("LastName", lastName)))
                .Future<T>().AsQueryable();
        }

    }
}
