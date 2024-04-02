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
    public partial class FrmPlanListesi : Form
    {
        public FrmPlanListesi()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPlanListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblPlanlarim.Where(x => x.Durum == true)
                                       select new
                                       {
                                           x.ID,
                                           x.PlanAd,
                                           x.PlanAciklama,
                                           x.PlanTur,                                    
                                           x.TarihStart,
                                           x.Saat,
                                           x.TarihFinish

                                       }).ToList();

            gridControl2.DataSource = (from x in db.TblPlanlarim.Where(x => x.Durum == false)
                                       select new
                                       {
                                           x.ID,
                                           x.PlanAd,
                                           x.PlanAciklama,
                                           x.PlanTur,                                          
                                           x.TarihStart,
                                           x.Saat,
                                           x.TarihFinish

                                       }).ToList();
        }
    }
}
