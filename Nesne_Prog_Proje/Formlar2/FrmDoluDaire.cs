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

namespace Nesne_Prog_Proje.Formlar2
{
    public partial class FrmDoluDaire : Form
    {
        public FrmDoluDaire()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        metrajHesapla daire = new metrajHesapla();
        double bilgi;
        double toplam1 = 0;
        private void BtnKareHesapla_Click(object sender, EventArgs e)
        {
            daire.x = Convert.ToInt32(txtyaricap.Text);
            daire.y = Convert.ToInt32(txtUzunluk.Text);
            daire.adet = Convert.ToInt32(txtAdet.Text);
            daire.d = Convert.ToInt32(lookUpEdit1.Text);
            daire.toplam = 0;
            daire.doluDaire();

            bilgi = daire.doluDaire();
            textEdit5.Text = Convert.ToString(daire.doluDaire());

        }

        private void FrmDoluDaire_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblMalzemeler
                            select new
                            {
                                x.ID,
                                x.MalzemeAd,
                                x.Yogunluk
                            }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Yogunluk";
            lookUpEdit1.Properties.DataSource = degerler;
        }

        private void BtnKareTemizle_Click(object sender, EventArgs e)
        {
            txtyaricap.Clear();
            txtUzunluk.Clear();
            txtAdet.Clear();
            lookUpEdit1.Clear();
            textEdit5.Clear();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(bilgi);
            toplam1 += bilgi / 1000;

            toplamKg.Text = toplam1.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            toplam1 = 0;
            toplamKg.Text = toplam1.ToString();
        }
    }
}
