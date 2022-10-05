using System;

namespace ДЗ_2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Ввод размера таблицы
            int n = 0;
            bool result;

            do
            {
                Console.WriteLine("Введите размерность таблицы (1 до 6):");
                result = int.TryParse(Console.ReadLine(), out int k);
                if (result == true)
                {
                    n = k;
                }
            }
            while (n < 1 || n > 6 || result == false);

            // Ввод текста 
            string nTxt;
            int nTxtLenght;
            Console.WriteLine();
            do
            {
                Console.WriteLine("Введите текст не длинее 40 символов:");
                nTxt = Console.ReadLine();
            }
            while (nTxt.Length == 0 || nTxt.Length > 40);

            nTxtLenght = nTxt.Length;

            // Считаем длину строки с учётом текста
            // "Ширина таблицы (каждой строки) зависит от числа n и длины введенной строки из п.2."
            int rowLenght;
            rowLenght = n - 1 + nTxtLenght + n - 1;

            // если построение всей таблицы будет проходить в рамках одного цикла,
            // а выбор, какую строку строить - при помощи switch case when
            bool RowBool1 = false, RowBool2 = false, RowBool3 = false;

            while (RowBool1 != true || RowBool2 != true || RowBool3 != true)
            {
                Console.WriteLine();

                int rowNum = 0;// Номер строки, которую выберет пользователь для вывода на экран
                do
                {
                    Console.WriteLine("Введите номер строки для построения (1-3):"
                        + (RowBool1 != true ? "[1]" : "")
                        + (RowBool2 != true ? "[2]" : "")
                        + (RowBool3 != true ? "[3]" : ""));
                    result = int.TryParse(Console.ReadLine(), out int k);
                    if (result == true)
                    {
                        rowNum = k;
                    }
                }
                while (rowNum < 1 || rowNum > 3 || result == false);

                BringOutHorizontalLine(rowLenght);// Верхняя граница

                switch (rowNum)
                {
                    case 1:
                        // Вывести 1ю строку таблицы с текстом, введенным в п.2.,
                        // который находится на расстоянии n-1 от каждой из границ строки.
                        // 1 строка
                        BringOutRow1(n, rowLenght, nTxtLenght, nTxt);
                        RowBool1 = true;
                        break;
                    case 2:
                        // Вывести 2ю строку таблицы. Она имеет ту же высоту, что и строка 1,
                        // и представляет собой набор символов +, чередующихся в шахматном порядке.
                        // 2 строка
                        BringOutRow2(n, rowLenght);
                        RowBool2 = true;
                        break;
                    case 3:
                        // Вывести 3ю строку таблицы. Она должна быть квадратной, "перечеркнутая" символом + по диагоналям
                        // 3 строка
                        BringOutRow3(rowLenght);
                        RowBool3 = true;
                        break;
                }

                BringOutHorizontalLine(rowLenght);// Нижняя граница
            }
        }

        static void BringOutHorizontalLine(int rowLenght)
        {
            Console.Write("+");
            for (int i = 0; i <= rowLenght - 1; i++)
            {
                Console.Write("+");
            }
            Console.Write("+");
        }


        static void BringOutRow1(int n, int rowLenght, int nTxtLenght, string nTxt)
        {
            int rowHight = 0;
            for (int i = 1; i <= n - 1; i++)//отступ сверху от текста
            {
                Console.WriteLine();
                Console.Write("+");
                for (int j = 0; j <= rowLenght - 1; j++)
                {
                    Console.Write("\u0020");
                }
                rowHight++;
                Console.Write("+");
            }
            Console.WriteLine();
            Console.Write("+");

            for (int i = 0; i <= rowLenght; i++)// текст
            {
                switch (i == n - 1)
                {
                    case true:
                        Console.Write(nTxt);
                        i = i + nTxtLenght;
                        break;
                    default:
                        Console.Write("\u0020");
                        break;
                }
            }
            Console.Write("+");

            for (int i = 1; i <= n - 1; i++)// отступ снизу от текста
            {
                Console.WriteLine();
                Console.Write("+");
                for (int j = 0; j <= rowLenght - 1; j++)
                {
                    Console.Write("\u0020");
                }
                rowHight++;
                Console.Write("+");
            }
            Console.WriteLine();
        }

        static void BringOutRow2(int n, int rowLenght)
        {
            int rowHight = 0;
            for (int i = 1; i <= n * 2 - 2; i++)
            {
                rowHight++;// Для расчёта высоты строки по второму условию
            }

            int[,] chess = new int[rowHight + 1, rowLenght];
            for (int i = 0; i < rowHight + 1; i++)
            {
                Console.WriteLine();
                Console.Write("+");
                for (int j = 0; j < rowLenght; j++)
                {
                    chess[i, j] = (i + j) % 2;
                    int k = chess[i, j];
                    switch (k)
                    {
                        case 0:
                            Console.Write("+");
                            break;
                        case 1:
                            Console.Write("\u0020");
                            break;
                    }
                }
                Console.Write("+");
            }
            Console.WriteLine();
        }

        static void BringOutRow3(int rowLenght)
        {
            for (int i = 0; i <= rowLenght - 1; i++)
            {
                Console.WriteLine();
                Console.Write("+");
                int k = i;
                int k2 = rowLenght - 1 - i;
                for (int j = 0; j <= rowLenght - 1; j++)
                {
                    if (j == k || j == k2)
                    { Console.Write("+"); }
                    else
                    { Console.Write("\u0020"); }
                }
                Console.Write("+");
            }
            Console.WriteLine();
        }
    }
}