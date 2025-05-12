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
using OgrenciOgretmenProje.Entity;
namespace OgrenciOgretmenProje.Formlar
{
    public partial class FrmOgrenciKayıt : Form
    {
        public FrmOgrenciKayıt()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        private void FrmOgrenciKayıt_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TblBolum",baglanti);
            //SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtSifre.Text == TxtSifreTekrar.Text)
            {

            
            //textBox3.Text = comboBox1.SelectedValue.ToString();
            try
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAd = TxtAd.Text;
                t.OgrSoyad = TxtSoyad.Text;
                t.OgrNumara = TxtNumara.Text;
                t.OgrMail = TxtMail.Text;
                t.OgrResim = TxtResim.Text;
                t.OgrSifre = TxtSifre.Text;
                t.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
                db.TblOgrenci.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ogrenci bilgileri sisteme başarılı bir şekilde kaydedildi", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                
            }

         
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          }
            else
            {
                MessageBox.Show("Girdiğiniz sifreler eşleşmemektedir.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text = openFileDialog1.FileName; //file name 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
