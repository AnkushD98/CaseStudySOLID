using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelsLib;
using ICUDBMySQLRepoInterfaceLib;
using Newtonsoft.Json;

namespace ICUDBMySQLRepository
{
    public class ICUDBMySQLRepo : IICUDBRepo
    {
        public ICUDBMySQLRepo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ICUDB;
               Integrated Security=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Beds", con);
            var reader = cmd1.ExecuteReader();
            Dictionary<int, bool> occupied = new Dictionary<int, bool>();
            occupied.Clear();

            while (reader.Read())
            {
                if ((string)reader[1] == "Y")
                {
                    occupied.Add((int)reader[0], true);
                }
                else
                {
                    occupied.Add((int)reader[0], false);
                }


            }

            ICU.BedOccupancy = occupied;
        }
        public void AdmitPatient(string id,int bedno)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ICUDB;
               Integrated Security=True;MultipleActiveResultSets=true");
            con.Open();
            //SqlCommand cmd1 = new SqlCommand("SELECT * FROM Beds", con);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM ICUSTATE", con);
            var reader2 = cmd2.ExecuteReader();
            int bedsFree=10, bedsOccupied=0;
            while (reader2.Read())
            {
                bedsFree = (int)reader2[5];
                bedsOccupied = (int)reader2[4];
            }
            reader2.Close();
            
            //Admit Patient 

            List<Patient> Patients=new List<Patient>();

            var reader1 = new StreamReader("PatientData.json");
            string content = reader1.ReadToEnd();

            var data = JsonConvert.DeserializeObject(content, typeof(List<Patient>));
            if (data is List<Patient>)
                Patients = data as List<Patient>;
                
            else
                throw new ArgumentException("Failed to load JSON file");
            con.Close();
            foreach (var patient in Patients)
            {
                if (patient.PatientId == id)
                {
                   
                    con.Open();
                    SqlCommand cmd = new SqlCommand($@"INSERT INTO ICUSTATE VALUES ('"+ id+"', "+patient.Spo2+", "+patient.PulseRate+", "+patient.Temperature+
                                                    ", " + bedsOccupied+ ", " + bedsFree+ ", " + bedno+");",con);
                    
                    string query = @"UPDATE ICUSTATE SET BEDSOCCUPIED=BEDSOCCUPIED+1 
                            ";
                    bedsOccupied++;
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    
                    SqlCommand cmd3 = new SqlCommand(@"UPDATE ICUSTATE SET BEDSFREE=BEDSFREE-1
                            ", con);
                    bedsFree--;
                    
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    
                }
            }
            
            if (ICU.BedOccupancy[bedno] ==true)
                return;
            ICU.BedOccupancy[bedno] = true;


            SqlCommand cmd4 = new SqlCommand($"UPDATE BEDS SET OCCUPIED='Y' WHERE BEDNO={bedno}", con);
            cmd4.ExecuteNonQuery();
        }

        public void DischargePatient(string id ,int bedno)
        { 
                if (ICU.BedOccupancy[bedno] != null && ICU.BedOccupancy[bedno] == true)
                    return;
                ICU.BedOccupancy[bedno] = false;
                SqlConnection con =
                    new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ICUDB;Integrated Security=True");
                string query = @"UPDATE ICUSTATE SET BEDSOCCUPIED=BEDSOCCUPIED-1 
                            ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd1 = new SqlCommand($"UPDATE BEDS SET OCCUPIED='N' WHERE BEDNO={bedno}", con);
                SqlCommand cmd3 = new SqlCommand($@"DELETE FROM ICUSTATE WHERE ICUSTATE.PATIENTID='{id}'",
                    con);
                SqlCommand cmd2 = new SqlCommand(@"UPDATE ICUSTATE SET BEDSFREE=BEDSFREE+1
                            ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
            
        }


        public void ReadRecord(ref string id, ref int spo2, ref int pulse, ref double temp)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ICUDB;
               Integrated Security=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd = new SqlCommand($@"SELECT * FROM ICUSTATE WHERE PATIENTID='{id}'", con);
            var reader = cmd.ExecuteReader();
            reader.Read();
             spo2 = (int)reader[1];
             pulse = (int)reader[3];
            _ = (string)reader[0];
            temp = (double)reader[2];


        }
    }
}
