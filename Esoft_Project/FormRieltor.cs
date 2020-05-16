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
    public partial class FormRieltor : Form
    {
        public FormRieltor()
        {
            InitializeComponent();
            ShowRieltor();
        }

        void ShowRieltor()
        {
            listViewRieltor.Items.Clear();
            foreach (РиэлторSet риэлторSet in Program.wftDb.РиэлторSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    риэлторSet.id.ToString() , риэлторSet.FirstName, риэлторSet.MiddleName, риэлторSet.LastName, риэлторSet.DealShare.ToString()
                });
                item.Tag = риэлторSet;
                listViewRieltor.Items.Add(item);
            }
            listViewRieltor.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void FormRieltor_Load(object sender, EventArgs e)
        {
            
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRieltor.SelectedItems.Count == 1)
            {
                РиэлторSet риэлторSet = listViewRieltor.SelectedItems[0].Tag as РиэлторSet;
                textBoxFirstName.Text = риэлторSet.FirstName;
                textBoxMiddleName.Text = риэлторSet.MiddleName;
                textBoxLastName.Text = риэлторSet.LastName;
                textBoxDealShare.Text = риэлторSet.DealShare.ToString();
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                РиэлторSet риэлторSet = new РиэлторSet();

                риэлторSet.FirstName = textBoxFirstName.Text;
                риэлторSet.MiddleName = textBoxMiddleName.Text;
                риэлторSet.LastName = textBoxLastName.Text;
                if (textBoxDealShare.Text != "")
                    риэлторSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                if (риэлторSet.FirstName == "" || риэлторSet.MiddleName == "" || риэлторSet.LastName == "")
                {
                    throw new Exception("Заполните ФИО");
                }
                if (риэлторSet.DealShare < 0 || риэлторSet.DealShare > 100)
                {
                    throw new Exception("Доля от комиссии: от 0 до 100");
                }
                Program.wftDb.РиэлторSet.Add(риэлторSet);

                Program.wftDb.SaveChanges();
                ShowRieltor();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void textBoxDealShare_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (listViewRieltor.SelectedItems.Count == 1)
                {
                    РиэлторSet риэлторSet = listViewRieltor.SelectedItems[0].Tag as РиэлторSet;
                    Program.wftDb.РиэлторSet.Remove(риэлторSet);
                    Program.wftDb.SaveChanges();
                    ShowRieltor();
                }
                
                textBoxFirstName.Text = " ";
                textBoxMiddleName.Text = " ";
                textBoxLastName.Text = " ";
                textBoxDealShare.Text = " ";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эту запись используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewRieltor.SelectedItems.Count == 1)
                {
                    //ищем элемент из таблицы по тегу
                    РиэлторSet риэлторSet = listViewRieltor.SelectedItems[0].Tag as РиэлторSet;
                    //указываем, что может быть изменено
                    риэлторSet.FirstName = textBoxFirstName.Text;
                    риэлторSet.MiddleName = textBoxMiddleName.Text;
                    риэлторSet.LastName = textBoxLastName.Text;
                    риэлторSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                    if (textBoxDealShare.Text != "")
                        риэлторSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                    if (риэлторSet.FirstName == "" || риэлторSet.MiddleName == "" || риэлторSet.LastName == "")
                    {
                        throw new Exception("Заполните ФИО");
                    }
                    if (риэлторSet.DealShare < 0 || риэлторSet.DealShare > 100)
                    {
                        throw new Exception("Доля от комиссии: от 0 до 100");
                    }
                    //cохраняем изменения в модели wtfDb (экземпляр которой был создан ранее)
                    Program.wftDb.SaveChanges();
                    //отображаем listView
                    ShowRieltor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
