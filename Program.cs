using MathNet.Numerics.Statistics;

List<string> data_StringList = [];

try
{

    data_StringList = [.. File.ReadAllLines("Khanevar92.csv").Skip(1)];

}
catch (System.Exception readCSV_Exception)
{
    
    System.Console.WriteLine(readCSV_Exception);

}

double[] familySize_DoubleArray = new double[data_StringList.Count];

double[] totalIncome_DoubleArray = new double[data_StringList.Count];

double[] incomePerMember_DoubleArray = new double[data_StringList.Count];

for (int row_Int = 0; row_Int < data_StringList.Count; row_Int++)
{

    _ = double.TryParse(data_StringList[row_Int].Split(",")[14], out familySize_DoubleArray[row_Int]);

    _ = double.TryParse(data_StringList[row_Int].Split(",")[16], out totalIncome_DoubleArray[row_Int]);

    incomePerMember_DoubleArray[row_Int] = totalIncome_DoubleArray[row_Int]/familySize_DoubleArray[row_Int];
    
}

int tenth_Int = incomePerMember_DoubleArray.Length/10;

double[] orderedTotalIncome_DoubleArray = incomePerMember_DoubleArray.Order().ToArray()[..tenth_Int];

//A)
System.Console.WriteLine($"Average Of Total Income: {totalIncome_DoubleArray.Average()}\n");

//B)
System.Console.WriteLine($"Median Of Total Income: {totalIncome_DoubleArray.Median()}\n");

//C)
System.Console.WriteLine($"Average Of Family Income: {incomePerMember_DoubleArray.Average()}\n");

//D)
System.Console.WriteLine($"Median Of Family Income: {incomePerMember_DoubleArray.Median()}\n");

//E)
System.Console.WriteLine($"Average Of Last 10% Income: {orderedTotalIncome_DoubleArray.Average()}");

System.Console.WriteLine($"Median Of Last 10% Income: {orderedTotalIncome_DoubleArray.Median()}");

System.Console.WriteLine("Last 10% Of Incomes:");

for (int row_Int = 0; row_Int < orderedTotalIncome_DoubleArray.Length; row_Int++)
{    

    System.Console.WriteLine($"{row_Int+1}: {orderedTotalIncome_DoubleArray[row_Int]}");
    
}

System.Console.WriteLine();

System.Console.WriteLine("Enter Anything To Exit");

Console.ReadKey(true);