using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciOgretmenProje.Entity;
namespace OgrenciOgretmenProje.Formlar
{
    public partial class FrmBolumListesi : Form
    {
        public FrmBolumListesi()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmBolumListesi_Load(object sender, EventArgs e)
        {
             var degerler = from x in db.TblBolum
                             select new
                             {
                                 x.BolumId,
                                 x.BolumAd
                             };
            dataGridView1.DataSource = degerler.ToList();
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
