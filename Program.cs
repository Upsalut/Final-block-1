//---------------------------------------------------------------------GetText-------------------------------------------------------------------------------------+
string GetText() // Получает текст с клавиатуры или предустановленный
{
    string text   = string.Empty;
    string myText = "Написать программу, которая из имеющегося массива строк формирует массив из строк, " + 
                    "длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры," +
                    " либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.";

    Console.Write("Если хотите вывести текст с клавиатуры нажмите 'y' и Enter. Если хотите использовать предустановленный текст, то нажмите любую клавишу и Enter.");

    if(Console.ReadLine() == "y")
     {
        Console.Write("Введите текст: ");
        text = Console.ReadLine()?? "";
     }
    else
     text = myText;

    return text;
}
//---------------------------------------------------------------------CalcSignToText------------------------------------------------------------------------------+
int CalcSignToText(string text, char sign) // Считаем количество искомых знаков в тексте
{
    int signs = 0;

    for (int i = 0; i < text.Length-1; i++)
        if(text[i] == sign && text[i+1]!=sign) signs++;

    return signs;
}
//---------------------------------------------------------------------SplitTextToArray----------------------------------------------------------------------------+
string[] SplitTextToArray(string text,char sign) // Делим текст на подстроки по разделителю.
{
    string[] strArray        = new string[CalcSignToText(text,sign)+1];
    int      strArrayCounter = 0;
    string   word            = string.Empty;

    for (int i = 0; i < text.Length; i++)
    {
        if(text[i] == sign && text[i+1]!=sign)
        {
            strArray[strArrayCounter] = word;
            word = string.Empty;
            strArrayCounter ++;
        }
        else
            word += text[i];
        if(i == text.Length-1) strArray[strArrayCounter] = word;
    }

    return strArray;
}
//---------------------------------------------------------------------GetLenthBySign------------------------------------------------------------------------------+
int GetLenthBySign(string[] array, int length) // Посчитаем количество элементов в массиве с длиной по условию
{
    int counter = 0;

    foreach (var item in array)
        if(item.Length <= length) counter++;

    return counter;
}
//---------------------------------------------------------------------GetSortedArray------------------------------------------------------------------------------+
string[] GetSortedArray(string[] inputArray, int digits) // Получим по условию заполненный массив 
{
    string[] outputArray = new string[GetLenthBySign(inputArray,digits)];
    int      outputArrayCounter = 0;

    foreach (var item in inputArray)
        if(item.Length <=3) {outputArray[outputArrayCounter] = item; outputArrayCounter++;}
    
    return outputArray;
}
//---------------------------------------------------------------------PrintStringArray----------------------------------------------------------------------------+
void PrintStringArray(string[] array) // Вывод на экран строкового масиива
{
    foreach (var item in array)
        Console.WriteLine(item);
    
    Console.WriteLine("//---------------------------------------------------------------------------------------------------------------------------------+");
}
//---------------------------------------------------------------------Main----------------------------------------------------------------------------------------+
Console.Clear();
string   text        = GetText();
string[] inputArray  = SplitTextToArray(text,' ');
string[] outputArray = GetSortedArray(inputArray,3);
string   letter      = string.Empty;

Console.WriteLine();
Console.Write("Если хотите вывести исходный текст и массивы до и после сортировки на экран нажмите 'y' и Enter. Если нет, то нажмите любую клавишу и Enter.");
Console.WriteLine();
letter = Console.ReadLine()?? "0";

if(letter.Equals("y"))
{
    Console.WriteLine(text);
    Console.WriteLine();
    PrintStringArray(inputArray);
    PrintStringArray(outputArray);
}