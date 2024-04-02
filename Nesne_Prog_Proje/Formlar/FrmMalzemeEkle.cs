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
using Nesne_Prog_Proje.Entity;
using DevExpress.XtraEditors;

namespace Nesne_Prog_Proje.Formlar
{
    public partial class FrmMalzemeEkle : Form
    {
        public FrmMalzemeEkle()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        private void FrmMalzemeEkle_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtResim.Text = openFileDialog1.FileName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TblMalzemeler t = new TblMalzemeler();
            t.MalzemeAd = txtAd.Text;
            t.MalzemeTur = txtTur.Text;
            t.Yogunluk = int.Parse(txtYogunluk.Text);
            t.Aciklama = txtAciklama.Text;
            t.MalzemeResim = txtResim.Text;
            db.TblMalzemeler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni malzeme kaydı başarılı şekilde gerçekleştirildi",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        // crud -> create read uptade delete
        void Listele()
        {
            
            var degerler = (from x in db.TblMalzemeler
                            select new
                            {
                                x.ID,
                                x.MalzemeAd,
                                x.MalzemeTur,
                                x.Yogunluk,
                                x.Aciklama
                            }).ToList();
            gridControl1.DataSource = degerler;
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtId.Text);
            var deger = db.TblMalzemeler.Find(x);
            deger.MalzemeAd = txtAd.Text;
            deger.MalzemeTur = txtTur.Text;
            deger.Yogunluk = int.Parse(txtYogunluk.Text);
            deger.Aciklama = txtAciklama.Text;
            deger.MalzemeResim = txtResim.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Malzeme başarılı bir şekilde güncellendi...", "Bilgi"
             , MessageBoxButtons.OK, MessageBoxIcon.Question);
            Listele();

        }

        private void gridControl1_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
                txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtAd.Text = gridView1.GetFocusedRowCellValue("MalzemeAd").ToString();
                txtTur.Text = gridView1.GetFocusedRowCellValue("MalzemeTur").ToString();
                txtYogunluk.Text = gridView1.GetFocusedRowCellValue("Yogunluk").ToString();
                txtAciklama.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
                
        }

        private void txtResim_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
