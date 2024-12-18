// See https://aka.ms/new-console-template for more information

using System.Text;
using HomeWork_4;


Console.OutputEncoding = Encoding.UTF8; // Інакше українське "і" не виводилось.
Console.Title = "Домашка №4";


#region Declarations
var strCollection = new GenericEnumerator<string>();
// івент метод
static void MethodOnExpanded(GenericEnumerator<string> sender, int newSize) =>
                                                                              Console.WriteLine($"  Розширили масив _data  до розміру {newSize}");
strCollection.OnExpanded += MethodOnExpanded;
#endregion

#region Ініціалізація
//strCollection.Capacity = 22;
var elementCount = 20;
Console.WriteLine($"Ініціалізація коллекції до {elementCount} элементов");
for (var i = 0; i < elementCount; i++)
{
    strCollection.Add($"Name {elementCount - i}");
}
PrintCollection(strCollection, "Коллекція після ініціалізації:");
#endregion

#region Приклади Linq
var strSorted = strCollection.OrderBy(x => Convert.ToInt32(x?[5..]));
PrintCollection(strSorted, "Отсортовано  за зростанням:");


var filterMax = 10;
var strFiltered = strCollection.Where(x => Convert.ToInt32(x?[5..]) > filterMax);
PrintCollection(strFiltered, $"Отфільтровано по номер більше ніж {filterMax}:");
#endregion

static void PrintCollection<T>(IEnumerable<T> collection, string msg = "")
{
    if (msg.Length > 0)
        Console.WriteLine(msg);
    foreach (var obj in collection)
    {
        Console.WriteLine($"  {obj?.ToString()}");
        /*if (Convert.ToInt32(obj?.ToString()[5..]) > filterMax)
            Console.WriteLine(Convert.ToInt32(obj?.ToString()[5..]));*/
    }
    Console.WriteLine();
}

