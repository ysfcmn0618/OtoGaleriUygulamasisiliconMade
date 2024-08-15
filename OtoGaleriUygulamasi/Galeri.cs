using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Galeri
    {
        // bu sınıf içinde galeri ile ilgili kodlar yazılacak.
        // Galeriye ilişkin herhangi bir verinin değiştirilmesi gerektiğinde 
        // ilgili kodlar bu sınıfta yazılmalı.

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count + 1;
            }
        }


        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;

                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == "Kirada")
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }

        public int GaleridekiAracSayisi { get; set; }
        public int ToplamAracKiralamaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.ToplamKiralanmaSuresi;
                }
                return toplam;
            }
        }
        public int ToplamAracKiralamaAdeti { get; set; }

        //araba kiralama bedeli ve araba kiralama suresi belli ise ciro bulunabilir
        public float Ciro { get; set; }


        public void ArabaKirala(string plaka, int sure)
        {
            // bu plakaya ait arabanın bulunması lazım.

            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Kirada";
                //a.KiralanmaSayisi++;  //bilgilendirme amacli.
                //a.ToplamKiralanmaSuresi += sure; bilgilendirme amacli.
                a.KiralamaSureleri.Add(sure);
            }

        }

        public void ArabaTeslimAl(string plaka)
        {
            // bu plakaya ait arabanın bulunması lazım.

            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }
            if (a != null)
            {
                a.Durum = "Galeride";
            }

        }

        public void KiralamaIptal(string plaka)
        {
            // arabayı bul

            // a.KiralamaSureleri.RemoveAt
            // KiralamaSureleri ndeki en son elamanı listeden çıkarıyoruz.

        }


        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aTipi)
        {
            // paramatreden aldığımız bilgiler ile yeni bir araba oluşacak.
            // bu oluşan arabayı Arabalar listesine de ekleyeceğiz.


            Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
            this.Arabalar.Add(a);


        }

    }
}
