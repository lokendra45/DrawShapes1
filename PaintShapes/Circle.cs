using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapes
{
   
    public class Circle : Shapes
    {

      int radius;

        /// <summary>
        /// Circle constructor which takes the parameter x , y and radius
        /// </summary>
        /// <param name="x">takes integer x as a paremeter</param>
        /// <param name="y">takes integer y as a paremeter</param>
        /// <param name="radius">takes integer y as a parameter</param>
        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;

        }

        /// <summary>
        /// Default Circle constructor
        /// </summary>
        public Circle()
        {

        }
        //circle constructor with paremater
        /// <summary>
        /// Circle constructor which takes integer=radius paremeter
        /// </summary>
        /// <param name="radius"></param>
        public Circle(int radius)
        {
            this.radius = radius;
        }
        /// <summary>
        /// Circle constructor which takes the x and y paremeter and extends base class parameter
        /// </summary>
        /// <param name="x">takes integer x paremeter</param>
        /// <param name="y">takes y integer parameter</param>
        public Circle(int x, int y) : base(x, y)
        {

        }

        // draw method with graphics assigned g
        /// <summary>
        /// This method is the inheritance method of base class Shapes which uses drawing library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        /// <param name="thickness">takes integer thickness for pen thickness</param>
        public override void paint(Graphics g, Color c, int thickness)
        {
            Pen p = new Pen(c, thickness);
            g.DrawEllipse(p, x, y, radius, radius);
        }
        /// <summary>
        /// This method is the inheritance method of base class Shapes which uses drawing library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        public override void fill(Graphics g, Color c)
        {
            SolidBrush fill = new SolidBrush(c);
            g.FillEllipse(fill, x, y, radius, radius);
        }

        /// <summary>
        /// This method is the Setter method of the radius
        /// </summary>
        /// <param name="radius">takes the integer radius as parameter</param>
        public void setRadius(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// This method is the get method oof the Radius
        /// </summary>
        /// <returns>This method returs the radius of circle/returns>
        public int getRadius()
        {
            return this.radius;
        }


    }
}
