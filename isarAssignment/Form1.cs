using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace isarAssignment
{
    
    public partial class s : Form
    {
        private JsonData data;
        public s()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capacity_ComboBox.Enabled = false;
            destination_comboBox.Enabled = false;
            destination_listBox.Enabled = false;
            route_listBox.Enabled = false;
            createRoute_button.Enabled = false;
            save_route_button.Enabled = false;

            spacecraft_ComboBox.Text = "Please Select a SpaceCraft";

            //using the full path for testing purpose. It will be change in the final version.
            using (StreamReader r = new StreamReader("C:\\Users\\Iagoh Ribeiro Lima\\Downloads\\DotNetAssignment\\data.json"))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<JsonData>(json);
            }

            //Console.WriteLine(data.Spacecrafts[0].Name);
            spacecraft_ComboBox.Items.Add("Please Select a Spacecraft");

            foreach (Spacecrafts item in data.Spacecrafts)
            {
                if (item.Name != null)
                {
                    spacecraft_ComboBox.Items.Add(item.Name);
                }
            }

            foreach (Planet item in data.Planet)
            {
                if (item.Name != null)
                {
                    destination_comboBox.Items.Add(item.Name);
                }
            }
        }

        private void spacecraft_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int capacity = 0;

            if (spacecraft_ComboBox.SelectedItem.ToString() == "Please Select a Spacecraft")
            {
                capacity_ComboBox.Enabled = false;
                destination_comboBox.Enabled = false;
                destination_listBox.Enabled = false;
                route_listBox.Enabled = false;
                createRoute_button.Enabled = false;
                save_route_button.Enabled = false;
                capacity_ComboBox.Text = "";
            }
            else
            {
                foreach (Spacecrafts item in data.Spacecrafts)
                {
                    if (item.Name != null && spacecraft_ComboBox.SelectedItem != null)
                    {
                        if (spacecraft_ComboBox.SelectedItem.ToString() == item.Name)
                        {
                            capacity = item.Capacity;
                            break;
                        }
                    }
                }

                capacity_ComboBox.Items.Clear();
                capacity_ComboBox.Text = "";
                capacity_ComboBox.Enabled = true;
                for (int index = 0; index < capacity; index++)
                {
                    capacity_ComboBox.Items.Add(index + 1);
                }
            }
        }

        private void capacity_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            destination_comboBox.Enabled = true;
            destination_listBox.Enabled = true;
            route_listBox.Enabled = true;
            createRoute_button.Enabled = true;
            save_route_button.Enabled = true;
        }

        private void destination_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            destination_listBox.Items.Add(destination_comboBox.SelectedItem.ToString());
        }

        private void destination_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemToRemove = destination_listBox.SelectedItem;
            //Console.WriteLine(destination_listBox.SelectedItems.ToString());
            destination_listBox.Items.Remove(itemToRemove);
        }
    }
}
