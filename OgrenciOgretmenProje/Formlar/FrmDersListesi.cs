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
    public partial class FrmDersListesi : Form
    {
        public FrmDersListesi()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmDersListesi_Load(object sender, EventArgs e)
        {
            var dersListesi = from x in db.TblDersler
                              select new
                              {
                                  x.DersID,
                                  x.DersAd
                              };
            dataGridView1.DataSource = dersListesi.ToList();
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
