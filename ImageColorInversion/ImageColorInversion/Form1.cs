using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageColorInversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(imagePath);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox2.Image = new Bitmap(imagePath);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox3.Image = new Bitmap(imagePath);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox4.Image = new Bitmap(imagePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Negative
            if (pictureBox1.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox1.Image);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        Color originalColor = originalImage.GetPixel(x, y);
                        Color invertedColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                        originalImage.SetPixel(x, y, invertedColor);
                    }
                }

                pictureBox1.Image = originalImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sepia
            if (pictureBox2.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox2.Image);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        Color originalColor = originalImage.GetPixel(x, y);

                        int sepiaR = (int)(0.393 * originalColor.R + 0.769 * originalColor.G + 0.189 * originalColor.B);
                        int sepiaG = (int)(0.349 * originalColor.R + 0.686 * originalColor.G + 0.168 * originalColor.B);
                        int sepiaB = (int)(0.272 * originalColor.R + 0.534 * originalColor.G + 0.131 * originalColor.B);

                        // Ensure values are within the valid color range (0-255)
                        sepiaR = Math.Min(255, sepiaR);
                        sepiaG = Math.Min(255, sepiaG);
                        sepiaB = Math.Min(255, sepiaB);

                        Color sepiaColor = Color.FromArgb(sepiaR, sepiaG, sepiaB);
                        originalImage.SetPixel(x, y, sepiaColor);
                    }
                }

                pictureBox2.Image = originalImage;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Gray
            if (pictureBox3.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox3.Image);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        Color originalColor = originalImage.GetPixel(x, y);
                        int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                        Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                        originalImage.SetPixel(x, y, grayColor);
                    }
                }

                pictureBox3.Image = originalImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Desaturated
            if (pictureBox4.Image != null)
            {
                Bitmap originalImage = new Bitmap(pictureBox4.Image);

                for (int x = 0; x < originalImage.Width; x++)
                {
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        Color originalColor = originalImage.GetPixel(x, y);

                        // Menghitung nilai rata-rata warna merah, hijau, dan biru
                        int averageColor = (originalColor.R + originalColor.G + originalColor.B) / 3;
                        Color desaturatedColor = Color.FromArgb(averageColor, averageColor, averageColor);
                        originalImage.SetPixel(x, y, desaturatedColor);
                    }
                }

                pictureBox4.Image = originalImage;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

