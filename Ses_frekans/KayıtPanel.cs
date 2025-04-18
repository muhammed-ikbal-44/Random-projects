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

namespace SesFrekansArayüz
{
    public partial class FrmKayıt : Form
    {
        public FrmKayıt()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DAHI\SQLEXPRESS;Initial Catalog=SesFrekansDb;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        bool durum;
        void mukerrer()
        {
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Select * from Tbl_Kullanici where AD=@p1", bgl);
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            bgl.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            mukerrer();
            if (durum == true)
            {


                bgl.Open();

                SqlCommand komut = new SqlCommand("insert into Tbl_Kullanici (AD,Sifre) values (@p1,@p2)", bgl);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                if (textBox2.Text == textBox3.Text)
                {
                    komut.ExecuteNonQuery();
                    MessageBox.Show(textBox1.Text + " Adlı Kullanıcı Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Girdiğiniz Şifreler Farklı, Lütfen Kontrol Edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                bgl.Close();
            }
            else
            {
                MessageBox.Show("Bu isimde Bir Kayıt Zaten Bulunmakta", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void FrmKayıt_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
