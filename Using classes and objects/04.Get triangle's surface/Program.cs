using System;

    //Write methods that calculate the surface of a triangle by given:
    //Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
class Program
{
    static double GetSurface(double side, double attitude)
    {
        double surface = (side * attitude) / 2;
        return surface;
    }

    static double GetSurface(double firstSide, double secondSide, double thirdSide)
    {
        double p = (firstSide + secondSide + thirdSide) / 2;
        double surface = Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
        return surface;
    }

    static double GetSurface(float angleBetween, double firstSide, double secondSide)
    {
        double sinOfAngle = Math.Sin(angleBetween);
        double surface = (firstSide * secondSide * sinOfAngle) / 2;
        return surface;
    }

    static void Main(string[] args)
    {
        double angle = Convert.ToDouble((Math.PI * 90) / 180);
    }
}
