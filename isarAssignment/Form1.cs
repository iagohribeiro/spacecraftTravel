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
        private JsonData data = null;
        private double maxDistanceSupported = 0;
        private double availableDistance = 0;
        private Planet lastItemSelected = null;
        private int lastTemperatureSignal = 0;
        private String inputPath = "";
        private String savedFilePath = "";
        private String file = "";
        private String loadSpacecraft = "";
        private String loadCapacity = "";
        private String loadDestinationItems = "";
        private String loadText = "";
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

            //Read the data json to populate the data attibute
            try
            {
                using (StreamReader r = new StreamReader("..\\..\\doc\\data.json"))
                {
                    string json = r.ReadToEnd();
                    data = JsonConvert.DeserializeObject<JsonData>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(ex.Message);
            }

            spacecraft_ComboBox.Text = "Please Select a Spacecraft";

            //Populates the spacecraft combox from the data obtained from the json file
            if (data != null)
            {
                try
                {
                    foreach (Spacecrafts item in data.Spacecrafts)
                    {
                        if (item.Name != null)
                        {
                            spacecraft_ComboBox.Items.Add(item.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Item cannot be added to spaceships list: ");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("The file could not be read correctly.");
            }
        }

        private void spacecraft_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int capacity = 0;

            //Checks if there is already a spacecraft selected to keeo some fields blocked
            if (spacecraft_ComboBox.Text.ToString().ToLower() == "Please Select a Spacecraft".ToLower())
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
                /*
                 * With each change of item selected in the spacecraft comboBox,
                 * the variable capacity will be updated to be able to populate the
                 * comboBox with the amount of passengers that the user can choose
                 */
                try
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

                    if (loadCapacity != "")
                    {
                        capacity_ComboBox.SelectedItem = int.Parse(loadCapacity);
                        Console.WriteLine(loadCapacity);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Item cannot be added to the comboBox: ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        private void capacity_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //After choosing the capacity, all fields on the main page can be activated.
            destination_comboBox.Enabled = true;
            destination_listBox.Enabled = true;
            route_textBox.Enabled = true;
            createRoute_button.Enabled = true;
            save_route_button.Enabled = true;

            try
            {
                foreach (Spacecrafts item in data.Spacecrafts)
                {
                    if (item.Name != null && spacecraft_ComboBox.SelectedItem != null && capacity_ComboBox.SelectedItem != null)
                    {
                        if (spacecraft_ComboBox.SelectedItem.ToString().ToLower() == item.Name.ToLower())
                        {
                            /* Calculating the maximum distance that the spacecraft can travel after choosing the
                             * number of passengers. The Equation is detailed in the link:
                             * https://github.com/iagohribeiro/spacecraftTravel#destination
                             */
                            maxDistanceSupported = item.MaxTravelDistance * (1 - (0.3 / (float)item.Capacity) * (float)int.Parse(capacity_ComboBox.SelectedItem.ToString()));
                            break;
                        }
                    }
                }
                availableDistance = maxDistanceSupported;

                destination_comboBox.Items.Clear();
                destination_listBox.Items.Clear();
                route_textBox.Clear();

                /* Pupulate the destination box, considering that the departure will be from Earth. In addition,
                 * it only adds the destinations that the spacecraft is able to go from its maximum distance
                 * calculated previously.
                 */
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
            catch (Exception ex)
            {
                Console.WriteLine("Item cannot be added to the comboBox: ");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void destination_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItemName = "";
            Planet itemSelected = null;
            int temperatureSignal = 0;

            if (destination_comboBox.SelectedItem != null)
            {
                selectedItemName = destination_comboBox.SelectedItem.ToString();
            }
            else
            {
                Console.WriteLine("No items were selected");
            }

            destination_listBox.Items.Add(selectedItemName);
            destination_comboBox.Items.Clear();

            //Assuming that the planets are aligned on a temperature ruler, let's get what the temperature signal of the selected planet is.
            if (data != null && data.Planet != null)
            {
                foreach (Planet item in data.Planet)
                {
                    if (item.Name != null)
                    {
                        if (item.Name.ToLower() == selectedItemName.ToLower())
                        {
                            itemSelected = item;

                            if (item.averageTemperature > 0)
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
            }
            else
            {
                Console.WriteLine("Could not get temperature signal!");
            }

            /* He we are assuming that the planets are aligned on a temperature ruler.
             * 
             * Checks if the planet was the first chosen from the list of destinations and, if so, recalculates
             * the available distance by decreasing its distance to the distance from Earth.
             * 
             * If not the first selected. Checks which signal of the temperature of the last selected destination.
             * 
             * If the temperature signal of the current destination is the same as the previous one: 
             * * After that, it checks if the earth distance of the selected item is smaller than the previously selected
             *   item, then considers the distance between the two planets. If the distance from the earth of the selected
             *   item is smaller than the distance of the previously selected item, also the distance between the two planets
             *   is considered in the account.
             * 
             * If the temperature signal of the current destination is different from the previous one:
             * * It has to be considered the distance from the earth of the two planets, since the earth will possibly be in
             *   the middle of them.
             */

            if (itemSelected != null)
            {
                if (destination_listBox.Items.Count <= 1)
                {
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
            }
            else
            {
                Console.WriteLine("Could not calculate the available Distance!");
            }

            lastItemSelected = itemSelected;
            lastTemperatureSignal = temperatureSignal;

            /* After calculating the available distance of the spacecraft. It is calculated, considering 
             * the available distance and the last chosen planet, which planets the spacecraft is able
             * to visit to fill the destination comboBox again.*/
            if (itemSelected != null)
            {
                if (data != null && data.Planet != null)
                {
                    foreach (Planet item in data.Planet)
                    {
                        double newDistance = 0;

                        if (item.Name != null)
                        {
                            if (item.Name.ToLower() != selectedItemName.ToLower())
                            {
                                if (temperatureSignal > 0)
                                {
                                    if (item.averageTemperature >= 0)
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
                                else if (temperatureSignal < 0)
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
            else
            {
                Console.WriteLine("No items were selected");
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
            //The starting point will always be the earth
            String routeCreated = "Earth";

            //The route structure will be created to be printed from the TextBox to the user.
            route_textBox.Text = "User Created Route:\r\n\r\n";

            for (int index = 0; index < destination_listBox.Items.Count; index++)
            {
                if (!(destination_listBox.Items[index].ToString().ToLower() == "earth" && index + 1 >= destination_listBox.Items.Count))
                    routeCreated = routeCreated + " > " + destination_listBox.Items[index].ToString();
            }

            //Add earth at the end since spacecraft always have to return earth
            route_textBox.Text = route_textBox.Text + routeCreated + " > " + "Earth\r\n\r\n";
            route_textBox.Text = route_textBox.Text + "Distance the spacecraft can still travel: " + availableDistance;
        }

        private void openDialog(String type)
        {
            if (type == "save")
            {
                Thread thread = new Thread(new ThreadStart(this.saveFile));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(this.loadFile));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
                thread.Join();
            }
        }

        [STAThread]
        private void save_route_button_Click(object sender, EventArgs e)
        {
            file = "";
            //---------- General Data -------------------
            file = file + "[GENERAL]\r\n";
            file = file + "maxDistanceSupported:" + maxDistanceSupported + "\r\n";
            file = file + "availableDistance:" + availableDistance + "\r\n";
            file = file + "inputPath:" + inputPath + "\r\n";
            file = file + "itemSelected:" + spacecraft_ComboBox.Text + "\r\n";
            file = file + "capacitySelected:" + capacity_ComboBox.Text + "\r\n";

            //Separators to make the file easier to read
            file = file + "------";

            //--------- Route Data --------------
            file = file + "\r\n[ROUTE]\r\n";

            for (int index = 0; index < destination_listBox.Items.Count; index++)
                file = file + destination_listBox.Items[index].ToString() + "\r\n";

            file = file + "------";

            //--------- Route Result --------------
            file = file + "\r\n[ROUTE RESULT]\r\n";
                file = file + route_textBox.Text + "\r\n";

            file = file + "------";

            openDialog("save");

        }

        [STAThread]
        private void load_route_button_Click(object sender, EventArgs e)
        {
            openDialog("load");

            if(loadSpacecraft != "")
                spacecraft_ComboBox.SelectedItem = loadSpacecraft;

            String[] itemsFromFile = loadDestinationItems.Split(':');

            for (int index = 1; index < itemsFromFile.Length; index++)
                destination_listBox.Items.Add(itemsFromFile[index]);

            route_textBox.Text = loadText;

            //cleanning the attibutes
            loadSpacecraft = "";
            loadCapacity = "";
            loadDestinationItems = "";
            loadText = "";

        }

        [STAThread]
        public void saveFile ()
        {
            saveFileDialog1.Title = "Save Route File";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = "Route_File_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.InitialDirectory = @"..\\";
            saveFileDialog1.RestoreDirectory = true;

            saveFileDialog1.CheckPathExists = true;

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(file);

                    writer.Close();

                    MessageBox.Show("File Saved Successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not save the file!");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation was canceled!");
            }
        }

        [STAThread]
        public void loadFile()
        {
            openFileDialog1.Title = "Open Route File";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.RestoreDirectory = true;
            var fileContent = string.Empty;
            var filePath = string.Empty;
            String test = "";

            openFileDialog1.CheckPathExists = true;

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                /* The reading will be done following the structure defined in the save_route_button_Click method.
                 * As the loadFile method executes within a thread, it is not possible to access form elements.
                 * With this, the file information was stored in attributes.*/
                try
                {
                    filePath = openFileDialog1.FileName;
                    var fileStream = openFileDialog1.OpenFile();
                    

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while (reader.Peek() >= 0)
                        {
                            String content = reader.ReadLine();

                            if (content == "[GENERAL]")
                            {
                                content = reader.ReadLine();
                                while (content != "------")
                                {
                                    String[] elements = content.Split(':');

                                    if (elements[0] != null || elements[1] != null)
                                    {
                                        if (elements[0].ToLower() == "maxDistanceSupported".ToLower())
                                        {
                                            maxDistanceSupported = double.Parse(elements[1].ToString());
                                        }
                                        else if (elements[0].ToLower() == "availableDistance".ToLower())
                                        {
                                            availableDistance = double.Parse(elements[1].ToString());
                                        }
                                        else if (elements[0].ToLower() == "inputPath".ToLower())
                                        {
                                            inputPath = elements[1].ToString();
                                        }
                                        else if (elements[0].ToLower() == "itemSelected".ToLower())
                                        {
                                            loadSpacecraft = elements[1].ToString();
                                        }
                                        else if (elements[0].ToLower() == "capacitySelected".ToLower())
                                        {
                                            loadCapacity = elements[1].ToString();
                                        }
                                    }
                                    content = reader.ReadLine();
                                }
                            }
                            else if (content == "[ROUTE]")
                            {
                                content = reader.ReadLine();
                                while (content != "------")
                                {
                                    loadDestinationItems = loadDestinationItems + ":" + content;
                                    content = reader.ReadLine();
                                }
                            }
                            else if (content == "[ROUTE RESULT]")
                            {
                                content = reader.ReadLine();
                                String text = content;

                                while (content != "------")
                                {
                                    text = text + content.ToString() + "\r\n";
                                    content = reader.ReadLine();
                                }
                                loadText = text;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open the file!");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Operation was canceled!");
            }
        } 
    }
}
