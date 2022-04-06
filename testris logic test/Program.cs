
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
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14
        { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0}, // 15
        { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0}, // 16
        { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0}, // 17
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 18
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}  // 19
};

SearchForClear(gamespace);

// Binary Search looking for clears
static void SearchForClear(int[,] array)
{
    // traverse Down to up in the 2d Array
    for (int Row = 19; Row >= 0; Row--)
    {
        int checkForClear = 0;
        int CheckForEmptyColumn = 0;
        // search from left to right in the 2d array
        for (int Column = 0; Column <= 9; Column++)
        {
            // count filled Rows
            if (array[Row, Column] == 1)
            {
                checkForClear++;
            }
            // count empty Rows
            else if (array[Row, Column] == 0)
            {
                CheckForEmptyColumn++;
            }
        }
        // if row is fully filled, add to cleared counter
        if (checkForClear == 10)
        {
            Row++;
            ClearLine(array, Row - 1);
        }
        // if full row empty then stop search
        else if (CheckForEmptyColumn == 10)
        {

        }
    }
    Test(array);
}

static void ClearLine(int[,] array, int num)
{
    // clears line
    for (int Column = 0; Column <= 9; Column++)
    {
        array[num, Column] = 0;
    }

    // move all blocks down 1 
    for (int Row = num; Row >= 0; Row--)
    {
        for (int Column = 0; Column <= 9; Column++)
        {
            if (Row != 19 && array[Row + 1, Column] != 1 && array[Row, Column] == 1)
            {
                array[Row + 1, Column] = 1;
                array[Row, Column] = 0;
            }
        }
    }
}

static void Test(int[,] array)
{
    for (int Row = 0; Row <= 19; Row++)
    {
        Console.WriteLine();
        for (int Column = 0; Column <= 9; Column++)
        {
            if(array[Row, Column] == 0)
            {
                Console.Write("-");
            } else
            {
                Console.Write(array[Row, Column]);
            }
        }
    }
}

