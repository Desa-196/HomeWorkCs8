/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)

*/
//Тут будем хранить уникальные числа которыми уже заполнили массив, для проверки, были ли они уже.
HashSet<int> hashSet = new HashSet<int>();

//Читаем кол-во строк и колонок массива из консоли
int[] ReadParameterArray()
{
    Console.Write("Введите высоту, ширину и глубину трехмерного массива через пробел: ");

    int[] intReadString = new int[3];
    while (true)
    {

        string[] ReadString = Console.ReadLine()!.Split();
        if (ReadString.Length != 3)
        {
            Console.Write("Необходимо ввести 3 числа, повторите ввод: ");
        }
        else if (int.TryParse(ReadString[0], out intReadString[0]) && int.TryParse(ReadString[1], out intReadString[1]) && int.TryParse(ReadString[2], out intReadString[2]))
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

//Выводит "послойно" трехмерный массив на экран
void PrintMatrix(int[,,] array)
{
    for (int k = 0; k < array.GetLength(1); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {

                Console.Write($"   {array[i, j, k]} ({i}, {j}, {k})");

            }
            Console.WriteLine();
        }
        Console.Write("\n\n");

    }

}

//Заполняет массив случайными, неповторяющимися числами от 10 до 99
void FillMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                //В цикле присваиваем случайное число переменной random_int, затем проверяем, 
                //было ли уже это число, если в hashSet оно уже есть, значит было, пробуем ещё раз.
                int random_int;
                do
                {
                    random_int = new Random().Next(10, 100);
                }
                while (hashSet.Contains(random_int));

                matrix[i, j, k] = random_int;
                hashSet.Add(random_int);
            }
        }
    }
}

int[] matrixParameter1;
//Проверяем введенные размеры массива, если общее число элементов массива больше 90, 
//значит мы не сможем сгенерировать столько уникальных двузначных чисел
while (true)
{
    matrixParameter1 = ReadParameterArray();
    if (matrixParameter1[0] * matrixParameter1[1] * matrixParameter1[2] > 90) 
        Console.WriteLine($"Матрица {matrixParameter1[0]}x{matrixParameter1[1]}x{matrixParameter1[2]}"+
        $" будет содержать {matrixParameter1[0]*matrixParameter1[1]*matrixParameter1[2]} элемента,"+
        " невозможно создать такое кол-во неповторяющихся двухзначных чисел");
    else break;
}
int[,,] matrix3D = new int[matrixParameter1[0], matrixParameter1[1], matrixParameter1[2]];
FillMatrix(matrix3D);
PrintMatrix(matrix3D);