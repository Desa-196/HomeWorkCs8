/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18

*/


const int ROW = 0;
const int COLUMN = 1;


//Читаем кол-во строк и колонок массива из консоли
int[] ReadParameterArray()
{
    Console.Write("Введите кол-во строк и колонок в двумерном массиве через пробел: ");

    int[] intReadString = new int[2];
    while (true)
    {

        string[] ReadString = Console.ReadLine()!.Split();
        if (ReadString.Length != 2)
        {
            Console.Write("Необходимо ввести 2 числа, кол-во строк и колонок массива, повторите ввод: ");
        }
        else if (int.TryParse(ReadString[0], out intReadString[0]) && int.TryParse(ReadString[1], out intReadString[1]))
        {
            break;
        }
        else
        {
            Console.Write("Введены некорректные числа, повторите попытку ввода:");
        }
    }
    return intReadString;
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

//Проверяет, можно ли перемножить matrix1 на matrix2
bool CheckMultiplicationMatrix(int[] matrixParameter1, int[] matrixParameter2)
{
    //Матрицу P можно умножить на матрицу K только в том случае, 
    //если число столбцов матрицы P равняется числу строк матрицы K. 
    //Матрицы, для которых данное условие не выполняется, умножать нельзя.
    if (matrixParameter1[COLUMN] == matrixParameter2[ROW]) return true;
    return false;
}

//Перемножает матрицы, возвращает результирующую матрицу
int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] multiplicationMatrix = new int[matrix1.GetLength(ROW), matrix2.GetLength(COLUMN)];

    for (int i = 0; i < multiplicationMatrix.GetLength(ROW); i++)
    {
        for (int j = 0; j < multiplicationMatrix.GetLength(COLUMN); j++)
        {
            for(int k=0; k<matrix1.GetLength(COLUMN); k++)
            {
                multiplicationMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }

    return multiplicationMatrix;

}

int[] matrixParameter1;
int[] matrixParameter2;

while (true)
{
    Console.WriteLine("Ввод параметров матрицы 1");
    matrixParameter1 = ReadParameterArray();

    Console.WriteLine("Ввод параметров матрицы 2");
    matrixParameter2 = ReadParameterArray();

    //Если матрицы возможно перемножить, выходим
    if (CheckMultiplicationMatrix(matrixParameter1, matrixParameter2)) break;
    //Если нельзя, просим ввести другие размеры
    else Console.WriteLine("Такие матрицы нельзя перемножить! Повторите ввод.");

}

int[,] matrix1 = new int[matrixParameter1[ROW], matrixParameter1[COLUMN]];
int[,] matrix2 = new int[matrixParameter2[ROW], matrixParameter2[COLUMN]];

FillMatrix(matrix1);
FillMatrix(matrix2);

PrintMatrix(matrix1);
PrintMatrix(matrix2);
PrintMatrix(MultiplicationMatrix(matrix1, matrix2));