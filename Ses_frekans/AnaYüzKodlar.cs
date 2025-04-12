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
using System.IO;



namespace SesFrekansArayüz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        

        SqlConnection bgl = new SqlConnection(@"Data Source=DAHI\SQLEXPRESS;Initial Catalog=SesFrekansDb;Integrated Security=True");



        void listele()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Ses", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["Dosyayolu"].Visible = false;
            this.dataGridView1.Columns["ID"].Visible = false;

        }

        void temizle()
        {
            txtAd.Clear();
            txtId.Clear();
            TxtDosyaco.Clear();
            TxtHz.Clear();
        }




        Bitmap bitmap1;

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            DatagridviewSetting(dataGridView1);
            
            trackBar1.Maximum = 20000;
            trackBar1.Minimum = 1;
            trackBar2.Maximum = 100;
            trackBar2.Minimum = 0;
            try
            {
                bitmap1 = (Bitmap)Bitmap.FromFile(@"C:\Users\Hp\Desktop\Tübitak Projeleri\İmages\dosyayol.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = bitmap1;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the bitmap.");
            }



        }

        




        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
        }

        private void varsayılanPembeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkCyan;
            panel10.BackColor = Color.Teal;
            panel12.BackColor = Color.Teal;
            panel1.BackColor = Color.Teal; //Tema değiştirme Beyaz,varsayılan,koyu
            panel14.BackColor = Color.Teal;
            panel13.BackColor = Color.Teal;
         //  pictureBox10.BackColor = Color.Teal;
            groupBox2.BackColor = Color.Teal;
            pictureBox11.BackColor = Color.DarkCyan;
            pictureBox12.BackColor = Color.DarkCyan;
            pictureBox13.BackColor = Color.DarkCyan;
            
            panel2.BackColor = Color.DarkCyan;
            panel3.BackColor = Color.DarkCyan;
            panel4.BackColor = Color.DarkCyan;
            panel5.BackColor = Color.DarkCyan;
            panel6.BackColor = Color.DarkCyan;
            panel7.BackColor = Color.DarkCyan;
            panel8.BackColor = Color.DarkCyan;
            panel9.BackColor = Color.DarkCyan;
           // panel11.BackColor = Color.Teal;
            pictureBox1.BackColor = Color.DarkCyan;
            button7.BackColor = Color.DarkCyan;
            trackBar1.BackColor = Color.DarkCyan;
            dataGridView1.BackgroundColor = Color.DarkCyan;
            pictureBox10.BackColor = Color.DarkCyan;

            pictureBox21.BackColor = Color.DarkCyan;
            button1.BackColor = Color.DarkCyan;
            button2.BackColor = Color.DarkCyan;
            button3.BackColor = Color.DarkCyan;
            button4.BackColor = Color.DarkCyan;
            BtnEkle.BackColor = Color.DarkCyan;
            BtnSil.BackColor = Color.DarkCyan;
            BtnKes.BackColor = Color.DarkCyan;
            BtnYurut.BackColor = Color.DarkCyan;
            BtnDevam.BackColor = Color.DarkCyan;
        }

        private void koyuGriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Indigo;
            panel10.BackColor = Color.DarkSlateBlue;
            panel12.BackColor = Color.DarkSlateBlue;
            panel1.BackColor = Color.DarkSlateBlue;
            panel14.BackColor = Color.DarkSlateBlue;
            groupBox2.BackColor = Color.DarkSlateBlue;
            panel13.BackColor = Color.DarkSlateBlue;
           // pictureBox10.BackColor = Color.DarkSlateBlue;
            pictureBox11.BackColor = Color.Indigo;
            pictureBox12.BackColor = Color.Indigo;
            pictureBox13.BackColor = Color.Indigo;
            dataGridView1.BackgroundColor = Color.Indigo;
            
            trackBar1.BackColor = Color.Indigo;
            panel2.BackColor = Color.Indigo;
            panel3.BackColor = Color.Indigo;
            panel4.BackColor = Color.Indigo;
            panel5.BackColor = Color.Indigo;
            panel6.BackColor = Color.Indigo;
            panel7.BackColor = Color.Indigo;
            panel8.BackColor = Color.Indigo;
            panel9.BackColor = Color.Indigo;
           // panel11.BackColor = Color.DarkSlateBlue;
            pictureBox1.BackColor = Color.Indigo;
            button7.BackColor = Color.Indigo;
           
            pictureBox21.BackColor = Color.Indigo;
            button1.BackColor = Color.Indigo;
            button2.BackColor = Color.Indigo;
            button3.BackColor = Color.Indigo;
            button4.BackColor = Color.Indigo;
            BtnEkle.BackColor = Color.Indigo;
            BtnSil.BackColor = Color.Indigo;
            BtnYurut.BackColor = Color.Indigo;
            BtnKes.BackColor = Color.Indigo;
            BtnDevam.BackColor = Color.Indigo;
            pictureBox10.BackColor = Color.Indigo;

            
        }

        private void açıkBeyazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            panel10.BackColor = Color.LightGreen;
            panel12.BackColor = Color.LightGreen;
            panel1.BackColor = Color.LightBlue;
            panel14.BackColor = Color.YellowGreen;
            panel13.BackColor = Color.Red;

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            file.ShowDialog();  // openfiledialog ekranını açıyoruz.
            string DosyaYolu = file.FileName;
            TxtDosyaco.Text = DosyaYolu;
          


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bgl.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_Ses (SesAd,SesFrekans,Dosyayolu) values (@p1,@p2,@p3)", bgl);//Ses ekleme
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtHz.Text);
                komut.Parameters.AddWithValue("@p3", TxtDosyaco.Text);
                komut.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("Ses Eklenmiştir Listede Görebilirsiniz", "Command Succesfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Başarısız. Lütfen Uyumlu karakterler kullanın.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("delete  from Tbl_Ses where ID=@p1", bgl);//silme
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Başarı İle Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            bgl.Close();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

           txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
           txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtHz.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtDosyaco.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            //seçilen datagridi çekme,silme işlemi için yaptım
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmHakkımızda fr = new FrmHakkımızda();
            fr.Show();
          
            
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        public void DatagridviewSetting(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            
            
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                
                if (this.BackColor == Color.DarkCyan)
                {
                    renk.BackColor = Color.DarkCyan;
                    dataGridView1.Rows[i].DefaultCellStyle = renk;
                }
                if (this.BackColor == Color.Indigo)
                {
                    renk.BackColor = Color.DarkSlateBlue;
                    dataGridView1.Rows[i].DefaultCellStyle = renk;
                }
            }
            
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            panel2.BackColor = Color.White;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel2.BackColor = Color.DarkCyan;
            }
            else if(this.BackColor == Color.Indigo)
            {
                panel2.BackColor = Color.Indigo;
            }
            
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            panel3.BackColor = Color.White;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel3.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel3.BackColor = Color.Indigo;
            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            panel4.BackColor = Color.White;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel4.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel4.BackColor = Color.Indigo;
            }
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            panel5.BackColor = Color.White;

           
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel5.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel5.BackColor = Color.Indigo;
            }
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.White;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel6.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel6.BackColor = Color.Indigo;
            }
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            panel7.BackColor = Color.White;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel7.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel7.BackColor = Color.Indigo;
            }
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            panel8.BackColor = Color.White;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel8.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel8.BackColor = Color.Indigo;
            }
        }

        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            panel9.BackColor = Color.White;
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                panel9.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                panel9.BackColor = Color.Indigo;
            }
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox11.BackColor = Color.White;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                pictureBox11.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                pictureBox11.BackColor = Color.Indigo;
            }
        }

        private void pictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox12.BackColor = Color.White;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                pictureBox12.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                pictureBox12.BackColor = Color.Indigo;
            }
        }

       

        

        

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            BtnEkle.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                BtnEkle.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                BtnEkle.BackColor = Color.Indigo;
            }
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            BtnSil.BackColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                BtnSil.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                BtnSil.BackColor = Color.Indigo;
            }
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                button4.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                button4.BackColor = Color.Indigo;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                button1.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                button1.BackColor = Color.Indigo;
            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                button2.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                button2.BackColor = Color.Indigo;
            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                button3.BackColor = Color.DarkCyan;
            }
            else if (this.BackColor == Color.Indigo)
            {
                button3.BackColor = Color.Indigo;
            }
        }

        private void pictureBox21_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox21.BackColor = Color.IndianRed;
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                pictureBox21.BackColor = Color.Teal;
            }
            else if (this.BackColor == Color.Indigo)
            {
                pictureBox21.BackColor = Color.Indigo;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume+50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDeney dy = new FormDeney();
            dy.Show();
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                button7.BackColor = Color.Teal;
            }
            else if (this.BackColor == Color.Indigo)
            {
                button7.BackColor = Color.Indigo;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSesOdası fs = new FrmSesOdası();
            fs.Show();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BtnYurut_MouseMove(object sender, MouseEventArgs e)
        {
            BtnYurut.BackColor = Color.White;
        }

        private void BtnYurut_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                BtnYurut.BackColor = Color.Teal;
            }
            else if (this.BackColor == Color.Indigo)
            {
                BtnYurut.BackColor = Color.Indigo;
            }
        }

        private void BtnKes_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKes.BackColor = Color.White;
        }

        private void BtnKes_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                BtnKes.BackColor = Color.Teal;
            }
            else if (this.BackColor == Color.Indigo)
            {
                BtnKes.BackColor = Color.Indigo;
            }
        }

        private void BtnYurut_Click(object sender, EventArgs e)
        {
            string oynat = TxtDosyaco.Text;
            axWindowsMediaPlayer1.URL = oynat;
            axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        private void BtnKes_Click(object sender, EventArgs e)
        {

           
            
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void BtnDevam_MouseMove(object sender, MouseEventArgs e)
        {
            BtnDevam.BackColor = Color.White;
        }

        private void BtnDevam_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                BtnDevam.BackColor = Color.Teal;
            }
            else if (this.BackColor == Color.Indigo)
            {
                BtnDevam.BackColor = Color.Indigo;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume-50;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 0;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 75;
        }

        
        private void txtfrekans_TextChanged(object sender, EventArgs e)
        {
            try
            {

                trackBar1.Value = int.Parse(txtfrekans.Text);
            }
            catch
            {
                txtfrekans.Text = "";
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap1 != null)
            {
                pictureBox1.Image = bitmap1;
                bitmap1.RotateFlip(RotateFlipType.Rotate180FlipY);
               
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             if(bitmap1 != null)
            {
                pictureBox1.Image = bitmap1;
                bitmap1.RotateFlip(RotateFlipType.Rotate270FlipX);



            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar2.Value;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deneylerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDeney fr = new FormDeney();
            fr.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHakkımızda hr = new FrmHakkımızda();
            hr.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            txtfrekans.Text = trackBar1.Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.DarkCyan)
            {
                pictureBox10.BackColor = Color.Teal;
            }
            else if (this.BackColor == Color.Indigo)
            {
                pictureBox10.BackColor = Color.Indigo;
            }
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.White;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
