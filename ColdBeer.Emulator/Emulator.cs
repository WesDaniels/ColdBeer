using ColdBeer.Components.Motor;
using ColdBeer.Components.Ping;
using ColdBeer.Controllers;
using ColdBeer.Emulator.Adapters;
using CoolBeer.Emulator.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoolBeer.Emulator
{
    public partial class Emulator : Form
    {
        public static string xMotor1_SetSpeed;
        public static string xMoter1_Direction;
        public static string xMotor2_SetSpeed;
        public static string xMoter2_Direction;

        public static bool xPing1_block = false;
        
        static DriveTrain driveTrain = new DriveTrain();

        static IMotor motor1 = new xMotor1();
        static IMotor motor2 = new xMotor2();

        public Emulator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveTrain driveTrain = new DriveTrain();
            driveTrain.ConnectFour(motor1, motor2);

            IPing ping = new xPing1();
            PingStream pingStream = new PingStream(ping);
            pingStream.PingList = new xPingList1();

            Captain captain = new Captain(driveTrain, pingStream);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            verticalProgressBar1.Value = int.Parse(xMotor1_SetSpeed);
            textBox2.Text = xMoter1_Direction;

            verticalProgressBar2.Value = int.Parse(xMotor2_SetSpeed);
            textBox4.Text = xMoter2_Direction;
        }

        private void cbBlocked_CheckedChanged(object sender, EventArgs e)
        {
            xPing1_block = cbBlocked.Checked;
        }
    }
}
