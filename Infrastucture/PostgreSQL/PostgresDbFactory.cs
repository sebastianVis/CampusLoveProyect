using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Factory;
using CampusLove.Domain.Ports;
using CampusLove.Infrastucture.Repositories;

namespace CampusLove.Infrastucture.PostgreSQL;
    public class PostgresDbFactory : IDbFactory
    {
        private readonly string _connectionString;

        public PostgresDbFactory(string connectionString){
            _connectionString = connectionString;
        }
        public IUserRepository CreateUserRepository(){
            return new ImpUserRepository(_connectionString);
        }
    }
