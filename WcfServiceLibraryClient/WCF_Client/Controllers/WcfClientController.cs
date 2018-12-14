using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using System.Collections;
using WCF_Client.IISHostServiceReference;

namespace WCF_Client.Controllers
{
    public class WcfClientController : Controller
    {
        // GET: WcfClient
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProcessForm(FormCollection collection,string GetOpeningJobs, string GetOpeningJobsByRole)
        {
            List<JobDetails> lList = new List<JobDetails>(); 
            IISHostServiceReference.JobOpeningClient client = new IISHostServiceReference.JobOpeningClient("BasicHttpBinding_IJobOpening");
            if (!string.IsNullOrEmpty(GetOpeningJobs))
            {
                client.Open();
                var lst = client.GetOpeningJobs();
                foreach (var item in lst)
                {
                    JobDetails usr = new JobDetails();
                    usr.JobName = item.JobName;
                    usr.Skill = item.Skill;
                    usr.Role = item.Role;
                    usr.Date = item.Date;
                    lList.Add(usr);

                }
                client.Close();
                client = null;
            }
            if (!string.IsNullOrEmpty(GetOpeningJobsByRole))
            {
                client.Open();
                var lst = client.GetOpeningJobsByRole(collection["myRoleName"]);

                JobDetails usr = new JobDetails();
                usr.JobName = lst.JobName;
                usr.Skill = lst.Skill;
                usr.Role = lst.Role;
                usr.Date = lst.Date;
                lList.Add(usr);

                client.Close();
                client = null;
            }
            return View("Index", lList);
        }
        public class JobDetails
        {
            public string JobName { get; set; }
            public string Skill { get; set; }
            public string JobLocation { get; set; }
            public string Date { get; set; }
            public string Role { get; set; }
        }
    }
    
}