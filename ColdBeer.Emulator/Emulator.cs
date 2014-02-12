using ColdBeer.Components.Motor;
using ColdBeer.Controllers;
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

        public static string xMotor3_SetSpeed;
        public static string xMoter3_Direction;

        public static string xMotor4_SetSpeed;
        public static string xMoter4_Direction;
        
        static DriveTrain driveTrain = new DriveTrain();

        static IMotor motor1 = new xMotor1();
        static IMotor motor2 = new xMotor2();
        static IMotor motor3 = new xMotor3();
        static IMotor motor4 = new xMotor4();

        public Emulator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            driveTrain.ConnectFour(motor1, motor2,motor3,motor4);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            verticalProgressBar1.Value = int.Parse(xMotor1_SetSpeed);
            textBox2.Text = xMoter1_Direction;

            verticalProgressBar2.Value = int.Parse(xMotor2_SetSpeed);
            textBox4.Text = xMoter2_Direction;

            verticalProgressBar3.Value = int.Parse(xMotor3_SetSpeed);
            textBox1.Text = xMoter3_Direction;

            verticalProgressBar4.Value = int.Parse(xMotor4_SetSpeed);
            textBox3.Text = xMoter4_Direction;
 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            driveTrain.Forward();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            driveTrain.Left();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            driveTrain.Right();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            driveTrain.Reverse();
        }
    }
}
