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
    public partial class FrmYeniDers : Form
    {
        public FrmYeniDers()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TblDersler t = new TblDersler();
                t.DersAd = TxtDersAd.Text;
                db.TblDersler.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yeni ders başarıyla kaydedilmiştir.", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata mesajı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
