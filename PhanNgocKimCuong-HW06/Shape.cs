using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanNgocKimCuong_HW06
{
    class Shape
    {
        public double Height { get; set; }
        public double Weight { set; get; }
        public double Area { set; get; }
        

    }

     class Rectangle : Shape
    {
        public Rectangle(){}
        
        public Rectangle(double height, double weight)
        {
            this.Height = height;
            this.Weight = weight;
            this.Area = height*weight ;
        }
    }
     class Square:Shape
    {
        public Square() { }
        Shape c = new Shape();
        public Square(double height)
        {
            this.Height = height;
            this.Weight = height;
            this.Area = height * height;
        }
    }
     class Circle:Shape
    {
        public Circle() { }
        Shape c = new Shape();
        public Circle(double height)
        {
            this.Height = height;
            this.Weight = height;
            this.Area = 3.14*height*height;
        }
    }
}
