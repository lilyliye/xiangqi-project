using System;

namespace XiangQi
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            GameDisplay display = new GameDisplay();
            //给棋盘所有棋子赋值 空黑红
            display.DisplayBorad(board);//打印棋盘
            while (board.getGeneralAlive() == true)
            {
                display.DisplayTheside(board);
                display.AskSelectPiece();
                while (!board.boolSelected(Console.ReadLine()) == true) { }
                display.AskMovePiece();
                while (!board.boolTogo(Console.ReadLine()) == true)
                {
                    Console.WriteLine("Sorry, the piece you choose can not go to the location. Please choose the place you want to go again");
                }
                display.Ifwin(board, display);
            }
        }
    }
}

