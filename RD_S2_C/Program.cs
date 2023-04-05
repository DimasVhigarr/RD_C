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
