using System.Threading.Channels;

List<int> integerList = new List<int>()
{
    1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
};


async Task<List<int>> FilterEvenAsync(List<int> numbers)
{
    await Task.Delay(1500);
    numbers = numbers.Where(x => x % 2 == 0).ToList();
    return numbers;
}


async Task<List<int>> FilterOddAsync(List<int> numbers)
{
    await Task.Delay(1500);
    numbers = numbers.Where(x => x % 2 == 1).ToList();
    return numbers;
}


async Task<int> CalculateSumAsync(List<int> numbers)
{
    int sum = numbers.Sum();
    await Task.Delay(1000);
    return sum;
}




#region Task1
integerList.ToList().ForEach(i => Console.WriteLine(i));
#endregion

#region Task2
var resultEven = await FilterEvenAsync(integerList);
resultEven.ForEach(i => Console.WriteLine(i));
#endregion


#region Task3
var resultOdd = await FilterOddAsync(integerList);
resultOdd.ForEach(i => Console.WriteLine(i));
#endregion


#region Task4
var resultSum = await CalculateSumAsync(integerList);
Console.WriteLine(resultSum);
#endregion
