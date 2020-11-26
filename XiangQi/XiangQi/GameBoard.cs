using System;
using System.Collections.Generic;
using System.Text;

namespace XiangQi
{
    class GameBoard
    {
        protected int selectedX;//要去的横坐标
        protected int selectedY;//要去的纵坐标
        protected Winner winner;
        protected Boolean GeneralAlive=true;
        public static  Player_side CurrentSide=Player_side.red;
        public static Piece[,] pieces = new Piece[10, 9];//每张棋盘上有要去的坐标
        public int[] GeneralLocation = new int[4] { 4, 9, 4, 0 };//先红再黑
        public Piece[,] getPiece()
        {
            return pieces;
        }
        public Player_side GetCurrentSide()
        {
            return CurrentSide;
        }
        public void SwitchPlayer()
        {
            if (CurrentSide == Player_side.red)
                CurrentSide = Player_side.black;
            else
                CurrentSide = Player_side.red;
        }
        public Boolean getGeneralAlive()
        {
            return GeneralAlive;
        }
        public Winner Return_Winner()
        {
            return winner;
        }
        public int LetterTonumber_swtich(char horizontal)
        {
            int h = 0;
            switch (horizontal)
            {
                case 'a': h = 0; break;
                case 'b': h = 1; break;
                case 'c': h = 2; break;
                case 'd': h = 3; break;
                case 'e': h = 4; break;
                case 'f': h = 5; break;
                case 'g': h = 6; break;
                case 'h': h = 7; break;
                case 'i': h = 8; break;
                default:
                    break;
            }
            return h;
        }
        public char NumberToletter_switch(int number)
        {
            char letter = 'a';
            switch (number)
            {
                case 0: letter = 'a'; break;
                case 1: letter = 'b'; break;
                case 2: letter = 'c'; break;
                case 3: letter = 'd'; break;
                case 4: letter = 'e'; break;
                case 5: letter = 'f'; break;
                case 6: letter = 'g'; break;
                case 7: letter = 'h'; break;
                case 8: letter = 'i'; break;
                default: break;
            }
            return letter;
        }
        public int getSelectedX()
        {
            return selectedX;
        }
        public int getSelectedY()
        {
            return selectedY;
        }
        public  GameBoard()//给棋盘所有棋子赋值
        {
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    if (i != 0 && i != 9)
                    {
                        if (i == 2 || i == 7)
                        {
                            if (j != 1 && j != 7)
                            {
                                pieces[i, j] = new Blank(NumberToletter_switch(j), i, Player_side.blank);
                            }
                        }
                        else if (i == 3 || i == 6)
                        {
                            if (j == 1 || j == 3 || j == 5 || j == 7)
                            {
                                pieces[i, j] = new Blank(NumberToletter_switch(j), i, Player_side.blank);

                            }
                        }
                        else
                        {
                            pieces[i, j] = new Blank(NumberToletter_switch(j), i, Player_side.blank);
                        }
                    }
                    
                }
            }
            pieces[9, 0] = new Rook('a', 9, Player_side.red);             //每个棋子的起始位置
            pieces[9, 1] = new Horse('b', 9, Player_side.red);
            pieces[9, 2] = new Elephant('c', 9, Player_side.red);
            pieces[9, 3] = new Advisor('d', 9, Player_side.red);
            pieces[9, 4] = new General('e', 9, Player_side.red);
            pieces[9, 5] = new Advisor('f', 9, Player_side.red);
            pieces[9, 6] = new Elephant('g', 9, Player_side.red);
            pieces[9, 7] = new Horse('h', 9, Player_side.red);
            pieces[9, 8] = new Rook('i', 9, Player_side.red);
            pieces[7, 1] = new Cannon('b', 7, Player_side.red);
            pieces[7, 7] = new Cannon('h', 7, Player_side.red);
            pieces[6, 0] = new Soldier('a', 6, Player_side.red);
            pieces[6, 2] = new Soldier('c', 6, Player_side.red);
            pieces[6, 4] = new Soldier('e', 6, Player_side.red);
            pieces[6, 6] = new Soldier('g', 6, Player_side.red);
            pieces[6, 8] = new Soldier('i', 6, Player_side.red);

