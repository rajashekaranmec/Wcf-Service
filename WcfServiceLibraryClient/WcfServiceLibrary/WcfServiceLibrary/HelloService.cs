using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class HelloService : IHelloService, IJobOpening, ICalculatorService
    {
        public string SayHello(string name)
        {
            return string.Format(getSession() + ", {0} !", name);
        }
        public string TodayProgram(string name)
        {
            return string.Format(checkIsWeekEnd() + ", {0} !", name);
        }

        private string getSession()
        {
            if(DateTime.Now.Hour < 12)
            {
               return  "Good Morning";
            }
            else if (DateTime.Now.Hour < 17)
            {
                return "Good Afternoon";
            }
            else
            {
                return "Good Evening";
            }
        }
        private string checkIsWeekEnd()
        {
            if ((DateTime.Now.DayOfWeek == DayOfWeek.Saturday) || (DateTime.Now.DayOfWeek == DayOfWeek.Sunday))
            {
                return "Happy weekend";
            }
            else
            {
                return "Enjoy Working day";
            }
        }
        public List<JobDetails> GetOpeningJobs()
        {
            List<JobDetails> cc = jobsOpenings();
            return cc.ToList();
        }
        public JobDetails GetOpeningJobsByRole(string role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("Role");
            }
            else
            {
                var jobDtls = jobsOpenings().Where(x => x.Role == role).Select(m => new JobDetails
                {
                    JobName = m.JobName,
                    JobLocation = m.JobLocation,
                    Date = m.Date,
                    Skill = m.Skill,
                    Role = m.Role
                });
                return jobDtls.ToList()[0];
            }
        }

        private List<JobDetails> jobsOpenings()
        {
            List<JobDetails> jbDtls = new List<JobDetails>();
             var jbs = new JobDetails
            {
                JobName = "Java Developer",
                JobLocation="Chennai",
                Date=DateTime.Now.ToShortDateString(),
                Skill="Java",
                Role = "Developer"
            };
            jbDtls.Add(jbs);
            jbs = new JobDetails
            {
                JobName = "Dotnet Developer",
                JobLocation = "Chennai",
                Date = DateTime.Now.ToShortDateString(),
                Skill = "Dotnet",
                Role = "SeniorDeveloper"
            };
            jbDtls.Add(jbs);
            return jbDtls;
        }
        public int sum(int num1, int num2)
        {
            return num1 + num2;
        }
        public int Subtract(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1 - num2;
            }
            else
            {
                return 0;
            }
        }
    }
}
