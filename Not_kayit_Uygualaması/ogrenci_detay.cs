using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_kayit_Uygualaması
{
    public partial class ogrenci_detay : Form
    {
        public ogrenci_detay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-3RVNUIO8\\SQLEXPRESS01;Initial Catalog=Dbnotkayit;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader dr;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ogrenci_detay_Load(object sender, EventArgs e)
        {
            
            lblno.Text = numara;
            baglanti.Open();
            komut = new SqlCommand("Select *from DersTbl where OGRNO = @p1 ",baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            dr = komut.ExecuteReader();
            while(dr.Read())
            {  
                lbladsoyad.Text = dr[2].ToString() + "  "+dr[3].ToString();
                lblsınav1.Text = dr[4].ToString();
                lblsınav2.Text = dr[5].ToString();
                lblsınav3.Text = dr[6].ToString();
                lblort.Text = dr[7].ToString();
             lbldurum.Text = dr[8].ToString();
            

            }
            baglanti.Close();   
            if (lbldurum.Text == "True ")
            {
                lbldurum.Text = "Tebrikler başarılı bir şekilde dersi geçtiniz";
            }
            else if (lbldurum.Text =="False")
            {
                lbldurum.Text = "Başarısız Oldunuz";
            }
            else
             {
                    lbldurum.Text = "Henüz notlarınız girilmedi";
             }
              
           
        }

        private void lblno_Click(object sender, EventArgs e)
        {

        }

        private void lbldurum_Click(object sender, EventArgs e)
        {

        }
    }
}
//Data Source=LAPTOP-3RVNUIO8\SQLEXPRESS01;Initial Catalog=Dbnotkayit;Integrated Security=True