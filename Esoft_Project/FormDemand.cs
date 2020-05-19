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
    public partial class FormDemand : Form
    {
        public FormDemand()
        {
            InitializeComponent();
            ShowAgents();
            ShowClient();
            ShowПотребности();
            comboBoxType.SelectedIndex = 0;
        }

        private void FormDemand_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxAgents_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        void ShowClient()
        {
            comboBoxClients.Items.Clear();
            foreach (КлиентыSet клиентыSet in Program.wftDb.КлиентыSet)
            {
                string[] item = { клиентыSet.id.ToString() + ".", клиентыSet.FirstName, клиентыSet.MiddleName, клиентыSet.LastName };
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listView_Appartment.SelectedItems.Count == 1)
                    {
                        ПотребностиSet потребности = listView_Appartment.SelectedItems[0].Tag as ПотребностиSet;
                        потребности.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        потребности.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        if (textboxMinPrise.Text != "")
                            потребности.MinPrice = Convert.ToInt64(textboxMinPrise.Text);
                        else потребности.MinPrice = null;
                        if (textBoxMaxPrise.Text != "")
                            потребности.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                        else потребности.MaxPrice = null;
                        if (потребности.MaxPrice < потребности.MinPrice)
                            throw new ApplicationException("цена");
                        if (textBoxMinS.Text != "")
                            потребности.MinArea = Convert.ToInt32(textBoxMinS.Text);
                        else потребности.MinArea = null;
                        if (textBoxMaxS.Text != "")
                            потребности.MaxArea = Convert.ToInt32(textBoxMaxS.Text);
                        else потребности.MaxArea = null;
                        if (потребности.MaxArea < потребности.MinArea)
                            throw new ApplicationException("площадь");
                        if (textBoxMinF.Text != "")
                            потребности.MinFloor = Convert.ToInt32(textBoxMinF.Text);
                        else потребности.MinFloor = null;
                        if (textBoxMaxF.Text != "")
                            потребности.MaxFloor = Convert.ToInt32(textBoxMaxF.Text);
                        else потребности.MaxFloor = null;
                        if (потребности.MaxFloor < потребности.MinFloor)
                            throw new Exception("этаж");
                        if (textBoxMinRoom.Text != "")
                            потребности.MinRooms = Convert.ToInt32(textBoxMinRoom.Text);
                        else потребности.MinRooms = null;
                        if (textBoxMaxRoom.Text != "")
                            потребности.MaxRooms = Convert.ToInt32(textBoxMaxRoom.Text);
                        else потребности.MaxRooms = null;
                        if (потребности.MaxRooms < потребности.MinRooms)
                            throw new AggregateException("количество комнат");
                        Program.wftDb.SaveChanges();
                        ShowПотребностиSet();
                    }
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listView_House.SelectedItems.Count == 1)
                    {
                        ПотребностиSet потребности = listView_House.SelectedItems[0].Tag as ПотребностиSet;
                        потребности.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        потребности.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        if (textboxMinPrise.Text != "")
                            потребности.MinPrice = Convert.ToInt64(textboxMinPrise.Text);
                        else потребности.MinPrice = null;
                        if (textBoxMaxPrise.Text != "")
                            потребности.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                        else потребности.MaxPrice = null;
                        if (потребности.MaxPrice < потребности.MinPrice)
                            throw new ApplicationException("цена");
                        if (textBoxMinS.Text != "")
                            потребности.MinArea = Convert.ToInt32(textBoxMinS.Text);
                        else потребности.MinArea = null;
                        if (textBoxMaxS.Text != "")
                            потребности.MaxArea = Convert.ToInt32(textBoxMaxS.Text);
                        else потребности.MaxArea = null;
                        if (потребности.MaxArea < потребности.MinArea)
                            throw new ApplicationException("площадь");
                        if (textBoxMFloors.Text != "")
                            потребности.MinFloors = Convert.ToInt32(textBoxMFloors.Text);
                        else потребности.MinFloors = null;
                        if (textBoxMaxFloors.Text != "")
                            потребности.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                        else потребности.MaxFloors = null;
                        if (потребности.MaxArea < потребности.MinArea)
                            throw new ApplicationException("этажность");
                        Program.wftDb.SaveChanges();
                        ShowПотребностиSet();
                    }
                }
                else
                {
                    if (listView_Land.SelectedItems.Count == 1)
                    {
                        ПотребностиSet потребности = listView_Land.SelectedItems[0].Tag as ПотребностиSet;
                        if (textboxMinPrise.Text != "")
                            потребности.MinPrice = Convert.ToInt64(textboxMinPrise.Text);
                        else потребности.MinPrice = null;
                        if (textBoxMaxPrise.Text != "")
                            потребности.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                        else потребности.MaxPrice = null;
                        if (потребности.MaxPrice < потребности.MinPrice)
                            throw new ApplicationException("цена");
                        if (textBoxMinS.Text != "")
                            потребности.MinArea = Convert.ToInt32(textBoxMinS.Text);
                        else потребности.MinArea = null;
                        if (textBoxMaxS.Text != "")
                            потребности.MaxArea = Convert.ToInt32(textBoxMaxS.Text);
                        else потребности.MaxArea = null;
                        if (потребности.MaxArea < потребности.MinArea)
                            throw new ApplicationException("площадь");
                        Program.wftDb.SaveChanges();
                        ShowПотребностиSet();
                    }
                }
            }
            catch (ApplicationException ex) { MessageBox.Show("Максимальная " + ex.Message + " не может быть меньше минимальной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (AggregateException ex) { MessageBox.Show("Максимальное " + ex.Message + " не может быть меньше минимального", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (Exception ex) { MessageBox.Show("Максимальный " + ex.Message + " не может быть меньше минимального", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        void ShowПотребности()
        {
            listView_Appartment.Items.Clear();
            foreach (ПотребностиSet потребности in Program.wftDb.ПотребностиSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    потребности.IdAgent.ToString(),
                    потребности.РиэлторSet.LastName+" "+потребности.РиэлторSet.FirstName+" "+потребности.РиэлторSet.MiddleName,
                    потребности.IdClient.ToString(),
                    потребности.КлиентыSet.LastName+" "+потребности.КлиентыSet.FirstName+" "+потребности.КлиентыSet.MiddleName,
                });
                item.Tag = потребности;
                listView_Appartment.Items.Add(item);
            }
        }



        void ShowПотребностиSet()
        {
            listView_Appartment.Items.Clear();
            listView_House.Items.Clear();
            listView_Land.Items.Clear();
            foreach (ПотребностиSet потребности in Program.wftDb.ПотребностиSet)
            {
                if (потребности.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        потребности.РиэлторSet.LastName+" "+потребности.РиэлторSet.FirstName+"."+потребности.РиэлторSet.MiddleName+".",
                        потребности.КлиентыSet.LastName+" "+потребности.КлиентыSet.FirstName+"."+потребности.КлиентыSet.MiddleName+".",
                        потребности.MinPrice.ToString(),
                        потребности.MaxPrice.ToString(),
                        потребности.MinArea.ToString(),
                        потребности.MaxArea.ToString(),
                        потребности.MinFloor.ToString(),
                        потребности.MaxFloor.ToString(),
                        потребности.MinRooms.ToString(),
                        потребности.MaxRooms.ToString(),
                        потребности.MinFloors.ToString(),
                        потребности.MaxFloors.ToString()
                    });
                    item.Tag = потребности;
                    listView_Appartment.Items.Add(item);
                }
                else if (потребности.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        потребности.РиэлторSet.LastName+" "+потребности.РиэлторSet.FirstName+"."+потребности.РиэлторSet.MiddleName+".",
                        потребности.КлиентыSet.LastName+" "+потребности.КлиентыSet.FirstName+"."+потребности.КлиентыSet.MiddleName+".",
                        потребности.MinPrice.ToString(),
                        потребности.MaxPrice.ToString(),
                        потребности.MinArea.ToString(),
                        потребности.MaxArea.ToString(),
                        потребности.MinFloors.ToString(),
                        потребности.MaxFloors.ToString(),
                    });
                    item.Tag = потребности;
                    listView_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        потребности.РиэлторSet.LastName+" "+потребности.РиэлторSet.FirstName+"."+потребности.РиэлторSet.MiddleName+".",
                        потребности.КлиентыSet.LastName+" "+потребности.КлиентыSet.FirstName+"."+потребности.КлиентыSet.MiddleName+".",
                        потребности.MinPrice.ToString(),
                        потребности.MaxPrice.ToString(),
                        потребности.MinArea.ToString(),
                        потребности.MaxArea.ToString(),
                    });
                    item.Tag = потребности;
                    listView_Land.Items.Add(item);
                }
                listView_Appartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listView_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void listViewПотребностиSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Appartment.SelectedItems.Count == 1)
            {
                ПотребностиSet потребности = listView_Appartment.SelectedItems[0].Tag as ПотребностиSet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(потребности.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(потребности.IdClient.ToString());
                textboxMinPrise.Text = потребности.MinPrice.ToString();
                textBoxMaxPrise.Text = потребности.MaxPrice.ToString();
                textBoxMinS.Text = потребности.MinArea.ToString();
                textBoxMaxS.Text = потребности.MaxArea.ToString();
                textBoxMinRoom.Text = потребности.MinRooms.ToString();
                textBoxMaxRoom.Text = потребности.MaxRooms.ToString();
                textBoxMinF.Text = потребности.MinFloor.ToString();
                textBoxMaxF.Text = потребности.MaxFloor.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textboxMinPrise.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxS.Text = "";
                textBoxMinRoom.Text = "";
                textBoxMaxRoom.Text = "";
                textBoxMinF.Text = "";
                textBoxMaxF.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxType != null)
                    {
                        ПотребностиSet потребности = new ПотребностиSet();
                        потребности.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        потребности.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        потребности.Type = 0;
                        if (textboxMinPrise.Text != "")
                            потребности.MinPrice = Convert.ToInt64(textboxMinPrise.Text);
                        if (textBoxMaxPrise.Text != "")
                            потребности.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                        if (потребности.MaxPrice < потребности.MinPrice) { throw new ApplicationException("цена"); }
                        if (textBoxMinS.Text != "")
                            потребности.MinArea = Convert.ToInt32(textBoxMinS.Text);
                        if (textBoxMaxS.Text != "")
                            потребности.MaxArea = Convert.ToInt32(textBoxMaxS.Text);
                        if (потребности.MaxArea < потребности.MinArea) { throw new ApplicationException("площадь"); }
                        if (textBoxMinF.Text != "")
                            потребности.MinFloor = Convert.ToInt32(textBoxMinF.Text);
                        if (textBoxMaxF.Text != "")
                            потребности.MaxFloor = Convert.ToInt32(textBoxMaxF.Text);
                        if (потребности.MaxFloor < потребности.MinFloor) { throw new Exception("этаж"); }
                        if (textBoxMinRoom.Text != "")
                            потребности.MinRooms = Convert.ToInt32(textBoxMinRoom.Text);
                        if (textBoxMaxRoom.Text != "")
                            потребности.MaxRooms = Convert.ToInt32(textBoxMaxRoom.Text);
                        if (потребности.MaxRooms < потребности.MinRooms) { throw new AggregateException("количество комнат"); }
                        Program.wftDb.ПотребностиSet.Add(потребности);
                        Program.wftDb.SaveChanges();
                        ShowПотребностиSet();
                    }
                    else MessageBox.Show("Данные не выбраны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxType != null)
                    {
                        ПотребностиSet потребности = new ПотребностиSet();
                        потребности.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        потребности.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        потребности.Type = 1;
                        if (textboxMinPrise.Text != "")
                            потребности.MinPrice = Convert.ToInt64(textboxMinPrise.Text);
                        if (textBoxMaxPrise.Text != "")
                            потребности.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                        if (потребности.MaxPrice < потребности.MinPrice) { throw new ApplicationException("цена"); }
                        if (textBoxMinS.Text != "")
                            потребности.MinArea = Convert.ToInt32(textBoxMinS.Text);
                        if (textBoxMaxS.Text != "")
                            потребности.MaxArea = Convert.ToInt32(textBoxMaxS.Text);
                        if (потребности.MaxArea < потребности.MinArea) { throw new ApplicationException("площадь"); }
                        if (textBoxMFloors.Text != "")
                            потребности.MinFloors = Convert.ToInt32(textBoxMFloors.Text);
                        if (textBoxMaxFloors.Text != "")
                            потребности.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                        if (потребности.MaxArea < потребности.MinArea) { throw new ApplicationException("этажность"); }
                        Program.wftDb.ПотребностиSet.Add(потребности);
                        Program.wftDb.SaveChanges();
                        ShowПотребностиSet();
                    }
                    else MessageBox.Show("Данные не выбраны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxType != null)
                    {
                        ПотребностиSet потребности = new ПотребностиSet();
                        потребности.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                        потребности.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                        потребности.Type = 2;
                        if (textboxMinPrise.Text != "")
                            потребности.MinPrice = Convert.ToInt64(textboxMinPrise.Text);
                        if (textBoxMaxPrise.Text != "")
                            потребности.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                        if (потребности.MaxPrice < потребности.MinPrice) { throw new ApplicationException("цена"); }
                        if (textBoxMinS.Text != "")
                            потребности.MinArea = Convert.ToInt32(textBoxMinS.Text);
                        if (textBoxMaxS.Text != "")
                            потребности.MaxArea = Convert.ToInt32(textBoxMaxS.Text);
                        if (потребности.MaxArea < потребности.MinArea) { throw new ApplicationException("площадь"); }
                        Program.wftDb.ПотребностиSet.Add(потребности);
                        Program.wftDb.SaveChanges();
                        ShowПотребностиSet();
                    }
                    else MessageBox.Show("Данные не выбраны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ApplicationException ex) { MessageBox.Show("Максимальная " + ex.Message + " не может быть меньше минимальной!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (AggregateException ex) { MessageBox.Show("Максимальное " + ex.Message + " не может быть меньше минимального!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (Exception ex) { MessageBox.Show("Максимальный " + ex.Message + " не может быть меньше минимального!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listView_Appartment.SelectedItems.Count == 1)
                    {
                        ПотребностиSet потребности = listView_Appartment.SelectedItems[0].Tag as ПотребностиSet;
                        Program.wftDb.ПотребностиSet.Remove(потребности);
                        Program.wftDb.SaveChanges();
                    }
                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    textboxMinPrise.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMinS.Text = "";
                    textBoxMaxS.Text = "";
                    textBoxMinRoom.Text = "";
                    textBoxMaxRoom.Text = "";
                    textBoxMinF.Text = "";
                    textBoxMaxF.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listView_House.SelectedItems.Count == 1)
                    {
                        ПотребностиSet потребности = listView_House.SelectedItems[0].Tag as ПотребностиSet;
                        Program.wftDb.ПотребностиSet.Remove(потребности);
                        Program.wftDb.SaveChanges();
                    }
                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    textboxMinPrise.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMinS.Text = "";
                    textBoxMaxS.Text = "";
                    textBoxMFloors.Text = "";
                    textBoxMaxFloors.Text = "";
                }
                else
                {
                    if (listView_Land.SelectedItems.Count == 1)
                    {
                        ПотребностиSet потребности = listView_Land.SelectedItems[0].Tag as ПотребностиSet;
                        Program.wftDb.ПотребностиSet.Remove(потребности);
                        Program.wftDb.SaveChanges();
                    }
                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    textboxMinPrise.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMinS.Text = "";
                    textBoxMaxS.Text = "";
                }
                ShowПотребностиSet();
            }
            catch { MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBoxMaxS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listView_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Land.SelectedItems.Count == 1)
            {
                ПотребностиSet потребности = listView_Land.SelectedItems[0].Tag as ПотребностиSet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(потребности.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(потребности.IdClient.ToString());
                textboxMinPrise.Text = потребности.MinPrice.ToString();
                textBoxMaxPrise.Text = потребности.MaxPrice.ToString();
                textBoxMinS.Text = потребности.MinArea.ToString();
                textBoxMaxS.Text = потребности.MaxArea.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textboxMinPrise.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxS.Text = "";
            }
        }

        private void listView_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_House.SelectedItems.Count == 1)
            {
                ПотребностиSet потребности = listView_House.SelectedItems[0].Tag as ПотребностиSet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(потребности.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(потребности.IdClient.ToString());
                textboxMinPrise.Text = потребности.MinPrice.ToString();
                textBoxMaxPrise.Text = потребности.MaxPrice.ToString();
                textBoxMinS.Text = потребности.MinArea.ToString();
                textBoxMaxS.Text = потребности.MaxArea.ToString();
                textBoxMFloors.Text = потребности.MinFloors.ToString();
                textBoxMaxFloors.Text = потребности.MaxFloors.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                textboxMinPrise.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxS.Text = "";
                textBoxMFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                labelMRoom.Visible = true;
                labelRoom.Visible = true;
                labelMinF.Visible = true;
                labelMaxF.Visible = true;
                labelMFloors.Visible = false;
                labelMaxFloors.Visible = false;

                textBoxMinRoom.Visible = true;
                textBoxMaxRoom.Visible = true;
                textBoxMinF.Visible = true;
                textBoxMaxF.Visible = true;
                textBoxMFloors.Visible = false;
                textBoxMFloors.Visible = false;
                textBoxMaxFloors.Visible = false;
                textboxMinPrise.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxS.Text = "";
                textBoxMinRoom.Text = "";
                textBoxMaxRoom.Text = "";
                textBoxMinF.Text = "";
                textBoxMaxF.Text = "";

                listView_Appartment.Visible = true;
                listView_House.Visible = false;
                listView_Land.Visible = false;
                ShowПотребностиSet();
            }

            else if (comboBoxType.SelectedIndex == 1)
            {
                labelMRoom.Visible = false;
                labelRoom.Visible = false;
                labelMinF.Visible = false;
                labelMaxF.Visible = false;
                labelMFloors.Visible = true;
                labelMaxFloors.Visible = true;

                textBoxMinRoom.Visible = false;
                textBoxMaxRoom.Visible = false;
                textBoxMinF.Visible = false;
                textBoxMaxF.Visible = false;
                textBoxMFloors.Visible = true;
                textBoxMaxFloors.Visible = true;
                textboxMinPrise.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMinS.Text = "";
                textBoxMaxS.Text = "";

                listView_Appartment.Visible = false;
                listView_House.Visible = true;
                listView_Land.Visible = false;
                ShowПотребностиSet();
            }
            else
            {
                labelMRoom.Visible = false;
                labelRoom.Visible = false;
                labelMinF.Visible = false;
                labelMaxF.Visible = false;
                labelMFloors.Visible = false;
                labelMaxFloors.Visible = false;

                textBoxMinRoom.Visible = false;
                textBoxMaxRoom.Visible = false;
                textBoxMinF.Visible = false;
                textBoxMaxF.Visible = false;
                textBoxMFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                listView_Appartment.Visible = false;
                listView_House.Visible = false;
                listView_Land.Visible = true;
                ShowПотребностиSet();
            }
        }

        private void lableAddress_House_Click(object sender, EventArgs e)
        {

        }

        private void labelAddress_Number_Click(object sender, EventArgs e)
        {

        }

        private void labelAddress_Street_Click(object sender, EventArgs e)
        {

        }

        private void textboxMinPrise_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMinS_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMaxPrise_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMaxFloors_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
