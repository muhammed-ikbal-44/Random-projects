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
    public partial class FrmSesOdası : Form
    {
        public FrmSesOdası()
        {
            InitializeComponent();
        }


        SqlConnection bgl = new SqlConnection(@"Data Source=DAHI\SQLEXPRESS;Initial Catalog=SesFrekansDb;Integrated Security=True");



        void listele()
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_SesOdası where SesTur='Olumlu'", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            this.dataGridView2.Columns["DosyaYol"].Visible = false;
            this.dataGridView2.Columns["ID"].Visible = false;


            SqlDataAdapter db = new SqlDataAdapter("select * from Tbl_SesOdası where SesTur='Olumsuz'", bgl);
            DataTable dk = new DataTable();
            db.Fill(dk);
            dataGridView3.DataSource = dk;
            this.dataGridView3.Columns["DosyaYol"].Visible = false;
            this.dataGridView3.Columns["ID"].Visible = false;

        }

        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedItem = null;
        }
        public void DatagridviewSetting(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.RowHeadersVisible = false;


        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSesOdası_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text;
        }






        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.ShowDialog();  // openfiledialog ekranını açıyoruz.
            string DosyaYolu = file.FileName;
            textBox2.Text = DosyaYolu;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            


                bgl.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_SesOdası (SesAd,DosyaYol,SesTur) values (@p1,@p2,@p3)", bgl);//Ses ekleme
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", label2.Text);
                komut.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("Ses Eklenmiştir Listede Görebilirsiniz", "Command Succesfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            
          


           




        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSesOdası_Load_1(object sender, EventArgs e)
        {
            listele();
            DatagridviewSetting(dataGridView2);
            DatagridviewSetting(dataGridView3);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 0;
            trackBar2.Maximum = 100;
            trackBar2.Minimum = 0;
            trackBar3.Maximum = 100;
            trackBar3.Minimum = 0;
           


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            textBox3.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            
            textBox2.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();

            if (TxtSes1.Text == "")
            {
                int secilen1 = dataGridView2.SelectedCells[0].RowIndex;

               
                TxtSes1.Text = dataGridView2.Rows[secilen1].Cells[1].Value.ToString();

                TxtSes1Dosyayol.Text = dataGridView2.Rows[secilen1].Cells[2].Value.ToString();
               
            }
            else if (TxtSes2.Text == "")
            {
                int secilen2 = dataGridView2.SelectedCells[0].RowIndex;


                TxtSes2.Text = dataGridView2.Rows[secilen2].Cells[1].Value.ToString();

                TxtSes2Dosyayol.Text = dataGridView2.Rows[secilen2].Cells[2].Value.ToString();
            }
            else if (TxtSes3.Text == "")
            {
                int secilen3 = dataGridView2.SelectedCells[0].RowIndex;


                TxtSes3.Text = dataGridView2.Rows[secilen3].Cells[1].Value.ToString();

                TxtSes3Dosyayol.Text = dataGridView2.Rows[secilen3].Cells[2].Value.ToString();
            }
            else
            {
               
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView3.SelectedCells[0].RowIndex;

            textBox3.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();

            if (TxtSes1.Text == "")
            {
                int secilen1 = dataGridView3.SelectedCells[0].RowIndex;


                TxtSes1.Text = dataGridView3.Rows[secilen1].Cells[1].Value.ToString();

                TxtSes1Dosyayol.Text = dataGridView3.Rows[secilen1].Cells[2].Value.ToString();

            }
            else if (TxtSes2.Text == "")
            {
                int secilen2 = dataGridView3.SelectedCells[0].RowIndex;


                TxtSes2.Text = dataGridView3.Rows[secilen2].Cells[1].Value.ToString();

                TxtSes2Dosyayol.Text = dataGridView3.Rows[secilen2].Cells[2].Value.ToString();
            }
            else if (TxtSes3.Text == "")
            {
                int secilen3 = dataGridView3.SelectedCells[0].RowIndex;


                TxtSes3.Text = dataGridView3.Rows[secilen3].Cells[1].Value.ToString();

                TxtSes3Dosyayol.Text = dataGridView3.Rows[secilen3].Cells[2].Value.ToString();
            }
            else
            {
                
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

               
                    renk.BackColor = Color.DarkSeaGreen;
                    dataGridView2.Rows[i].DefaultCellStyle = renk;
               
            }
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();


                renk.BackColor = Color.DarkSeaGreen;
                dataGridView3.Rows[i].DefaultCellStyle = renk;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("delete  from Tbl_SesOdası where ID=@p1", bgl);
            komut.Parameters.AddWithValue("@p1", textBox3.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Ses Başarıyla Silindi", "Command Sucesfuly",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bgl.Close();
            listele();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = TxtSes1Dosyayol.Text;
            axWindowsMediaPlayer2.URL = TxtSes2Dosyayol.Text;
            axWindowsMediaPlayer3.URL = TxtSes3Dosyayol.Text;

            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer2.Ctlcontrols.play();
            axWindowsMediaPlayer3.Ctlcontrols.play();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
           
           
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.settings.volume = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.settings.volume = trackBar3.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            axWindowsMediaPlayer3.Ctlcontrols.pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer2.Ctlcontrols.play();
            axWindowsMediaPlayer3.Ctlcontrols.play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TxtSes1Dosyayol.Clear();
            TxtSes1.Clear();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TxtSes2Dosyayol.Clear();
            TxtSes2.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TxtSes3Dosyayol.Clear();
            TxtSes3.Clear();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
