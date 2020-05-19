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
    public partial class FormSupply : Form
    {
        public FormSupply()
        {
            InitializeComponent();
            ShowAgents();
            ShowClient();
            ShowОбъекты_недвижимости();
            ShowПредложенияSet();
        }

        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (РиэлторSet риэлторSet in Program.wftDb.РиэлторSet)
            {
                string[] item = { риэлторSet.id.ToString() + ".", риэлторSet.FirstName, риэлторSet.MiddleName, риэлторSet.LastName };
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }

        void ShowОбъекты_недвижимости()
        {
            comboBoxRealEstate.Items.Clear();
            foreach (Объекты_недвижимостиSet объекты_НедвижимостиSet in Program.wftDb.Объекты_недвижимостиSet)
            {
                string[] item = { объекты_НедвижимостиSet.Id.ToString() + ".", объекты_НедвижимостиSet.Address_City + ",", объекты_НедвижимостиSet.Address_Street + ",", "д. "+ объекты_НедвижимостиSet.Address_House + ",", "кв. " + объекты_НедвижимостиSet.Address_Number };
                comboBoxRealEstate.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClient()
        {
            comboBoxClients.Items.Clear();
            foreach (КлиентыSet клиентыSet in Program.wftDb.КлиентыSet)
            {
                string[] item = { клиентыSet.id.ToString() + ".", клиентыSet.FirstName, клиентыSet.MiddleName, клиентыSet.LastName };
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxAgents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void ShowПредложенияSet()
        {
            listViewSupplySet.Items.Clear();
            foreach(ПредложенияSet предложения in Program.wftDb.ПредложенияSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    предложения.IdAgent.ToString(),
                    предложения.РиэлторSet.LastName+" "+предложения.РиэлторSet.FirstName+" "+предложения.РиэлторSet.MiddleName,
                    предложения.IdClient.ToString(),
                    предложения.КлиентыSet.LastName+" "+предложения.КлиентыSet.FirstName+" "+предложения.КлиентыSet.MiddleName,
                    предложения.IdRealEstate.ToString(),
                    "г. "+предложения.Объекты_недвижимостиSet.Address_City+", ул."+предложения.Объекты_недвижимостиSet.Address_Street+", д."+предложения.Объекты_недвижимостиSet.Address_House+", кв."+предложения.Объекты_недвижимостиSet.Address_Number,
                    предложения.Price.ToString()
                });
                item.Tag = предложения;
                listViewSupplySet.Items.Add(item);
            }  
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxRealEstate != null && textBoxPrice.Text != "")
            {
                ПредложенияSet предложения = new ПредложенияSet();
                предложения.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                предложения.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                предложения.IdRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                предложения.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.wftDb.ПредложенияSet.Add(предложения);
                Program.wftDb.SaveChanges();
                ShowПредложенияSet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                ПредложенияSet предложения = listViewSupplySet.SelectedItems[0].Tag as ПредложенияSet;
                предложения.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                предложения.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                предложения.IdRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                предложения.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.wftDb.SaveChanges();
                ShowПредложенияSet();
            }
        }

        private void listViewSupplySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                ПредложенияSet предложения = listViewSupplySet.SelectedItems[0].Tag as ПредложенияSet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(предложения.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(предложения.IdClient.ToString());
                comboBoxRealEstate.SelectedIndex = comboBoxRealEstate.FindString(предложения.IdRealEstate.ToString());
                textBoxPrice.Text = предложения.Price.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = " ";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewSupplySet.SelectedItems.Count == 1)
                {
                    ПредложенияSet предложения = listViewSupplySet.SelectedItems[0].Tag as ПредложенияSet;
                    Program.wftDb.ПредложенияSet.Remove(предложения);
                    Program.wftDb.SaveChanges();
                    ShowПредложенияSet();
                }
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
