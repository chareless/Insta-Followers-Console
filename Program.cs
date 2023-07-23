using System.Net;
using System.Text;
using HtmlAgilityPack;

string takipciURL = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//takipci.html";
string takipEdilenURL = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//takipEdilen.html";

Console.Write("Takipçi Sayısı : ");
int takipciSayi = Convert.ToInt32(Console.ReadLine());
Console.Write("Takip Edilen Sayısı : ");
int takipEdilenSayi = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("İşleniyor...");

string[] takipci = new string[takipciSayi+1];
string[] takipEdilen = new string[takipEdilenSayi+1];

//Takipci

Uri urlTakipci = new Uri(takipciURL);
WebClient clientTakipci = new WebClient();
clientTakipci.Encoding = Encoding.UTF8;
string htmlTakipci = clientTakipci.DownloadString(urlTakipci);
HtmlDocument dokumanTakipci = new HtmlDocument();
dokumanTakipci.LoadHtml(htmlTakipci);
for (int i = 1; i <= takipciSayi; i++)
{
    HtmlNodeCollection titlesTakipci = dokumanTakipci.DocumentNode.SelectNodes("body/div[2]/div/div/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div/div[2]/div[1]/div/div[" + i + "]/div/div/div/div[2]/div/div/div/div/div/a/span/div");
    foreach (HtmlNode title in titlesTakipci)
    {
        takipci[i] = (title.InnerText.Trim());
    }
}
StreamWriter KayitTakipci = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//takipci.txt");
for (int i = 1; i <= takipciSayi; i++)
{
    KayitTakipci.WriteLine(takipci[i]);
}
KayitTakipci.Close();
Console.WriteLine("Takipçileriniz kaydedildi.");

//Takip Edilen

Uri urlTakipEdilen = new Uri(takipEdilenURL);
WebClient clientTakipEdilen = new WebClient();
clientTakipEdilen.Encoding = Encoding.UTF8;
string htmlTakipEdilen = clientTakipEdilen.DownloadString(urlTakipEdilen);
HtmlDocument dokumanTakipEdilen = new HtmlDocument();
dokumanTakipEdilen.LoadHtml(htmlTakipEdilen);
for (int i = 1; i <= takipEdilenSayi; i++)
{
    HtmlNodeCollection titlesTakipEdilen = dokumanTakipEdilen.DocumentNode.SelectNodes("body/div[2]/div/div/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div/div[3]/div/div/div[" + i + "]/div/div/div/div[2]/div/div/div/div/div/a/span/div");
    foreach (HtmlNode title in titlesTakipEdilen)
    {
        takipEdilen[i] = (title.InnerText.Trim());
    }
}
StreamWriter KayitTakipEdilen = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "//takipEdilen.txt");
for (int i = 1; i <= takipEdilenSayi; i++)
{
    KayitTakipEdilen.WriteLine(takipEdilen[i]);
}
KayitTakipEdilen.Close();
Console.WriteLine("Takip ettikleriniz kaydedildi.");
Console.WriteLine("İşlem tamamlandı.");