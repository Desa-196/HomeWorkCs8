/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/


//Читаем кол-во строк и колонок массива из консоли

const int ROW = 0;
const int COLUMN = 1;

int[] ReadParameterArray()
{
    Console.Write("Введите кол-во строк и колонок в двумерном массиве через пробел: ");

    int[] IntReadString = new int[2];
    while (true)
    {

        string[] ReadString = Console.ReadLine()!.Split();
        if (ReadString.Length != 2)
        {
            Console.Write("Необходимо ввести 2 числа, кол-во строк и колонок массива, повторите ввод: ");
        }
        else if (int.TryParse(ReadString[0], out IntReadString[0]) && int.TryParse(ReadString[1], out IntReadString[1]))
        {
            break;
        }
        else
        {
            Console.Write("Введены некорректные числа, повторите попытку ввода:");
        }
    }
    return IntReadString;
}

//Выводит двумерный массив на экран
void PrintMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}



//Возвращает массив со значениями сумм всех элементов строки двумерного массива
int[] GetSumRow(int[,] array)
{
    int[] rowArray = new int[array.GetLength(0)];
    int sum = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        rowArray[i] = sum;
        sum = 0;
    }
    return rowArray;
}

//Возвращает индекс минимального элемента массива
int GetMinIndexElement(int[] array)
{
    int min = array[0];
    int indexMinElement = 0;

    for (int i = 1; i < array.Length; i++)
    {
        if (min > array[i])
        {
            min = array[i];
            indexMinElement = i;
        }
    }
    return indexMinElement;
}

//Заполняет массив случайными числами от 1 до 10
void FillMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(0, 11);
        }
    }
}

int[] readMatrixParameter = ReadParameterArray();

int[,] matrix = new int[readMatrixParameter[ROW], readMatrixParameter[COLUMN]];

FillMatrix(matrix);
PrintMatrix(matrix);

Console.WriteLine(  GetMinIndexElement(GetSumRow(matrix))    );