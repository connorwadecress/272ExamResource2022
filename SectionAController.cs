using Section_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Newtonsoft.Json;

namespace Section_A.Controllers
{
    public class SectionAController : Controller
    {
        /* Section A  Total 10 Marks                                                                                                 /
         * This Section is meant to test your knowledge On Ajax and Jquery                                                          /
         * This Section Consists of 2 questions , Question 1 and 2 both for 5 Marks each                                             /  
         * Please Complete all the code within this Controller                                                                       /
         * Once Completed please remember to save all your work                                                                      /
         * As this is a Mock Exam, No Time limit is Given but try to attempt it like it was the actual exam to get the full benefit */


        /* Start HERE */





        /******Start Question 1 ********/
        public JsonResult Question1()
        {
            var coporateRelationship = db.Customers.Include(c => c.Employee).Select(x => new
            {
                Customer = x.FirstName + " " + x.LastName,
                Employee = x.Employee.FirstName + " " + x.LastName,
                ReportsTo = db.Employees.Where(y => y.EmployeeId == x.Employee.ReportsTo).FirstOrDefault().Email
            }).ToList();
            return new JsonResult { Data = new { relationship = coporateRelationship }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        public string Question2(string playlist)
        {
            bool status = false;
            if (playlist != null)
            {
                db.Playlists.Add(new Playlist { Name = playlist });
                db.SaveChanges();
                status = true;
            }
            return JsonConvert.SerializeObject(new { message = status });
        }
        /** End Question 2 **/ /*** Total 5 MARKS ****/


        /* End HERE */



        /*****Dont Touch This*******/

        private ChinookEntities db = new ChinookEntities();

        public ActionResult Q1Index()
        {
            return View("Question1");
        }

        public ActionResult Q2Index()
        {
            return View("Question2");
        }

    }
}