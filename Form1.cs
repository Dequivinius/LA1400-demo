using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voluminator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            string selected = comboBox1.SelectedItem.ToString();
            lbl_value2.Visible = false;
            bx_text2.Visible = false;


            if (selected == "Sphere")
            {
                show_sphere();
            }

            if (selected == "Cylinder")
            {
                show_cylinder();
            }

            if (selected == "Cube")
            {
                show_cube();
            }

        }

        private void show_cube()
        {
            groupBox1.Visible = true;
            pictureBox1.Visible = true;
            lbl_value.Text = "Length";
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\sazerac\\Downloads\\Cube.svg.png");

        }

        private void show_sphere()
        {
            groupBox1.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\sazerac\\Downloads\\Sphere.svg.png");

            lbl_value.Text = "Radius";
        }

        private void show_cylinder()
        {
            groupBox1.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\sazerac\\Downloads\\Cylinder.svg.png");
            lbl_value.Text = "Height";

            lbl_value2.Visible = true;
            lbl_value2.Text = "Radius";
            bx_text2.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();
            double volume = -1.0;
            double input = -1.0;

            // check user input
            if (!String.IsNullOrEmpty(bx_text1.Text)) 
            {
                try {
                    input = Convert.ToDouble(bx_text1.Text);
                } 
                
                catch
                {
                    MessageBox.Show("Enter a value");
                    return;
                }
            }

            switch (selected)
            {
                case "Cube":

                    double radius = input;
                    volume = volume_cube(radius);
                    break;

                case "Sphere":

                    double sphere_radius = input;
                    volume = volume_sphere(sphere_radius);
                    break;

                case "Cylinder":
                    double cylinder_radius = input;
                    double height = Convert.ToDouble(bx_text2.Text);
                    volume = volume_cylinder(cylinder_radius, height);
                    break;
            }

            if (volume > 0)
            {
                MessageBox.Show("Your volume is: \n" + volume);
            }
        }

        public double volume_cube(double length)
        {
            return length * length * length;
        }

        private double volume_sphere(double radius)
        {
            return ( 4 / 3 ) * Math.PI * radius * radius * radius;
        }

        private double volume_cylinder(double radius, double height)
        {
            return radius * radius * Math.PI * height;
        }
    }
}
