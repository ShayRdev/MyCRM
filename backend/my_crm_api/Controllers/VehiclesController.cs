using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_crm_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace my_crm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        //Reads connection string form appsettings.json - SHAYR
        private readonly IConfiguration _configuration;

        // is instantiated inside of the constructor durring runtime. Good example of dependency injection. - SHAYR
        public VehiclesController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            SELECT
                            VehicleId,
                            UserId,
                            VIN,
                            Make,
                            Model,
                            Year,
                            Mileage,
                            EngineType,
                            EstimatedLifespanMiles,
                            LifespanEvaluationDate,
                            CreatedAt,
                            UpdatedAt
                            FROM dbo.Vehicles
                            ";

            // Creates a new data table object to manage queried data - SHAYR
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRMAppCon");

            // Sets the data table with data from the query - SHAYR
            SqlDataReader myReader;

            // Executes SQL commands in the database - SHAYR
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                // Open the database connection. Using the query the following code block creates a command - SHAYR
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // Execute the command using the Executereader method. Expects a return value from the SELECT query. - SHAYR
                    myReader = myCommand.ExecuteReader();
                    // Adds data to datatable using myreader SqlDataReader - SHAYR
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }


        [HttpPost]
        public JsonResult Post(Vehicles veh)
        {
            string query = @"
                            INSERT INTO dbo.Vehicles
                            (UserId, VIN, Make, Model, Year, Mileage, EngineType, EstimatedLifespanMiles, LifespanEvaluationDate, CreatedAt, UpdatedAt)
                            Values
                            (@UserId, @VIN, @Make, @Model, @Year, @Mileage, @EngineType, @EstimatedLifespanMiles, @LifespanEvaluationDate, @CreatedAt, @UpdatedAt);
                            ";

            // Creates a new data table object to manage queried data - SHAYR
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRMAppCon");

            // Sets the data table with data from the query - SHAYR
            SqlDataReader myReader;

            // Executes SQL commands in the database - SHAYR
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                // Open the database connection. Using the query the following code block creates a command - SHAYR
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // Pass the values to the command using command parameters and avoid SQL injections -SHAYR
                    myCommand.Parameters.AddWithValue("@UserId", veh.UserId);
                    myCommand.Parameters.AddWithValue("@Vin", veh.VIN);
                    myCommand.Parameters.AddWithValue("@Make", veh.Make);
                    myCommand.Parameters.AddWithValue("@Model", veh.Model);
                    myCommand.Parameters.AddWithValue("@Year", veh.Year);
                    myCommand.Parameters.AddWithValue("@Mileage", veh.Mileage);
                    myCommand.Parameters.AddWithValue("@EngineType", veh.EngineType);
                    myCommand.Parameters.AddWithValue("@EstimatedLifespanMiles", veh.EstimatedLifespanMiles);
                    myCommand.Parameters.AddWithValue("@LifespanEvaluationDate", veh.LifespanEvaluationDate);
                    myCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    // Execute the command using the Executereader method. Expects a return value from the SELECT query. - SHAYR
                    myReader = myCommand.ExecuteReader();
                    // Adds data to datatable using myreader SqlDataReader - SHAYR
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Vehicle created successfully");

        }


        [HttpPut]
        public JsonResult Put(Vehicles veh)
        {
            string query = @"
                            UPDATE dbo.Vehicles
                            SET
                            UserId = @UserId, 
                            VIN = @VIN,
                            Make = @Make, 
                            Model = @Model, 
                            Year = @Year, 
                            Mileage = @Mileage, 
                            EngineType = @EngineType, 
                            EstimatedLifespanMiles = @EstimatedLifespanMiles, 
                            LifespanEvaluationDate = @LifespanEvaluationDate, 
                            CreatedAt = @CreatedAt, 
                            UpdatedAt = @UpdatedAt
                            WHERE VehicleId = @VehicleId
                            ";

            // Creates a new data table object to manage queried data - SHAYR
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRMAppCon");

            // Sets the data table with data from the query - SHAYR
            SqlDataReader myReader;

            // Executes SQL commands in the database - SHAYR
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                // Open the database connection. Using the query the following code block creates a command - SHAYR
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // Pass the values to the command using command parameters and avoid SQL injections -SHAYR
                    myCommand.Parameters.AddWithValue("@VehicleId", veh.VehicleId);
                    myCommand.Parameters.AddWithValue("@UserId", veh.UserId);
                    myCommand.Parameters.AddWithValue("@Vin", veh.VIN);
                    myCommand.Parameters.AddWithValue("@Make", veh.Make);
                    myCommand.Parameters.AddWithValue("@Model", veh.Model);
                    myCommand.Parameters.AddWithValue("@Year", veh.Year);
                    myCommand.Parameters.AddWithValue("@Mileage", veh.Mileage);
                    myCommand.Parameters.AddWithValue("@EngineType", veh.EngineType);
                    myCommand.Parameters.AddWithValue("@EstimatedLifespanMiles", veh.EstimatedLifespanMiles);
                    myCommand.Parameters.AddWithValue("@LifespanEvaluationDate", veh.LifespanEvaluationDate);
                    myCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    // Execute the command using the Executereader method. Expects a return value from the SELECT query. - SHAYR
                    myReader = myCommand.ExecuteReader();
                    // Adds data to datatable using myreader SqlDataReader - SHAYR
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Vehicle updated successfully");

        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                            DELETE FROM dbo.Vehicles
                            WHERE VehicleId = @VehicleId
                            ";

            // Creates a new data table object to manage queried data - SHAYR
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CRMAppCon");

            // Sets the data table with data from the query - SHAYR
            SqlDataReader myReader;

            // Executes SQL commands in the database - SHAYR
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                // Open the database connection. Using the query the following code block creates a command - SHAYR
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // Pass the iD to the command using command parameters for the specific Vehicle you want to delete -SHAYR
                    myCommand.Parameters.AddWithValue("@VehicleId", id);
                    // Execute the command using the Executereader method. Expects a return value from the SELECT query. - SHAYR
                    myReader = myCommand.ExecuteReader();
                    // Adds data to datatable using myreader SqlDataReader - SHAYR
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Vehicle updated successfully");

        }

    }
}
