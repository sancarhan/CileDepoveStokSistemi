using System;
using System.Collections.Generic;

namespace DepoStokTakipUygulamasi
{
    class Program
    {
        static List<Depo> depolar = new List<Depo>();
        static List<Stok> stoklar = new List<Stok>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Depo Ekle");
                Console.WriteLine("2. Stok Ekle");
                Console.WriteLine("3. Stok Çıkarma");
                Console.WriteLine("4. Çıkış");

                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        DepoEkle();
                        break;
                    case 2:
                        StokEkle();
                        break;
                    case 3:
                        StokCikarma();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void DepoEkle()
        {
            Console.Write("Depo Adı: ");
            string depoAdi = Console.ReadLine();
            Console.Write("Adres: ");
            string adres = Console.ReadLine();

            Depo depo = new Depo(depoAdi, adres);
            depolar.Add(depo);

            Console.WriteLine("Depo başarıyla eklendi.");
        }

        static void StokEkle()
        {
            Console.Write("Ürün Adı: ");
            string urunAdi = Console.ReadLine();
            Console.Write("Miktar: ");
            int miktar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Depo Adı: ");
            string depoAdi = Console.ReadLine();

            Depo depo = depolar.Find(d => d.Adi == depoAdi);
            if (depo != null)
            {
                Stok stok = new Stok(urunAdi, miktar, depo);
                stoklar.Add(stok);

                Console.WriteLine("Stok başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Depo bulunamadı.");
            }
        }

        static void StokCikarma()
        {
            Console.Write("Ürün Adı: ");
            string urunAdi = Console.ReadLine();
            Console.Write("Miktar: ");
            int miktar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Depo Adı: ");
            string depoAdi = Console.ReadLine();

            Depo depo = depolar.Find(d => d.Adi == depoAdi);
            if (depo != null)
            {
                Stok stok = stoklar.Find(s => s.UrunAdi == urunAdi && s.Depo == depo);
                if (stok != null)
                {
                    if (stok.Miktar >= miktar)
                    {
                        stok.Miktar -= miktar;
                        Console.WriteLine("Stok başarıyla çıkartıldı.");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz stok.");
                    }
                }
                else
                {
                    Console.WriteLine("Stok bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Depo bulunamadı.");
            }
        }
    }

    class Depo
    {
        public string Adi { get; set; }
        public string Adres { get; set; }

        public Depo(string adi, string adres)
        {
            Adi = adi;
            Adres = adres;
        }
    }

    class Stok
    {
        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
        public Depo Depo { get; set; }

        public Stok(string urunAdi, int miktar, Depo depo)
        {
            UrunAdi = urunAdi;
            Miktar = miktar;
            Depo = depo;
        }
    }
}
