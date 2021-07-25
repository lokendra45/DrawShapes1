using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawShapes
{
    public partial class Form1 : Form
    {

        
        Boolean drawCircle, drawRectangle, drawPolygon, drawTriangle, fill;
                String app;
        
        String[] words;
        
        int moveX, moveY;
      
        int thickness;
        
        Shapes circle_shape, rectangle_shape, polygon_shape, trianle_shape;
        
        List<Circle> circleObjects;
        
        List<RectangleShape> rectangleObjects;
        
        List<PolygonShape> polygonObjects;

        List<HandlePoint> moveObjects;

        List<TriangleShape> triangleObjects;

        Circle circle;
        RectangleShape rectangle;

        //stores the implement command form implement text
        string implementCmd;
        string console_text;

        Graphics g;
        PolygonShape polygon;
       
        Color c;

        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            circle = new Circle(); 
            rectangle = new RectangleShape(); 
            circleObjects = new List<Circle>(); 
            rectangleObjects = new List<RectangleShape>(); 
            moveObjects = new List<HandlePoint>(); 
            triangleObjects = new List<TriangleShape>(); 
            polygonObjects = new List<PolygonShape>();
            c = Color.DarkRed;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to Draw Shapes:\n" +

              "To draw Shapes Shape Drawing Command have to Enter in the Command Box \n" + "" +
              "For Example \n" +
              "Write Draw Circle 200 and Write run in command box and hit Draw it will draw Circle Shape \n" +
              "For Ploygon write 'draw ploygon' and it will draw polygon Shape \n" +
              "For Rectangle Write 'draw rectangle 100 200' it will draw Rectangle Shape \n" +
              "For Trianlge write 'draw triangle\n" +
              "TO CHANGE THE CORDINATES OF THE SHAPES COMMANDS\n" +

                "moveTo 100 100\n");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        


        public Form1()
        {
            InitializeComponent();
            FactoryAbstract shapeFactory = ShapeFactory.getFactory("Shapes");
            circle_shape = shapeFactory.getShapes("Circle");
            rectangle_shape = shapeFactory.getShapes("Rectangle");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            implementCmd = textBox1.Text.ToLower();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (implementCmd)
            {
                case "run":
                    if (richTextBox1.Text == "")
                    {
                        MessageBox.Show("No Syntax and Paramater Detected");
                    }
                    try
                    {
                        app = richTextBox1.Text.ToLower();

                        char[] delimiters = new char[] { '\r', '\n' };
                        //holds invididuals code line 
                        string[] parts = app.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        console_text = "app code: \n";
                        foreach (string part in parts)
                        {
                            console_text += part + "\n";
                        }
                        console_text += "\n\n";
                        //loop through the whole app code line
                        for (int i = 0; i < parts.Length; i++)
                        {
                            //single code line
                            String code_line = parts[i];
                            //splits the code when space 
                            char[] value_code = new char[] { ' ' };
                            //holds invididuals code line
                            words = code_line.Split(value_code, StringSplitOptions.RemoveEmptyEntries);
                            //checks if words has move command then
                            //if (words[0] == "moveTo")
                            //{
                                //if (Convert.ToInt32(words[1]) == locationOutput.Location.X &&
                                  //  Convert.ToInt32(words[2]) == locationOutput.Location.Y)//checks if shape is in different position
                               // {
                                 //   console_text += "Its in requested position\n\n";
                               // }
                               // else
                                //{
                                 //   moveX = Convert.ToInt32(words[1]);
                                   // moveY = Convert.ToInt32(words[2]);
                                    //console_text += "X=" + moveX + "\n" + "Y=" + moveY + "\n\n";
                               // }
                            //}

                            //checks if word holds the value color then
                            if (words[0] == "color")
                            {
                                thickness = Convert.ToInt32(words[2]);//converting string value to integer value

                                if (words[1] == "red")//if red then color changes to red
                                {
                                    c = Color.Red;
                                    console_text += "red color\n\n";
                                }
                                else if (words[1] == "blue")//if blue then color changes to blue
                                {
                                    c = Color.Blue;
                                    console_text += "blue color\n\n";
                                }
                                else if (words[1] == "yellow")//if yellow then color changes to yellow
                                {
                                    c = Color.Yellow;
                                    console_text += "yellow color\n\n";
                                }
                                else
                                {
                                    c = Color.AliceBlue;
                                    console_text += "green color\n\n";//default color 
                                }
                            }

                            //checks for 'paint' word
                            if (words[0].Equals("draw"))
                            {
                                //checks for 'circle' word
                                if (words[1] == "circle")
                                {
                                    //checks weather the written code is right or wrong
                                    if (!(words.Length == 3))
                                    {
                                        MessageBox.Show("!!!Wrong Command!!!\neg.paint circle 100");

                                    }
                                    else
                                    {
                                        Circle circle = new Circle();
                                        circle.setX(moveX);
                                        circle.setY(moveY);
                                        circle.setRadius(Convert.ToInt32(words[2]));
                                        circleObjects.Add(circle);
                                        drawCircle = true;
                                        console_text += "Adding new circle\n\n";
                                    }
                                }
                                //checks if the word is rectangle or not
                                if (words[1].Equals("rectangle"))
                                {
                                    //checks if the given paramater is wrng then displays message
                                    if (!(words.Length == 4))
                                    {
                                        MessageBox.Show("!!!Wrong Command!!!\neg.paint rectangle 100 100 ");
                                    }
                                    else
                                    {
                                        RectangleShape rect = new RectangleShape();
                                        rect.setX(moveX);
                                        rect.setY(moveY);
                                        rect.setHeight(Convert.ToInt32(words[2]));
                                        rect.setWidth(Convert.ToInt32(words[3]));
                                        rectangleObjects.Add(rect);
                                        drawRectangle = true;
                                        console_text += "Adding new rectangle\n\n";
                                    }
                                }
                                if (words[1].Equals("polygon"))
                                {
                                    drawPolygon = true;
                                }
                            }
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        console_text += "Error: " + ex.Message + "\n\n";
                    }
                    //refresh everytime painting equals to true
                    output_Box.Refresh();
                    break;
                case "clear"://if action command is clear
                    circleObjects.Clear();
                    rectangleObjects.Clear();
                    moveObjects.Clear();
                    polygonObjects.Clear();
                    drawCircle = false;
                    drawRectangle = false;
                    drawPolygon = false;
                    richTextBox1.Clear();
                    output_Box.Refresh();
                    break;
                default:
                    MessageBox.Show("The action command is empty\n" +
                        "Or\n" +
                        "Must be: 'Run' for Execuit the app\n" +
                        "Must be: 'Clear' for Fresh Start");
                    break;
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;

            if (drawCircle == true)
            {
                foreach (Circle circleObject in circleObjects)
                {
                    console_text += "painting Circle\n\n";
                    circleObject.paint(g, c, thickness); 
                }
            }

            if (drawRectangle == true) 
            {
                foreach (RectangleShape rectangleObject in rectangleObjects)
                {
                    console_text += "painting Rectangle\n\n";
                    rectangleObject.paint(g, c, thickness); 
                }
            }

            if (drawPolygon == true)
            {
                Pen blackPen = new Pen(c, thickness);
                SolidBrush fill = new SolidBrush(c);

                PointF point1 = new PointF(50.0F, 50.0F);
                PointF point2 = new PointF(70.0F, 25.0F);
                PointF point3 = new PointF(100.0F, 5.0F);
                PointF point4 = new PointF(150.0F, 30.0F);
                PointF point5 = new PointF(200.0F, 50.0F);
                PointF point6 = new PointF(250.0F, 100.0F);
                PointF point7 = new PointF(150.0F, 150.0F);
                string[] str = new string[5];
                PointF[] curvePoints =
                 {
                    point1,
                    point2,
                    point3,
                    point4,
                    point5,
                    point6,
                    point7
             };
                e.Graphics.DrawPolygon(blackPen, curvePoints);
                e.Graphics.FillPolygon(fill, curvePoints);
            }
        }
    }
}
