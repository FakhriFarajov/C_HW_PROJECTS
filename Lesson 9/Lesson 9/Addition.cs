using static ICalculatorOperation;

public class Addition : ICalculatorOperation
{
    public double Execute(double a, double b)
    {
        return a + b;
    }
    private string _name = "Addition";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}