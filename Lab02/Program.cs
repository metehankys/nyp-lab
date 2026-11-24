using System;

interface IBildirimServisi
{
    void Gonder(string mesaj);
}
interface ILoglanabilir
{
    void LogYaz(string mesaj);
}

class EmailServisi : IBildirimServisi, ILoglanabilir
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine("Email gonderildi : " + mesaj);
    }
    public void LogYaz(string mesaj)
    {
        Console.WriteLine("Email logu :" + mesaj);
    }
}

class SmsServisi : IBildirimServisi
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine("SMS gonderildi : " + mesaj);
    }
}

class MobilBildirimSistemi : IBildirimServisi
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine("Mobil bildirim gonderildi : " + mesaj);
    }
}

class SiparisServisi
{
    private IBildirimServisi bildirimServisi;
    public SiparisServisi(IBildirimServisi bildirimServisi)
    {
        this.bildirimServisi = bildirimServisi;
    }

    public void SiparisOlustur(string urunAdi)
    {
        Console.WriteLine($"{urunAdi} siparisi olusturuldu" );
        bildirimServisi.Gonder(urunAdi);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IBildirimServisi emailServisi = new EmailServisi();
        SiparisServisi siparis1 = new SiparisServisi(emailServisi);
        siparis1.SiparisOlustur("Laptop");
        Console.WriteLine();
        
        IBildirimServisi smsServisi = new SmsServisi();
        SiparisServisi siparis2 = new SiparisServisi(smsServisi);
        siparis2.SiparisOlustur("Telefon");
        Console.WriteLine();

        IBildirimServisi mobilBildirimServisi = new MobilBildirimSistemi();
        SiparisServisi siparis3 = new SiparisServisi(mobilBildirimServisi);
        siparis3.SiparisOlustur("Tablet");
        Console.WriteLine();
    }
}