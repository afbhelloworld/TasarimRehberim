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
    public partial class FrmMalzemeler : Form
    {
        public FrmMalzemeler()
        {
            InitializeComponent();
        }

        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        private void FrmMalzemeler_Load(object sender, EventArgs e)
        {
            
            var degerler = (from x in db.TblMalzemeler
                            select new
                            {
                                x.ID,
                                x.MalzemeAd,
                                x.MalzemeTur,
                                x.Yogunluk,
                                x.Aciklama,
                                x.MalzemeResim
                            }).ToList();
            dataGridView1.DataSource = degerler;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
             textEdit1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }
    }
}
