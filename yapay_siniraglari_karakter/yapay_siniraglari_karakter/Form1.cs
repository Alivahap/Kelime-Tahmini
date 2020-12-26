using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yapay_siniraglari_karakter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        //giriş matrislerimizin değerini alırız örnek giris[5].deger=1 gibi
        //ara katman, giriş katman ve çıkış katmanındaki sinirleri oluşturuyoruz.
        Giris_Sinir[] giris_sinir = new Giris_Sinir[35];


        Arakatman_Sinir[] ara_sinir = new Arakatman_Sinir[3];



        Cikis_Sinir[] cikis_sinir = new Cikis_Sinir[5];



        //katmalar arası hesaplamanın yapıldığı sınıf. Bu sınıfda sigmoid 
        //fonksiyonu sınucu oluşan degğerler hesaplanır. Bias eklenir. bag değerleri atanır.
        Katman_Hesaplamalari hesapla = new Katman_Hesaplamalari();

        private void Form1_Load(object sender, EventArgs e)
        {

           // matrislerimize 
            for (int i = 0; i < 35; i++)
            {
                giris_sinir[i] = new Giris_Sinir();
            }



            for (int i = 0; i < 3; i++)
            {
                ara_sinir[i] = new Arakatman_Sinir();
            }





            for (int i = 0; i < 5; i++)
            {
                cikis_sinir[i] = new Cikis_Sinir();
            }


           



            foreach (TextBox t in panel1.Controls)
            {
                t.Text = "0";
               
            }

        }

        public void ButtonKontrol()
        {
            foreach (TextBox t in panel1.Controls)
            {

                int a = Convert.ToInt32(t.Text);

                if (a < 0 || a > 1)
                {

                    MessageBox.Show("Lütfen 0 ile 1 arasında değer giriniz");
                }

            }

        }
      

      public void Tanımlama()
        {


        }


        private void button1_Click(object sender, EventArgs e)
        {
            


            int k = 0;
            foreach (TextBox t in panel1.Controls)
            {
                

                int a = Convert.ToInt32(t.Text);

                giris_sinir[k].deger = a;


                if (t.Text == "1")
                {
                    t.BackColor = Color.Red;
                }
                else
                {
                    t.BackColor = Color.White;
                }

                k++;
            }


            //
          ara_sinir= hesapla.Giris_ArakatmanEsikleme(ara_sinir, giris_sinir);

          //  label1.Text =ara_sinir[0].bag_x+"---"+ara_sinir[0].esik+"----"+ ara_sinir[0].cozum;


        cikis_sinir=  hesapla.Cikis_ArakatmanEsikleme(ara_sinir,cikis_sinir, giris_sinir);



            //buradan sonra öğrenme algoritmaları devreye girer

            //hata payı bulma ile öğretmedim. iterasyon ile öğrettim onun için algoritmaya 
            //en yakın harfi buluyor
            for (int i=0;i<300; i++) {

                    
                        ara_sinir = hesapla.Cikis_Arakatman_Ogrenme(ara_sinir);
                        giris_sinir = hesapla.Giris_Arakatman_Ogrenme(giris_sinir, ara_sinir);
                    

              
          


            }

            label1.Text = "A harfi =" + (cikis_sinir[0].esik) + "\n B harfi= " + ( cikis_sinir[1].esik) + " \n C harfi =" + (cikis_sinir[2].esik)

               + "\n D harfi=" + ( cikis_sinir[3].esik) + "\n E harfi=" + ( cikis_sinir[4].esik);




        }

        private void buttonRastgele_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            foreach (TextBox t in panel1.Controls)
            {

                int a = Convert.ToInt32(t.Text);

                t.Text =""+rn.Next(0, 2);
                if (t.Text == "1")
                {

                    t.BackColor = Color.Red;
                }
                else
                {
                    t.BackColor = Color.White;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in panel1.Controls)
            {               
                
                    t.BackColor = Color.White;
                t.Text = "0";               

            }
        }

    }
    }

