public interface ICalculatorOperation
{
    public double Execute(double a, double b);
    public string Name { get; set; }
}