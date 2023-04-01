/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

*/

//Читаем кол-во строк и колонок массива из консоли
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

//Сортирует массив по убыванию, получает и возвращает одномерный массив
int[] BubbleSort(int[] mas)
{
    int temp;
    for (int i = 0; i < mas.Length; i++)
    {
        for (int j = i + 1; j < mas.Length; j++)
        {
            if (mas[i] < mas[j])
            {
                temp = mas[i];
                mas[i] = mas[j];
                mas[j] = temp;
            }
        }
    }
    return mas;
}

//Возвращает строку numRow, двумерного массива в виде одномерного массива
int[] GetRow(int[,] array, int numRow)
{
    int[] rowArray = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(1); i++)
    {
        rowArray[i] = array[numRow, i];
    }
    return rowArray;
}

//Заполняет заданную строку numRow двумерного массива из одномерного массива array
void SetRow(int[,] matrix, int[] array, int numRow)
{
    for (int i = 0; i < array.Length; i++)
    {
        matrix[numRow, i] = array[i];
    }
}

//Сортирует строки двумерного массива
void SortRows(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        //Получаем массив строки с помощью GetRow, затем передаем её в функцию BubbleSort для сортировки, результат 
        //передаем в SetRow для записи отсортированной строки в двумерный массив.
        SetRow(matrix, BubbleSort( GetRow(matrix, i)    ), i);
    }
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

int[] matrixParameter = ReadParameterArray();
int[,] array = new int[matrixParameter[0], matrixParameter[1]];
FillMatrix(array);
PrintMatrix(array);
SortRows(array);
PrintMatrix(array);