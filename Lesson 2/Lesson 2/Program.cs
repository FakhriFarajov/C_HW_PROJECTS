#region Task1

using System.Globalization;

int[] array = {1,1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

int even = 0;
int odd = 0;
int count = 0;
for (int i = 0; i < array.Length; i++)
{
    if (array[i] % 2 == 0)
    {
        even++;
    }
    else if (array[i] % 2 != 0)
    {
        odd++;
    }

    int temp_count = 0;
    for (int j = 0; j < array.Length; j++)
    {
        if (array[i] == array[j])
        {
            temp_count++;
        }
    }


    if (temp_count > 1)
    {
        continue;
    }
    else
    {
        count++;
    }
}

Console.WriteLine("Task1");

Console.WriteLine(even);
Console.WriteLine(odd);
Console.WriteLine(count);

#endregion

#region Task2
int[] array1 = {1,1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
int userNUmber;
bool res = int.TryParse(Console.ReadLine(), out userNUmber);
if (res)
{
    for (int i = 0; i < array1.Length; i++)
    {
        if (userNUmber > array1[i])
        {
            Console.Write($"{array1[i]} " );
        }
    }
}
Console.WriteLine("Task2");

Console.WriteLine();
#endregion

#region Task3
int[] array2 = {1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
int number3 = int.Parse(Console.ReadLine());

int sequence = 0;

for (int i = 0; i + 2 < array2.Length; i++)
{
    if (array2[i] == number1 && array2[i + 1] == number2 && array2[i + 2] == number3)
    {
        sequence++;
    }
}

Console.WriteLine("Task3");
Console.WriteLine(sequence);

#endregion

#region Task4


int[] array3 = {1, 23};
int[] array4 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
int[] array5 = new int[array3.Length + array4.Length];

int index_count = 0;
for (int i = 0; i < array3.Length; i++)
{
    array5[index_count++] = array3[i];
}
for (int i = 0; i < array4.Length; i++)
{
    if (array5[i] == array4[i])
    {
        continue;
    }
    array5[index_count++] = array4[i];
}

Console.WriteLine("Task4");

for (int i = 0; i < index_count; i++)
{
    Console.Write($"{array5[i]} " );
}


#endregion

#region Task5


int[][] jagged_arr = new int[][] 
{
    new int[] {1, 2, 3, 4},
    new int[] {11, 34, 67},
    new int[] {89, 23},
    new int[] {0, 45, 78, 53, 99}
};


int max = jagged_arr[0][0];
int min = jagged_arr[0][0];


for (int i = 0; i < jagged_arr.Length; i++)
{
    for (int j = 0; j < jagged_arr[i].Length; j++)
    {
        if (jagged_arr[i][j] > max)
        {
            max = jagged_arr[i][j];
        }

        if (jagged_arr[i][j] < min)
        {
            min = jagged_arr[i][j];
        }
    }
}

Console.WriteLine("Task5");
Console.WriteLine(max);
Console.WriteLine(min);






#endregion

#region Task6
string sentance = Console.ReadLine();

string[] array_string = sentance.Split();

Console.WriteLine("Task6");
Console.WriteLine(array_string.Length);
#endregion

#region Task7
string input = Console.ReadLine();

string[] words = input.Split();

for (int i = 0; i < words.Length; i++)
{
    char[] charArray = words[i].ToCharArray();
    charArray.Reverse();
    string word = new string(charArray);
    words[i] = word;
}

string result = string.Join(" ", words);

Console.WriteLine($"Результат: {result}");
#endregion

#region Task8
string array_string2 = Console.ReadLine().ToLowerInvariant();

char[] vowels = {'a', 'e', 'i', 'o', 'u'};

int coutner_wovel = 0;
for (int i = 0; i < array_string2.Length; i++)
{
    if (Array.Exists(vowels, v => v == array_string2[i]))
    {
        coutner_wovel++;
    }
}

Console.WriteLine("Task8");
Console.WriteLine(coutner_wovel);

#endregion

#region Task9

string[] array_string3 = Console.ReadLine().ToLowerInvariant().Split();
string search_word = Console.ReadLine().ToLowerInvariant();
int count_word = 0;

for (int i = 0; i < array_string3.Length; i++)
{
    if (array_string3[i] == search_word)
    {
        count_word++;
    }    
}

Console.WriteLine("Task9");
Console.WriteLine(count_word);
#endregion