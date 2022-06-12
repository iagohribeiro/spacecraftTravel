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
using System.Threading;

namespace isarAssignment
{
    
    public partial class s : Form
    {
        private JsonData data;
        private double maxDistanceSupported = 0;
        private double availableDistance = 0;
        private Planet lastItemSelected = null;
        private int lastTemperatureSignal = 0;
        private String inputPath = "";
        private String savedFilePath = "";
        private String file = "";
        public s()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capacity_ComboBox.Enabled = false;
            destination_comboBox.Enabled = false;
            destination_listBox.Enabled = false;
            route_textBox.Enabled = false;
            createRoute_button.Enabled = false;
            save_route_button.Enabled = false;
            route_textBox.ReadOnly = true;
            route_textBox.BackColor = Color.White;
            spacecraft_ComboBox.Text = "Please Select a SpaceCraft";

            //using the full path for testing purpose. It will be changed in the final version.
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
        }

        private void spacecraft_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int capacity = 0;

            if (spacecraft_ComboBox.SelectedItem.ToString() == "Please Select a Spacecraft")
            {
                capacity_ComboBox.Enabled = false;
                destination_comboBox.Enabled = false;
                destination_listBox.Enabled = false;
                route_textBox.Enabled = false;
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
                destination_listBox.Items.Clear();
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
            route_textBox.Enabled = true;
            createRoute_button.Enabled = true;
            save_route_button.Enabled = true;

            foreach (Spacecrafts item in data.Spacecrafts)
            {
                if (item.Name != null && spacecraft_ComboBox.SelectedItem != null)
                {
                    if (spacecraft_ComboBox.SelectedItem.ToString() == item.Name)
                    {
                        maxDistanceSupported = item.MaxTravelDistance * (1 - (0.3 / (float)item.Capacity) * (float)int.Parse(capacity_ComboBox.SelectedItem.ToString()));
                        break;
                    }
                }
            }
            availableDistance = maxDistanceSupported;

            destination_comboBox.Items.Clear();
            destination_listBox.Items.Clear();
            route_textBox.Clear();

            foreach (Planet item in data.Planet)
            {
                if (item.Name != null)
                {
                    if (item.Name.ToLower() != "earth")
                    {
                        if (item.distanceFromEarth * 2 <= maxDistanceSupported)
                            destination_comboBox.Items.Add(item.Name);
                    }
                }
            }
        }

        private void destination_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItemName = destination_comboBox.SelectedItem.ToString();
            Planet itemSelected = null;
            int temperatureSignal = 0;

            destination_listBox.Items.Add(selectedItemName);

            destination_comboBox.Items.Clear();
            Console.WriteLine("Distancia disponivel Antes: " + availableDistance);
            Console.WriteLine("Distancia disponivel Antes: " + maxDistanceSupported);

            foreach (Planet item in data.Planet)
            {
                if (item.Name != null)
                {
                    if (item.Name.ToLower() == selectedItemName.ToLower())
                    {
                        itemSelected = item;

                        if(item.averageTemperature > 0)
                        {
                            temperatureSignal = 1;
                        }
                        else
                        {
                            temperatureSignal = -1;
                        }
                        break;
                    }
                }
            }

            Console.WriteLine("Quantidade Itens: " + destination_listBox.Items.Count);
            //recalcule availability
            if (destination_listBox.Items.Count <= 1)
            {
                if (itemSelected != null)
                    availableDistance = availableDistance - itemSelected.distanceFromEarth;
            }
            else
            {
                if (lastTemperatureSignal > 0)
                {
                    if (temperatureSignal > 0)
                    {
                        if (itemSelected.distanceFromEarth >= lastItemSelected.distanceFromEarth)
                        {
                            availableDistance = availableDistance - (itemSelected.distanceFromEarth - lastItemSelected.distanceFromEarth);
                        }
                        else
                        {
                            availableDistance = availableDistance - (lastItemSelected.distanceFromEarth - itemSelected.distanceFromEarth);
                        }
                    }
                    else
                    {
                        availableDistance = availableDistance - (lastItemSelected.distanceFromEarth + itemSelected.distanceFromEarth);

                    }
                }
                else
                {
                    if (temperatureSignal < 0)
                    {
                        if (itemSelected.distanceFromEarth >= lastItemSelected.distanceFromEarth)
                        {
                            availableDistance = availableDistance - (itemSelected.distanceFromEarth - lastItemSelected.distanceFromEarth);
                        }
                        else
                        {
                            availableDistance = availableDistance - (lastItemSelected.distanceFromEarth - itemSelected.distanceFromEarth);
                        }
                    }
                    else
                    {
                        availableDistance = availableDistance - (lastItemSelected.distanceFromEarth + itemSelected.distanceFromEarth);

                    }

                }
            }

