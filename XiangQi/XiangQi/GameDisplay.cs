using System;
using System.Collections.Generic;
using System.Text;

namespace XiangQi
{
    class GameDisplay
    {
        public void DisplayBorad(GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" _____________________________ ");
            pieces = theboard.getPiece();
            for (int i = 0; i < pieces.GetLength(0); i++)//行
            {
                for (int j = 0; j < pieces.GetLength(1); j++)//列 
                {
                    if (j == 0)//第一列
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(i + " ");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("丨");
                    }
                    Console.ForegroundColor = ConsoleColor.Black;

                    switch (pieces[i, j].type)
                    {
                        case Piece_type.blank:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" 十"); break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    if (pieces[i, j].side == Player_side.red)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        switch (pieces[i, j].type)
                        {
                            case Piece_type.Rook: Console.Write(" 車"); break;
                            case Piece_type.Horse: Console.Write(" 馬"); break;
                            case Piece_type.Elephant: Console.Write(" 相"); break;
                            case Piece_type.Advisor: Console.Write(" 仕"); break;
                            case Piece_type.General: Console.Write(" 帥"); break;
                            case Piece_type.Cannon: Console.Write(" 砲"); break;
                            case Piece_type.Soldier: Console.Write(" 兵"); break;
                            default: break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (pieces[i, j].side == Player_side.black)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        switch (pieces[i, j].type)
                        {
                            case Piece_type.Rook: Console.Write(" 車"); break;
                            case Piece_type.Horse: Console.Write(" 馬"); break;
                            case Piece_type.Elephant: Console.Write(" 象"); break;
                            case Piece_type.Advisor: Console.Write(" 士"); break;
                            case Piece_type.General: Console.Write(" 將"); break;
                            case Piece_type.Cannon: Console.Write(" 炮"); break;
                            case Piece_type.Soldier: Console.Write(" 卒"); break;
                            default: break;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (j == 8)//最后一列
                    {

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("丨");
                    }
                    if (i == 4 && j == 8)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("丨     楚  河      漢  界    丨\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ￣￣￣￣￣￣￣￣￣￣￣￣￣￣￣");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("     a  b  c  d   e  f  g  h  i   ");
        }
        public void AskSelectPiece()
        {
            Console.WriteLine("Which piece do you want to move?");
        }
        public void AskMovePiece()
        {
            Console.WriteLine("Where do you want to move?");
            Console.WriteLine("(Input the same location to cancel the selection)");
        }
        public void DisplayTheside(GameBoard theboard)
        {
            if (GameBoard.CurrentSide == Player_side.red)
            {
                Console.Write("The current side:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(theboard.GetCurrentSide());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (GameBoard.CurrentSide == Player_side.black)
            {
                Console.Write("The current side:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(theboard.GetCurrentSide());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void Refresh()
        {
            Console.Clear();
        }
        public void Congratulate(GameBoard theboard)
        {
            if (theboard.Return_Winner() == Winner.Red)
            {
                Console.Write("Congratulation! The ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(theboard.Return_Winner());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" win!!!");
            }
            else
            {
                Console.WriteLine("Congratulation! The " + theboard.Return_Winner() + " win!!!");
            }
        }
        public void Ifwin(GameBoard board, GameDisplay display)
        {
            if (board.getGeneralAlive() == true)
            {
                display.Refresh();
                display.DisplayBorad(board);
                board.SwitchPlayer();
            }
            else
            {
                display.Refresh();
                display.DisplayBorad(board);
                display.Congratulate(board);
            }
        }
    }
}

