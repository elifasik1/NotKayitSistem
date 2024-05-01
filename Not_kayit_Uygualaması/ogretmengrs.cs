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
using System.Diagnostics.Eventing.Reader;
namespace Not_kayit_Uygualaması
{
    public partial class ogretmengrs : Form
    {
        public ogretmengrs()
        {
            InitializeComponent();
        }
        private int gecen = 0;
        private int kalan = 0;

        //Data Source=LAPTOP-3RVNUIO8\SQLEXPRESS01;Initial Catalog=Dbnotkayit;Integrated Security=True
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-3RVNUIO8\\SQLEXPRESS01;Initial Catalog=Dbnotkayit;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter ad;
        
        private void ogrenciekle_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ogretmengrs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbnotkayitDataSet1.DersTbl' table. You can move, or remove it, as needed.
            this.dersTblTableAdapter.Fill(this.dbnotkayitDataSet1.DersTbl);
           

        }

        private void btnekleme_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new SqlCommand("insert into DersTbl(OGRNO,OGRAD,OGRSOYAD) values(@p1,@p2,@p3)",baglanti);
            cmd.Parameters.AddWithValue("@p1", txtno.Text);
            cmd.Parameters.AddWithValue("@p2", txtad.Text);
            cmd.Parameters.AddWithValue("@p3", txtsoyad.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.dersTblTableAdapter.Fill(this.dbnotkayitDataSet1.DersTbl);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            s1 = Convert.ToDouble(txtsınav1.Text);
            s2 = Convert.ToDouble(txtsınav2.Text);
            s3 = Convert.ToDouble(txtsınav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            lblort.Text = ortalama.ToString();
            string durum;
           
            if(ortalama>=50)
            {
                durum = "True";
                gecen++;
            }
            else
            {
                durum = "False";
                kalan++;
            }
            baglanti.Open();
            cmd = new SqlCommand("update DersTbl set OGRS1=@s1,OGRS2=@s2,OGRS3=@s3,ORTALAMA=@ort,DURUM=@s4 where OGRNO=@s6", baglanti);

            cmd.Parameters.AddWithValue("@s1", txtsınav1.Text);
            cmd.Parameters.AddWithValue("@s2", txtsınav2.Text);
            cmd.Parameters.AddWithValue("@s3", txtsınav3.Text);
            cmd.Parameters.AddWithValue("@ort",decimal.Parse(lblort.Text));
            cmd.Parameters.AddWithValue("@s4", durum);
            cmd.Parameters.AddWithValue("@s6",txtno.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları güncellendi");
            this.dersTblTableAdapter.Fill(this.dbnotkayitDataSet1.DersTbl);
           
          
            lblgecen.Text = gecen.ToString();
            lblkalan.Text = kalan.ToString();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtno.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();




            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
