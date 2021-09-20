using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class StoreProcedure : IStoreProcedure
    {
        private readonly ApplicationDbContext _db;
        private static string _connectionString = "";

        public StoreProcedure(ApplicationDbContext db)
        {
            _db = db;
            _connectionString = db.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return (T) conn.ExecuteScalar(procedureName, param,
                    commandType: System
                        .Data
                        .CommandType
                        .StoredProcedure
                );
            }
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return (T) conn.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName,
            DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var result = SqlMapper.QueryMultiple(conn, procedureName, param,
                    commandType: System
                        .Data
                        .CommandType
                        .StoredProcedure);

                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();
                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }
    }
}