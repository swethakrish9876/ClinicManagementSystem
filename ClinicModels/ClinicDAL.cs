using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace ProjectClinic.Models.DAL
{
    public class ClinicDAL
    {
        public string cnn = "";

        public object PatientId { get; private set; }

        public ClinicDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }


        public int LogCon(Login log)
        {


            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("ProcLogin", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User", log.UserName);
            cmd.Parameters.AddWithValue("@Pass", log.Passwrd);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);

            con.Close();
            return (0);

        }

        public int DocCon(Doctor doc)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("ProcDoc", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@docfn", doc.Doctor_FirstName);
            cmd.Parameters.AddWithValue("@docln", doc.Doctor_LastName);
            cmd.Parameters.AddWithValue("@docsex", doc.Doctor_Sex);
            cmd.Parameters.AddWithValue("@docspec", doc.Doctor_Specialisation);
            cmd.Parameters.AddWithValue("@docvisit", doc.Doctor_VisitingHours);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int PatCon(Patient pat)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("ProcPat", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patfn", pat.Patient_FirstName);
            cmd.Parameters.AddWithValue("@patln", pat.Patient_LastName);
            cmd.Parameters.AddWithValue("@patsex", pat.Patient_Sex);
            //cmd.Parameters.AddWithValue("@patage", pat.Patient_Age);
            cmd.Parameters.AddWithValue("@patdob", pat.Patient_DOB);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public int AppCon(Appointment app)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("ProcApp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patid", app.PatientId);
            cmd.Parameters.AddWithValue("@spec", app.Specialisation);
            cmd.Parameters.AddWithValue("@doc", app.Doctor);
            cmd.Parameters.AddWithValue("@visit", app.Visit_Date);
            cmd.Parameters.AddWithValue("@app", app.Appointment_Time);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        //public int CanCon(int id,CancelAppoint can)
        //{

        //    SqlConnection con = new SqlConnection(cnn);
        //    SqlCommand cmd = new SqlCommand("ProcCan", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@pat", can.PatientId);           
        //    con.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;
        //}




        public int DeleteData(CancelAppoint c)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("CancelAppoint", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientid", c.PatientId);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public List<Appointment> CancelApp()
        {
            List<Appointment> listPatient = new List<Appointment>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("SelectAll", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listPatient.Add(new Appointment()
                        {
                            PatientId = int.Parse(reader["PatientId"].ToString()),
                            Specialisation = reader["Specialisation"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                            Visit_Date = reader["Visit_Date"].ToString(),
                            Appointment_Time = reader["Appointment_Time"].ToString(),
                        });
                    }

                }
            }
            return listPatient;
        }

        public List<Doctor> DoctorInfo()
        {
            List<Doctor> listDoctor = new List<Doctor>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("SelectDoctor", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listDoctor.Add(new Doctor()
                        {
                            DoctorId = int.Parse(reader["DoctorId"].ToString()),
                            Doctor_FirstName = reader["Doctor_FirstName"].ToString(),
                            Doctor_LastName = reader["Doctor_LastName"].ToString(),
                            Doctor_Sex = reader["Doctor_Sex"].ToString(),
                            Doctor_Specialisation = reader["Doctor_Specialisation"].ToString(),
                            Doctor_VisitingHours = reader["Doctor_VisitingHours"].ToString(),
                        });
                    }

                }
            }
            return listDoctor;
        }


        public List<Patient> PatientInfo()
        {
            List<Patient> listPatient = new List<Patient>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("SelectPatient", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listPatient.Add(new Patient()
                        {
                            Patient_FirstName = reader["Patient_FirstName"].ToString(),
                            Patient_LastName = reader["Patient_LastName"].ToString(),
                            Patient_Sex = reader["Patient_Sex"].ToString(),
                            Patient_Age = int.Parse(reader["Patient_Age"].ToString()),
                            Patient_DOB = reader["Patient_Date_Of_Birth"].ToString(),
                                                      
                            
                        });
                    }

                }
            }
            return listPatient;
        }



    }
}
