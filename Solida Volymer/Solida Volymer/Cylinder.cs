using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solida_Volymer
{
    public class Cylinder : Solid // Uträkningar för Cylinder
    {

        public override double BaseArea
        {

            get
            {
                return Math.PI * RadiusSquare;
            }

        }

        public override double SurfaceArea
        {

            get
            {
                return 2 * Math.PI * Radius * (Height + Radius);
            }

        }

        public override double Volume
        {

            get
            {
                return Math.PI * RadiusSquare * Height;
            }

        }

        public Cylinder(double radius, double height) : base(radius, height) { }

    }

}
