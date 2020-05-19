using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormDeal : Form
    {
        public FormDeal()
        {
            InitializeComponent();
            ShowDemand();
            ShowSupply();
            ShowDealSet();
        }

        void ShowSupply()
        {
            comboBoxSupply.Items.Clear();
            foreach (ПредложенияSet предложенияSet in Program.wftDb.ПредложенияSet)
            {
                string[] item = { предложенияSet.Id.ToString() + ". ", "Риелтор: " + предложенияSet.РиэлторSet.LastName, "Клиент: " + предложенияSet.КлиентыSet.LastName};
                comboBoxSupply.Items.Add(string.Join(" ", item));
            }
        }

        void ShowDemand()
        {
            comboBoxDemand.Items.Clear();
            foreach (ПотребностиSet потребностиSet in Program.wftDb.ПотребностиSet)
            {
                string[] item = { потребностиSet.id.ToString() + ". ", "Риелтор: " + потребностиSet.РиэлторSet.LastName, "Клиент: " + потребностиSet.КлиентыSet.LastName };
                comboBoxDemand.Items.Add(string.Join(" ", item));
            }
        }
            
        private void comboBoxSupply_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        private void comboBoxDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        void Deductions()
        {
            if(comboBoxSupply.SelectedItem != null && comboBoxDemand.SelectedItem != null)

            {
                ПредложенияSet supplySet = Program.wftDb.ПредложенияSet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                ПотребностиSet demandSet = Program.wftDb.ПотребностиSet.Find(Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]));

                double customerCompanyDeductions = supplySet.Price * 0.03;
                textBoxCustomerCompanyDeductions.Text = customerCompanyDeductions.ToString("0.00");

                if (demandSet.РиэлторSet.DealShare != null)
                {
                    double agentCustomerDeductions = customerCompanyDeductions * Convert.ToDouble(demandSet.РиэлторSet.DealShare) / 100.00;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");

                }
                else
                {
                    double agentCustomerDeductions = customerCompanyDeductions * 0.45;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");

                }
            }
            else
            {
                textBoxCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";

            }
            if (comboBoxSupply.SelectedItem != null)
            {
                ПредложенияSet предложенияSet = Program.wftDb.ПредложенияSet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                double sellerCompanyDeductions;
                if (предложенияSet.Объекты_недвижимостиSet.Type == 0)
                {
                    sellerCompanyDeductions = 36000 + предложенияSet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else if (предложенияSet.Объекты_недвижимостиSet.Type == 1)
                {
                    sellerCompanyDeductions = 30000 + предложенияSet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else
                {
                    sellerCompanyDeductions = 30000 + предложенияSet.Price * 0.02;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                if (предложенияSet.РиэлторSet.DealShare != null)
                {
                    double agentSellerDeductions = sellerCompanyDeductions * Convert.ToDouble(предложенияSet.РиэлторSet.DealShare) / 100.00;
                    textBoxAgentCustomerDeductions.Text = agentSellerDeductions.ToString("0.00");
                }
                else
                {
                    double agentSellerDeductions = sellerCompanyDeductions * 0.45;
                    textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00");
                }
            }
            else
            {
                textBoxSellerCompanyDeductions.Text = " ";
                textBoxAgentSellerDeductions.Text = " ";
                textBoxCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";
            }
        }

        void ShowDealSet()
        {
            listViewDealSet.Items.Clear();
            foreach (СделкиSet сделки in Program.wftDb.СделкиSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    сделки.ПредложенияSet.КлиентыSet.LastName,
                    сделки.ПредложенияSet.РиэлторSet.LastName,
                    сделки.ПотребностиSet.КлиентыSet.LastName,
                    сделки.ПотребностиSet.РиэлторSet.LastName,
                    "г. "+сделки.ПредложенияSet.Объекты_недвижимостиSet.Address_City+", ул."+сделки.ПредложенияSet.Объекты_недвижимостиSet.Address_Street+", д. "+сделки.ПредложенияSet.Объекты_недвижимостиSet.Address_House+", кв. "+сделки.ПредложенияSet.Объекты_недвижимостиSet.Address_Number,
                    сделки.ПредложенияSet.Price.ToString()
                });
                item.Tag = сделки;
                listViewDealSet.Items.Add(item);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDemand.SelectedItem != null && comboBoxSupply.SelectedItem != null)
            {
                СделкиSet сделки = new СделкиSet();
                сделки.IdSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                сделки.IdDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.wftDb.СделкиSet.Add(сделки);
                Program.wftDb.SaveChanges();
                ShowDealSet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDealSet.SelectedItems.Count == 1)
            {
                СделкиSet сделки = listViewDealSet.SelectedItems[0].Tag as СделкиSet;
                сделки.IdSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                сделки.IdDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.wftDb.SaveChanges();
                ShowDealSet();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDealSet.SelectedItems.Count == 1)
                {
                    СделкиSet сделки = listViewDealSet.SelectedItems[0].Tag as СделкиSet;
                    Program.wftDb.СделкиSet.Remove(сделки);
                    Program.wftDb.SaveChanges();
                    ShowDealSet();
                }
                comboBoxSupply.SelectedItem = null;
                comboBoxDemand.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewDealSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDealSet.SelectedItems.Count == 1)
            {
                СделкиSet сделки = listViewDealSet.SelectedItems[0].Tag as СделкиSet;
                comboBoxSupply.SelectedIndex = comboBoxSupply.FindString(сделки.IdSupply.ToString());
                comboBoxDemand.SelectedIndex = comboBoxDemand.FindString(сделки.IdDemand.ToString());
            }
            else
            {
                comboBoxSupply.SelectedItem = null;
                comboBoxDemand.SelectedItem = null;
            }
        }
    }
}
