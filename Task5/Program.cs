/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

const int ROW = 0;
const int COLUMN = 1;


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

//Функция заполняет по спирали двумерный массив любой размерности
void FillSpiralMatrix(int[,] matrix)
{
    int dRow = 0; //Приращение по строкам
    int dColumn = 1; //Приращение по столбцам
    int row = 0;
    int column = 0;

    for (int i = 1; i <= matrix.GetLength(ROW) * matrix.GetLength(COLUMN); i++)
    {
        matrix[row, column] = i;
        
        
        //Если следующий шаг уже заполнен (не 0) или выйдем за пределы индекса (стоим на краю), то поворачиваем по часовой стрелке
        if (
            row + dRow >= matrix.GetLength(ROW) ||
            column + dColumn >= matrix.GetLength(COLUMN)||
            row + dRow < 0 ||
            column + dColumn < 0||
            matrix[row + dRow, column + dColumn] != 0
        )
        {
            //Если двигались направо, то двигаемся вниз
            if (dRow == 0 && dColumn == 1) { dRow = 1; dColumn = 0; }
            //Если двигались вниз, то двигаемся налево
            else if (dRow == 1 && dColumn == 0) { dRow = 0; dColumn = -1; }
            //Если двигались налево, то двигаемся вверх
            else if (dRow == 0 && dColumn == -1) { dRow = -1; dColumn = 0; }
            //Если двигались вверх, то двигаемся направо
            else { dRow = 0; dColumn = 1; }
        }
        row += dRow;
        column += dColumn;
    }
}


int[,] matrix = new int[4, 4];

FillSpiralMatrix(matrix);
PrintMatrix(matrix);