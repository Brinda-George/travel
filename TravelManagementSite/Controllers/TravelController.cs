using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelManagementSite.Models;

namespace TravelManagementSite.Controllers
{
    public class TravelController : Controller
    {
        // GET: Travel
        SqlConnection con = new SqlConnection("Server=SUYPC228\\SQLEXPRESS;Database=Travel;Integrated security=true");

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(LoginModel m)
        {
            con.Open();


                    string query = "Select * from Registration where username= '" + m.username + "' and password= '" + m.password + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int a = Convert.ToInt16(cmd.ExecuteScalar());
                    if (a == 0)
                    {
                        Response.Write("<script>alert('Login Failed')</script>");
                        return View("Index");
                    }
                    else
                    {
                        
                        TravelEntities2 db = new TravelEntities2();
                        ViewBag.Destination = new SelectList(db.TrainLists, "destination", "destination");
                        ViewBag.Source = new SelectList(db.TrainLists, "source", "source");
                        ViewBag.Time = new SelectList(db.TrainLists, "date", "date");
                        Session["name"] = m.username;
                        ViewBag.name1 = Session["name"];
                        return View("Search");
                    }



            
        }
        public ActionResult Registration()
        {
            return View();
        }



        public ActionResult Registration1(LoginModel m)
        {

             if (ModelState.IsValid)
             {
                    con.Open();
                    string str = "insert into Registration(name,username,password,email,mobile,gender,location) values('" + m.name + "','" + m.username + "','" + m.password + "','" + m.email + "','" + m.mobile + "','" + m.gender + "','" + m.location + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                
                    return RedirectToAction("Index");

             }
             else
             {

                    return View("Registration");
             }

         
        }
        public ActionResult Search()
        {
            
            return View();
        }
        public ActionResult SearchList(Train t)
        {
            TravelEntities2 db = new TravelEntities2();
            ViewBag.name = Session["name"];
            var query = from c in db.TrainLists where c.source == t.source && c.destination==t.destination && c.date==t.date  select c;
            return View(query.ToList());

        }
           


    }
}