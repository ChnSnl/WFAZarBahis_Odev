using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAZarBahis_Odev
{
    //Form basladıgında 2. oyuncunun bahis yatırma secenegi kapalı olsun...
    //Aynı zamanda zar atma butonları da kapalı olsun...
    //1. oyuncu bahis yatırdıgında birinci oyuncunun bahis yatırma butonu deaktif olsun
    //2. oyuncunun bahis yatırma butonu acılsın...(bahisler ancak 100 lira yatırılabilsin...)
    //İkinci oyuncu da bahsi yatırdıktan sonra onun da bahis yatırma butonu deaktif olsun ve 1. oyuncunun zar atma butonu acılsın...
    //1. Oyuncu zar attıktan sonra zar sonucunu ilgili label'ina yazdırın sonra 1. oyuncunun zar atma butonu kapansın ve 2. oyuncunun zar atma butonu acılsın...
    //2. oyuncu zar atsın ve onun da sonucunu yazdırın ve kimin kazandıgını belirleyin...
    //Oyuncular berabere zar atarsa o ilgili zar atısı tekrarlansın...
    //Yani 2. oyuncunun zar atısını kapatın 1. oyuncununkini acın sonra 2. oyuncununkini acarsınız...
    //Birisi kazanırsa tekrar 1. oyuncunun bahis butonu acılsın diger butonlar kapansın ve bahis sisteminden oyun yeniden baslasın...
    //Bir oyuncu bahis icin 100 lira yatıramayacak konuma geldigi an oyun diger oyuncunun zaferiyle sonlansın... 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        Random zar = new Random();
        int bakiye1, bakiye2, bahis;
       
        private void btnBahis1_Click(object sender, EventArgs e)
        {
            bakiye1 -= bahis;
            lblBakiye1.Text = bakiye1.ToString();
            btnBahis1.Enabled = false;
            btnBahis2.Enabled = true;
                           
        }

        private void btnBahis2_Click(object sender, EventArgs e)
        {
            bakiye2 -= bahis;
            lblBakiye2.Text = bakiye2.ToString();
            btnBahis2.Enabled = false;
            btnZar1.Enabled = true;
         
        }
        private void btnZar1_Click(object sender, EventArgs e)
        {
            //lblZar1.Text = Convert.ToString(zar.Next(1, 10));
            lblZar1.Text = zar.Next(1, 7).ToString();
            btnZar2.Enabled = true;
            btnZar1.Enabled = false;
        }

        private void btnZar2_Click(object sender, EventArgs e)
        {
            lblZar2.Text = zar.Next(1, 7).ToString();
            btnZar2.Enabled = false;

            if (lblZar1.Text == lblZar2.Text)
            {
                lblSonuc.Text = "Kazanan çıkmadı.\nZar atışı tekrarlansın.";
                btnZar1.Enabled=true;
            }
            else if (Convert.ToInt32(lblZar1.Text) > Convert.ToInt32(lblZar2.Text))
            {
                lblSonuc.Text = "1.Kumarbaz Kazandı.\nBahisler açılmıştır.";
                lblBakiye1.Text = (bakiye1 += 200).ToString();
                btnBahis1.Enabled = true;
                
            }
            else if (Convert.ToInt32(lblZar1.Text) < Convert.ToInt32(lblZar2.Text)) 
            {
                lblSonuc.Text = "2.Kumarbaz Kazandı.\nBahisler açılmıştır.";
                lblBakiye2.Text = (bakiye2 += 200).ToString();
                btnBahis1.Enabled = true;
            }


            if(Convert.ToInt32(lblBakiye1.Text) <= 0 || Convert.ToInt32(lblBakiye2.Text) <= 0) 
            { 
                btnBahis1.Enabled=false;
                MessageBox.Show("Bakiye yetersiz.");
                Application.Exit();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBahis2.Enabled = false;
            btnZar2.Enabled = false;
            btnZar1.Enabled = false;
            bakiye1 = 300; bakiye2 = 300; bahis = 100;
            lblBakiye1.Text = Convert.ToString(bakiye1);
            lblBakiye2.Text = Convert.ToString(bakiye2);


            timer1.Start();

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
