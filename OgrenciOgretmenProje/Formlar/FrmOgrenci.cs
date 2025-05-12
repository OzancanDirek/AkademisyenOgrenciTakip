using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciOgretmenProje.Entity;
using OgrenciOgretmenProje.Formlar;
namespace OgrenciOgretmenProje.Formlar
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");

        public void List()
        {
            var degerler = from x in db.TblOgrenci
                          
                          select new
                          {
                              x.OgrID,
                              x.OgrAd,
                              x.OgrSoyad,
                              x.OgrNumara,
                              x.OgrSifre,
                              x.OgrMail,
                              x.OgrResim,
                              x.OgrBolum,
                              BolumAd = x.TblBolum.BolumAd,
                              x.OgrDurum
                          };

            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum ==true).ToList();

            
        }
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1030,600);
            List();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;

            ComboBoxVeriYukle();
        }

        private void ComboBoxVeriYukle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TblBolum", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            List();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TblBolum", baglanti);
            //SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSifreTekrar.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";

            if (dataGridView1.Rows[e.RowIndex].Cells[6].Value != null)
            {
                TxtResimYol.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            else
            {
                TxtResimYol.Text = "";
            }

            int bolumId = (int)dataGridView1.Rows[e.RowIndex].Cells[7].Value; // ID'si alınıyor
            comboBox1.SelectedValue = bolumId;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtID.Text);
                var x = db.TblOgrenci.Find(id);
                x.OgrDurum = false;
                db.SaveChanges();
                MessageBox.Show("Öğrenci başarıyla sistemden silindi,Pasif öğrenciler listesi üzerinden erişebilirsiniz" +
                    "", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Mesajı: {ex.Message}","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtID.Text);
                var x = db.TblOgrenci.Find(id);
                x.OgrAd = TxtAd.Text;
                x.OgrSoyad = TxtSoyad.Text;
                x.OgrNumara = TxtNumara.Text;
                x.OgrMail = TxtMail.Text;
                x.OgrResim = TxtResimYol.Text;
                x.OgrSifre = TxtSifre.Text;
                x.TblBolum = db.TblBolum.Find(int.Parse(comboBox1.SelectedValue.ToString()));
                db.SaveChanges();
                MessageBox.Show("Öğrenci bilgileri başarıyla güncellendi" +
                    "", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Mesajı: {ex.Message}" +
                    "", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResimYol.Text = openFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
