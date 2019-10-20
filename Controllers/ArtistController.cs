using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ArtistController : Controller
    {
        private readonly string _connectionString;
        List<ArtistModel> artLsts = new List<ArtistModel>();

        public ArtistController(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                var query = @"select * from Artist";
                var sqlCommand = new SqlCommand(query, sqlConnection);              

                sqlConnection.Open();

                SqlDataReader results = sqlCommand.ExecuteReader();

                if (results.HasRows)
                {
                    while (results.Read())
                    {
                        ArtistModel artist = new ArtistModel();
                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}", results.GetInt32(0), results.GetString(1), results.GetString(2), results.GetString(3));

                        //artist.Id = results.GetInt32(0);
                        artist.ArtistName = results.GetString(1);
                        artist.Country = results.GetString(2);
                        artist.Label = results.GetString(3);

                        artLsts.Add(artist);
                    }
                }
                sqlConnection.Close();
            }
        }

        public ActionResult View()
        {
            return View(artLsts);
        }
        // GET: Artist
        public ActionResult Index(IFormCollection collection)
        //public ContentResult Index(IFormCollection collection)
        {
            //return new ContentResult() { Content = "{message:ok sent}", StatusCode = 200, ContentType = "json" };
            //return View(nameof(HomeController.Index));

            //string site = string.Empty;
            //using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            //{
            //    var query = @"INSERT INTO ShakemapContours (SeismicIdentifier, Contour) VALUES (@SeismicIdentifier,@Contour)";
            //    var sqlCommand = new SqlCommand(query, sqlConnection);

            //    sqlCommand.Parameters.AddWithValue("@SeismicIdentifier", SeismicIdentifier);
            //    sqlCommand.Parameters.AddWithValue("@Contour", Contour);

            //    sqlConnection.Open();
            //    int result = sqlCommand.ExecuteNonQuery();

            //    // Check Error
            //    if (result < 0)
            //    {
            //        Console.WriteLine("Error inserting data into Database!");
            //    }

            //}
            //return site;

           return RedirectToAction("Index", "Home");
        }

        // GET: Artist/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artist/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}