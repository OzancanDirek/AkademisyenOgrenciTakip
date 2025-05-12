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
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();

        public string numara;
        int ogrenciid;
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1040, 444);

            TxtNumara.Text = numara;
            TxtAd.Text = db.TblOgrenci.Where(x=> x.OgrNumara == numara).Select(y => y.OgrAd).FirstOrDefault();
            TxtSoyad.Text = db.TblOgrenci.Where(x=> x.OgrNumara == numara).Select(y => y.OgrSoyad).FirstOrDefault();
            TxtMail.Text = db.TblOgrenci.Where(x=> x.OgrNumara == numara).Select(y => y.OgrMail).FirstOrDefault();
            TxtSifre.Text = db.TblOgrenci.Where(x=> x.OgrNumara == numara).Select(y => y.OgrSifre).FirstOrDefault();
            TxtBolum.Text = db.TblOgrenci.Where(x=> x.OgrNumara == numara).Select(y => y.OgrBolum).FirstOrDefault().ToString();

            ogrenciid = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrID).FirstOrDefault();

            var sinavnotlari = (from x in db.TblNotlar
                               select new
                               {
                                   x.TblDersler.DersAd,
                                   x.Sinav1,
                                   x.Sinav2,
                                   x.Sinav3,
                                   x.Quiz1,
                                   x.Quiz2,
                                   x.Ortalama,
                                   x.Ogrenci
                               }).Where(y=> y.Ogrenci == ogrenciid).ToList();
            dataGridView1.DataSource = sinavnotlari;

            label9.Text = db.TblOgrenci.Where(x=> x.OgrNumara == numara).Select(y=> y.OgrID).FirstOrDefault().ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                
              if(TxtSifre == TxtSifreTekrar)
                {
                    var deger = db.TblOgrenci.Find(ogrenciid);
                    deger.OgrSifre = TxtYeniSifre.Text;
                    db.SaveChanges();
                    MessageBox.Show("Şifre başarıyla güncellendi...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Hata Oluştu","Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
