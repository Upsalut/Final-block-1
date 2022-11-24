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