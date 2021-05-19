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
            string sql = "SELECT * FROM knights;";
            return _db.Query<Knight>(sql);
        }

        internal Knight GetOne(int id)
        {
            string sql = "SELECT * FROM knights WHERE id = @id;";
            return _db.QueryFirstOrDefault<Knight>(sql, new { id });
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

        internal bool Edit(Knight previous)
        {
            string sql = @"
            UPDATE knights
            SET
                name = @Name
            WHERE
                id = @Id;";
            int total = _db.Execute(sql, previous);
            return total == 1;
        }

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM knights WHERE id = @id LIMIT 1;";
            int total = _db.Execute(sql, new { id });
            return total == 1;
        }
    }
}