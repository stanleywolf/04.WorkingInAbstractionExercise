using System;
using System.Linq;


class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();
        int x = dimestions[0];
        int y = dimestions[1];

        int[,] matrix = new int[x, y];

        int value = 0;
        value = FillMatrix(x, y, matrix, value);

        string command;
        long sum = 0;
        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] ivoS = command.Split().Select(int.Parse)
                .ToArray();
            int[] evil = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int xEvil = evil[0];
            int yEvil = evil[1];

            int xIvo, yIvo;

            IvoMoves(matrix, ivoS, ref xEvil, ref yEvil, out xIvo, out yIvo);

            EvilMoves(matrix, ref sum, ref xIvo, ref yIvo);
        }

        Console.WriteLine(sum);

    }

    private static int FillMatrix(int x, int y, int[,] matrix, int value)
    {
        for (int row = 0; row < x; row++)
        {
            for (int col = 0; col < y; col++)
            {
                matrix[row, col] = value++;
            }
        }

        return value;
    }

    private static void EvilMoves(int[,] matrix, ref long sum, ref int xIvo, ref int yIvo)
    {
        while (xIvo >= 0 && yIvo < matrix.GetLength(1))
        {
            if (xIvo >= 0 && xIvo < matrix.GetLength(0) && yIvo >= 0 && yIvo < matrix.GetLength(1))
            {
                sum += matrix[xIvo, yIvo];
            }

            yIvo++;
            xIvo--;
        }
    }

    private static void IvoMoves(int[,] matrix, int[] ivoS, ref int xEvil, ref int yEvil, out int xIvo, out int yIvo)
    {
        while (xEvil >= 0 && yEvil >= 0)
        {
            if (xEvil >= 0 && xEvil < matrix.GetLength(0) && yEvil >= 0 && yEvil < matrix.GetLength(1))
            {
                matrix[xEvil, yEvil] = 0;
            }
            xEvil--;
            yEvil--;
        }

        xIvo = ivoS[0];
        yIvo = ivoS[1];
    }
}

