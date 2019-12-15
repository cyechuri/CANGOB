using SampleMvcLoginiApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcLoginiApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel lg) {

            string conString = @"Server=tcp:nrcan.database.windows.net,1433;Initial Catalog=NRCANDB;Persist Security Info=False;User ID=nrcanuser;Password=Qwer1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=300;";
            var output = 0;
            if (!string.IsNullOrEmpty(lg.UserName))
            {
                string test = "Success";
                try {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "nrcan.database.windows.net";
                    builder.UserID = "nrcanuser";
                    builder.Password = "Qwer1234";
                    builder.InitialCatalog = "NRCANDB";
                    SqlConnection con = new SqlConnection(builder.ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from NRCANUSERS where UserName = '" + lg.UserName + "' and Password = '" + lg.Password + "'", con);

                    output = int.Parse(cmd.ExecuteScalar().ToString());

                }
                catch (Exception ex)
                {
                    return RedirectToAction("About");
                }

                if (output == 1)
                {
                    Session["UserName"] = lg.UserName;
                    return RedirectToAction("About");
                }
                //We need to write our logic here 
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
