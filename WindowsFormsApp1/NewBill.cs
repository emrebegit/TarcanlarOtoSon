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
    public partial class NewBill : Form
    {
        int mov;
        int movX;
        int movY;
        public NewBill()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewBill_Load(object sender, EventArgs e)
        {

            var genericRepositoryTip = new GenericRepository<FaturaTip>(new OtoContext());
            genericRepositoryTip.Create(new FaturaTip() { faturatipNo = 0, faturaTuru = "Alım işlemi" });
            genericRepositoryTip.Create(new FaturaTip() { faturatipNo = 1, faturaTuru = "Satım işlemi" });
            comboBoxFaturatip.DataSource = genericRepositoryTip.GetAll().ToList();
            comboBoxFaturatip.DisplayMember = "faturaTuru";
            comboBoxFaturatip.ValueMember = "faturatipNo";
            comboBoxUrun.Items.Add("Deneme");
            /*var genericRepositoryUrun = new GenericRepository<Stok>(new OtoContext());
            comboBoxUrun.DataSource = genericRepositoryUrun.GetAll().ToList();
            comboBoxUrun.DisplayMember = "UrunId";
            comboBoxUrun.ValueMember = "UrunId";*/
            int[] sayilar = new int[50];
            for (int i = 1; i <= 50; i++)
            {
                sayilar[i - 1] = i;
            }
            comboBoxUrunadet.DataSource = sayilar;
            

        }
        public void FillGridUrun() 
        {
            OtoContext otoContext = new OtoContext();
            object query2 = (from stok in otoContext.Stok join urun in otoContext.UrunDetay on stok.UrunDetayId equals urun.UrunDetayId
                             select new 
                             {
                                 urunmarka=urun.UrunMarka,
                                 urunmodel=urun.UrunModel,
                                 urunuretimtarihi=urun.UrunUretimTarihi,
                                 urunadet=comboBoxUrunadet.SelectedItem,
                                 faturatarihi=dateTimePickerFaturatarihi.Value,
                                 satistürü=comboBoxFaturatip.SelectedItem
                             }).ToList();
            dataGridView2.DataSource = query2;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FillGridUrun();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
