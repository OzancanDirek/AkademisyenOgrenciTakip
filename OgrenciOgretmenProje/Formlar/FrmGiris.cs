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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 300);

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            if (TxtNumara.Text == "00000" && TxtSifre.Text == "000")
            {
                FrmAnaSayfa anasayfa = new FrmAnaSayfa();
                anasayfa.Show();
                this.Hide();
                return;
            }

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from TblOgrenci where OgrNumara = @p1 and OgrSifre = @p2", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtNumara.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    FrmOgrenciPanel frm = new FrmOgrenciPanel();
                    frm.numara = TxtNumara.Text;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Numaranız veya Şifreniz Hatalıdır", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Mesajı: {ex.Message}", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
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