            pieces[0, 0] = new Rook('a', 0, Player_side.black);
            pieces[0, 1] = new Horse('b', 0, Player_side.black);
            pieces[0, 2] = new Elephant('c', 0, Player_side.black);
            pieces[0, 3] = new Advisor('d', 0, Player_side.black);
            pieces[0, 4] = new General('e', 0, Player_side.black);
            pieces[0, 5] = new Advisor('f', 0, Player_side.black);
            pieces[0, 6] = new Elephant('g', 0, Player_side.black);
            pieces[0, 7] = new Horse('h', 0, Player_side.black);
            pieces[0, 8] = new Rook('i', 0, Player_side.black);
            pieces[2, 1] = new Cannon('b', 2, Player_side.black);
            pieces[2, 7] = new Cannon('h', 2, Player_side.black);
            pieces[3, 0] = new Soldier('a', 3, Player_side.black);
            pieces[3, 2] = new Soldier('c', 3, Player_side.black);
            pieces[3, 4] = new Soldier('e', 3, Player_side.black);
            pieces[3, 6] = new Soldier('g', 3, Player_side.black);
            pieces[3, 8] = new Soldier('i', 3, Player_side.black);

            
        }
        public int[] InputJudgement(string Input)//判断输入的坐标是否在棋盘内且符合格式要求
        {
            int[] LocationArray = new int[2] { -1, -1 };
            if (Input.Length != 2)
                return LocationArray;
            if (Input[0] > 96 && Input[0] < 106)
                LocationArray[0] = Input[0] - 97;
            if (Input[1] > 47 && Input[1] < 58)
                LocationArray[1] = Input[1] - 48;
            return LocationArray;

        }
        public Boolean boolSelected(string Input)
        {
            int[] LocationArray = new int[2];//LocationArray[0]储存的是选中棋子的横坐标，LocationArray[1]储存的是选中棋子的竖坐标
            LocationArray = InputJudgement(Input);
            if (LocationArray[0] < 0 || LocationArray[1] < 0)
            {
                Console.WriteLine("Sorry, your Input is wrong. Please choose again");
                return false; 
            }
            if (pieces[LocationArray[1], LocationArray[0]].type == Piece_type.blank)
            {
                Console.WriteLine("You have chosen the place that have no piece. Please choose again");
                return false; 
            }
            if (pieces[LocationArray[1], LocationArray[0]].side != CurrentSide)
            {
                Console.WriteLine("Sorry, you choose the wrong side piece.Please choose again");
                return false;
            }
            this.selectedX=LocationArray[0];//将选中的横坐标赋给当前的棋盘
            this.selectedY = LocationArray[1];//将选中的纵坐标赋给当前的棋盘
            return true;
        }
        public Boolean boolTogo(string Input)
        {
            int[] LocationArray = new int[2];
            LocationArray = InputJudgement(Input);
            int ChosenX = LocationArray[0];
            int ChosenY = LocationArray[1];
            //if(pieces[LocationArray[1], LocationArray[0]].boolCanMove())这里要判断去的坐标是否为空且不应该为自己一方的（还没写出来）
            if (selectedY == ChosenY && selectedX == ChosenX)
            {
                SwitchPlayer();
                return true;
            }
            if (pieces[selectedY, selectedX].ValidMove(ChosenX,ChosenY,this))//是否符合规则
            {
                ChangeGeneral_Location(ChosenX, ChosenY);
                if (pieces[ChosenY, ChosenX].type == Piece_type.General)
                {
                    if (pieces[ChosenY, ChosenX].side == Player_side.red)
                        winner = Winner.Black;
                    if (pieces[ChosenY, ChosenX].side == Player_side.black)
                        winner = Winner.Red;
                    GeneralAlive = false;
                }
                MovePiece(ChosenX, ChosenY);
                return DetectGeneral_OneLine(ChosenX, ChosenY); 
            }
            return false;
        }
        public Boolean DetectGeneral_OneLine(int ChosenX,int ChosenY)
        {
            int RH, RV, BH, BV;
            RH = GeneralLocation[0];RV = GeneralLocation[1];BH = GeneralLocation[2];BV = GeneralLocation[3];
            if (RH == BH)
            {
                int count = 0;
                for (int i = BV+1; i <=RV-1; i++)
                {
                    if (pieces[i, RH].type != Piece_type.blank)
                        count++;
                    if (count >= 1)
                        break;
                }
                if (count == 0)
                {
                    RegretPiece(ChosenX, ChosenY);
                    return false;
                }
                return true;
            }
            return true;
        }
        public void ChangeGeneral_Location(int ChosenX,int ChosenY)//改变将在棋盘上标记的坐标
        {
            if (pieces[selectedY, selectedX].type == Piece_type.General)
            {
                if(pieces[selectedY, selectedX].side==Player_side.red)
                {
                    GeneralLocation[0] = ChosenX;GeneralLocation[1] = ChosenY;
                }
                if(pieces[selectedY, selectedX].side == Player_side.black)
                {
                    GeneralLocation[2] = ChosenX; GeneralLocation[3] = ChosenY;
                }
            }
        }
        public void MovePiece(int ChosenX,int ChosenY)
        {
            pieces[ChosenY, ChosenX] = pieces[selectedY, selectedX];
            pieces[selectedY, selectedX] = new Blank(NumberToletter_switch(selectedY), selectedX, Player_side.blank);
        }
        public void RegretPiece(int ChosenX,int ChosenY)//将棋子搬回去（类似于悔棋）但只适用于选中的棋子走之后，将在一条直线且中间没棋子时
        {
            pieces[selectedY, selectedX] = pieces[ChosenY, ChosenX];
            pieces[ChosenY, ChosenX] = new Blank(NumberToletter_switch(ChosenY), ChosenX, Player_side.blank);
        }
    }
}

