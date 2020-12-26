using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapay_siniraglari_karakter
{
    public class Katman_Hesaplamalari
    {
        //giris ile ara katman arasında bulunana sinir hücrelisinin, aldığı değer ile bag değeri çarpılıp bias değeri eklenerek
        //elde edilcek sonucu geri döndüren fonksiyon.
        // Çözüm değeri bulunduktan sonra sigmoid fonksiyonu ile eşik değeri bulunur
        public Arakatman_Sinir[] Giris_ArakatmanEsikleme(Arakatman_Sinir[] ara, Giris_Sinir [] giris)
        {
            //ara sinir hüçrelerinin çözüm  değeri bulunur. x ,y ve z düzlemindeki bağlar sırasıyla ara sinir hücrelerine eklenir.
            //sonra bias değerleri eklenir.ilk başta biat değeri diye bildiğim için değişkeni yanlışlıkla biat yazdım
            for(int i=0;i<35; i++)
            {
                ara[0].cozum += giris[i].deger * giris[i].bag_x;
                ara[1].cozum += giris[i].deger * giris[i].bag_y;
                ara[2].cozum += giris[i].deger * giris[i].bag_z;
            }
            ara[0].cozum += giris[0].biat;
            ara[1].cozum += giris[0].biat;
            ara[2].cozum += giris[0].biat;     
            //sigmoid fonk ile eşik değeri bulunur
            for(int i = 0; i < 3; i++) { 
            ara[i].esik = 1 /( 1 + Math.Pow(Math.E,ara[i].cozum));
            }
            return ara;
        }

        //harfe ve girilen matrise bakarak istenen harfe yakınlığı bulunur
        //ve eşik değeri ile çıkarılarak yeni eşik değeri bulunur
        public double EsikDegerBul(Giris_Sinir[] giris_matris,int[] harf)
        {
            double esik=0;
            for(int i = 0; i < 35; i++)
            {
                if (giris_matris[i].deger == harf[i])
                {
                    esik++;
                }
            }
            return (esik / 35);
        }





        //istenen harflerin ikili karşılığı
            public double[] EsikDegerAta(Giris_Sinir []giris_matris)
        {
            //a harfi
            int[] a = { 0,0,1,0,0,
                        0,1,0,1,0,
                        1,1,1,1,1,
                        1,0,0,0,1,
                        1,0,0,0,1,
                        1,0,0,0,1,
                        1,0,0,0,1

            };


            //b harfi
            int[] b = { 1,1,1,0,0,
                        1,0,0,1,0,
                        1,1,1,0,0,
                        1,1,1,0,0,
                        1,0,0,1,0,
                        1,0,1,0,0,
                        1,1,0,0,0
            };


            int[] c = { 0,0,1,1,1,
                        0,1,0,0,0,
                        1,0,0,0,0,
                        1,0,0,0,0,
                        1,0,0,0,0,
                        0,1,0,0,0,
                        0,0,1,1,1
            };

            int[] d = { 1,1,1,1,0,
                        1,0,0,0,1,
                        1,0,0,0,1,
                        1,0,0,0,1,
                        1,0,0,0,1,
                        1,0,0,0,1,
                        1,1,1,1,0
            };


            int[] e = { 1,1,1,1,1,
                        1,0,0,0,0,
                        1,0,0,0,0,
                        1,1,1,1,1,
                        1,0,0,0,0,
                        1,0,0,0,0,
                        1,1,1,1,1
            };

            //eşik değeri bulunan fonksiyon eşikleme fonksiyonlarında kullanılır.
            double[] esik =new double[5];
            esik[0]= EsikDegerBul(giris_matris, a);
            esik[1] = EsikDegerBul(giris_matris, b);
            esik[2] = EsikDegerBul(giris_matris, c);
            esik[3] = EsikDegerBul(giris_matris, d);
            esik[4] = EsikDegerBul(giris_matris, e);


            return esik;
        }

        //çıkış ile sinir hücreleri arasındaki çözüm ve eşik değerlerini hesaplayana algoritma. 
        //Algoritma ara hücreleri ile çıkış hücreleri arasındaki bağın degerini çözüm degeri* bağ değeri ile çarpıp bias değeri ekler.

        public Cikis_Sinir[] Cikis_ArakatmanEsikleme(Arakatman_Sinir[] ara, Cikis_Sinir[] cikis,Giris_Sinir[] giris_matris)
        {

            for (int i = 0; i < 3; i++)
            {
                cikis[0].cozum  += ara[i].cozum * ara[i].bag_x;
                cikis[1].cozum += ara[i].cozum * ara[i].bag_y;
                cikis[2].cozum += ara[i].cozum * ara[i].bag_z;
                cikis[3].cozum += ara[i].cozum * ara[i].bag_a;
                cikis[4].cozum += ara[i].cozum * ara[i].bag_b;

            }

            cikis[0].cozum += cikis[0].biat;
            cikis[1].cozum += cikis[0].biat;
            cikis[2].cozum += cikis[0].biat;
            cikis[3].cozum += cikis[0].biat;
            cikis[4].cozum += cikis[0].biat;


            double [] EsikHarf= EsikDegerAta(giris_matris);

            //esik değeri bularak harflere bezemesine göre değer döndüren fonksiyon

            for (int i = 0; i <= 4; i++)
            {

                cikis[i].esik = 1 / (1 + Math.Pow(Math.E, cikis[i].cozum));

                cikis[i].esik = EsikHarf[i] - cikis[i].esik;

            }



            //eşik değeri bulma lagoritması gerekli
          










            return cikis; 
        }


        //geriye doğru öğrenmenin başladığı kodlar

        //s değerinin bulunduğu yer
        double[] s = new double[3];
        public Arakatman_Sinir[] Cikis_Arakatman_Ogrenme(Arakatman_Sinir[] ara)
        {
           
            
            for (int i = 0; i < 3; i++)
            {
                //S=ç*(1-ç)*E değerinin yazıldığı fonksiyon
                s[i] = ara[0].cozum * (1 - ara[0].cozum) * ara[0].esik;

            }
           
            for (int i = 0; i < 3; i++)
            {
                //0.5 ve 0.8 sabit değerlerdir. ve bağlara yeni değerler atanır
                double x = 0.5 * ara[i].esik * s[i] + ara[i].eskideger * 0.8;
                ara[i].eskideger = ara[i].esik;

                ara[i].bag_x = ara[i].bag_x - x;
                ara[i].bag_y = ara[i].bag_y - x;
                ara[i].bag_z = ara[i].bag_z - x;
                ara[i].bag_a = ara[i].bag_a - x;
                ara[i].bag_b = ara[i].bag_b - x;

            }


           





            return ara;

        }
        //giris ara katman arası öğrenmenin yapıldığı kodlar.
        //giris sinir hücresinin bağ değerleri güncellenir

        public Giris_Sinir[] Giris_Arakatman_Ogrenme(Giris_Sinir[] giris, Arakatman_Sinir[] ara )
        {
            

            double[] s = new double[35];
            for (int i = 0; i < 35; i++)
            {
               //s=Eskideğer*0.8*Sjm*Ç*(1-Ç) formülünün uygulandığı yer 
                s[i]= ara[0].eskideger * this.s[i%3]*giris[i].cozum*(1- giris[i].cozum);
             

            }
            //yeni giriş değerlerinin verildiği yer

            for (int i = 0; i < 35; i++)
            {
                double x = 0.5*s[i]*ara[i % 3].bag_x + giris[i].eskideger*0.8;


                giris[i].eskideger = giris[i].deger;

                giris[i].bag_x = giris[i].bag_x - x;
                giris[i].bag_y = giris[i].bag_y - x;
                giris[i].bag_z = giris[i].bag_z - x;
               



            }






            return giris;
        }



    }







}
