using System;
using System.Collections.Generic;
using System.Numerics;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        static Galeri OtoGaleri = new Galeri();
        static List<Araba> Arabalar = OtoGaleri.Arabalar;
        static void Main(string[] args)
        {
            // Kullanıcı ile etkileşime gireceğimiz bütün kodlar program sınıfı içerisinde yazılacak.
            //Console.Write("Sayi girin");
            //string sayi = Console.ReadLine();
            //int x = 0;
            //bool sonuc = int.TryParse(sayi, out x);
            //Console.WriteLine(sonuc);
            SahteVeriEkle();
            Uygulama();


        }
        static void Uygulama()
        {
            Menu();
            //do
            //{
            //    SecimAl();
            //} while (true);
            while (true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                    case "K": ArabaKirala(); break;
                    case "2":
                    case "T": ArabaTeslimAl(); break;
                    case "3":
                    case "R": KiradakiArabalariListele(); break;
                    case "4":
                    case "M": GaleridekiArabalariListele(); break;
                    case "5":
                    case "A": TümArabalariListele(); break;
                    case "6":
                    case "I": KiralamaIptal(); break;
                    case "7":
                    case "Y": ArabaEkle(); break;
                    case "8":
                    case "S": ArabaSil(); break;
                    case "9":
                    case "G": BilgileriGöster(); break;
                }

            }

        }

        private static void BilgileriGöster()
        {
            throw new NotImplementedException();
        }

        private static void ArabaSil()
        {
            throw new NotImplementedException();
        }

        private static void KiralamaIptal()
        {
            throw new NotImplementedException();
        }

        private static void TümArabalariListele()
        {
            throw new NotImplementedException();
        }

        private static void GaleridekiArabalariListele()
        {
            throw new NotImplementedException();
        }

        private static void KiradakiArabalariListele()
        {
            throw new NotImplementedException();
        }
        static void SahteVeriEkle()
        {
            Araba a = new Araba("01qwe123", "qwert", 123, "Suv") { };
            Araba b = new Araba("02qwe123", "qwert", 123, "Sedan") { };
            Araba c = new Araba("03qwe123", "qwert", 123, "Hatchback") { };
            Araba d = new Araba("04qwe123", "qwert", 123, "Suv") { };
            Arabalar.Add(a);
            Arabalar.Add(b);
            Arabalar.Add(c);
            Arabalar.Add(d);
        }

        private static void ArabaTeslimAl()
        {
            Console.WriteLine("-Araba Kirala-");
            string plaka;
            foreach (Araba a in Arabalar)
            {
                if (a.Durum != "Kirada")
                {
                    Console.WriteLine("Kirada hiç araba yok.");
                }
            }
            // kiralanacak arabanın plakası doğru girilmediği sürece tekrar plaka istenecek.           
            do
            {
                Console.Write("Teslim edilecek arabanın plakası: ");
                plaka = Console.ReadLine();

                if (!PlakaDogruMu(plaka))
                {
                    PlakaHata();
                    continue;
                }
                foreach (Araba a in Arabalar)
                {
                    if (a.Plaka != plaka)
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        break;
                    }
                    else if (a.Durum == "Galeride")
                    {
                        Console.WriteLine("Hatalı giris yapıldı. Araba zaten galeride.");
                        break;
                    }
                    else
                    {
                        a.Durum = "Galeride";
                        Console.WriteLine();
                        Console.WriteLine("Araba galeride beklemeye alındı.");
                        return;
                    }
                }
            } while (true);
        }
        static string SecimAl()
        {
            string karakterler = "123456789KTRMAIYSG";
            int sayac = 0;
            while (true)
            {
                sayac++;
                Console.WriteLine();
                Console.Write("Seçiminiz : ");
                string giris = Console.ReadLine().ToUpper();
                Console.WriteLine();
                int index = karakterler.IndexOf(giris);
                if (giris.Length == 1 && index >= 0)
                {
                    return giris;
                }
                else
                {
                    if (sayac == 10)
                    {
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatalı islem gerçeklestirildi. Tekrar deneyin.");
                    Console.WriteLine();
                }
            }
        }
        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1- Araba Kirala (K)");
            Console.WriteLine("2- Araba Teslim Al (T)");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)");
            Console.WriteLine("5- Tüm Arabaları Listele (A)");
            Console.WriteLine("6- Kiralama İptali (I)");
            Console.WriteLine("7- Araba Ekle (Y)");
            Console.WriteLine("8- Araba Sil (S)");
            Console.WriteLine("9- Bilgileri Göster (G)");
        }


        static void ArabaKirala()
        {
            Araba car = null;
            Console.WriteLine("-Araba Kirala-");
            string plaka;
            // kiralanacak arabanın plakası doğru girilmediği sürece tekrar plaka istenecek.
            do
            {
                Console.Write("Kiralanacak arabanın plakası: ");
                plaka = Console.ReadLine();
                if (!PlakaDogruMu(plaka))
                {
                    PlakaHata();
                    continue;
                }
                foreach (Araba a in Arabalar)
                {
                    if (a.Plaka == plaka)
                    {
                        car = a;
                        // Arabalar.Remove(a);
                        break;
                    }
                }
                if (car.Durum == "Kirada")
                {
                    Console.WriteLine("Araç zaten kirada.");
                    plaka = "kirada";
                    continue;
                }
                if (car == null)
                {
                    Console.WriteLine("Galeride böyle bir araba yok demektri.");
                    continue;
                }
            } while (!PlakaDogruMu(plaka));
            int time;
            bool t = true;
            do
            {
                Console.Write("Kiralama süresi: ");

                string sure = Console.ReadLine();
                t = int.TryParse(sure, out time);

            } while (!t);


            OtoGaleri.ArabaKirala(plaka, time);

        }
        static void PlakaHata()
        {
            Console.WriteLine("Bu sekilde plaka girisi yapamazsınız. Tekrar deneyin.");
        }
        static bool PlakaDogruMu(string plaka)
        {
            if (plaka.Length < 7 || plaka.Length > 9)
            {
                return false;
            }
            string sehir = plaka.Substring(0, 2);
            if (!int.TryParse(sehir, out int sayi))
            {

                return false;
            }

            string kalan = plaka.Substring(2);
            int sayac = 0;
            while (sayac < kalan.Length && char.IsLetter(kalan[sayac]))
            {
                sayac++;
            }
            string harfler = kalan.Substring(0, sayac);
            if (harfler.Length < 1 && harfler.Length > 3)
            {
                return false;
            }

            string rakamlar = kalan.Substring(sayac);
            if (!int.TryParse(rakamlar, out int sayi2) || rakamlar.Length < 2 || rakamlar.Length > 4)
            {
                return false;
            }

            return true;
        }

        static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();
            string plaka;
            do
            {
                Console.Write("Plaka: ");
                plaka = Console.ReadLine();
                if (!PlakaDogruMu(plaka))
                {
                    PlakaHata();
                    continue;
                }
                foreach (Araba a in Arabalar)
                {
                    if (a.Plaka == plaka)
                    {
                        Console.WriteLine("Aynı plakada araba mevcut. Girdiginiz plakayı kontrol edin.");
                        continue;
                    }
                }

            } while (!PlakaDogruMu(plaka));
            string marka;
            do
            {
                Console.Write("Marka: ");
                marka = Console.ReadLine();
                if (int.TryParse(marka, out int a))
                {
                    Console.WriteLine("Giris tanımlanamadı. Tekrar deneyin.");
                    continue;
                }
                break;

            } while (true);


            float kiralamaBedeli = 0;
            do
            {
                Console.Write("Kiralama bedeli: ");
                string bedel = Console.ReadLine();
                if (!float.TryParse(bedel, out kiralamaBedeli))
                {
                    Console.WriteLine("Giris tanımlanamadı. Tekrar deneyin.");
                    continue;
                }
                break;

            } while (true);

            Console.WriteLine("Araç tipi:\r\nSUV için 1\r\nHatchback için 2\r\nSedan için 3");
            string aTipi = "";
            do
            {
                Console.Write("Araba Tipi: ");
                aTipi = Console.ReadLine();
                if (int.TryParse(aTipi, out int t))
                {
                    switch (aTipi)
                    {
                        case "1": aTipi = "SUV"; break;
                        case "2": aTipi = "Hatchback"; break;
                        case "3": aTipi = "Sedan"; break;
                        default:
                            Console.WriteLine("Giris tanımlanamadı. Tekrar deneyin.");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Giris tanımlanamadı. Tekrar deneyin.");
                    continue;
                }
                break;

            } while (true);
            Console.WriteLine();
            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aTipi);

        }
    }
}
