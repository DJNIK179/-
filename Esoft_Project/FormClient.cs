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
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
            ShowClient();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //условие, если в listView выбран 1 элемент
            if (listViewClient.SelectedItems.Count == 1)
            {
                //ищем элемент из таблицы по тегу
                КлиентыSet clientSet = listViewClient.SelectedItems[0].Tag as КлиентыSet;
                //указываем, что может быть изменено
                clientSet.FirstName = textBoxFirstName.Text;
                clientSet.MiddleName = textBoxMiddleName.Text;
                clientSet.LastName = textBoxLastName.Text;
                clientSet.Phone = textBoxPhone.Text;
                clientSet.Email = textBoxEmail.Text;
                //cохраняем изменения в модели wtfDb (экземпляр которой был создан ранее)
                Program.wftDb.SaveChanges();
                //отображаем listView
                ShowClient();
            }
        }

        void ShowClient()
        {
            listViewClient.Items.Clear();
            foreach (КлиентыSet клиентыSet in Program.wftDb.КлиентыSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    клиентыSet.id.ToString() , клиентыSet.FirstName, клиентыSet.MiddleName, клиентыSet.LastName, клиентыSet.Phone, клиентыSet.Email
                });
                item.Tag = клиентыSet;
                listViewClient.Items.Add(item);
            }
            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //создаём новый экземпляр класса Клиент
            КлиентыSet clientSet = new КлиентыSet();
            //делаем ссылку на объект, который хранится в textBox-ax
            clientSet.FirstName = textBoxFirstName.Text;
            clientSet.MiddleName = textBoxMiddleName.Text;
            clientSet.LastName = textBoxLastName.Text;
            clientSet.Phone = textBoxPhone.Text;
            clientSet.Email = textBoxEmail.Text;
            //Добавляем в таблицу ClientSet нового клиента clientSet
            Program.wftDb.КлиентыSet.Add(clientSet);
            //Сохраняем изменения в модели wftDb (экземпляр который создан ранее)
            Program.wftDb.SaveChanges();
            ShowClient();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //пробуем совершить действие
            try
            {
                //если выбран 1 эл. из листа
                if (listViewClient.SelectedItems.Count == 1)
                {
                    КлиентыSet clientSet = listViewClient.SelectedItems[0].Tag as КлиентыSet;
                    Program.wftDb.КлиентыSet.Remove(clientSet);
                    Program.wftDb.SaveChanges();
                    ShowClient();
                }
                //очищаем
                textBoxFirstName.Text = " ";
                textBoxMiddleName.Text = " ";
                textBoxLastName.Text = " ";
                textBoxPhone.Text = " ";
                textBoxEmail.Text = " ";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эту запись используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                КлиентыSet clientSet = listViewClient.SelectedItems[0].Tag as КлиентыSet;
                textBoxFirstName.Text = clientSet.FirstName;
                textBoxMiddleName.Text = clientSet.MiddleName;
                textBoxLastName.Text = clientSet.LastName;
                textBoxPhone.Text = clientSet.Phone;
                textBoxEmail.Text = clientSet.Email;
            }
            else
            {
                //условие, иначе, если не выбран ни один элемент, то задаем пустые поля
                textBoxFirstName.Text = " ";
                textBoxMiddleName.Text = " ";
                textBoxLastName.Text = " ";
                textBoxPhone.Text = " ";
                textBoxEmail.Text = " ";
            }
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
