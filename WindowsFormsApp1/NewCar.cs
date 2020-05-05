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
    
    public partial class NewCar : Form
    {
        int mov;
        int movX;
        int movY;
        public NewCar()
        {
            InitializeComponent();
        }

        private void panelBanner_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void FillGrid()
        {
            OtoContext otoContext = new OtoContext();
            object query2 = (from arac in otoContext.Arac
                             join marka in otoContext.Marka
                             on arac.MarkaId equals marka.MarkaId
                             join aracmodel in otoContext.AracModel
                             on arac.ModelId equals aracmodel.ModelId
                             join vites in otoContext.Vites
                             on arac.VitesId equals vites.VitesId
                             join yakit in otoContext.Yakit
                             on arac.YakitId equals yakit.YakitId
                             select new
                             {
                                 AracSaseNo = arac.AracSaseNo,
                                 MarkaAdi = marka.MarkaAdi,
                                 ModelAdi = aracmodel.ModelAdi,
                                 Yakit = yakit.YakitTuru,
                                 Vites = vites.VitesTuru,
                                 AracYil = arac.AracYil,
                                 AracKm = arac.AracKm,
                                 AracRenk = arac.AracRenk
                             }).ToList();
            dataGridView1.DataSource = query2;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var grArac = new GenericRepository<Arac>(new OtoContext());
            int markaid = int.Parse(comboBoxAracmarka.SelectedValue.ToString());//Selected Value olmasına dikkat!
            int modelid = int.Parse(comboBoxAracmodel.SelectedValue.ToString());
            int vitesid = int.Parse(comboBoxAracvites.SelectedValue.ToString());
            int yakitid = int.Parse(comboBoxAracyakit.SelectedValue.ToString());
            string renk = comboBoxAracrenk.Text;
            string arackm = textBoxArackm.Text;
            string aracyil = comboBoxAracyil.Text;

            grArac.Create(new Arac()
            {
                MarkaId = markaid,
                ModelId = modelid,
                AracRenk = renk,
                YakitId=yakitid,
                AracKm=arackm,
                AracYil=aracyil,
                VitesId = vitesid
            });

            FillGrid();
        }

        private void NewCar_Load(object sender, EventArgs e)
        {
            var grMarka = new GenericRepository<Marka>(new OtoContext());
            
            grMarka.Create(new Marka() { MarkaAdi = "Mercedes" });
            grMarka.Create(new Marka() { MarkaAdi = "Fiat" });
            grMarka.Create(new Marka() { MarkaAdi = "Renault" });
            
            comboBoxAracmarka.DataSource = grMarka.GetAll().ToList();
            comboBoxAracmarka.DisplayMember = "MarkaAdi";
            comboBoxAracmarka.ValueMember = "MarkaId";

            var grModel = new GenericRepository<AracModel>(new OtoContext());
            
            grModel.Create(new AracModel() { MarkaId=1,ModelAdi="C 180" });
            grModel.Create(new AracModel() { MarkaId = 1, ModelAdi = "C 180" });
            grModel.Create(new AracModel() { MarkaId = 1, ModelAdi = "E 250" });
            grModel.Create(new AracModel() { MarkaId = 2, ModelAdi = "Linea" });
            grModel.Create(new AracModel() { MarkaId = 2, ModelAdi = "Agea" });
            grModel.Create(new AracModel() { MarkaId = 3, ModelAdi = "Clio" });
            

            comboBoxAracmodel.DataSource = grModel.GetAll().ToList();
            comboBoxAracmodel.DisplayMember = "ModelAdi";
            comboBoxAracmodel.ValueMember = "ModelId";

            var grVites = new GenericRepository<Vites>(new OtoContext());
            
            grVites.Create(new Vites() { VitesTuru = "Otomatik" });
            grVites.Create(new Vites() { VitesTuru = "Manuel" });
            

            comboBoxAracvites.DataSource = grVites.GetAll().ToList();
            comboBoxAracvites.DisplayMember = "VitesTuru";
            comboBoxAracvites.ValueMember = "VitesId";

            var grYakit = new GenericRepository<Yakit>(new OtoContext());
            
            grYakit.Create(new Yakit() { YakitTuru = "Benzin" });
            grYakit.Create(new Yakit() { YakitTuru = "Dizel" });
            grYakit.Create(new Yakit() { YakitTuru = "Elektrik" });
            

            comboBoxAracyakit.DataSource = grYakit.GetAll().ToList();
            comboBoxAracyakit.DisplayMember = "YakitTuru";
            comboBoxAracyakit.ValueMember = "YakitId";

            comboBoxAracrenk.Items.Add("Kırmızı");
            comboBoxAracrenk.Items.Add("Beyaz");
            comboBoxAracrenk.Items.Add("Mavi");
            comboBoxAracrenk.Items.Add("Siyah");

            for (int yil = DateTime.UtcNow.Year; yil > 1980; yil--)
            {
                comboBoxAracyil.Items.Add(yil);
            }

            FillGrid();
        }
        List<AracModel> AracModelGetir(int id)
        {
            var grAracModel = new GenericRepository<AracModel>(new OtoContext());
            return grAracModel.GetAll().Where(i => i.MarkaId == id).ToList();
        }
        private void comboBoxAracmarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAracmodel.DataSource = null;
            int markaid = comboBoxAracmarka.SelectedIndex+1;
            comboBoxAracmodel.DataSource = AracModelGetir(markaid);
            comboBoxAracmodel.DisplayMember = "ModelAdi";
            comboBoxAracmodel.ValueMember = "ModelId";

        }
        public int indexRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            //Cells[1] 1 ile başlıyor çünkü 0 da primary key var
            textBoxSaseno.Text = row.Cells[0].Value.ToString();
            string AracMarka = row.Cells[1].Value.ToString();
            comboBoxAracmarka.SelectedIndex = comboBoxAracmarka.FindStringExact(AracMarka);
            string AracModel = row.Cells[2].Value.ToString();
            comboBoxAracmodel.SelectedIndex = comboBoxAracmodel.FindStringExact(AracModel);
            string AracYakit = row.Cells[3].Value.ToString();
            comboBoxAracyakit.SelectedIndex = comboBoxAracyakit.FindStringExact(AracYakit);
            string AracVites = row.Cells[4].Value.ToString();
            comboBoxAracvites.SelectedIndex = comboBoxAracvites.FindStringExact(AracVites);
            comboBoxAracyil.Text = "";
            comboBoxAracyil.SelectedText = row.Cells[5].Value.ToString();
            textBoxArackm.Text = row.Cells[6].Value.ToString();
            comboBoxAracrenk.Text = "";
            comboBoxAracrenk.SelectedText = row.Cells[7].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var gRArac = new GenericRepository<Arac>(new OtoContext());
            int markaid = int.Parse(comboBoxAracmarka.SelectedValue.ToString());//Selected Value olmasına dikkat!
            int modelid = int.Parse(comboBoxAracmodel.SelectedValue.ToString());
            int vitesid = int.Parse(comboBoxAracvites.SelectedValue.ToString());
            int yakitid = int.Parse(comboBoxAracyakit.SelectedValue.ToString());
            string renk = comboBoxAracrenk.Text;
            string arackm = textBoxArackm.Text;
            string aracyil = comboBoxAracyil.Text;

            gRArac.Update(new Arac()
            {
                AracSaseNo = int.Parse(textBoxSaseno.Text),
                MarkaId = markaid,
                ModelId = modelid,
                AracRenk = renk,
                YakitId = yakitid,
                AracKm = arackm,
                AracYil = aracyil,
                VitesId = vitesid
            }, int.Parse(textBoxSaseno.Text));
            FillGrid();
        }
        int saseNo;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int row = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (row > -1)
                {
                    dataGridView1.Rows[row].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    saseNo = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gRArac = new GenericRepository<Arac>(new OtoContext());
            Arac arac = gRArac.GetById(saseNo);
            gRArac.Delete(arac);
            FillGrid();
        }
    }
}
