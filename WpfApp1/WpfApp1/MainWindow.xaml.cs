using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

// 2D array that represents the Tetris grid thats (20 by 10)
static void GameSpace()
{
    int[,] gamespace =
    {  // 0  1  2  3  4  5  6  7  8  9
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
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} // 19
    };
    SearchForClear(gamespace);
}

// Binary Search looking for clears
static void SearchForClear(int[,] array)
{
    int Cleared = 0;

    // traverse Down to up in the 2d Array
    for (int Row = 19; Row >= 0; Row--)
    {
        int checkForClear = 0;
        int CheckForEmptyColumn = 0;

        // search from left to right in the 2d array
        for (int Column = 0; Column <= 9; Column++)
        {
            // count filled Rows
            if (array[Column, Row] == 1)
            {
                checkForClear++;
            }
            // count empty Rows
            else if (array[Column, Row] == 0)
            {
                CheckForEmptyColumn++;
            }
        }
        // if row is fully filled, add to cleared counter
        if (checkForClear == 10)
        {
            Cleared++;
        }
        // if full row empty then stop search
        else if (CheckForEmptyColumn == 10)
        {
            //return;
        }
    }
}

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool Rotate, down;
        int speed = 30;
        DispatcherTimer gametimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Focus();

            gametimer.Tick += gametimerEvent;
            gametimer.Interval = TimeSpan.FromMilliseconds(500);
            gametimer.Start();
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gametimerEvent(object? sender, EventArgs e)
        {

        }

    }
}
