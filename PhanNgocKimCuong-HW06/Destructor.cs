using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanNgocKimCuong_HW06
{
    class Destructor
    {
        Third t = new Third();
    }
    class First
    {
        public First()
        {
            Console.WriteLine("First's contructor is called");
        }
        ~First()
        {
            //System.Diagnostics.Trace.WriteLine("First's destructor is called.");
            Console.WriteLine("First's destructor is called.");
        }
    }

    class Second : First
    {
        public Second()
        {
            Console.WriteLine("Second's contructor is called");
        }
        ~Second()
        {
            //System.Diagnostics.Trace.WriteLine("Second's destructor is called.");
            Console.WriteLine("Second's destructor is called.");

        }
    }

    class Third : Second
    {
        public Third()
        {
            Console.WriteLine("Third's contructor is called");
        }
        ~Third()
        {
            //System.Diagnostics.Trace.WriteLine("Third's destructor is called.");
            Console.WriteLine("Third's destructor is called.");

        }
    }
}
