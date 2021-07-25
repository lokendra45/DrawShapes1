using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapes
{
    public class FactoryShapes : FactoryAbstract
    {
        /// <summary>
        /// created an abstract class os shape 
        /// </summary>
        /// <param name="shapeType">takes string shapeType parameter</param>
        /// <returns>if shape has no string then return null</returns>
        public override Shapes getShapes(String shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }

            if (shapeType.Equals("Circle"))
            {
                return new Circle(0, 0, 100);

            }
            else if (shapeType.Equals("Rectangle"))
            {
                return new RectangleShape(0, 0, 100, 100);
            }
            return null;
        }
    }
}
