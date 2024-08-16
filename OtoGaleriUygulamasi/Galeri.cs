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
        public int ToplamAracKiralamaAdeti = 0;

        //araba kiralama bedeli ve araba kiralama suresi belli ise ciro bulunabilir
        public float Ciro
        {
            get
            {
                float ciro = 0;
                foreach (Araba item in Arabalar)
                {
                    foreach (int süre in item.KiralamaSureleri)
                    {
                        ciro += süre * item.KiralamaBedeli;
                    }
                }
                return ciro;
            }
        }


        public void ArabaKirala(string plaka, int sure)
        {
            // bu plakaya ait arabanın bulunması lazım.

            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                    a.Durum = "Kirada";
                    a.KiralamaSureleri.Add(sure);
                    ToplamAracKiralamaAdeti++;
                }
            }
            Console.WriteLine($"{plaka} plakalı araba {sure} saatliğine kiralandı.");
            //if (a != null)
            //{
            //    a.Durum = "Kirada";
            //    //a.KiralanmaSayisi++;  //bilgilendirme amacli.
            //    //a.ToplamKiralanmaSuresi += sure; bilgilendirme amacli.
            //    a.KiralamaSureleri.Add(sure);
            //}
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
            if (KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada hiç araba yok.");
                return;
            }
            // arabayı bul
            foreach (Araba item in Arabalar)//Araba listesini dön plaka eşleşiyorsa son kiralama süresini listeden çıkar
            {
                if (item.Plaka == plaka)
                {
                    // KiralamaSureleri ndeki en son elamanı listeden çıkarıyoruz.
                    item.KiralamaSureleri.RemoveAt(item.KiralamaSureleri.Count - 1);
                    ArabaTeslimAl(plaka);
                    break;
                }
            }
        }
        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aTipi)
        {
            // paramatreden aldığımız bilgiler ile yeni bir araba oluşacak.
            // bu oluşan arabayı Arabalar listesine de ekleyeceğiz.
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
            this.Arabalar.Add(a);
            Console.WriteLine("Araba basarılı bir sekilde eklendi.");
        }

    }
}
