using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_kayit_Uygualaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void maskedTextBox1_TextChanged(object sender,EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                ogretmengrs fr = new ogretmengrs();
                fr.Show();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ogrenci_detay frm = new ogrenci_detay();
            frm.numara = maskedTextBox1.Text;
            frm.Show();
            this.Hide();
        }

        
       
    }
}
