﻿// Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void GetRowsDescend (int[,] massive)
{
    for (int row = 0; row < massive.GetLength(0); row++)
    {
        for (int column = 0; column < massive.GetLength(1) - 1; column++)
        {
            int colMax = column;
            for (int j = column + 1; j < massive.GetLength(1); j++)
            {
                if (massive[row, j] > massive[row, colMax])
                {
                    colMax = j;
                }
            }
            int temp = massive[row, column];
            massive[row, column] = massive[row, colMax];
            massive[row, colMax] = temp;
        }
    }
}
void Print2DMassive(int[,] massive)
{
    for( int i = 0; i < massive.GetLength(0); i++)
    {
        for( int j = 0; j < massive.GetLength(1); j++)
        {
            Console.Write($" {massive[i, j]}\t", -2);
        }
        Console.WriteLine();
    }
}

int[,] Generate2DMassive(int rows, int columns, int startValue, int finishValue)
{
    int[,] matrix = new int[rows,columns];
    for( int i = 0; i < matrix.GetLength(0); i++)
    {
        for( int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(startValue, finishValue + 1);
        }
    }
    return matrix;
}

int GetInput(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int m = GetInput("Введите количество строк массива: ");
int n = GetInput("Введите количество столбцов массива: ");
int startValue = GetInput("Введите минимальное число диапазона: ");
int finishValue = GetInput("Введите максимальное число диапазона: ");
int[,] massive = Generate2DMassive(m, n, startValue, finishValue);
Print2DMassive(massive);
Console.WriteLine("Новый массив:");
GetRowsDescend(massive);
Print2DMassive(massive);