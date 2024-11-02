using System;
using System.Diagnostics;
using System.IO.Ports; // added
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Thrust_Stand_GUI  //hello
{
    public partial class Form1 : Form
    {

        // public delegate void d1(string indata);
        // private static int counter;
        List<string> throttleThrustData = new List<string>(); // Store the throttle and thrust values

        public Form1()
        {
            InitializeComponent();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); // added

            

            // Initialize chart for Thrust vs. Throttle
            chartThrustVsThrottle.Series.Clear();  // clear everything
            Series series = new Series("Thrust vs. Throttle");
            series.ChartType = SeriesChartType.Line;  // line chart for continuous data
            chartThrustVsThrottle.Series.Add(series);

            chartThrustVsThrottle.ChartAreas[0].AxisX.Title = "Throttle (%)";
            chartThrustVsThrottle.ChartAreas[0].AxisY.Title = "Thrust (lbs)";

            // Set X-axis (Throttle) range from 0 to 110
            chartThrustVsThrottle.ChartAreas[0].AxisX.Minimum = 0;
            chartThrustVsThrottle.ChartAreas[0].AxisX.Maximum = 110;
            chartThrustVsThrottle.ChartAreas[0].AxisX.Interval = 10; 

            // Set Y-axis (Thrust) range depending on expected values (check w ayden)
            chartThrustVsThrottle.ChartAreas[0].AxisY.Minimum = -2;
            chartThrustVsThrottle.ChartAreas[0].AxisY.Maximum = 15;
            chartThrustVsThrottle.ChartAreas[0].AxisY.Interval = 1; 

        }

        private void startTest_Click(object sender, EventArgs e)
        {
            // Send command to arduino to start test
            SendCommand('S');
        }

        private void endTest_Click(object sender, EventArgs e)
        {
            // Send command to arduino to end test
            SendCommand('E');
        }

        private void recalibrate_Click(object sender, EventArgs e)
        {
            // Send command to arduino to recalibrate
            SendCommand('R');
        }

        string filePath;
        private void exportData_Click(object sender, EventArgs e)
        {
            SaveDataToCSV(filePath);
        }
        private void SendCommand(char command)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(command.ToString());
                    Debug.WriteLine($"Sent command: {command}");
                }
                else
                {
                    Debug.WriteLine("Serial port is not open.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while sending command '{command}'. {ex.Message}");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string indata = serialPort1.ReadLine(); // Read incoming data
                this.BeginInvoke(new Action<string>(Write2Form), indata); // Invoke UI update
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading serial data: {ex.Message}");
            }
        }

        public void Write2Form(string indata)
        {
            textBox1.AppendText(indata + Environment.NewLine); // Append received data to text box

            // Split data based on a space or tab (idk what kinda spacing it is)
            string[] parts = indata.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Check for two parts (throttle and thrust)
            if (parts.Length == 2)
            {

                double throttle;
                double thrust;

                bool isThrottleNumeric = double.TryParse(parts[0], out throttle);
                bool isThrustNumeric = double.TryParse(parts[1], out thrust);

                // Make sure both parts are the numerical values we want
                if (isThrottleNumeric && isThrustNumeric)
                {

                    // Store the throttle and thrust in a string (comma-separated for CSV)
                    throttleThrustData.Add(parts[0] + "," + parts[1]);

                    // Convert string to numerical value
                    if (double.TryParse(parts[0], out throttle) && double.TryParse(parts[1], out thrust))
                    {
                        // Display thrust value in textBox2
                        textBox2.Text = $"Thrust: {thrust} lbs";

                        // Add data point to the chart (throttle vs thrust)
                        chartThrustVsThrottle.Series[0].Points.AddXY(throttle, thrust);
                    }

                }
            }

        }
        

        private void SaveDataToCSV(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Header for CSV file
                    writer.WriteLine("Throttle,Thrust (lbs)");

                    // Write each line of throttle and thrust values
                    foreach (string line in throttleThrustData)
                    {
                        if (!string.IsNullOrWhiteSpace(line)) // Get rid of extra rows in excel file
                        {
                            writer.WriteLine(line);
                        }
                     
                    }
                }

                MessageBox.Show("Data successfully exported to " + fileName, "Export Complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Export Error");
            }
        }

        private void buttonConnectSerialPort_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                serialPort1.Dispose();
                buttonConnectSerialPort.Text = "Connect Serial";
            }
            else
            {                
                try
                {
                    serialPort1.Open();
                    Debug.WriteLine("Serial port opened.");
                    buttonConnectSerialPort.Text = "Disconnect Serial";
                }
                catch (UnauthorizedAccessException ex)
                {
                    Debug.WriteLine($"Access to the COM port is denied!!");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxCOMPorts.SelectedItem.ToString();
        }

        private void buttonSelectFileLocation_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialogBox = new SaveFileDialog();
            myDialogBox.InitialDirectory = @"C:\Users";
            myDialogBox.ShowDialog();
            filePath = myDialogBox.FileName.ToString() + ".csv";
            textBoxFileName.Text = filePath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateSerial();
        }

        private void updateSerial()
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
        }
    }
}
