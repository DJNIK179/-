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
    public partial class Объекты_недвижимости : Form
    {
        public Объекты_недвижимости()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            showОбъекты_недвижимостиSet();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelAddress_City_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewRealEstateSet_Apartment.Visible = true;
                labelFloor.Visible = true;
                textBoxFloor.Visible = true;
                labelRooms.Visible = true;
                textBoxRooms.Visible = true;

                listViewRealEstateSet_House.Visible = false;
                listViewRealEstateSet_Land.Visible = false;
                labelTotalFloors.Visible = false;
                textBoxTotalFloors.Visible = false;

                textboxAddress_City.Text = " ";
                textBoxAddress_House.Text = " ";
                textBoxAddress_Street.Text = " ";
                textBoxAddress_Number.Text = " ";
                textBoxCoordinate_latitude.Text = " ";
                textBoxCoodrinate_longitude.Text = " ";
                textBoxTotalArea.Text = " ";
                textBoxRooms.Text = " ";
                textBoxFloor.Text = " ";
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewRealEstateSet_House.Visible = true;
                labelTotalFloors.Visible = true;
                textBoxTotalFloors.Visible = true;

                listViewRealEstateSet_Land.Visible = false;
                listViewRealEstateSet_Apartment.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;
                labelRooms.Visible = false;
                textBoxRooms.Visible = false;

                textboxAddress_City.Text = " ";
                textBoxAddress_House.Text = " ";
                textBoxAddress_Street.Text = " ";
                textBoxAddress_Number.Text = " ";
                textBoxCoordinate_latitude.Text = " ";
                textBoxCoodrinate_longitude.Text = " ";
                textBoxTotalArea.Text = " ";
                textBoxTotalFloors.Text = " ";
            }
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewRealEstateSet_Land.Visible = true;

                listViewRealEstateSet_House.Visible = false;
                listViewRealEstateSet_Apartment.Visible = false;
                labelFloor.Visible = false;
                textBoxFloor.Visible = false;
                labelRooms.Visible = false;
                textBoxRooms.Visible = false;
                labelTotalFloors.Visible = false;
                textBoxTotalFloors.Visible = false;

                textboxAddress_City.Text = " ";
                textBoxAddress_House.Text = " ";
                textBoxAddress_Street.Text = " ";
                textBoxAddress_Number.Text = " ";
                textBoxCoordinate_latitude.Text = " ";
                textBoxCoodrinate_longitude.Text = " ";
                textBoxTotalArea.Text = " ";
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        void showОбъекты_недвижимостиSet()
        {
            listViewRealEstateSet_Apartment.Items.Clear();
            listViewRealEstateSet_House.Items.Clear();
            listViewRealEstateSet_Land.Items.Clear();

            foreach (Объекты_недвижимостиSet объекты_недвижимости in Program.wftDb.Объекты_недвижимостиSet)
            {
                if (объекты_недвижимости.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        объекты_недвижимости.Address_City, объекты_недвижимости.Address_Street, объекты_недвижимости.Address_House,
                        объекты_недвижимости.Address_Number, объекты_недвижимости.Coordinate_latitude.ToString(),
                        объекты_недвижимости.Rooms.ToString(), объекты_недвижимости.Floor.ToString()
                    });

                    item.Tag = item.Tag = объекты_недвижимости;

                    listViewRealEstateSet_Apartment.Items.Add(item);
                }
                else if (объекты_недвижимости.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        объекты_недвижимости.Address_City, объекты_недвижимости.Address_Street, объекты_недвижимости.Address_House,
                        объекты_недвижимости.Address_Number, объекты_недвижимости.Coordinate_latitude.ToString(),
                        объекты_недвижимости.Coordinate_longitude.ToString(), объекты_недвижимости.TotalArea.ToString(),
                        объекты_недвижимости.TotalFloors.ToString()

                    });

                    item.Tag = объекты_недвижимости;

                    listViewRealEstateSet_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        объекты_недвижимости.Address_City, объекты_недвижимости.Address_Street, объекты_недвижимости.Address_House, объекты_недвижимости.Address_Number, объекты_недвижимости.Coordinate_latitude.ToString(), объекты_недвижимости.Coordinate_longitude.ToString(), объекты_недвижимости.TotalArea.ToString()
                    });

                    item.Tag = объекты_недвижимости;
                    listViewRealEstateSet_Land.Items.Add(item);
                }
            }

            listViewRealEstateSet_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewRealEstateSet_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewRealEstateSet_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Объекты_недвижимостиSet объекты_недвижимости = new Объекты_недвижимостиSet();
            объекты_недвижимости.Address_City = textboxAddress_City.Text;
            объекты_недвижимости.Address_House = textBoxAddress_House.Text;
            объекты_недвижимости.Address_Street = textBoxAddress_Street.Text;
            объекты_недвижимости.Address_Number = textBoxAddress_Number.Text;
            объекты_недвижимости.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
            объекты_недвижимости.Coordinate_longitude = Convert.ToDouble(textBoxCoodrinate_longitude.Text);
            объекты_недвижимости.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);

            if (comboBoxType.SelectedIndex == 0)
            {
                объекты_недвижимости.Type = 0;
                объекты_недвижимости.Rooms = Convert.ToInt32(textBoxRooms.Text);
                объекты_недвижимости.Floor = Convert.ToInt32(textBoxFloor.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                объекты_недвижимости.Type = 1;
                if (textBoxTotalFloors.Text != "") { объекты_недвижимости.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text); }
            }
            
            else
            {
                объекты_недвижимости.Type = 2;
            }

            Program.wftDb.Объекты_недвижимостиSet.Add(объекты_недвижимости);
            Program.wftDb.SaveChanges();
            showОбъекты_недвижимостиSet();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    Объекты_недвижимостиSet объекты_недвижимости = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as Объекты_недвижимостиSet;
                    объекты_недвижимости.Address_City = textboxAddress_City.Text;
                    объекты_недвижимости.Address_House = textBoxAddress_House.Text;
                    объекты_недвижимости.Address_Street = textBoxAddress_Street.Text;
                    объекты_недвижимости.Address_Number = textBoxAddress_Number.Text;
                    объекты_недвижимости.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    объекты_недвижимости.Coordinate_longitude = Convert.ToDouble(textBoxCoodrinate_longitude.Text);
                    объекты_недвижимости.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    объекты_недвижимости.Rooms = Convert.ToInt32(textBoxRooms.Text);
                    объекты_недвижимости.Floor = Convert.ToInt32(textBoxFloor.Text);

                    Program.wftDb.SaveChanges();
                    showОбъекты_недвижимостиSet();
                }
            }

            else if (comboBoxType.SelectedIndex == 1)
            {
               
                if (listViewRealEstateSet_House.SelectedItems.Count == 1)
                {

                    Объекты_недвижимостиSet объекты_недвижимости = listViewRealEstateSet_House.SelectedItems[0].Tag as Объекты_недвижимостиSet;

                    объекты_недвижимости.Address_City = textboxAddress_City.Text;
                    объекты_недвижимости.Address_House = textBoxAddress_House.Text;
                    объекты_недвижимости.Address_Street = textBoxAddress_Street.Text;
                    объекты_недвижимости.Address_Number = textBoxAddress_Number.Text;
                    if (textBoxCoordinate_latitude.Text != "")
                        объекты_недвижимости.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    if (textBoxCoodrinate_longitude.Text != "")
                        объекты_недвижимости.Coordinate_longitude = Convert.ToDouble(textBoxCoodrinate_longitude.Text);
                    if (textBoxTotalArea.Text != "")
                        объекты_недвижимости.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    if (textBoxTotalFloors.Text != "")
                        объекты_недвижимости.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text);

                    Program.wftDb.SaveChanges();
                    showОбъекты_недвижимостиSet();
                }
            }
            else
            {

                if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
                {
                    Объекты_недвижимостиSet объекты_недвижимости = listViewRealEstateSet_Land.SelectedItems[0].Tag as Объекты_недвижимостиSet;
                    объекты_недвижимости.Address_City = textboxAddress_City.Text;
                    объекты_недвижимости.Address_House = textBoxAddress_House.Text;
                    объекты_недвижимости.Address_Street = textBoxAddress_Street.Text;
                    объекты_недвижимости.Address_Number = textBoxAddress_Number.Text;
                    if (textBoxCoordinate_latitude.Text != "")
                        объекты_недвижимости.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    if (textBoxCoodrinate_longitude.Text != "")
                        объекты_недвижимости.Coordinate_longitude = Convert.ToDouble(textBoxCoodrinate_longitude.Text);
                    if (textBoxTotalArea.Text != "")
                        объекты_недвижимости.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    Program.wftDb.SaveChanges();
                    showОбъекты_недвижимостиSet();
                }
            }


        }
        private void listViewRealEstateSet_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
            {
                Объекты_недвижимостиSet объекты_Недвижимости = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as Объекты_недвижимостиSet;

                textboxAddress_City.Text = объекты_Недвижимости.Address_City;
                textBoxAddress_Street.Text = объекты_Недвижимости.Address_Street;
                textBoxAddress_House.Text = объекты_Недвижимости.Address_House;
                textBoxAddress_Number.Text = объекты_Недвижимости.Address_Number;
                textBoxCoordinate_latitude.Text = объекты_Недвижимости.Coordinate_latitude.ToString();
                textBoxCoodrinate_longitude.Text = объекты_Недвижимости.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = объекты_Недвижимости.TotalArea.ToString();
                textBoxRooms.Text = объекты_Недвижимости.Rooms.ToString();
                textBoxFloor.Text = объекты_Недвижимости.Floor.ToString();

            }
            else
            {
                textboxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoodrinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";

            }
        }

        private void listViewRealEstateSet_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_House.SelectedItems.Count == 1)
            {
                Объекты_недвижимостиSet объекты_Недвижимости = listViewRealEstateSet_House.SelectedItems[0].Tag as Объекты_недвижимостиSet;

                textboxAddress_City.Text = объекты_Недвижимости.Address_City;
                textBoxAddress_Street.Text = объекты_Недвижимости.Address_Street;
                textBoxAddress_House.Text = объекты_Недвижимости.Address_House;
                textBoxAddress_Number.Text = объекты_Недвижимости.Address_Number;
                textBoxCoordinate_latitude.Text = объекты_Недвижимости.Coordinate_latitude.ToString();
                textBoxCoodrinate_longitude.Text = объекты_Недвижимости.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = объекты_Недвижимости.TotalArea.ToString();
                textBoxRooms.Text = объекты_Недвижимости.Rooms.ToString();
                textBoxFloor.Text = объекты_Недвижимости.Floor.ToString();
            }
            else
            {
                textboxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoodrinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }
        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
            {
                Объекты_недвижимостиSet объекты_Недвижимости = listViewRealEstateSet_Land.SelectedItems[0].Tag as Объекты_недвижимостиSet;

                textboxAddress_City.Text = объекты_Недвижимости.Address_City;
                textBoxAddress_Street.Text = объекты_Недвижимости.Address_Street;
                textBoxAddress_House.Text = объекты_Недвижимости.Address_House;
                textBoxAddress_Number.Text = объекты_Недвижимости.Address_Number;
                textBoxCoordinate_latitude.Text = объекты_Недвижимости.Coordinate_latitude.ToString();
                textBoxCoodrinate_longitude.Text = объекты_Недвижимости.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = объекты_Недвижимости.TotalArea.ToString();
                textBoxRooms.Text = объекты_Недвижимости.Rooms.ToString();
                textBoxFloor.Text = объекты_Недвижимости.Floor.ToString();
            }
            else
            {
                textboxAddress_City.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoodrinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                    {
                        Объекты_недвижимостиSet объекты_Недвижимости = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as Объекты_недвижимостиSet;
                        Program.wftDb.Объекты_недвижимостиSet.Remove(объекты_Недвижимости);
                        Program.wftDb.SaveChanges();
                        showОбъекты_недвижимостиSet();
                    }
                    textboxAddress_City.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_latitude.Text = "";
                    textBoxCoodrinate_longitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxRooms.Text = "";
                    textBoxFloor.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewRealEstateSet_House.SelectedItems.Count == 1)
                    {
                        Объекты_недвижимостиSet объекты_Недвижимости = listViewRealEstateSet_House.SelectedItems[0].Tag as Объекты_недвижимостиSet;
                        Program.wftDb.Объекты_недвижимостиSet.Remove(объекты_Недвижимости);
                        Program.wftDb.SaveChanges();
                        showОбъекты_недвижимостиSet();
                    }
                    textboxAddress_City.Text = "";
                    textBoxAddress_Street.Text = "";
                    textBoxAddress_House.Text = "";
                    textBoxAddress_Number.Text = "";
                    textBoxCoordinate_latitude.Text = "";
                    textBoxCoodrinate_longitude.Text = "";
                    textBoxTotalArea.Text = "";
                    textBoxTotalFloors.Text = "";
                }
                else
                {
                    if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
                    {
                        Объекты_недвижимостиSet объекты_Недвижимости = listViewRealEstateSet_Land.SelectedItems[0].Tag as Объекты_недвижимостиSet;
                        Program.wftDb.Объекты_недвижимостиSet.Remove(объекты_Недвижимости);
                        Program.wftDb.SaveChanges();
                        showОбъекты_недвижимостиSet();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
