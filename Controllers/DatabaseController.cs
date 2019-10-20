using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly string _connectionString;

        public DatabaseController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: api/Database
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            return Get(1);
        }


        public ContentResult Create(IFormCollection collection)
        {
            try { 
                return new ContentResult() { Content = "{message:ok sent}", StatusCode = 200, ContentType = "json" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ContentResult() { Content = "{message:" + ex.Message.ToString() + "}", StatusCode = 400, ContentType = "json" };
        //return View();
        }
}

        // GET: api/Database/5
        [HttpGet("{id}", Name = "Get")]
        public String Get(int id)
        {

            String[] artists;
            string tempp = "";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var query = @"select * from Artist";
                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                SqlDataReader results = sqlCommand.ExecuteReader();
                int i = 0;

                var lst = new List<String>();

                while (results.Read())
                {
                    //site = results.GetGuid(0).ToString("D");
                    //row.DeptApp = results.GetString(0);
                    //row.Status = results.GetString(1);
                    //row.Supervisor = results.GetString(2);
                    //lst.Add(row);
                }
                sqlConnection.Close();

                //while (results.Read())
                //{
                //    //artists = results.GetGuid(0).ToString("D");
                //    //artists[i] = results.GetGuid(0).ToString("D");
                //    tempp = results.GetGuid(0).ToString("D");
                //    i++;
                //}

                return tempp;
            }

            
            //return tempp;
        }

        // POST: api/Database
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Database/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
