using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.EmployeeServiceClient client = new ServiceReference1.EmployeeServiceClient();
        IList<ServiceReference1.Employee> LstEmployee = null;

        [HttpGet]
        public ActionResult ShowAllEmployeee()
        {
            client = new ServiceReference1.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            LstEmployee = client.RetreiveAllEmployees();
            return View(LstEmployee);
        }

        [HttpGet]
        public ActionResult ShowEmployeee(string employeeId)
        {
            ServiceReference1.Employee employee = client.RetreiveEmployees(employeeId);
            return View(employee);
        }

        [HttpGet]
        public ActionResult SaveEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEmployee(ServiceReference1.Employee employee)
        {
            client.AddEmployee(employee);
            return View();
        }

        [HttpGet]
        public ActionResult EditEmployee(string jEmployee)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ServiceReference1.Employee));
            var employee = (ServiceReference1.Employee)ser.ReadObject(GenerateStreamFromString(jEmployee));
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(ServiceReference1.Employee employee)
        {
            client.UpdateEmployee(employee);
            return RedirectToAction("ShowAllEmployeee");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(string employeeId)
        {
            ServiceReference1.Employee employee = client.RetreiveEmployees(employeeId);
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmed(string employeeId)
        {
            client.DeleteEmployee(employeeId);
            return RedirectToAction("ShowAllEmployeee");
        }

        private static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}