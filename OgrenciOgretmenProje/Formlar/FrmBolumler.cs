using OgrenciOgretmenProje.Entity;
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

namespace OgrenciOgretmenProje.Formlar
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtBolumAd.Text == "")
            {
                errorProvider1.SetError(TxtBolumAd, "Bölüm adı boş geçilemez");
                return;
            }

            try
            {
                baglanti.Open();
                TblBolum t = new TblBolum();
                t.BolumAd = TxtBolumAd.Text;
                db.TblBolum.Add(t);
                db.SaveChanges();
                baglanti.Close();

                MessageBox.Show("Bölüm başarıyla eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata mesajı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmBolumler_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
