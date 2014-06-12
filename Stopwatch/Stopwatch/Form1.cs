using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Stopwatch object
        /// </summary>
        private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        /// <summary>
        /// Timer object
        /// </summary>
        private System.Windows.Forms.Timer formUpdateTimer = new Timer();

        // Constructor
        public Form1()
        {
            InitializeComponent();
        }

        // Form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Assembly.GetExecutingAssembly().GetName().Name;
            Form1_Resize(this, null);
            stopwatch = new System.Diagnostics.Stopwatch();
            formUpdateTimer.Interval = 20;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();
        }

        /// <summary>
        /// Resize form event
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            labelTime.Font = new Font(labelTime.Font.FontFamily, (float)this.Width / 9);
            labelTime.Location = new Point(0, (this.Height / 2) - (int)(labelTime.Font.Size / 2.0f) - 50);
        }

        /// <summary>
        /// Forum update timer event
        /// </summary>
        void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan((long)((double)stopwatch.ElapsedTicks * (1000.0 * 1000.0 * 10.0 / (double)(System.Diagnostics.Stopwatch.Frequency))));
            labelTime.Text = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
        }

        /// <summary>
        /// Start button event
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
        }

        /// <summary>
        /// Stop button event
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        /// <summary>
        /// Reset button event
        /// </summary>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
            }
            else
            {
                stopwatch = new System.Diagnostics.Stopwatch();
            }
        }
    }
}
