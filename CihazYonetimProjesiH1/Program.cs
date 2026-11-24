enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi,
}

class Cihaz
{
    public int Kimlik { get; }
    public string Ad { get; }
    public CihazTuru Tur { get; }
    public bool AcikMi { get; private set; }

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        this.Kimlik = kimlik;
        this.Ad = ad;
        this.Tur = tur;
        AcikMi = false;
    }

    public void Ac()
    {
        if (AcikMi)
        {
            Console.WriteLine($"{Ad} zaten acik");
            return;
        }
        AcikMi = true;
        Console.WriteLine($"{Ad} acildi");
    }

    public void Kapat()
    {
        if (!AcikMi)
        {
            Console.WriteLine($"{Ad} zaten kapli");
            return;
        }
        AcikMi = false;
        Console.WriteLine($"{Ad} kapatildi");
    }

    public void BilgileriGoster()
    {
        string durum = AcikMi ? "Acik" : "Kapali";
        Console.WriteLine($"[{Kimlik}] {Ad} -  {Tur} - {durum}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cihaz> cihazlar = new List<Cihaz>
        {
            new Cihaz(1, "Lamba", CihazTuru.Lamba),
            new Cihaz(2, "Klima", CihazTuru.Klima),
            new Cihaz(3, "Guvenlik Sistemi", CihazTuru.GuvenlikSistemi)
        };
        while (true)
        {
            Console.WriteLine("\n--- AKILLI EV ---");
            Console.WriteLine("1- Cihazlari listele");
            Console.WriteLine("2- Yeni cihaz ekle");
            Console.WriteLine("3- Cihaz ac");
            Console.WriteLine("4- Cihaz kapat");
            Console.WriteLine("0- Cikis");
            Console.Write("Seciminiz: ");
            
            string secim = Console.ReadLine() ?? "";
            
            switch (secim)
            {
                case "1": CihazlariListele(cihazlar); break;
                case "2": CihazEkle(cihazlar); break;
                case "3": CihazAcKapat(cihazlar, true); break;
                case "4": CihazAcKapat(cihazlar, false); break;
                case "0": return;
                default: Console.WriteLine("Gecersiz secim."); break;
            }
        }
        
    }
    static void CihazlariListele(List<Cihaz> cihazlar)
    {
        if (cihazlar.Count == 0)
        {
            Console.WriteLine("Kayitli cihaz yok.");
            return;
        }
        foreach (Cihaz c in cihazlar)
            c.BilgileriGoster();
    }
    static void CihazEkle(List<Cihaz> cihazlar)
    {
        int kimlik = SayiOku("Kimlik: ");
        
        if (CihazBul(cihazlar, kimlik) != null) //null olmaz yani bir sey return ederse o cihaz var
        {
            Console.WriteLine("Hata: Bu kimlige sahip bir cihaz zaten var.");
            return;
        }

        Console.Write("Ad: ");
        string ad = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(ad))
        {
            Console.WriteLine("Hata: Ad bos olamaz.");
            return;
        }

        Console.WriteLine("Tur: 0- Lamba, 1- Klima, 2- GuvenlikSistemi");
        int turNo = SayiOku("Tur numarasi: ");
        if (!Enum.IsDefined(typeof(CihazTuru), turNo))
        {
            Console.WriteLine("Hata: Gecersiz cihaz turu.");
            return;
        }

        cihazlar.Add(new Cihaz(kimlik, ad, (CihazTuru)turNo));
        Console.WriteLine("Cihaz eklendi.");
    }
    static void CihazAcKapat(List<Cihaz> cihazlar, bool ac)
    {
        int kimlik = SayiOku("Cihaz kimligi: ");
        Cihaz? cihaz = CihazBul(cihazlar, kimlik);
        if (cihaz == null)
        {
            Console.WriteLine("Hata: Bu kimlige sahip cihaz bulunamadi.");
            return;
        }

        if (ac) cihaz.Ac();
        else cihaz.Kapat();
    }
    static Cihaz? CihazBul(List<Cihaz> cihazlar, int kimlik)
    {
        foreach (Cihaz c in cihazlar)
        {
            if (c.Kimlik == kimlik)
                return c;
        }
        return null;
    }
    static int SayiOku(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);
            if (int.TryParse(Console.ReadLine(), out int sayi))
                return sayi;
            Console.WriteLine("Lutfen gecerli bir sayi girin.");
        }
    }
}
