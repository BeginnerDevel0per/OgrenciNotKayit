using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciNotKayit
{
    public class repository
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        List<ogrencibilgi> ogrencibilgis;
        List<login> logins;


        public repository() // SQL bağlantısı
        {
            con = new SqlConnection("Data Source=ASUS;Initial Catalog=DBnotkayit;User ID=sa;password=1");

        }

        public ogrencibilgi login(string ogrnumara) // öğrenci giriş
        {
            ogrencibilgi ogrencibilgi = new ogrencibilgi();
            ogrencibilgis = new List<ogrencibilgi>();
            con.Open();
            cmd = new SqlCommand("select * from TBL_DERS where OGRNUMARA=@ogrnumara", con);
            cmd.Parameters.AddWithValue("@ogrnumara", ogrnumara);
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {


                ogrencibilgi.ogrnumara = dr["OGRNUMARA"].ToString();
                ogrencibilgi.ograd = dr["OGRAD"].ToString();
                ogrencibilgi.ogrsoyad = dr["OGRSOYAD"].ToString();

                object ogrs1 = dr["OGRS1"];
                object ogrs2 = dr["OGRS2"];
                object ogrs3 = dr["OGRS3"];
                if (ogrs1 == DBNull.Value)
                {
                    ogrs1 = 0;
                }
                if (ogrs2 == DBNull.Value)
                {
                    ogrs2 = 0;
                }
                if (ogrs3 == DBNull.Value)
                {
                    ogrs3 = 0;
                }
                ogrencibilgi.ogrs1 = Convert.ToByte(ogrs1);
                ogrencibilgi.ogrs2 = Convert.ToByte(ogrs2);
                ogrencibilgi.ogrs3 = Convert.ToByte(ogrs3);
                ogrencibilgi.ortalama = Convert.ToDecimal(dr["ORTALAMA"].ToString());
                ogrencibilgi.durum = dr["DURUM"].ToString();
                ogrencibilgi.status = loginstatus.basarili;
                ogrencibilgis.Add(ogrencibilgi);
                con.Close();
                return ogrencibilgi;
            }
            else
            {
                ogrencibilgi.status = loginstatus.basarisiz;
                ogrencibilgis.Add(ogrencibilgi);
                con.Close();
                return ogrencibilgi;
            }
            
        }

        public login ogretmengiris(string kullaniciadi, string sifre)
        {
            logins = new List<login>();
            con.Open();
            cmd = new SqlCommand("select * from TBL_OGRETMENGIRIS WHERE KULADI=@kulad and SIFRE=@sifre", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciadi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                login login = new login();
                login.id = Convert.ToInt32(dr["ID"].ToString());
                login.kullaniciadi = dr["KULADI"].ToString();
                login.sifre = dr["SIFRE"].ToString();
                login.status = loginstatus.basarili;
                logins.Add(login);
                con.Close();
                return login;
            }
            
            else
            {
                login login = new login();
                login.status = loginstatus.basarisiz;
                logins.Add(login);
                return login;
            }

        }

        public List<ogrencibilgi> GetOgrencibilgi()
        {
            ogrencibilgis = new List<ogrencibilgi>();
            con.Open();
            cmd = new SqlCommand("select * from TBL_DERS", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ogrencibilgi ogrencibilgi = new ogrencibilgi();
                ogrencibilgi.id = Convert.ToInt32(dr["ID"].ToString());
                ogrencibilgi.ogrnumara = dr["OGRNUMARA"].ToString();
                ogrencibilgi.ograd = dr["OGRAD"].ToString();
                ogrencibilgi.ogrsoyad = dr["OGRSOYAD"].ToString();
                object ogrs1 = dr["OGRS1"];
                object ogrs2 = dr["OGRS2"];
                object ogrs3 = dr["OGRS3"];
                object ortalama = dr["ORTALAMA"];
                if (ogrs1 == DBNull.Value)
                {
                    ogrs1 = 0;
                }
                if (ogrs2 == DBNull.Value)
                {
                    ogrs2 = 0;
                }
                if (ogrs3 == DBNull.Value)
                {
                    ogrs3 = 0;
                }
                if (ortalama == DBNull.Value || Convert.ToInt32(ortalama) == 1)
                {
                    ortalama = 0;
                }
                ogrencibilgi.ogrs1 = Convert.ToByte(ogrs1);
                ogrencibilgi.ogrs2 = Convert.ToByte(ogrs2);
                ogrencibilgi.ogrs3 = Convert.ToByte(ogrs3);
                ogrencibilgi.ortalama = Convert.ToDecimal(ortalama);
                if (Convert.ToInt32(ortalama) != 0)
                {
                    ogrencibilgi.durum = dr["DURUM"].ToString();
                }
                ogrencibilgis.Add(ogrencibilgi);

            }
            con.Close();
            return ogrencibilgis;

        }

        public void delete() // silme
        {

        }

        public loginstatus insertOgrenci(string ogrnumara, string ograd, string ogrsoyad) //ekleme
        {
            con.Open();
            cmd = new SqlCommand("insert into TBL_DERS(OGRNUMARA,OGRAD,OGRSOYAD,OGRS1) values(@ogrnumara,@ograd,@ogrsoyad,@ogrs1)", con);
            cmd.Parameters.AddWithValue("@ogrnumara", ogrnumara);
            cmd.Parameters.AddWithValue("@ograd", ograd);
            cmd.Parameters.AddWithValue("@ogrsoyad", ogrsoyad);
            cmd.Parameters.AddWithValue("@ogrs1", 1);
            int returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue >= 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }


        }


        public loginstatus updateOgrenci(byte ogrs1, byte ogrs2, byte ogrs3, string ogrnumara) //güncelleme
        {
            con.Open();
            cmd = new SqlCommand("update TBL_DERS set OGRS1=@ogrs1 , OGRS2=@ogrs2 , OGRS3=@ogrs3 where OGRNUMARA=@ogrnumara  ", con);
            cmd.Parameters.AddWithValue("@ogrs1", ogrs1);
            cmd.Parameters.AddWithValue("@ogrs2", ogrs2);
            cmd.Parameters.AddWithValue("@ogrs3", ogrs3);
            cmd.Parameters.AddWithValue("@ogrnumara", ogrnumara);

            int result =(int)cmd.ExecuteNonQuery();
            con.Close();
            if (result >= 1)
            {
                return loginstatus.basarili;
            }
            else
            {
                return loginstatus.basarisiz;
            }
        }
        public decimal Getavg()
        {

            ogrencibilgi ogrencibilgi = new ogrencibilgi();
            con.Open();
            cmd = new SqlCommand("SELECT AVG(ORTALAMA) ORT FROM TBL_DERS WHERE ORTALAMA IS NOT NULL AND ORTALAMA != 1;", con);
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {

                ogrencibilgi.ortalama = Convert.ToDecimal(dr["ORT"].ToString());
                con.Close();
                return ogrencibilgi.ortalama;
            }
            else
            {
                return 00;
            }
            

           

        }
        public string getkalan()
        {
            string kalan;
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(DURUM) durum FROM TBL_DERS where DURUM in('kaldı')", con);
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                kalan = dr["durum"].ToString();
                con.Close();
                return kalan;
            }
            else
            {
                return "00";
            }


        }

        public string getgecen()
        {
            string kalan;
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(DURUM) durum FROM TBL_DERS where DURUM in('Geçti')", con);
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                kalan = dr["durum"].ToString();
                con.Close();
                return kalan;
            }
            else
            {
                return "00";
            }

        }
    }
}
