using System;
using System.Collections.Generic;
using System.Data;
using week10day3afternoon.Models;
using Dapper;

namespace week10day3afternoon.Repositories
{
    public class KnightsRepository
    {
        private readonly IDbConnection _db;

        public KnightsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Knight> GetAll()
        {
            string sql = "SELECT * FROM knights";
            return _db.Query<Knight>(sql);
        }

        internal Knight Create(Knight newKnight)
        {
            string sql = @"
            INSERT INTO knights
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();";
            newKnight.Id = _db.ExecuteScalar<int>(sql, newKnight);
            return newKnight;
        }
    }
}