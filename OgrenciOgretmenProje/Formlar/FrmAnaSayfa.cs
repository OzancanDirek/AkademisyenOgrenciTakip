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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void panel1_Click(object sender, EventArgs e)
        {
            FrmBolumListesi bolumler = new FrmBolumListesi();
            bolumler.Show();
        }

        private void PnlBolumListesi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PnlYeniBolum_Click(object sender, EventArgs e)
        {
            FrmBolumler YeniBolum = new FrmBolumler();
            YeniBolum.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            FrmNotlar notlar = new FrmNotlar();
            notlar.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            FrmOgrenci ogrenciForm = new FrmOgrenci();
            ogrenciForm.Show();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            FrmOgrenciKayıt ogrenciKayit = new FrmOgrenciKayıt();
            ogrenciKayit.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            FrmDersListesi dersListesi = new FrmDersListesi();
            dersListesi.Show();
        }

        private void PnlCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PnlYardım_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu projede akademisyen için kullanıcı adı: 00000 olup sifre: 000 seklindedir" +
                "Akademisyen panelinden öğrenci, ders, bolum, sınav notları gibi işlemlerin tamamı gerçekleştirilebilir" +
                "Sisteme giris yapan ogrenci kendine ait notları görüntüleyebilir" +
                "","Yardım Penceresi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void PnlYeniDers_Click(object sender, EventArgs e)
        {
            FrmYeniDers yeniDers = new FrmYeniDers();
            yeniDers.Show();
        }
    }
}
