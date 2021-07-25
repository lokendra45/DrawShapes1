using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapes
{
    class ShapeFactory
    {
        
        public static FactoryAbstract getFactory(String choice)
        {
            //if condition to check if choice is shape or color
            if (choice.Equals("Shapes"))
            {
                return new FactoryShapes();
            }
            return null;
        }
    }
}
