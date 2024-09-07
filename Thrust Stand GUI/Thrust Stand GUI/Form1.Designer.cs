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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.startTest = new System.Windows.Forms.Button();
            this.endTest = new System.Windows.Forms.Button();
            this.recalibrate = new System.Windows.Forms.Button();
            this.exportData = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chartThrustVsThrottle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartThrustVsThrottle)).BeginInit();
            this.SuspendLayout();
            // 
            // startTest
            // 
            this.startTest.BackColor = System.Drawing.Color.Lime;
            this.startTest.Location = new System.Drawing.Point(59, 28);
            this.startTest.Name = "startTest";
            this.startTest.Size = new System.Drawing.Size(179, 61);
            this.startTest.TabIndex = 0;
            this.startTest.Text = "Start Test";
            this.startTest.UseVisualStyleBackColor = false;
            this.startTest.Click += new System.EventHandler(this.startTest_Click);
            // 
            // endTest
            // 
            this.endTest.BackColor = System.Drawing.Color.Red;
            this.endTest.Location = new System.Drawing.Point(59, 95);
            this.endTest.Name = "endTest";
            this.endTest.Size = new System.Drawing.Size(179, 61);
            this.endTest.TabIndex = 1;
            this.endTest.Text = "End Test";
            this.endTest.UseVisualStyleBackColor = false;
            this.endTest.Click += new System.EventHandler(this.endTest_Click);
            // 
            // recalibrate
            // 
            this.recalibrate.BackColor = System.Drawing.Color.Yellow;
            this.recalibrate.Location = new System.Drawing.Point(244, 28);
            this.recalibrate.Name = "recalibrate";
            this.recalibrate.Size = new System.Drawing.Size(179, 61);
            this.recalibrate.TabIndex = 2;
            this.recalibrate.Text = "Recalibrate";
            this.recalibrate.UseVisualStyleBackColor = false;
            this.recalibrate.Click += new System.EventHandler(this.recalibrate_Click);
            // 
            // exportData
            // 
            this.exportData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exportData.Location = new System.Drawing.Point(244, 95);
            this.exportData.Name = "exportData";
            this.exportData.Size = new System.Drawing.Size(179, 61);
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
            this.textBox1.Location = new System.Drawing.Point(59, 185);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 470);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(809, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 31);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // chartThrustVsThrottle
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThrustVsThrottle.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThrustVsThrottle.Legends.Add(legend1);
            this.chartThrustVsThrottle.Location = new System.Drawing.Point(465, 185);
            this.chartThrustVsThrottle.Name = "chartThrustVsThrottle";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThrustVsThrottle.Series.Add(series1);
            this.chartThrustVsThrottle.Size = new System.Drawing.Size(937, 470);
            this.chartThrustVsThrottle.TabIndex = 6;
            this.chartThrustVsThrottle.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 691);
            this.Controls.Add(this.chartThrustVsThrottle);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.exportData);
            this.Controls.Add(this.recalibrate);
            this.Controls.Add(this.endTest);
            this.Controls.Add(this.startTest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartThrustVsThrottle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startTest;
        private System.Windows.Forms.Button endTest;
        private System.Windows.Forms.Button recalibrate;
        private System.Windows.Forms.Button exportData;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThrustVsThrottle;
    }
}

