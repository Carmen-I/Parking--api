using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SensadeData.Models;

namespace SensadeData.DatabaseLayer
{
    public class ParkingSpaceDB:IParkingSpace
    {
        private readonly string _connectionString;

        public ParkingSpaceDB(IConfiguration inConfig)
        {
            _connectionString = inConfig.GetConnectionString("SensadeConnection");
                
        }

        public int CountSpacesByStatus(int areaId, int status)
        {
            string sql = @"SELECT COUNT(*) FROM parkingspaces 
                   WHERE parkingareaid = @AreaId AND status = @Status;";

            using var con = new NpgsqlConnection(_connectionString);
            con.Open();

            int count = con.ExecuteScalar<int>(sql, new { AreaId = areaId, Status = status });
            return count;
        }

        public bool CreateParkingSpace(ParkingSpace ps)
        {
            string sql = @"INSERT INTO parkingspaces (spacenumber, status, parkingareaid)
                           VALUES (@SpaceNumber, @Status, @ParkingAreaId);";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();
            int rowsAffected = con.Execute(sql, ps);
            return rowsAffected > 0;
        }

        public List<ParkingSpace?>? GetParkingSpaceByIdOrAll(int id = -1)
        {
            string sql;
            object parameters;

            if (id == -1)
            {
                sql = "SELECT * FROM parkingspaces ORDER BY id;";
                parameters = new { };
            }
            else
            {
                sql = "SELECT * FROM parkingspaces WHERE id = @Id;";
                parameters = new { Id = id };
            }

            using NpgsqlConnection con = new(_connectionString);
            con.Open();
            var spaces = con.Query<ParkingSpace>(sql, parameters).ToList();
            return spaces;
        }

        public List<ParkingSpace?>? GetSpacesFromArea(int areaId)
        {
            string sql = "SELECT * FROM parkingspaces WHERE parkingareaid = @AreaId ORDER BY id;";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();
            var spaces = con.Query<ParkingSpace>(sql, new { AreaId = areaId }).ToList();
            return spaces;
        }

        public bool UpdateParkingSpace(ParkingSpace ps)
        {
            string sql = @"UPDATE parkingspaces
                           SET spacenumber = @SpaceNumber,
                               status = @Status,
                               parkingareaid = @ParkingAreaId
                           WHERE id = @Id;";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();
            int rowsAffected = con.Execute(sql, ps);
            return rowsAffected > 0;
        }

        public bool DeleteParkingSpace(int id)
        {
            string sql = "DELETE FROM parkingspaces WHERE id = @Id;";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();
            int rowsAffected = con.Execute(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public bool UpdateStatus(int id, ParkingStatus status)
        {
            string sql = "UPDATE parkingspaces SET status = @Status WHERE id = @Id";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();

            int rowsAffected = con.Execute(sql, new { Status = (int)status, Id = id });
            return rowsAffected > 0;
        }
    }
}
    

