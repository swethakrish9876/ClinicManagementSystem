using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectClinic.Models;
using ProjectClinic.Models.DAL;

namespace ProjectClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidateIndex(Login log)
        {
            if (ModelState.IsValid)
            {
                ClinicDAL cobj = new ClinicDAL();
                int result = cobj.LogCon(log);
                if (result == 1)
                {
                    
                    return RedirectToAction("Home");
                }
                else
                {
                    return View("Invalid");
                }
                                
            }
            return View("Index");                                   
        }
        public IActionResult Home()
        {
            return View();
        }

       

        public IActionResult AddDoctor()
        {
            return View();
        }
        public IActionResult DocValidate(Doctor doc)
        {
            if (ModelState.IsValid)
            {
                ClinicDAL cobj = new ClinicDAL();
                int result = cobj.DocCon(doc);
                if (result == 1)
                    return View("RegSuccess");                
                   
            }
            return View("AddDoctor");

        }

        public IActionResult AddPatient()
        {
            return View();
        }

        public IActionResult PatValidate(Patient pat)
        {
            if (ModelState.IsValid)
            {
                ClinicDAL cobj = new ClinicDAL();
                int result = cobj.PatCon(pat);
                if (result == 1)
                    return View("RegSuccess");
            }
            
               return View("AddPatient");

        }

        public IActionResult AddAppointment()
        {
            return View();
        }

        public IActionResult AppValidate(Appointment app)
        {
            if (ModelState.IsValid)
            {
                ClinicDAL cobj = new ClinicDAL();
                int result = cobj.AppCon(app);
                if (result == 1)
                    return View("AppReg");
            }
            
                return View("AddAppointment");
        }
        public IActionResult DeleteApp()
        {
            return View();
        }
        public IActionResult CancelAppointment()
        {
            ClinicDAL obj = new ClinicDAL();
            List<Appointment> PatientList = new List<Appointment>();
            PatientList = obj.CancelApp();
            return View(PatientList);
        }
        //public IActionResult CanValidate(int id, CancelAppoint ca)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ClinicDAL cobj = new ClinicDAL();
        //        int result = cobj.CanCon(id, ca);
        //        if (result == 1)
        //            return View("CanReg");
        //    }

        //    return View("CancelAppointment");

        //}

       
        public IActionResult Deleting(CancelAppoint c)
        {
            int result;
            int PatientId = c.PatientId;
            if (ModelState.IsValid)
            {
                ClinicDAL cobj = new ClinicDAL();
                result = cobj.DeleteData(c);
                return View("CanReg");
            }
            else
                return RedirectToAction("DeleteApp");
        }


        public IActionResult DoctorInformation()
        {
            ClinicDAL obj = new ClinicDAL();
            List<Doctor> DoctorList = new List<Doctor>();
            DoctorList = obj.DoctorInfo();
            return View(DoctorList);
        }

        public IActionResult PatientInformation()
        {
            ClinicDAL obj = new ClinicDAL();
            List<Patient> PatientList = new List<Patient>();
            PatientList = obj.PatientInfo();
            return View(PatientList);
        }

        public IActionResult ScheduleInformation()
        {
            ClinicDAL obj = new ClinicDAL();
            List<Appointment> ScheduleList = new List<Appointment>();
            ScheduleList = obj.CancelApp();
            return View(ScheduleList);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
