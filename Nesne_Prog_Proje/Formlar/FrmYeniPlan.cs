using DevExpress.XtraEditors;
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
    public partial class FrmYeniPlan : Form
    {
        public FrmYeniPlan()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        void Listele()
        {
            var degerler = from x in db.TblPlanlarim
                           select new
                           {
                               x.ID,
                               x.PlanAd,
                               x.PlanAciklama,
                               x.PlanTur,
                               x.Durum,
                               x.TarihStart,
                               x.Saat,
                               x.TarihFinish
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblPlanlarim t = new TblPlanlarim();
            t.PlanAd = TxtPlanAd.Text;
            t.PlanAciklama = TxtAciklama.Text;
            t.PlanTur = TxtTur.Text;
            t.Durum = true;
            t.TarihStart = DateTime.Parse(TxtStartTarih.Text);
            t.Saat = TxtTarih.Text;
            t.TarihFinish = DateTime.Parse(TxtEndTarih.Text);
            db.TblPlanlarim.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Plan başarılı bir şekilde eklendi", "Bilgi"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtId.Text);
            var deger = db.TblPlanlarim.Find(x);
            deger.PlanAd = TxtPlanAd.Text;
            deger.PlanAciklama = TxtAciklama.Text;
            deger.PlanTur = TxtTur.Text;
            deger.Durum = true;
            deger.TarihStart = DateTime.Parse(TxtStartTarih.Text); 
            deger.Saat = TxtTarih.Text;
            deger.TarihFinish = DateTime.Parse(TxtEndTarih.Text);
            db.SaveChanges();
            XtraMessageBox.Show("Plan başarılı bir şekilde güncellendi...", "Bilgi"
             , MessageBoxButtons.OK, MessageBoxIcon.Question);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtPlanAd.Text = gridView1.GetFocusedRowCellValue("PlanAd").ToString();
            TxtAciklama.Text = gridView1.GetFocusedRowCellValue("PlanAciklama").ToString();
            TxtTur.Text = gridView1.GetFocusedRowCellValue("PlanTur").ToString();
            TxtStartTarih.Text = gridView1.GetFocusedRowCellValue("TarihStart").ToString();
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("Saat").ToString();
            TxtEndTarih.Text = gridView1.GetFocusedRowCellValue("TarihFinish").ToString();
        }

        private void BtnPasifYap_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtId.Text);
            var deger = db.TblPlanlarim.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Plan pasif hale getirildi...", "Bilgi"
             , MessageBoxButtons.OK, MessageBoxIcon.Question);
            Listele();
        }

        private void FrmYeniPlan_Load(object sender, EventArgs e)
        {

        }
    }
}
