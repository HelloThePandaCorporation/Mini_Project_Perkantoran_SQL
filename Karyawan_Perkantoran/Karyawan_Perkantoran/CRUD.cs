using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Karyawan_Perkantoran
{
    class CRUD
    {
        public SqlConnection sqlConn = new SqlConnection();
        public SqlCommand sqlcom = new SqlCommand();
        public SqlParameter sqlpar = new SqlParameter();
        public string connectionString = "Data Source= LAPTOP-S368EH41;" +
                                       "Initial Catalog= MProject_Kantor;" +
                                       "User Id= HelloPanda;" +
                                       "Password= hello123;";

       

        public void tambah_karyawan(karyawan karyawan)
        {
            using (sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlTransaction sqltrans = sqlConn.BeginTransaction();

                sqlcom = sqlConn.CreateCommand();
                sqlcom.Transaction = sqltrans;

                //nama
                sqlpar = new SqlParameter();
                sqlpar.ParameterName = "@name";
                sqlpar.Value = karyawan.name;

                sqlcom.Parameters.Add(sqlpar);

                //alamat
                SqlParameter sqlpar1 = new SqlParameter();
                sqlpar1.ParameterName = "@address";
                sqlpar1.Value = karyawan.address;

                sqlcom.Parameters.Add(sqlpar1);

                //gender
                SqlParameter sqlpar2 = new SqlParameter();
                sqlpar2.ParameterName = "@gender";
                sqlpar2.Value = karyawan.gender;
                
                sqlcom.Parameters.Add(sqlpar2);

                //salaryid
                SqlParameter sqlpar3 = new SqlParameter();
                sqlpar3.ParameterName = "@salaryid";
                sqlpar3.Value = karyawan.salaryid;

                sqlcom.Parameters.Add(sqlpar3);

                
                try
                {
                    sqlcom.CommandText = "INSERT INTO karyawan " +
                        "" +
                        "VALUES (@name,@address,@gender,@salaryid)";
                    sqlcom.ExecuteNonQuery();
                    sqltrans.Commit();
                    Console.WriteLine("Berhasil!");
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Tambah_Karyawan....");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void tambah_gaji(int id, string name, decimal salary)
        {
            using (sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlTransaction sqltrans = sqlConn.BeginTransaction();

                sqlcom = sqlConn.CreateCommand();
                sqlcom.Transaction = sqltrans;

                //nama
                sqlpar = new SqlParameter();
                sqlpar.ParameterName = "@id";
                sqlpar.Value = id;

                sqlcom.Parameters.Add(sqlpar);

                //alamat
                SqlParameter sqlpar1 = new SqlParameter();
                sqlpar1.ParameterName = "@golongan";
                sqlpar1.Value = name;

                sqlcom.Parameters.Add(sqlpar1);

                //gender
                SqlParameter sqlpar2 = new SqlParameter();
                sqlpar2.ParameterName = "@salary";
                sqlpar2.Value = salary;

                sqlcom.Parameters.Add(sqlpar2);
                try
                {
                    sqlcom.CommandText = "INSERT INTO gaji " +
                        "" +
                        "VALUES (@id,@golongan,@salary)";
                    sqlcom.ExecuteNonQuery();
                    sqltrans.Commit();
                    Console.WriteLine("Berhasil!");
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Tambah_gaji....");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void tambah_terlambat(decimal late, int idperson)
        {
            using (sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlTransaction sqltrans = sqlConn.BeginTransaction();

                sqlcom = sqlConn.CreateCommand();
                sqlcom.Transaction = sqltrans;

                //nama
                sqlpar = new SqlParameter();
                sqlpar.ParameterName = "@personid";
                sqlpar.Value = idperson;

                sqlcom.Parameters.Add(sqlpar);

                //alamat
                SqlParameter sqlpar1 = new SqlParameter();
                sqlpar1.ParameterName = "@late";
                sqlpar1.Value = late;

                sqlcom.Parameters.Add(sqlpar1);

                
                try
                {
                    sqlcom.CommandText = "INSERT INTO late " +
                        "" +
                        "VALUES (@late,@personid)";
                    sqlcom.ExecuteNonQuery();
                    sqltrans.Commit();
                    Console.WriteLine("Berhasil!");
                    Console.WriteLine("");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Tambah_late....");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Tampil_karyawan()
        {
            string query = "SELECT * FROM karyawan";
            sqlConn = new SqlConnection(connectionString);
            sqlcom = new SqlCommand(query,sqlConn);
            try
            {
                sqlConn.Open();
                using (SqlDataReader sqlDataReader = sqlcom.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        
                        while (sqlDataReader.Read())
                        {
                            Console.Write(sqlDataReader[0] + " | ");
                            Console.Write(sqlDataReader[1] + " | ");
                            Console.Write(sqlDataReader[2] + " | ");
                            Console.Write(sqlDataReader[3] + " | ");
                            Console.Write(sqlDataReader[4] + " | ");
                            Console.WriteLine("");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows in Karyawan. -------");
                    }
                    sqlConn.Close();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error tampil_karyawan...");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }
            
        }
        public void Tampil_karyawan(int id)
        {
            string query = "SELECT * FROM karyawan WHERE personid = @id";
            sqlpar.ParameterName = "@id";
            sqlpar.Value = id;

            sqlConn = new SqlConnection(connectionString);
            sqlcom = new SqlCommand(query, sqlConn);
            sqlcom.Parameters.Add(sqlpar);
            try
            {
                sqlConn.Open();
                using (SqlDataReader sqlDataReader = sqlcom.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {

                        while (sqlDataReader.Read())
                        {
                            Console.Write(sqlDataReader[0] + " | ");
                            Console.Write(sqlDataReader[1] + " | ");
                            Console.Write(sqlDataReader[2] + " | ");
                            Console.Write(sqlDataReader[3] + " | ");
                            Console.Write(sqlDataReader[4] + " | ");
                            Console.WriteLine("");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Data Rows in Karyawan. -------");
                    }
                    sqlConn.Close();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error tampil_karyawan with value...");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }
        }
        public void Tampil_gaji()
        {
            string query = "SELECT * FROM gaji";
            sqlConn = new SqlConnection(connectionString);
            sqlcom = new SqlCommand(query, sqlConn);
            try
            {
                sqlConn.Open();
                using (SqlDataReader sqlDataReader = sqlcom.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {

                        while (sqlDataReader.Read())
                        {
                            Console.Write(sqlDataReader[0] + " | ");
                            Console.Write(sqlDataReader[1] + " | ");
                            Console.Write(sqlDataReader[2] + " | ");
                            Console.WriteLine("");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Data Rows in gaji. -------");
                    }
                    sqlConn.Close();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error tampil_gaji...");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }

        }
        public void Tampil_terlambat()
        {
            string query = "SELECT late.*, karyawan.name FROM late inner join karyawan ON " +
                "late.personid = karyawan.personid";
            sqlConn = new SqlConnection(connectionString);
            sqlcom = new SqlCommand(query, sqlConn);
            try
            {
                sqlConn.Open();
                using (SqlDataReader sqlDataReader = sqlcom.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {

                        while (sqlDataReader.Read())
                        {
                            Console.Write(sqlDataReader[0] + " | ");
                            Console.Write(sqlDataReader[1] + " | ");
                            Console.Write(sqlDataReader[2] + " | ");
                            Console.Write(sqlDataReader[3] + " | ");
                            Console.WriteLine("");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Data Rows in late. -------");
                    }
                    sqlConn.Close();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error tampil_late...");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }

        }

        public void update_karyawan(karyawan karyawan)
        {
            sqlConn.Open();
            SqlTransaction sqltrans = sqlConn.BeginTransaction();

            sqlcom = sqlConn.CreateCommand();
            sqlcom.Transaction = sqltrans;

            //id
            sqlpar = new SqlParameter();
            sqlpar.ParameterName = "@id";
            sqlpar.Value = karyawan.id;

            sqlcom.Parameters.Add(sqlpar);
            //nama
            SqlParameter sqlpar0 = new SqlParameter();
            
            sqlpar0.ParameterName = "@name";
            sqlpar0.Value = karyawan.name;

            sqlcom.Parameters.Add(sqlpar0);

            //alamat
            SqlParameter sqlpar1 = new SqlParameter();
            sqlpar1.ParameterName = "@address";
            sqlpar1.Value = karyawan.address;

            sqlcom.Parameters.Add(sqlpar1);

            //gender
            SqlParameter sqlpar2 = new SqlParameter();
            sqlpar2.ParameterName = "@gender";
            sqlpar2.Value = karyawan.gender;

            sqlcom.Parameters.Add(sqlpar2);

            //salaryid
            SqlParameter sqlpar3 = new SqlParameter();
            sqlpar3.ParameterName = "@salaryid";
            sqlpar3.Value = karyawan.salaryid;

            sqlcom.Parameters.Add(sqlpar3);


            try
            {
                sqlcom.CommandText = "UPDATE karyawan SET " +
                    "name = @name,address = @address,gender= @gender," +
                    "salaryid = @salaryid  " +
                    "WHERE personid = @id";
                sqlcom.ExecuteNonQuery();
                sqltrans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Update_Karyawan....");
                Console.WriteLine(ex.Message);
            }
        }
        public void update_gaji(int id, string name, decimal salary)
        {
            sqlConn.Open();
            SqlTransaction sqltrans = sqlConn.BeginTransaction();

            sqlcom = sqlConn.CreateCommand();
            sqlcom.Transaction = sqltrans;

            //id
            sqlpar = new SqlParameter();
            sqlpar.ParameterName = "@id";
            sqlpar.Value = id;

            sqlcom.Parameters.Add(sqlpar);
            //nama
            SqlParameter sqlpar0 = new SqlParameter();

            sqlpar0.ParameterName = "@name";
            sqlpar0.Value = name;

            sqlcom.Parameters.Add(sqlpar0);

            //alamat
            SqlParameter sqlpar1 = new SqlParameter();
            sqlpar1.ParameterName = "@salary";
            sqlpar1.Value = salary;

            sqlcom.Parameters.Add(sqlpar1);
            try
            {
                sqlcom.CommandText = "UPDATE gaji SET " +
                    "salarytype = @name,salary= @salary " +
                    "WHERE salaryid = @id";
                sqlcom.ExecuteNonQuery();
                sqltrans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Update_Karyawan....");
                Console.WriteLine(ex.Message);
            }
        }
        public void update_terlambat(int id, decimal second)
        {
            sqlConn.Open();
            SqlTransaction sqltrans = sqlConn.BeginTransaction();

            sqlcom = sqlConn.CreateCommand();
            sqlcom.Transaction = sqltrans;

            //id
            sqlpar = new SqlParameter();
            sqlpar.ParameterName = "@id";
            sqlpar.Value = id;

            sqlcom.Parameters.Add(sqlpar);
            //nama
            SqlParameter sqlpar0 = new SqlParameter();

            sqlpar0.ParameterName = "@second";
            sqlpar0.Value = second;

            sqlcom.Parameters.Add(sqlpar0);

            
            try
            {
                sqlcom.CommandText = "UPDATE late SET " +
                    "late = @second " +
                    "WHERE lateid = @id";
                sqlcom.ExecuteNonQuery();
                sqltrans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Update_late....");
                Console.WriteLine(ex.Message);
            }
        }

        public void hapus_karyawan(int id)
        {
            sqlConn.Open();
            SqlTransaction sqltrans = sqlConn.BeginTransaction();

            sqlcom = sqlConn.CreateCommand();
            sqlcom.Transaction = sqltrans;

            try
            {
                sqlcom.CommandText = "DELETE karyawan " +
                     "WHERE personid = " + id;
                sqlcom.ExecuteNonQuery();
                sqltrans.Commit();
                Console.WriteLine("Berhasil!");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Hapus_Karyawan....");
                Console.WriteLine(ex.Message);
            }
        }
        public void hapus_gaji(int id)
        {
            sqlConn.Open();
            SqlTransaction sqltrans = sqlConn.BeginTransaction();

            sqlcom = sqlConn.CreateCommand();
            sqlcom.Transaction = sqltrans;

            try
            {
                sqlcom.CommandText = "DELETE gaji " +
                     "WHERE salaryid = " + id;
                sqlcom.ExecuteNonQuery();
                sqltrans.Commit();
                Console.WriteLine("Berhasil!");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Hapus_Gaji....");
                Console.WriteLine(ex.Message);
            }
        }
        public void hapus_terlambat(int id)
        {
            sqlConn.Open();
            SqlTransaction sqltrans = sqlConn.BeginTransaction();

            sqlcom = sqlConn.CreateCommand();
            sqlcom.Transaction = sqltrans;

            try
            {
                sqlcom.CommandText = "DELETE late " +
                     "WHERE lateid = " + id;
                sqlcom.ExecuteNonQuery();
                sqltrans.Commit();
                Console.WriteLine("Berhasil!");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Hapus_late....");
                Console.WriteLine(ex.Message);
            }
        }

    }

    class karyawan
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int gender { get; set; }
        public int salaryid { get; set; }
    }

    class Gaji : CRUD
    {

        public void gaji_total(int id)
        {
            string query = "SELECT late FROM late WHERE personid =" + id;
            sqlConn = new SqlConnection(connectionString);
            sqlcom = new SqlCommand(query, sqlConn);
            double total_telat = 0;
            try
            {
                sqlConn.Open();
                using (SqlDataReader sqlDataReader = sqlcom.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {

                        while (sqlDataReader.Read())
                        {
                            total_telat = total_telat + Convert.ToDouble(sqlDataReader[0]);
                            
                        }

                    }
                    else
                    {
                        total_telat = 0;
                        Console.WriteLine("No Data Rows in Karyawan. -------");
                    }
                    sqlConn.Close();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error tampil_karyawan...");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }
            double salary = salarys(id);
            double Total_Gaji = hasil_bagi(salary, total_telat);

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Total Telat : " + total_telat);

            Console.WriteLine("Total Telat : " + (total_telat / 5) * 5000);
            Console.WriteLine("Total Gaji diterima : " + Total_Gaji);
            Console.WriteLine("-------------------------------------------------");
        }

        double hasil_bagi(double salary, double total_telat)
        {
            double potongan = (total_telat / 5) * 5000;
            double hasil_gaji = salary - potongan;
            return hasil_gaji;
        }

        double salarys(int id)
        {
            string query = "SELECT salary FROM gaji inner join karyawan ON " +
                "karyawan.personid = gaji.salaryid";
            sqlConn = new SqlConnection(connectionString);
            sqlcom = new SqlCommand(query, sqlConn);
            double gaji_karyawan = 0;
            try
            {
                sqlConn.Open();
                using (SqlDataReader sqlDataReader = sqlcom.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {

                        while (sqlDataReader.Read())
                        {
                            gaji_karyawan = Convert.ToDouble(sqlDataReader[0]);

                        }

                    }
                    else
                    {
                        
                        Console.WriteLine("No Data Rows in Karyawan. -------");
                    }
                    sqlConn.Close();
                }
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error total gaji...");
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }
            return gaji_karyawan;
        }
        
    }
}
