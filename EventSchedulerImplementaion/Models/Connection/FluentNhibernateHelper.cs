
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using NHibernate; 
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using EventSchedulerImplementaion.Models.Mapping;

namespace EventSchedulerImplementaion.Models.Connection
{
   
    public class FluentNhibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    string connectionString = "Data Source=NAIMURRAHMAN;Initial Catalog=EventSchedular;TrustServerCertificate=True;Trusted_Connection=True;";
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EventMapping>())
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static NHibernate.ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}