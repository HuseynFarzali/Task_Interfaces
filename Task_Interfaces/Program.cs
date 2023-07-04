using System;

namespace Task_Interfaces
{
    public static class GeometryHelper
    {
        public static bool TriangleChecker(double side1, double side2, double side3)
        {
            if (side1 + side2 <= side3) return false;
            else if (side2 + side3 <= side3) return false;
            else if (side3 + side1 <= side2) return false;

            return true;
        }

        public static decimal RectangleArea(double side1, double side2)
        {
            return (decimal)(side1 * side2);
        }

        public static decimal TriangleArea(double side1, double side2, double side3)
        {
            if (!TriangleChecker(side1, side2, side3)) throw new ArgumentException("Invalid side parameters for a triangle.");

            double p = (side1 + side2 + side3) / 2.0;
            double area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

            return (decimal)area;
        }
        public static decimal TriangleArea(double side1, double side2, int angle)
        {
            return (decimal)(1/2.0 * side1 * side2 * Math.Sin(angle));
        }
        public static decimal TriangleArea(double side)
        {
            return (decimal)(Math.Sqrt(3) / 4.0 * Math.Pow(side, 2));
        }

        public static decimal CircleArea(double radius)
        {
            return (decimal)(Math.PI * Math.Pow(radius, 2));
        }
    }

    internal class Program
    {
        static double CustomDoubleReturner(
            string user_message = "Enter the number: ",
            string error_message = "Invalid input entered.")
        {
            Console.Write(user_message);
            bool success = Double.TryParse(Console.ReadLine(), out double result);

            if (!success) throw new ArgumentException(error_message);

            return result;
        }

        static void Task1_Geometry()
        {
            double s1 = CustomDoubleReturner("Enter the first side of the rectangle: ");
            double s2 = CustomDoubleReturner("Enter the second side of the rectangle: ");
            Console.WriteLine($"The area of the rectangle: {GeometryHelper.RectangleArea(s1, s2)}");

            Console.WriteLine();

            double side1 = CustomDoubleReturner("Enter the first side of the triangle: ");
            double side2 = CustomDoubleReturner("Enter the second side of the triangle: ");
            double side3 = CustomDoubleReturner("Enter the third side of the triangle: ");
            Console.WriteLine($"The area of the triangle: {GeometryHelper.TriangleArea(side1, side2, side3)}");

            Console.WriteLine();

            double radius = CustomDoubleReturner("Enter the radius of the triangle: ");
            Console.WriteLine($"The area of the circle: {GeometryHelper.CircleArea(radius)}");

        }

        static void Main(string[] args)
        {
            Task1_Geometry();
        }
    }
}
