using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapes
{
   
    class RectangleShape : Shapes
    {
        
        int height, width;


       
        /// <param name="x">takes int x as parameter</param>
        /// <param name="y">takes y as parameter</param>
        /// <param name="height">takes integer height as parameter</param>
        /// <param name="width">takes integer width as parameter</param>
        public RectangleShape(int x, int y, int height, int width) : base(x, y)
        {
            this.height = height;
            this.width = width;
        }

        /// <summary>
        /// declared default constructor
        /// </summary>
        public RectangleShape()
        {
        }

        /// <summary>
        /// Paint method is the inheritance of the shape class which uses Drawing library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        /// <param name="thickness">takes integer thickness as Pen thickness</param>
        public override void paint(Graphics g, Color c, int thickness)
        {
            Pen p = new Pen(c, thickness);
            g.DrawRectangle(p, x, y, height, width);
        }
        /// <summary>
        /// Fill method is the inheritance of the shape class which uses Drawing library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        public override void fill(Graphics g, Color c)
        {
            SolidBrush fill = new SolidBrush(c);
            g.FillRectangle(fill, x, y, height, width);
        }
        /// <summary>
        /// this method is the set method of the Height
        /// </summary>
        /// <param name="height">takes integer height as parameter</param>
        public void setHeight(int height) //height setter method
        {
            this.height = height;
        }
        /// <summary>
        /// method get Height
        /// </summary>
        /// <returns>returns the height of the rectangle</returns>
        public int getHeight()
        {
            return this.height;
        }
        /// <summary>
        /// set method of width
        /// </summary>
        /// <param name="width">takes integer width as the parameter</param>
        public void setWidth(int width)//width setter method
        {
            this.width = width;
        }
        /// <summary>
        /// get method of Width
        /// </summary>
        /// <returns>returns the width of the rectangle</returns>
        public int getWidth() //width getter method
        {
            return this.width;
        }

    }
}
