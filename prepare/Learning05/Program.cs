using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 10);
        // Console.WriteLine(square.GetColor());
        // Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle("green", 10, 5);
        // Console.WriteLine(rectangle.GetColor());
        // Console.WriteLine(rectangle.GetArea());

        Circle circle = new Circle("blue", 10);
        // Console.WriteLine(circle.GetColor());
        // Console.WriteLine(circle.GetArea());

        List<Shape> shapes = new List<Shape>{square, rectangle, circle};
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}