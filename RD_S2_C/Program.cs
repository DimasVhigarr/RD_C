using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD_S2_C
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi Ke Database\n");
                    Console.WriteLine("Masukkan User ID: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password: ");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database tujuan: ");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data Source = LAPTOP-1VTGMJT8\\DIMPSY" +
                                    "initial catalog = {0}; " +
                                    "User ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat seluruh data");
                                        Console.WriteLine("2. Tambah data");
                                        Console.WriteLine("4. Update Data");
                                        Console.WriteLine("5. Hapus Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.WriteLine("\nEnter your choice (1-3): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA Pelanggan\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA Pelanggan\n");
                                                    Console.WriteLine("Nama_pelanggan :");
                                                    string Nama_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat Pelanggan :");
                                                    string Alamat = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telepon :");
                                                    string Nomor_telepon = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(Nama_pelanggan, Alamat, Nomor_telepon conn);

                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda ridak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                        }
                                    }
                                }
                            }
                    }
                }
                
            }
        }

        

        public void insert(string Nama_pelanggan, string Alamat, string Nomor_telepon, SqlConnection con)
        {
            string str = "";
            str = "insert into pelanggan (Nama_pelanggan, Alamat, Nomor_telepon)" + "values(@Nama_pelanggan, @alamat, @Nomor_Telepon)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("Nama_pelanggan", Nama_pelanggan));
            cmd.Parameters.Add(new SqlParameter("Alamat", Alamat));
            cmd.Parameters.Add(new SqlParameter("Nomor_telepon", Nomor_telepon));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }
    }
}
