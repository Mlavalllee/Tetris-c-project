﻿using System.Threading;

Console.CursorVisible = false;

// 2D array that represents the Tetris grid thats (20 by 10)
int[,] gamespace =
{      // 0  1  2  3  4  5  6  7  8  9
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 1
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 3
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 7
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 9
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10
        { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2}, // 11
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0}  // 19
};

loop();

void loop() 
{
    ShapeLogic(gamespace);
    SearchForClear(gamespace);
    PrintGame(gamespace);
    loop();
}

static async void ShapeLogic(int[,] array)
{
    // move all blocks down 1 
    for (int Row = 19; Row >= 0; Row--)
    {
        int mydelay = 500; 
        for (int Column = 0; Column < 10; Column++)
        {
            if (Row == 19 && array[Row, Column] == 2 ||
            Row != 19 && array[Row + 1, Column] == 1 && array[Row, Column] == 2)
            {
                array[Row, Column] = 1;
            }

            if (Row != 19 && array[Row + 1, Column] != 1 && array[Row, Column] == 2)
            {
                await Task.Delay(mydelay);
                array[Row + 1, Column] = 2;
                array[Row, Column] = 0;
                mydelay -= 100;
            }
        }
    }
}

static void SearchForClear(int[,] array)
{

    // traverse Down to up in the 2d Array
    for (int Row = 19; Row >= 0; Row--)
    {
        int CheckForClear = 0;
        for (int Column = 0; Column < 10; Column++)
        {
            // count filled Rows
            if (array[Row, Column] == 1)
            {
                CheckForClear++;
            }
        }
        // if row is fully filled, add to cleared counter
        if (CheckForClear == 10)
        {
            Row++;
            ClearLine(array, Row - 1);
        }
        // if full row empty then stop search
        else if (CheckForClear == 0)
        {

        }
    }
}

static void ClearLine(int[,] array, int num)
{
    // clears line
    for (int Column = 0; Column < 10; Column++)
    {
        array[num, Column] = 0;
    }
    DownAfterClear(array);
}

static void DownAfterClear (int[,] array) {
    // move all blocks down 1 
    for (int Row = 19; Row >= 0; Row--)
    {
        for (int Column = 0; Column < 10; Column++)
        {
            if (Row != 19 && array[Row + 1, Column] != 1 && array[Row, Column] == 1)
            {
                array[Row + 1, Column] = 1;
                array[Row, Column] = 0;
            }
        }
    }
}

static void PrintGame(int[,] array)
{
    for (int Row = 0; Row < 20; Row++)
    {
        Console.SetCursorPosition(0, Row);
        for (int Column = 0; Column < 10; Column++)
        {
            if (array[Row, Column] == 0)
            {
                Console.Write("-");
            } else
            {
                Console.Write(array[Row, Column]);
            }
        }
    }
}