using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje.Formlar
{
    public partial class FrmHesapMakinesi : Form
    {
        public FrmHesapMakinesi()
        {
            InitializeComponent();
        }

        private void FrmHesapMakinesi_Load(object sender, EventArgs e)
        {
            string sayilar = "0123456789";
            foreach (Control abc in this.Controls)
            {
                if (abc is Button)
                {
                    if (sayilar.IndexOf(abc.Text) != -1)
                        abc.Font = new Font("Arial", 21);
                    else
                    {
                        abc.Font = new Font("Arial", 17);
                        (abc as Button).FlatStyle = FlatStyle.Flat;
                        (abc as Button).FlatAppearance.BorderSize = 0;
                        (abc as Button).BackColor = Color.FromName("ControlLight");
                    }

                }
            }
        }

        Boolean sayisec = false;
        Boolean islemsec = false;
        Boolean esittir = false;
        int sayi1 = 0;
        int sayi2 = 0;
        string islem;

        private void button7_Click(object sender, EventArgs e)
        {

            Button abc = (Button)sender;

            if (textBox1.Text == "0" || islemsec)
                textBox1.Text = abc.Text;
            else
                textBox1.Text += abc.Text;

            sayisec = true;
            islemsec = false;

            label1.Text = "sayi secili:" + sayisec + Environment.NewLine +
                           "sayi1: " + sayi1.ToString() + Environment.NewLine +
                           "sayi2: " + sayi2.ToString() + Environment.NewLine +
                            "islem: " + islem + Environment.NewLine +
                           "islemsecili : " + islemsec;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button abc = (Button)sender;

            if ("+-*/".IndexOf(abc.Text) != -1)
            {
                islem = abc.Text;
                islemsec = true;
            }
            int sonuc = 0;




            if ((sayisec && sayi1 == 0) || esittir)
            {
                sayi1 = Convert.ToInt32(textBox1.Text);
                textBox2.Text = sayi1 + " " + islem;
            }
            else if (sayisec && sayi2 == 0)
            {
                sayi2 = Convert.ToInt32(textBox1.Text);
                textBox2.Text = textBox2.Text + sayi2.ToString() + " " + islem;

                switch (islem)
                {

                    case "+":
                        sonuc = sayi1 + sayi2;
                        break;
                    case "-":
                        sonuc = sayi1 - sayi2;
                        break;
                    case "*":
                        sonuc = sayi1 * sayi2;
                        break;
                    case "/":
                        sonuc = sayi1 / sayi2;
                        break;
                }

                textBox1.Text = (sonuc).ToString();
                sayi1 = sonuc;
                sayi2 = 0;

            }

            if (islemsec && textBox2.Text != "")
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 2) + " " + islem;
            }





            sayisec = false;
            esittir = false;


            label1.Text = "sayi secili:" + sayisec + Environment.NewLine +
                           "sayi1: " + sayi1.ToString() + Environment.NewLine +
                           "sayi2: " + sayi2.ToString() + Environment.NewLine +
                           "islem: " + islem + Environment.NewLine +
                           "islemsecili : " + islemsec;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int sonuc = 0;

            if (islem != "" && sayisec)
                sayi2 = Convert.ToInt32(textBox1.Text);
            else
                sayi2 = sayi1;

            switch (islem)
            {
                case "+":
                    sonuc = sayi1 + sayi2;
                    break;
                case "-":
                    sonuc = sayi1 - sayi2;
                    break;
                case "*":
                    sonuc = sayi1 * sayi2;
                    break;
                case "/":
                    sonuc = sayi1 / sayi2;
                    break;
            }

            textBox1.Text = (sonuc).ToString();
            sayi1 = sonuc;
            sayi2 = 0;
            //islemsec = true;

            esittir = true;

            label1.Text = "sayi secili:" + sayisec + Environment.NewLine +
                           "sayi1: " + sayi1.ToString() + Environment.NewLine +
                           "sayi2: " + sayi2.ToString() + Environment.NewLine +
                           "islem: " + islem + Environment.NewLine +
                           "islemsecili : " + islemsec;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            sayi1 = 0;
            sayi2 = 0;
            esittir = false;
            sayisec = false;
            islemsec = false;


            textBox1.Text = "0";
            textBox2.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
                textBox1.Text = "0";
            else
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
