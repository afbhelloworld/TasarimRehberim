using DevExpress.Utils.CommonDialogs;
using Nesne_Prog_Proje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje.Formlar
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            LblAktifPlan.Text = db.TblPlanlarim.Where(x => x.Durum == true).Count().ToString();
            LblPasifPlan.Text = db.TblPlanlarim.Where(x => x.Durum == false).Count().ToString();

            chartControl1.Series["Series"].Points.AddPoint("Aktif Planlar",db.TblPlanlarim.Where(x => x.Durum == true).Count());
            chartControl1.Series["Series"].Points.AddPoint("Pasif Planlar", db.TblPlanlarim.Where(x => x.Durum == false).Count());

            var degerler = (from x in db.TblCizim
                            select new
                            {
                                x.ID,
                               x.Resim
                            }).ToList();
            dataGridView1.DataSource = degerler;

            //pictureBox1.ImageLocation = "C:\\Users\\PC\\Desktop\\My Drawings\\Cizcad\\dwg1.jpg";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
