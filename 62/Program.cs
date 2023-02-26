// Напишите программу, которая заполнит спирально массив 4 на 4. 
// Например, на выходе получается вот такой массив:
// 01 02 03 04      00 01 02 03
// 12 13 14 05      10 11 12 13  array[i,j]
// 11 16 15 06      20 21 22 23
// 10 09 08 07      30 31 32 33
//       4            3         3         2       2      1   1
// {00 01 02 03} {13 23 33} {32 31 30} {20 10} {11 12} {22} {21}

// 01 02 03 04 05   00 01 02 03 04
// 16 17 18 19 06   10 11 12 13 14
// 15 24 25 20 07   20 21 22 23 24
// 14 23 22 21 08   30 31 32 33 34
// 13 12 11 10 09   40 41 42 43 44
//      j  5  >>       i  4 >>        j 4 <<      i 3 <<     j 3 >>    i 2>>  j 2<<  i 1<< j 1>>
// {00 01 02 03 04} {14 24 34 44} {43 42 41 40} {30 20 10} {11 12 13} {23 33} {32 31} {21} {22}
//  01 02 03 04 05   06 07 08 09   10 11 12 13   14 15 16   17 18 19   20 21   22 23   24   25

Console.Clear();
Console.Write("Enter the size of the array: ");
int size = int.Parse(Console.ReadLine());
int[,] array1 = new int[size, size];
int[,] array2 = SpiralFilling(array1);
PrintDoubleArray (array2);

int[,] SpiralFilling(int[,] array){
    int size = array.GetLength(0);
    int value = 1;
    int i = 0, j = 0;
    for (; j < size; j++, value++)
    {                           //  1    2    3    4    5   Значение элемента при каждой итерации
        array[i, j] = value;    // 0 0, 0 1, 0 2, 0 3, 0 4 Значение i, j при каждой итерации
    } // i = 0, j = 5, value = 6    Значение переменных по выходу из цикла
    SpiralSupportRecursion(array, value, i, j, 0);
    return array;
}

void SpiralSupportRecursion (int[,] array, int value, int i, int j, int count){
    i += 1; // i = 1 / 2
    j -= 1; // j = 4 / 3
    count += 1; // size = 4 / 3
    for (; i <= array1.GetLength(0)-count; i++, value++)
    {                        //  6    7    8    9  / 20   21
        array[i, j] = value; // 1 4, 2 4, 3 4, 4 4 / 2 3, 3 3
    } // i = 5 / 4, j = 4 / 3, value = 10 / 22
    i -= 1; // i = 4 / 3
    for (j = array1.GetLength(0)-count-1; j >= count-1; j--, value++) // j = 3 / 2, lowBoarder = 0 / 1
    {                        //  10  11   12   13  / 22   23
        array[i, j] = value; // 4 3, 4 2, 4 1, 4 0 / 3 2, 3 1
    } // i = 4 / 3, j = -1 / 0, value = 14 / 24
    j += 1; // j = 0 / 1
    for (i = array1.GetLength(0)-count-1; i >= count; i--, value++) // i = 3
    {                        //  14   15   16 / 24
        array[i, j] = value; // 3 0, 2 0, 1 0 / 2 1
    } // i = 0 / 1, j = 0 / 1, value = 17 / 25
    i += 1; // i = 1 / 2
    j += 1; // j = 1 / 2
    for (; j < array1.GetLength(0)-count; j++, value++)
    {                        // 17   18   19  / 25
        array[i, j] = value; // 1 1, 1 2, 1 3 / 2 2
    } // i = 1 / 2, j = 4 / 3, value = 20 / 26
    if(value < Math.Pow(array.GetLength(0), 2)) SpiralSupportRecursion(array, value, i, j, count);
}

void PrintDoubleArray (int[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]:00} ");
        }
        Console.WriteLine();
    }
}