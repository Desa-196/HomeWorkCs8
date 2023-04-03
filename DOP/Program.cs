/*
Задача 61(Дополнительная задача):Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника
*/

int get_int_from_console()
{
    int console_int = 0;

    Console.Write("Введите кол-во строк: ");

    while(true)
    {
        if( int.TryParse(Console.ReadLine(), out console_int ) )
        {
            break;
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }
    }
    return console_int;

}

double factorial(int n)
{
    double x = 1;
    for (int i = 1; i <= n; i++)
    {
        x *= i;
    }
    return x;
}
void PrintPascalTriangle(int n)
{
    for (int i = 0; i < n; i++)
    {
        //Добавляем табуляцию перед началом каждой строки
        for (int k = (n / 2) * 2 - i; k > 0; k--)
        {
            Console.Write("\t");
        }
        for (int j = 0; j <= i; j++)
        {
            //По формуле рассчитываем каждый элемент треугольника
            Console.Write($"{factorial(i) / (factorial(j) * factorial(i - j))}\t\t");
        }
        Console.WriteLine();
    }
}

PrintPascalTriangle(get_int_from_console());