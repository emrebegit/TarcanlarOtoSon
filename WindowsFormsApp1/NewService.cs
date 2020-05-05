using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.Model.Context;
using WindowsFormsApp1.Model.Entity;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        int mov;
        int movX;
        int movY;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelBanner_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panelBanner_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panelBanner_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        public void FillGrid()
        {
            OtoContext otoContext = new OtoContext();
            object query2 = (from servis in otoContext.Servis
                             join cari in otoContext.Cari
                             on servis.CariId equals cari.cariID
                             join durum in otoContext.Durum
                             on servis.DurumId equals durum.DurumId
                             join calisan in otoContext.Cari
                             on servis.CalisanNo equals calisan.cariID
                             select new
                             {
                                 ServisKayitNo = servis.ServisKayitNo,
                                 AracSaseNo = servis.AracSaseNo,
                                 CariAdi = cari.ad,
                                 Durum = durum.Aciklama,
                                 CalisanAdi = calisan.ad,
                                 GirisTarihi = servis.GirisTarihi,
                                 CikisTarihi = servis.CikisTarihi
                             }).ToList();
            dataGridView1.DataSource = query2;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            /*
            OtoContext otoContext = new OtoContext();
            UrunDetay urunDetay = new UrunDetay { UrunMarka="Deneme", UrunModel="Deneme", UrunUretimTarihi=DateTime.Now };
            Stok stok = new Stok { UrunDetayId = urunDetay, Adet = 10, Birimi = "Tane" };
            otoContext.UrunDetay.Add(urunDetay);
            otoContext.Stok.Add(stok);
            otoContext.SaveChanges();
            */

            #region CRUD kodları
            var genericRepository = new GenericRepository<Il>(new OtoContext());

            //Ekleme kodu
            //Il il = new Il() { IlAdi = "pendik" };
            //genericRepository.Create(il);

            //Silme kodu
            //Il il = genericRepository.GetById(81);
            //genericRepository.Delete(il);

            //Güncelleme kodu
            //Il il = new Il() { Ilid=81,IlAdi = "Huseyinin Yeri" };
            //genericRepository.Update(il, 81);

            //dataGridView1.DataSource = genericRepository.GetAll().ToList<Il>();

            //var genericRepositoryRol = new GenericRepository<Rol>(new OtoContext());
            //genericRepositoryRol.Create(new Rol() { RolAdi = "Çalışan" });
            //dataGridView1.DataSource = genericRepositoryRol.GetAll().ToList();
            #endregion

            var genericRepositoryCari = new GenericRepository<Cari>(new OtoContext());
            /*
            genericRepositoryCari.Create(new Cari() { ad="Hüseyin",soyad="Özsoy", email="deneme@gmail.com",ilceID=1, rolID=1,tel="05355555555",adresdetay="Pendik"});
            genericRepositoryCari.Create(new Cari() { ad = "Ali", soyad = "Özsoy", email = "deneme@gmail.com", ilceID = 1, rolID = 1, tel = "05355555555", adresdetay = "Pendik" });
            genericRepositoryCari.Create(new Cari() { ad = "Kadir", soyad = "Özsoy", email = "deneme@gmail.com", ilceID = 1, rolID = 1, tel = "05355555555", adresdetay = "Pendik" });
            */
            comboBoxCari.DataSource = genericRepositoryCari.GetAll().ToList();
            comboBoxCari.DisplayMember = "ad";
            comboBoxCari.ValueMember = "cariID";

            comboBoxCalisan.DataSource = genericRepositoryCari.GetAll().Where(i=>i.rolAdi=="Veznedar").ToList();
            comboBoxCalisan.DisplayMember = "ad";
            comboBoxCalisan.ValueMember = "cariID";

            var gRDurum = new GenericRepository<Durum>(new OtoContext());
            comboBoxDurum.DataSource = gRDurum.GetAll().ToList();
            comboBoxDurum.DisplayMember = "Aciklama";
            comboBoxDurum.ValueMember = "DurumId";

            //dataGridView1.DataSource = new GenericRepository<Servis>(new OtoContext()).GetAll().ToList();

            FillGrid();//datagridviewi dolduran fonk. Yukarıda
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            var gRServis = new GenericRepository<Servis>(new OtoContext());
            int calisanID = int.Parse(comboBoxCalisan.SelectedValue.ToString());//Selected Value olmasına dikkat!
            int cariID = int.Parse(comboBoxCari.SelectedValue.ToString());//Selected Value olmasına dikkat!

            gRServis.Create(new Servis()
            {
                AracSaseNo = textBoxSaseno.Text,
                CalisanNo = calisanID,
                CariId = cariID,
                DurumId = int.Parse(comboBoxDurum.SelectedValue.ToString()),//Selected Value olmasına dikkat!
                GirisTarihi =dateTimePickerGiristarihi.Value,
                CikisTarihi = dateTimePickerGiristarihi.Value
            });
            
            FillGrid();
            
        }
        public int indexRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            //Cells[1] 1 ile başlıyor çünkü 0 da primary key olan Servis No var
            labelServisNo.Text = row.Cells[0].Value.ToString();
            textBoxSaseno.Text = row.Cells[1].Value.ToString();
            string Cariad =row.Cells[2].Value.ToString();
            string Durum = row.Cells[3].Value.ToString();
            string CalisanAdi = row.Cells[4].Value.ToString();
            DateTime GirisTarihi = DateTime.Parse(row.Cells[5].Value.ToString());
            dateTimePickerGiristarihi.Value = GirisTarihi;
            DateTime CikisTarihi = DateTime.Parse(row.Cells[6].Value.ToString());
            dateTimePickerCikistarihi.Value = CikisTarihi;
            comboBoxCari.SelectedIndex = comboBoxCari.FindStringExact(Cariad);
            comboBoxDurum.SelectedIndex = comboBoxDurum.FindStringExact(Durum);

            //Gereksiz kodlar
            //var cariID = new OtoContext().Cari.Where(i => i.ad == Cariad).FirstOrDefault().ToString();
            //OtoContext otoContext = new OtoContext();
            //object cariID = (from c in otoContext.Cari where c.ad == Cariad.ToString() select c.cariID).First();
            //object durumID = (from d in otoContext.Durum where d.Aciklama == Durum.ToString() select d.DurumId).First();
            //MessageBox.Show(cariID.ToString());
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            var gRServis = new GenericRepository<Servis>(new OtoContext());
            gRServis.Update(new Servis() { AracSaseNo = textBoxSaseno.Text, CalisanNo = int.Parse(comboBoxCalisan.SelectedValue.ToString()),
                CariId= int.Parse(comboBoxCari.SelectedValue.ToString()),
                DurumId = int.Parse(comboBoxDurum.SelectedValue.ToString()),
                GirisTarihi =dateTimePickerGiristarihi.Value,
                CikisTarihi = dateTimePickerCikistarihi.Value,
                ServisKayitNo=int.Parse(labelServisNo.Text)
            },int.Parse(labelServisNo.Text));
            FillGrid();
        }
        
        int ServisNo;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (row > -1)
                {
                    dataGridView1.Rows[row].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    ServisNo = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gRServis = new GenericRepository<Servis>(new OtoContext());
            Servis servis = gRServis.GetById(ServisNo);
            gRServis.Delete(servis);
            FillGrid();
        }
    }
}
