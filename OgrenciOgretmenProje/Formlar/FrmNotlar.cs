using OgrenciOgretmenProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOgretmenProje.Formlar
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                TblNotlar t = new TblNotlar();
                t.Sinav1 = byte.Parse(TxtSınav1.Text);
                t.Sinav2 = byte.Parse(TxtSınav2.Text);
                t.Sinav3 = byte.Parse(TxtSınav3.Text);
                t.Proje = byte.Parse(TxtProje.Text);
                t.Quiz1 = byte.Parse(TxtQuiz1.Text);
                t.Quiz2 = byte.Parse(TxtQuiz2.Text);
                t.Ders = int.Parse(comboBox1.SelectedValue.ToString());
                t.Ogrenci = int.Parse(TxtOgrenci.Text);
                db.TblNotlar.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ogrenci not bilgisi için sisteme kayıt edildi", "Bilgi");

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata Mesajı: {ex.Message}" +
                                   "", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1030, 620);
            comboBox1.DisplayMember = "DersAd";
            comboBox1.ValueMember = "DersID";
            comboBox1.DataSource = db.TblDersler.ToList();
            comboBox2.DisplayMember = "DersAd";
            comboBox2.ValueMember = "DersID";
            comboBox2.DataSource = db.TblDersler.ToList();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, q1, q2, proje;
            double ortalama;

            s1 = Convert.ToByte(TxtSınav1.Text);
            s2 = byte.Parse(TxtSınav2.Text);
            s3 = byte.Parse(TxtSınav3.Text);
            q1 = byte.Parse(TxtQuiz1.Text);
            q2 = byte.Parse(TxtQuiz2.Text);
            proje = byte.Parse(TxtProje.Text);
            ortalama = (s1 + s2 + s3 + q1 + q2 + proje) / 6;
            TxtOrtalama.Text = ortalama.ToString();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NotlarList1();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            try
            {
                var degerler = from x in db.TblNotlar
                               select new
                               {
                                   x.NotID,
                                   x.TblDersler.DersAd,
                                   Oğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                                   x.Sinav1,
                                   x.Sinav2,
                                   x.Sinav3,
                                   x.Quiz1,
                                   x.Quiz2,
                                   x.Proje,
                                   x.Ortalama,
                                   x.Ders,
                               };
                int ders = int.Parse(comboBox2.SelectedValue.ToString());
                dataGridView1.DataSource = degerler.Where(y => y.Ders == ders).ToList();
                dataGridView1.Columns["Ders"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata Mesajı: {ex.Message}" +
                                                   "", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string no = maskedTextBox1.Text;
                var deger = db.TblOgrenci.Where(x => x.OgrNumara == no).Select(y => y.OgrID).FirstOrDefault();
                //TxtID.Text = deger.ToString();
                var notlar = from x in db.TblNotlar
                             select new
                             {
                                 x.NotID,
                                 x.TblDersler.DersAd,
                                 Oğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                                 x.Sinav1,
                                 x.Sinav2,
                                 x.Sinav3,
                                 x.Quiz1,
                                 x.Quiz2,
                                 x.Proje,
                                 x.Ortalama,
                                 x.Ders,
                                 x.Ogrenci
                             };
                dataGridView1.DataSource = notlar.Where(x => x.Ogrenci == deger).ToList();
                dataGridView1.Columns["Ders"].Visible = false;
                dataGridView1.Columns["Ogrenci"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata Mesajı: {ex.Message}" +
                                                  "", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtID.Text);
                var x = db.TblNotlar.Find(id);
                x.Sinav1 = byte.Parse(TxtSınav1.Text);
                x.Sinav2 = byte.Parse(TxtSınav2.Text);
                x.Sinav3 = byte.Parse(TxtSınav3.Text);
                x.Quiz1 = byte.Parse(TxtQuiz1.Text);
                x.Quiz2 = byte.Parse(TxtQuiz2.Text);
                x.Proje = byte.Parse(TxtProje.Text);
                x.Ortalama = byte.Parse(TxtOrtalama.Text);

                db.SaveChanges();
                MessageBox.Show("Öğrenci notları başarıyla güncellendi" +
                    "", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Mesajı: {ex.Message}" +
                    "", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                TxtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                TxtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[9].Value != null)
                {
                    TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                }
                else
                {
                    TxtOrtalama.Text = " ";
                }
            }
            catch (Exception ex)    
            {

                MessageBox.Show($"Hata Mesajı: {ex.Message}" +
                    "", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             //comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();






        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
