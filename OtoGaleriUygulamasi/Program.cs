using System;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        static Galeri OtoGaleri = new Galeri();

        static void Main(string[] args)
        {
            // Kullanıcı ile etkileşime gireceğimiz bütün kodlar program sınıfı içerisinde yazılacak.
           // Uygulama();


            Console.Write("Sayi girin");
            string sayi = Console.ReadLine();
            int x = 0;

            bool sonuc = int.TryParse(sayi , out x);



            Console.WriteLine(sonuc);




        }
        static void Uygulama()
        {
            Menu();
            // switch-case
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                        ");
            Console.WriteLine("1 - Araba Kirala(K)                     ");
            Console.WriteLine("2 - Araba Teslim Al(T)                  ");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)       ");
            Console.WriteLine("4 - Galerideki Arabaları Listele(M)     ");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)            ");
            Console.WriteLine("6 - Kiralama İptali(I)                  ");
            Console.WriteLine("7 - Araba Ekle(Y)                       ");
            Console.WriteLine("8 - Araba Sil(S)                        ");
            Console.WriteLine("9 - Bilgileri Göster(G)                 ");
        }


        static void ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            Console.Write("Kiralanacak arabanın plakası: ");
            string plaka = Console.ReadLine();
            // kiralanacak arabanın plakası doğru girilmediği sürece tekrar plaka istenecek.

            Console.Write("Kiralama süresi: ");
            int sure = int.Parse(Console.ReadLine());

            
            OtoGaleri.ArabaKirala(plaka, sure);

        }

        static void ArabaEkle()
        {
            string plaka = "";
            string marka = "";
            float kiralamaBedeli = 0;
            string aTipi = "";
            string arabaTipiSecim = "2";

            if (arabaTipiSecim == "2")
            {
                aTipi = "Hatchback";
            }

            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aTipi);

        }
    }
}
