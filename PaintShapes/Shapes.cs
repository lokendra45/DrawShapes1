using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapes
{
    public abstract class Shapes
    {

        
        protected int x = 0, y = 0, z = 0;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Shapes()
        {

        }

        /// <summary>
        /// Declared Parameterized Constructor
        /// </summary>
        /// <param name="x">takes x as parameter</param>
        /// <param name="y">takes y as parameter</param>
        /// <param name="z">takes z as parameter</param>
        public Shapes(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// Decleared a parameterized constructor
        /// </summary>
        /// <param name="x">takes the interger x as the parameter</param>
        /// <param name="y">take the integer y as the parameter</param>
        public Shapes(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Decleared set method of x
        /// </summary>
        /// <param name="x">takes x as the parameter</param>
        public void setX(int x)
        {
            this.x = x;
        }


        // X getter method
        /// <summary>
        /// declared get method of y
        /// </summary>
        /// <returns>returns the Shapes X</returns>
        public int getX()
        {
            return x;
        }

        /// <summary>
        /// declared set method of Y
        /// </summary>
        /// <param name="y">takes int y as parameter</param>
        public void setY(int y)
        {
            this.y = y;
        }
        /// <summary>
        /// Declared get function of y
        /// </summary>
        /// <returns>returnst the Shapes Y</returns>
        public int getY()
        {
            return y;
        }

        /// <summary>
        /// Created paint method which uses Drawing Library
        /// </summary>
        /// <param name="g">takes g as Graphic Function</param>
        /// <param name="c">takes c as Color function</param>
        /// <param name="thickness">takes thicksness as Pen thickness</param>
        public abstract void paint(Graphics g, Color c, int thickness);

        /// <summary>
        /// Created fill method which uses Drawing Library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        public abstract void fill(Graphics g, Color c);

    }
}
