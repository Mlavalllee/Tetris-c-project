using System.Threading;
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
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 11
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}  // 19
};

RandomShape(gamespace);
loop();

void loop() 
{
    ShapeFallingLogic(gamespace);
    PrintGame(gamespace);
    loop();
}

// create Random shape
static void RandomShape(int[,] array)
{
    Random rand = new Random();
    int Num = rand.Next(0, 7);

    switch (Num)
    {
        case 0:
            CreateSquare(array);
            break;
        case 1:
            CreateL(array);
            break;
        case 2:
            CreateReverseL(array);
            break;
        case 3:
            CreateLine(array);
            break;
        case 4:
            CreateZ(array);
            break;
        case 5:
            CreateReverseZ(array);
            break;
        case 6:
            CreateT(array);
            break;
    }
}

static void CreateSquare(int[,] array) {
    array[0, 4] = 2;
    array[0, 5] = 2;
    array[1, 4] = 2;
    array[1, 5] = 2;
}

static void CreateL(int[,] array)
{
    array[0, 5] = 2;
    array[1, 5] = 2;
    array[1, 4] = 2;
    array[1, 3] = 2;
}

static void CreateReverseL(int[,] array)
{
    array[0, 3] = 2;
    array[1, 3] = 2;
    array[1, 4] = 2;
    array[1, 5] = 2;
}

static void CreateLine(int[,] array)
{
    array[0, 3] = 2;
    array[0, 4] = 2;
    array[0, 5] = 2;
    array[0, 6] = 2;
}

static void CreateZ(int[,] array)
{
    array[0, 3] = 2;
    array[0, 4] = 2;
    array[1, 4] = 2;
    array[1, 5] = 2;
}

static void CreateReverseZ(int[,] array)
{
    array[0, 5] = 2;
    array[0, 4] = 2;
    array[1, 4] = 2;
    array[1, 3] = 2;
}

static void CreateT(int[,] array)
{
    array[0, 3] = 2;
    array[0, 4] = 2;
    array[0, 5] = 2;
    array[1, 4] = 2;
}

// shape logic
static async void ShapeFallingLogic(int[,] array)
{
    // move all blocks down 1 
    for (int Column = 19; Column >= 0; Column--)
    {
        for (int Row = 0; Row < 10; Row++)
        {
            if (Column != 19 && array[Column + 1, Row] != 1 && array[Column, Row] == 2)
            {
                array[Column + 1, Row] = 2;
                array[Column, Row] = 0;
            }
        }
    }
    ShapeLockingLogic(array);
}

static void ShapeLockingLogic(int[,] array)
{
    int temp = 0;
    for (int Column = 19; Column >= 0; Column--)
    {
        for (int Row = 0; Row < 10; Row++)
        {
            if (Column == 19 && array[Column, Row] == 2 ||
            Column != 19 && array[Column + 1, Row] == 1 && array[Column, Row] == 2)
            {
                array[Column, Row] = 1;
                temp++;
                break;
            }
            if (temp != 0)
            {
                break;
            }
        }
        if (temp != 0)
        {
            for (int column = 19; column >= 0; column--)
            {
                for (int row = 0; row < 10; row++)
                {
                    if (array[column, row] == 2)
                    {
                        array[column, row] = 1;
                    }
                }
            }
            SearchForClear(array);
            RandomShape(array);
            break;
        }
    }
}

// clear logic
static void SearchForClear(int[,] array)
{
    // traverse Down to up in the 2d Array
    for (int Column = 19; Column >= 0; Column--)
    {
        int CheckForClear = 0;
        for (int Row = 0; Row < 10; Row++)
        {
            // count filled column
            if (array[Column, Row] == 1)
            {
                CheckForClear++;
            }
        }
        // if column is fully filled, clear line/return to same column again to check for clear
        if (CheckForClear == 10)
        {
            Column++;
            ClearLine(array, Column - 1);
        }
        // if full row empty then stop search when empty row found
        else if (CheckForClear == 0)
        {
            break;
        }
    }
}

static void ClearLine(int[,] array, int num)
{
    // clears line
    for (int Row = 0; Row < 10; Row++)
    {
        array[num, Row] = 0;
    }
    DownAfterClear(array);
}

static void DownAfterClear (int[,] array) {
    // move all blocks down 1 
    for (int Column = 19; Column >= 0; Column--)
    {
        for (int Row = 0; Row < 10; Row++)
        {
            if (Column != 19 && array[Column + 1, Row] != 1 && array[Column, Row] == 1)
            {
                array[Column + 1, Row] = 1;
                array[Column, Row] = 0;
            }
        }
    }
}

// print game to console
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



// maybe replace parts of searches for better efficency 
int LinearSearch(int[] array, int item)
{
    for (int i = 0; i < array.Length; i++)
        {
        if (array[i] == item)
        {
            return 1;
        }
    }
    return -1;
}