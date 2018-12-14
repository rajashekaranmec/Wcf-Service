using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string TodayProgram(string name);

    }
    [ServiceContract]
    public interface IJobOpening
    {
        [OperationContract]
        List<JobDetails> GetOpeningJobs();

        [OperationContract]
        JobDetails GetOpeningJobsByRole(string Role);

    }
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int sum(int num1, int num2);

        [OperationContract]
        int Subtract(int num1, int num2);
    }

    [DataContract]
    public class JobDetails
    {
        [DataMember]
        public string JobName { get; set; }
        [DataMember]
        public string Skill { get; set; }
        [DataMember]
        public string JobLocation { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
