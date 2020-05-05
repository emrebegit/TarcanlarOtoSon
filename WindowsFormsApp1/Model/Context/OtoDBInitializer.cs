using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.Model.Entity;

namespace WindowsFormsApp1.Model.Context
{
    class OtoDBInitializer<T> : DropCreateDatabaseAlways<OtoContext>
    {
        protected override void Seed(OtoContext context)
        {
            /*
            IList<UrunDetay> defaultUrundetaylar = new List<UrunDetay>();
            defaultUrundetaylar.Add(new UrunDetay() { UrunMarka = "EMR", UrunModel = "DY418-12", UrunUretimTarihi = DateTime.Now });
            defaultUrundetaylar.Add(new UrunDetay() { UrunMarka = "EMR", UrunModel = "DY453-15", UrunUretimTarihi = DateTime.Now });
            defaultUrundetaylar.Add(new UrunDetay() { UrunMarka = "EMR", UrunModel = "DY500-20", UrunUretimTarihi = DateTime.Now });
            context.UrunDetay.AddRange(defaultUrundetaylar);
            */
            //81 İl veritabanına ekleme
            string[] iller = new string[] {"Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin",
            "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
            "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir",
            "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir",
            "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
            "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya",
            "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak",
            "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak",
            "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"};
            IList<Il> defaultIller = new List<Il>();
            for (int i = 0; i < iller.Length; i++)
            {
                defaultIller.Add(new Il() { Ilid = (Array.IndexOf(iller, iller[i])) + 1, IlAdi = iller[i] });
            }
            context.Il.AddRange(defaultIller);
            //Ilce ekleme

            IList<Ilce> defaultIlceler = new List<Ilce>();
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Merkez" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Aladağ" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Ceyhan" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Çukurova" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Feke" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "İmamoğlu" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Karaisalı" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Karataş" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Kozan‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Pozantı‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Saimbeyli‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Sarıçam" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Seyhan" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Tufanbeyli" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Yumurtalık‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 1, IlceAdi = "Yüreğir" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Kahta" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Besni" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Gölbaşı" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Gerger" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Sincik" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Çelikhan" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Tut" });
            defaultIlceler.Add(new Ilce() { Ilid = 2, IlceAdi = "Samsat" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Başmakçı" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Bayat" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Bolvadin" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Çay" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Çobanlar" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Dazkırı" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Dinar" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Emirdağ‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Evciler‎‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Hocalar‎‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "İhsaniye‎‎‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "İscehisar" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Kızılören‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Sandıklı‎‎" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Sincanlı" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Sultandağı" });
            defaultIlceler.Add(new Ilce() { Ilid = 3, IlceAdi = "Şuhut" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Diyadin" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Doğubayazıt" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Eleşkirt" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Hamur" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Patnos" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Taşlıçay" });
            defaultIlceler.Add(new Ilce() { Ilid = 4, IlceAdi = "Tutak" });
            defaultIlceler.Add(new Ilce() { Ilid = 5, IlceAdi = "Göynücek" });
            defaultIlceler.Add(new Ilce() { Ilid = 5, IlceAdi = "Gümüşhacıköy" });
            defaultIlceler.Add(new Ilce() { Ilid = 5, IlceAdi = "Hamamözü" });
            defaultIlceler.Add(new Ilce() { Ilid = 5, IlceAdi = "Merzifon" });
            defaultIlceler.Add(new Ilce() { Ilid = 5, IlceAdi = "Suluova" });
            defaultIlceler.Add(new Ilce() { Ilid = 5, IlceAdi = "Taşova" });
            defaultIlceler.Add(new Ilce() { Ilid = 34, IlceAdi = "Pendik" });
            defaultIlceler.Add(new Ilce() { Ilid = 34, IlceAdi = "Tuzla" });
            defaultIlceler.Add(new Ilce() { Ilid = 34, IlceAdi = "Kadıköy" });
            defaultIlceler.Add(new Ilce() { Ilid = 34, IlceAdi = "Başakşehir" });
            defaultIlceler.Add(new Ilce() { Ilid = 35, IlceAdi = "Aliağa" });
            defaultIlceler.Add(new Ilce() { Ilid = 34, IlceAdi = "Karşıyaka" });
            context.Ilce.AddRange(defaultIlceler);

            //Durum Ekleme
            IList<Durum> defaultDurumlar = new List<Durum>();
            defaultDurumlar.Add(new Durum() { Aciklama = "Servis Kaydı Alındı" });
            defaultDurumlar.Add(new Durum() { Aciklama = "İşlem Devam Ediyor" });
            defaultDurumlar.Add(new Durum() { Aciklama = "Servis İşlemi Bitti" });
            defaultDurumlar.Add(new Durum() { Aciklama = "Teslim Edildi" });
            context.Durum.AddRange(defaultDurumlar);

            //Rol ekleme
            IList<Rol> defaultRoller = new List<Rol>();
            defaultRoller.Add(new Rol() { RolId=0,RolAdi = "Veznedar" });
            defaultRoller.Add(new Rol() { RolId=1,RolAdi="Çırak" });
            defaultRoller.Add(new Rol() { RolId = 2, RolAdi = "Boyacı" });
            defaultRoller.Add(new Rol() { RolId = 3, RolAdi = "Motor ustası" });
            defaultRoller.Add(new Rol() { RolId = 4, RolAdi = "Müşteri" });
            context.Rol.AddRange(defaultRoller);
            base.Seed(context);
        }
    }
}