            lastItemSelected = itemSelected;
            lastTemperatureSignal = temperatureSignal;

            Console.WriteLine("Distancia disponivel: " + availableDistance);
            Console.WriteLine("Item Selecionado: " + selectedItemName);

            if (itemSelected != null)
            {
                foreach (Planet item in data.Planet)
                {
                    double newDistance = 0;

                    if (item.Name != null)
                    {
                        if (item.Name.ToLower() != "earth" && item.Name.ToLower() != selectedItemName.ToLower())
                        {
                            if (temperatureSignal > 0)
                            {
                                if(item.averageTemperature >= 0)
                                {
                                    if (item.distanceFromEarth >= itemSelected.distanceFromEarth)
                                    {
                                        newDistance = availableDistance - ((item.distanceFromEarth - itemSelected.distanceFromEarth) + item.distanceFromEarth);

                                        if (newDistance >= 0)
                                        {
                                            destination_comboBox.Items.Add(item.Name);
                                        }
                                    }
                                    else
                                    {
                                        if (itemSelected.distanceFromEarth >= 0)
                                            destination_comboBox.Items.Add(item.Name);
                                    }
                                }
                                else
                                {
                                    newDistance = availableDistance - (item.distanceFromEarth * 2 + itemSelected.distanceFromEarth);

                                    if (newDistance >= 0)
                                    {
                                        destination_comboBox.Items.Add(item.Name);
                                    }
                                }
                                    
                            }
                            else if(temperatureSignal < 0)
                            {
                                if (item.averageTemperature < 0)
                                {
                                    if (item.distanceFromEarth >= itemSelected.distanceFromEarth)
                                    {
                                        newDistance = availableDistance - ((item.distanceFromEarth - itemSelected.distanceFromEarth) + item.distanceFromEarth);

                                        if (newDistance >= 0)
                                        {
                                            destination_comboBox.Items.Add(item.Name);
                                        }
                                    }
                                    else
                                    {
                                        if (itemSelected.distanceFromEarth >= 0)
                                            destination_comboBox.Items.Add(item.Name);
                                    }
                                }
                                else
                                {
                                    newDistance = availableDistance - (item.distanceFromEarth * 2 + itemSelected.distanceFromEarth);

                                    if (newDistance >= 0)
                                    {
                                        destination_comboBox.Items.Add(item.Name);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void destination_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemToRemove = destination_listBox.SelectedIndex;

            if (itemToRemove != -1)
                destination_listBox.Items.RemoveAt(itemToRemove);
        }

        private void createRoute_button_Click(object sender, EventArgs e)
        {
            String routeCreated = "Earth";

            route_textBox.Text = "User Created Route:\r\n\r\n";
            for (int index =0; index < destination_listBox.Items.Count; index++)
                routeCreated = routeCreated + " > " +destination_listBox.Items[index].ToString();
            
            route_textBox.Text = route_textBox.Text + routeCreated + " > "+ "Earth\r\n\r\n";
            route_textBox.Text = route_textBox.Text + "Distance the spacecraft can still travel: " + availableDistance;
        }

        private void openDialog()
        {
            Thread thread = new Thread(new ThreadStart(this.saveFile));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        [STAThread]
        private void save_route_button_Click(object sender, EventArgs e)
        {
            file = "";
            //---------- General Data -------------------
            file = file + "[GENERAL]\r\n";
            file = file + "maxDistanceSupported: " + maxDistanceSupported + "\r\n";
            file = file + "availableDistance: " + availableDistance + "\r\n";
            file = file + "inputPath: " + inputPath + "\r\n";

            //--------- Route Data --------------
            file = file + "\r\n[ROUTE]\r\n";
            for (int index = 0; index < destination_listBox.Items.Count; index++)
                file = file + destination_listBox.Items[index].ToString() + "\r\n";

            //--------- Route Result --------------
            file = file + "\r\n[ROUTE RESULT]\r\n";
                file = file + route_textBox.Text + "\r\n";

            openDialog();

        }

        [STAThread]
        public void saveFile ()
        {
            saveFileDialog1.Title = "Save Route File";
            saveFileDialog1.Filter = "Text File|.txt";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = "Route_File_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.InitialDirectory = @"..\\";
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.CheckPathExists = true;

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(file);

                writer.Close();

                MessageBox.Show("File Saved Successfully!");
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation was canceled");
            }
        }

    }
}
