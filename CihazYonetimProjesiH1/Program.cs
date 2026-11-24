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
/*
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
        }
    }
}
*/