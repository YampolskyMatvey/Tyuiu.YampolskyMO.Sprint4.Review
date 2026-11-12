using System.Text;
using Tyuiu.YampolskyMO.Sprint4.TaskReview.V30.Lib;

namespace Tyuiu.YampolskyMO.Sprint4.TaskReview.V30;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Спринт #4 | Выполнил: Ямпольский М. О. | ИИПб-26-1";
        const string source = "684259137159648";
        DataService ds = new DataService();
        int[,] matrix = ds.GetMatrix(source, 5, 3);

        Line();
        Row("Спринт #4");
        Row("Тема: Добавление к решению итоговых проектов");
        Row("Вариант #30");
        Row("Выполнил: Ямпольский Матвей Олегович | ИИПб-26-1");
        Line();
        Row("УСЛОВИЕ:");
        Row("Дана строка из одноразрядных цифр.");
        Row("Преобразовать её в матрицу 5 на 3 и подсчитать");
        Row("произведение чётных чисел.");
        Line();
        Row("ИСХОДНЫЕ ДАННЫЕ:");
        Row("Строка: " + source);
        Line();
        Row("Матрица 5 x 3:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string row = "";
            for (int j = 0; j < matrix.GetLength(1); j++)
                row += matrix[i, j].ToString().PadLeft(4);
            Row(row);
        }
        Line();
        Row("РЕЗУЛЬТАТ:");
        Row("Произведение чётных элементов = " + ds.Calculate(matrix));
        Line();
        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey(true);
        }
    }

    private static void Line() => Console.WriteLine(new string('*', 76));
    private static void Row(string text) => Console.WriteLine("* " + text.PadRight(72) + " *");
}
