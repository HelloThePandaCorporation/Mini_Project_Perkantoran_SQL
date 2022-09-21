using System;
using System.Data.SqlClient;

namespace Karyawan_Perkantoran
{
    class Program { 
       
        static void Main(string[] args)
        {
            string note;
            CRUD crud = new CRUD();
            do
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("Menu Perkantoran");
                Console.WriteLine("1. Karyawan");
                Console.WriteLine("2. Gaji");
                Console.WriteLine("3. Keterlambatan");
                
                Console.WriteLine("=======================================================");
                Console.WriteLine("Pilih Salah satu menu diatas dengan inputan 1-4: ");
                string userinput = Console.ReadLine();
                Console.WriteLine("=======================================================");
                int userin = Convert.ToInt16(userinput);
                Console.Clear();
                switch (userin)
                {
                    case 1:
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Menu Karyawan");
                        Console.WriteLine("1. Tampilkan semua Karyawan");
                        Console.WriteLine("2. Tampilkan berdasarkan id");
                        Console.WriteLine("3. Tambah karyawan baru");
                        Console.WriteLine("4. Update data karyawan");
                        Console.WriteLine("5. Delete data karyawan");
                        Console.WriteLine("Masukkan 1-5 bila selain itu balik ke menu utama");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Pilih Salah satu menu diatas dengan inputan 1-4: ");
                        userinput = Console.ReadLine();
                        userin = Convert.ToInt32(userinput);
                        
                        //menu switch
                        switch (userin)
                        {
                            case 1:
                                crud.Tampil_karyawan();
                                break;
                            case 2:
                                Console.WriteLine("Inputkan id dari karyawan: ");
                                string ids = Console.ReadLine();
                                int idx = Convert.ToInt32(ids);
                                crud.Tampil_karyawan(idx);
                                break;
                            case 3:
                                Console.WriteLine("---------------Tabel Gaji---------------");
                                crud.Tampil_gaji();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan Data ------");
                                Console.WriteLine("Masukkan Nama Karyawan : ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Masukkan alamat Karyawan : ");
                                string alamat = Console.ReadLine();
                                Console.WriteLine("Masukkan gender Karyawan 0 = Perempuan dan 1 = laki-laki  : ");
                                string genders = Console.ReadLine();
                                int gender = Convert.ToInt32(genders);
                                Console.WriteLine("Masukkan idsalary Karyawan : ");
                                string salaryids = Console.ReadLine();
                                int salaryid = Convert.ToInt32(salaryids);

                                karyawan karyawan = new karyawan()
                                {
                                    name = name,
                                    address = alamat,
                                    gender = gender,
                                    salaryid = salaryid
                                };
                                crud.tambah_karyawan(karyawan);
                                crud.Tampil_karyawan();
                                break;
                            case 4:
                                Console.WriteLine("---------------Tabel Karyawan---------------");
                                crud.Tampil_karyawan();
                                Console.WriteLine("");
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("Input nilai id karyawan yang akan diubah:");
                                ids = Console.ReadLine();
                                idx = Convert.ToInt32(ids);
                                Console.WriteLine("Masukkan Nama Karyawan : ");
                                name = Console.ReadLine();
                                Console.WriteLine("Masukkan alamat Karyawan : ");
                                alamat = Console.ReadLine();
                                Console.WriteLine("Masukkan gender Karyawan 0 = Perempuan dan 1 = laki-laki  : ");
                                genders = Console.ReadLine();
                                gender = Convert.ToInt32(genders);
                                Console.WriteLine("Masukkan idsalary Karyawan : ");
                                salaryids = Console.ReadLine();
                                salaryid = Convert.ToInt32(salaryids);

                                karyawan = new karyawan()
                                {
                                    id = idx,
                                    name = name,
                                    address = alamat,
                                    gender = gender,
                                    salaryid = salaryid
                                };
                                crud.update_karyawan(karyawan);
                                break;
                            case 5:
                                Console.WriteLine("---------------Tabel Karyawan---------------");
                                crud.Tampil_karyawan();
                                Console.WriteLine("");
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("Input nilai id karyawan yang akan dihapus:");
                                ids = Console.ReadLine();
                                idx = Convert.ToInt32(ids);

                                crud.hapus_karyawan(idx);
                                crud.Tampil_karyawan();
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Gaji");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Menu Karyawan");
                        Console.WriteLine("1. Tampilkan semua Golongan Gaji");
                        Console.WriteLine("2. Tambah golongan gaji");
                        Console.WriteLine("3. Update golongan gaji");
                        Console.WriteLine("4. Delete golongan gaji");
                        Console.WriteLine("Masukkan 1-4 bila selain itu balik ke menu utama");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Pilih Salah satu menu diatas dengan inputan 1-4: ");
                        userinput = Console.ReadLine();
                        userin = Convert.ToInt32(userinput);

                        //menu switch
                        switch (userin)
                        {
                            case 1:
                                crud.Tampil_gaji();
                                break;
                            
                            case 2:
                                Console.WriteLine("---------------Tabel Gaji---------------");
                                crud.Tampil_gaji();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan Data ------");
                                Console.WriteLine("Masukkan Nama Golongan gaji : ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Masukkan id golongan pastikan beda dengan yang sudah ada  : ");
                                string ids = Console.ReadLine();
                                int idxs = Convert.ToInt32(ids);
                                Console.WriteLine("Masukkan salary golongan : ");
                                string salaryids = Console.ReadLine();
                                decimal salary = Convert.ToDecimal(salaryids);

                                crud.tambah_gaji(idxs, name, salary);
                                crud.Tampil_gaji();
                                break;
                            case 3:
                                Console.WriteLine("---------------Tabel Gaji---------------");
                                crud.Tampil_gaji();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan id dari gaji yang akan diedit: ");
                                ids = Console.ReadLine();
                                idxs = Convert.ToInt32(ids);
                                Console.WriteLine("Masukkan Nama Golongan gaji : ");
                                name = Console.ReadLine();
                                Console.WriteLine("Masukkan salary golongan : ");
                                salaryids = Console.ReadLine();
                                salary = Convert.ToDecimal(salaryids);

                                crud.update_gaji(idxs, name, salary);
                                crud.Tampil_gaji();
                                break;
                            case 4:
                                Console.WriteLine("---------------Tabel Gaji---------------");
                                crud.Tampil_gaji();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan id dari gaji yang akan dihapus: ");
                                ids = Console.ReadLine();
                                idxs = Convert.ToInt32(ids);

                                crud.hapus_gaji(idxs);
                                Console.WriteLine("---------------Tabel Gaji---------------");
                                crud.Tampil_gaji();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Keterlambatan");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Menu Karyawan");
                        Console.WriteLine("1. Tampilkan semua keterlambatan");
                        Console.WriteLine("2. Tambah keterlambatan");
                        Console.WriteLine("3. Update keterlambatan");
                        Console.WriteLine("4. Delete keterlambatan");
                        Console.WriteLine("Masukkan 1-4 bila selain itu balik ke menu utama");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Pilih Salah satu menu diatas dengan inputan 1-4: ");
                        userinput = Console.ReadLine();
                        userin = Convert.ToInt32(userinput);
                        switch (userin)
                        {
                            case 1:
                                crud.Tampil_terlambat();
                                break;

                            case 2:
                                Console.WriteLine("---------------Tabel Keterlambatan---------------");
                                crud.Tampil_terlambat();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan Data ------");
                                Console.WriteLine("Masukkan lama keterlambatan dalam menit  : ");
                                string ids = Console.ReadLine();
                                decimal second = Convert.ToDecimal(ids);
                                Console.WriteLine("Masukkan id karyawan : ");
                                string karyawan = Console.ReadLine();
                                int idperson = Convert.ToInt32(karyawan);

                                crud.tambah_terlambat(second, idperson);
                                crud.Tampil_terlambat();
                                break;
                            case 3:
                                Console.WriteLine("---------------Tabel Keterlambatan---------------");
                                crud.Tampil_terlambat();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan Data ------");
                                Console.WriteLine("Masukkan id data keterlamabatan yang akan diubah:");
                                string idss = Console.ReadLine();
                                int idxs = Convert.ToInt32(idss);
                                Console.WriteLine("Masukkan lama keterlambatan dalam menit  : ");
                                ids = Console.ReadLine();
                                second = Convert.ToDecimal(ids);
                                

                                crud.update_terlambat(idxs, second);
                                crud.Tampil_terlambat();
                                break;

                            case 4:
                                Console.WriteLine("---------------Tabel Keterlambatan---------------");
                                crud.Tampil_terlambat();
                                Console.WriteLine("");
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Masukkan Data ------");
                                Console.WriteLine("Masukkan id data keterlamabatan yang akan dihapus:");
                                idss = Console.ReadLine();
                                idxs = Convert.ToInt32(idss);

                                crud.hapus_terlambat(idxs);
                                crud.Tampil_terlambat();
                                break;     
                        }

                        break;
                    case 4:
                        Console.WriteLine("----------------Perhitungan Total Gaji---------------------");
                        Console.WriteLine("Masukkan id karyawan yang akan dihitung gajinya ");
                        string idsss = Console.ReadLine();
                        int id = Convert.ToInt32(idsss);
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Total_gaji");
                        Gaji total_gaji = new Gaji();
                        total_gaji.gaji_total(id);
                        
                        break;
                    default:
                        Console.WriteLine("=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!");
                        Console.WriteLine("Tolong inputkan nilai 1-4 saja sesuai menu yang tersedia!");
                        Console.WriteLine("=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!=!");
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine("Apa anda ingin melanjutkan? (y/t) : ");
                note = Console.ReadLine();
            } while (note == "y");

        }
    }
}

