namespace Thrust_Stand_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.startTest = new System.Windows.Forms.Button();
            this.endTest = new System.Windows.Forms.Button();
            this.recalibrate = new System.Windows.Forms.Button();
            this.exportData = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chartThrustVsThrottle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerialPort = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.throttleSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.chartThrustVsThrottle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.throttleSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // startTest
            // 
            this.startTest.BackColor = System.Drawing.Color.Lime;
            this.startTest.Location = new System.Drawing.Point(224, 7);
            this.startTest.Margin = new System.Windows.Forms.Padding(2);
            this.startTest.Name = "startTest";
            this.startTest.Size = new System.Drawing.Size(89, 32);
            this.startTest.TabIndex = 0;
            this.startTest.Text = "Start Test";
            this.startTest.UseVisualStyleBackColor = false;
            this.startTest.Click += new System.EventHandler(this.startTest_Click);
            // 
            // endTest
            // 
            this.endTest.BackColor = System.Drawing.Color.Red;
            this.endTest.Location = new System.Drawing.Point(317, 7);
            this.endTest.Margin = new System.Windows.Forms.Padding(2);
            this.endTest.Name = "endTest";
            this.endTest.Size = new System.Drawing.Size(89, 32);
            this.endTest.TabIndex = 1;
            this.endTest.Text = "End Test";
            this.endTest.UseVisualStyleBackColor = false;
            this.endTest.Click += new System.EventHandler(this.endTest_Click);
            // 
            // recalibrate
            // 
            this.recalibrate.BackColor = System.Drawing.Color.Yellow;
            this.recalibrate.Location = new System.Drawing.Point(410, 7);
            this.recalibrate.Margin = new System.Windows.Forms.Padding(2);
            this.recalibrate.Name = "recalibrate";
            this.recalibrate.Size = new System.Drawing.Size(89, 32);
            this.recalibrate.TabIndex = 2;
            this.recalibrate.Text = "Recalibrate";
            this.recalibrate.UseVisualStyleBackColor = false;
            this.recalibrate.Click += new System.EventHandler(this.recalibrate_Click);
            // 
            // exportData
            // 
            this.exportData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exportData.Location = new System.Drawing.Point(503, 7);
            this.exportData.Margin = new System.Windows.Forms.Padding(2);
            this.exportData.Name = "exportData";
            this.exportData.Size = new System.Drawing.Size(89, 32);
            this.exportData.TabIndex = 3;
            this.exportData.Text = "Export Data";
            this.exportData.UseVisualStyleBackColor = false;
            this.exportData.Click += new System.EventHandler(this.exportData_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 62);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 334);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(435, 94);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(104, 20);
            this.textBox2.TabIndex = 5;
            // 
            // chartThrustVsThrottle
            // 
            chartArea2.Name = "ChartArea1";
            this.chartThrustVsThrottle.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThrustVsThrottle.Legends.Add(legend2);
            this.chartThrustVsThrottle.Location = new System.Drawing.Point(247, 128);
            this.chartThrustVsThrottle.Margin = new System.Windows.Forms.Padding(2);
            this.chartThrustVsThrottle.Name = "chartThrustVsThrottle";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartThrustVsThrottle.Series.Add(series2);
            this.chartThrustVsThrottle.Size = new System.Drawing.Size(469, 268);
            this.chartThrustVsThrottle.TabIndex = 6;
            this.chartThrustVsThrottle.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thrust [lbf]";
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(28, 14);
            this.comboBoxCOMPorts.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(92, 21);
            this.comboBoxCOMPorts.TabIndex = 8;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonConnectSerialPort
            // 
            this.buttonConnectSerialPort.Location = new System.Drawing.Point(28, 39);
            this.buttonConnectSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConnectSerialPort.Name = "buttonConnectSerialPort";
            this.buttonConnectSerialPort.Size = new System.Drawing.Size(56, 19);
            this.buttonConnectSerialPort.TabIndex = 9;
            this.buttonConnectSerialPort.Text = "Connect";
            this.buttonConnectSerialPort.UseVisualStyleBackColor = true;
            this.buttonConnectSerialPort.Click += new System.EventHandler(this.buttonConnectSerialPort_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 19);
            this.button1.TabIndex = 10;
            this.button1.Text = "select file location";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSelectFileLocation_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(503, 43);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(205, 20);
            this.textBoxFileName.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // throttleSlider
            // 
            this.throttleSlider.Location = new System.Drawing.Point(224, 44);
            this.throttleSlider.Maximum = 100;
            this.throttleSlider.Name = "throttleSlider";
            this.throttleSlider.Size = new System.Drawing.Size(274, 45);
            this.throttleSlider.TabIndex = 12;
            this.throttleSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.throttleSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.throttleSlider_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 412);
            this.Controls.Add(this.throttleSlider);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonConnectSerialPort);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartThrustVsThrottle);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.exportData);
            this.Controls.Add(this.recalibrate);
            this.Controls.Add(this.endTest);
            this.Controls.Add(this.startTest);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThrustVsThrottle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.throttleSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button endTest;
        private System.Windows.Forms.Button recalibrate;
        private System.Windows.Forms.Button exportData;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThrustVsThrottle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button buttonConnectSerialPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button startTest;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar throttleSlider;
    }
}

