namespace Lesson_9.Operations;
using Lesson_9.Interfaces;

public class Division : ICalculatorOperation{
    public double Execute(double a, double b)
    {
        return a / b;
    }
    private string _name = "Division";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}    