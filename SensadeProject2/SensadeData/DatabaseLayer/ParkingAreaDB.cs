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
    public class ParkingAreaDB:IParkingArea
    {
        private readonly string? _connectionString;

        public ParkingAreaDB(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SensadeConnection")  ;
        }

        public bool CreateParkingArea(ParkingArea pa)
        {
            string sql = @"INSERT INTO parkingareas (streetname, streetnumber, zipcode, latitude, longitude)
                           VALUES (@StreetName, @StreetNumber, @ZipCode, @Latitude, @Longitude);";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();

            int rowsAffected = con.Execute(sql, pa);
            return rowsAffected > 0;

        }

        public bool DeleteParkingArea(int id)
        {
            string sql = "DELETE FROM parkingareas WHERE id = @Id;";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();

            int rowsAffected = con.Execute(sql, new { Id = id });
           
            return rowsAffected > 0;
        }

        public List<ParkingArea> GetParkingAreaByIdOrAll(int id = -1)
        {
            string sql;
            object parameters;

            if (id == -1)
            {
                sql = "SELECT * FROM parkingareas ORDER BY id;";
                parameters = new { };
            }
            else
            {
                sql = "SELECT * FROM parkingareas WHERE id = @Id;";
                parameters = new { Id = id };
            }

            using NpgsqlConnection con = new(_connectionString);
            con.Open();

            var areas = con.Query<ParkingArea>(sql, parameters).ToList();

            return areas;
        }

        public bool UpdateParkingArea(ParkingArea pa)
        {
            string sql = @"UPDATE parkingareas
                           SET streetname = @StreetName,
                               streetnumber = @StreetNumber,
                               zipcode = @ZipCode,
                               latitude = @Latitude,
                               longitude = @Longitude
                           WHERE id = @Id;";

            using NpgsqlConnection con = new(_connectionString);
            con.Open();

            int rowsAffected = con.Execute(sql, pa);
            return rowsAffected > 0;
        }
    }
}
