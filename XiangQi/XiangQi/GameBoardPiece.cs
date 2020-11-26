using System;
using System.Collections.Generic;
using System.Text;

namespace XiangQi
{
    public enum Piece_type
    {
        blank,
        General,
        Advisor,
        Elephant,
        Horse,
        Rook,
        Cannon,
        Soldier
    }
    public enum Player_side
    {
        blank,
        black,
        red
    }
    public enum Winner
    {
        Red,Black
    }
    abstract class Piece
    {
        public Player_side side;
        public char letter_horizontal;
        public int vertical;
        public Piece_type type;
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
        public Piece(char letter_horizontal, int vertical)
        {
            this.letter_horizontal = letter_horizontal;
            this.vertical = vertical;

        }
        public abstract bool ValidMove(int ChosenX,int ChosenY,GameBoard theboard);
        //判断输入的坐标能否到达，每一个子类都有一个override的
    }
    class General : Piece
    {
        public int number_horizontal;
        public General(char letter_horizontal, int vertical, Player_side side) : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);
            this.type = Piece_type.General;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();
            if (Math.Abs(ChosenX - theboard.getSelectedX()) > 1 ||Math.Abs( ChosenY - theboard.getSelectedY())>1)
                //判断输入的棋子是否大于将能走的一格
            {
                return false;
            }
            if (Math.Abs(ChosenX - theboard.getSelectedX()) != 1 && ChosenY == theboard.getSelectedY())
                //水平移动
            {
                return false;
            }
            if (Math.Abs(ChosenY - theboard.getSelectedY()) != 1 && ChosenX == theboard.getSelectedX())
                //竖直移动
            {
                return false;
            }
            else
            {
                if (this.side == Player_side.red)
                {
                    if (ChosenY <7||ChosenX<3||ChosenX>5)
                    {
                        return false;
                    }
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.red)
                            return false;
                        return true;
                    }
                }
                if (this.side == Player_side.black)
                {
                    if (ChosenY >2|| ChosenX < 3 || ChosenX > 5)
                        return false;
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.black)
                            return false;
                        return true;
                    }
                }
                return false;
            }
        }
    }
    class Advisor : Piece
    {
        public int number_horizontal;
        public Advisor(char letter_horizontal, int vertical, Player_side side)
            : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);
            this.type = Piece_type.Advisor;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();
            if (Math.Abs(ChosenX - theboard.getSelectedX()) > 1 || Math.Abs(ChosenY - theboard.getSelectedY()) > 1)
            //判断输入的棋子是否大于将能走的一格
            {
                return false;
            }
            if (Math.Abs(ChosenX - theboard.getSelectedX()) != 1 && Math.Abs(ChosenY - theboard.getSelectedY()) == 1)
                //水平移动
            {
                return false;
            }
            if (Math.Abs(ChosenY - theboard.getSelectedY()) != 1 && Math.Abs(ChosenX - theboard.getSelectedX()) == 1)
            //竖直移动
            {
                return false;
            }
            else
            {
                if (this.side == Player_side.red)
                {
                    if (ChosenY < 7 || ChosenX < 3 || ChosenX > 5)
                    {
                        return false;
                    }
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.red)
                            return false;
                        return true;
                    }
                }
                if (this.side == Player_side.black)
                {
                    if (ChosenY > 2 || ChosenX < 3 || ChosenX > 5)
                        return false;
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.black)
                            return false;
                        return true;
                    }
                }
                return false;
            }
        }
    }
    class Horse : Piece
    {
        public int number_horizontal;
        public Horse(char letter_horizontal, int vertical, Player_side side) : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);
            this.type = Piece_type.Horse;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();
            int HorseFootX1 = (ChosenX + theboard.getSelectedX()) / 2;//横马脚位置
            int HorseFootY1 = theboard.getSelectedY();
            int HorseFootX2 = theboard.getSelectedX();//竖马脚位置
            int HorseFootY2 = (ChosenY + theboard.getSelectedY()) / 2;

            if (Math.Abs(ChosenY - theboard.getSelectedY()) != 2 && Math.Abs(ChosenX - theboard.getSelectedX()) == 1)//马只能走横日
            {
                return false;
            }
            if (Math.Abs(ChosenX - theboard.getSelectedX()) == 1 && Math.Abs(ChosenY - theboard.getSelectedY()) != 2)//或者竖日
            {
                return false;
            }
            else
            {

                if (Math.Abs(ChosenX - theboard.getSelectedX()) == 2)//如果走的是 横“日”
                {
                    if (this.side == pieces[ChosenY, ChosenX].side) //判定目标位置是否有友方棋子                
                        return false;
                    if (pieces[HorseFootY1, HorseFootX1].type != Piece_type.blank)
                        return false;//判断马脚是否有棋子
                    return true;
                }
            }
            if (Math.Abs(ChosenY - theboard.getSelectedY()) == 2)//如果走的是竖 “日”
            {
                if (this.side == pieces[ChosenY, ChosenX].side)
                    return false;
                if (pieces[HorseFootY2, HorseFootX2].type != Piece_type.blank)
                    return false;//判断马脚是否有棋子
                return true;
            }
            return false;
        }
    }
    class Cannon : Piece
    {
        public int number_horizontal;
        public Cannon(char letter_horizontal, int vertical, Player_side side)
        : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);
            this.type = Piece_type.Cannon;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();

            //竖着走
            if (ChosenX == theboard.getSelectedX() && ChosenY != theboard.getSelectedY())//竖着走
            {
                int max = ChosenY > theboard.getSelectedY() ? ChosenY : theboard.getSelectedY();
                int min = ChosenY > theboard.getSelectedY() ? theboard.getSelectedY() : ChosenY;

                int count = 0;
                for (int i = min + 1; i <= max - 1; i++)//统计移动路径上棋子的数量
                    if (pieces[i, ChosenX].side == Player_side.red || pieces[i, ChosenX].side == Player_side.black)
                        count++;

                if (count == 0 && pieces[ChosenY, ChosenX].side == Player_side.blank)//0且落点无子
                {
                    return true;
                }
                else if (count == 1 && pieces[theboard.getSelectedY(), theboard.getSelectedX()].side != Player_side.blank)//1且落点有子
                {
                    if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.red)//选红吃黑
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.black)
                            return true;
                    }
                    else if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.black)
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.red)
                            return true;
                    }
                }
            }
            //横着走
            else if (ChosenY == theboard.getSelectedY() && ChosenX != theboard.getSelectedX())//横着走
            {
                int max = ChosenX > theboard.getSelectedX() ? ChosenX : theboard.getSelectedX();
                int min = ChosenX > theboard.getSelectedX() ? theboard.getSelectedX() : ChosenX;

                int count = 0;
                for (int i = min + 1; i <= max - 1; i++)//统计移动路径上棋子的数量
                    if (pieces[ChosenY, i].side == Player_side.red || pieces[ChosenY, i].side == Player_side.black)
                        count++;

                if (count == 0 && pieces[ChosenY, ChosenX].side == Player_side.blank)//0且落点无子
                {
                    return true;
                }
                else if (count == 1 && pieces[theboard.getSelectedY(), theboard.getSelectedX()].side != Player_side.blank)//1且落点有子
                {
                    if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.red)//选红子
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.black)//吃黑子
                            return true;
                    }
                    else if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.black)
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.red)
                            return true;
                    }
                }
            }
            return false;
        }
    }
    class Elephant : Piece
    {
        public int number_horizontal;
        public Elephant(char letter_horizontal, int vertical, Player_side side)
            : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);       //方法的属性
            this.type = Piece_type.Elephant;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();
            int ElephantFootX=(ChosenX+theboard.getSelectedX())/2;//象脚位置
            int ElephantFootY= (ChosenY + theboard.getSelectedY()) / 2;//
            if (Math.Abs(ChosenX - theboard.getSelectedX()) !=2 || Math.Abs(ChosenY - theboard.getSelectedY()) != 2)
            {
                return false;
            }
            else
            {
                if (this.side == Player_side.red)
                {
                    if (ChosenY < 5)
                        return false;
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side ==Player_side.red)
                            return false;
                        if (pieces[ElephantFootY, ElephantFootX].type != Piece_type.blank)
                            return false;//判断是象脚有棋子
                        return true;
                    }
                }
                if (this.side == Player_side.black)
                {
                    if (ChosenY > 4)
                        return false;
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.black)
                            return false;
                        if (pieces[ElephantFootY, ElephantFootX].type != Piece_type.blank)
                            return false;//判断是象脚有棋子
                        return true;
                    }

                }
            }
            return false;
        }
    }
    class Rook : Piece
    {
        public int number_horizontal;
        public Rook(char letter_horizontal, int vertical, Player_side side)
        : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);
            this.type = Piece_type.Rook;
            this.side = side;
        }
        public void Setnumber_horizontal(int number_horizontal)
        {
            this.number_horizontal = number_horizontal;
        }
        public void Setvertical(int vertical)
        {
            this.vertical = vertical;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();

            //竖着走
            if (ChosenX == theboard.getSelectedX() && ChosenY != theboard.getSelectedY())//竖着走
            {
                int max = ChosenY > theboard.getSelectedY() ? ChosenY : theboard.getSelectedY();
                int min = ChosenY > theboard.getSelectedY() ? theboard.getSelectedY() : ChosenY;

                int count = 0;
                for (int i = min + 1; i <= max - 1; i++)//统计移动路径上棋子的数量
                    if (pieces[i, ChosenX].side == Player_side.red || pieces[i, ChosenX].side == Player_side.black)
                        count++;

                if (count == 0)
                {
                    if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.red)
                    {
                        //落子点为无子或对方棋子
                        if (pieces[ChosenY, ChosenX].side == Player_side.blank || pieces[ChosenY, ChosenX].side == Player_side.black)
                            return true;
                    }
                    else if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.black)
                    {
                        //落子点为无子或对方棋子
                        if (pieces[ChosenY, ChosenX].side == Player_side.blank || pieces[ChosenY, ChosenX].side == Player_side.red)
                            return true;
                    }
                }
            }
            else if (ChosenY == theboard.getSelectedY() && ChosenX != theboard.getSelectedX())//横着走
            {
                int max = ChosenX > theboard.getSelectedX() ? ChosenX : theboard.getSelectedX();
                int min = ChosenX > theboard.getSelectedX() ? theboard.getSelectedX() : ChosenX;

                int count = 0;
                for (int i = min + 1; i <= max - 1; i++)//统计移动路径上棋子的数量
                    if (pieces[ChosenY, i].side == Player_side.red || pieces[ChosenY, i].side == Player_side.black)
                        count++;

                if (count == 0)
                {
                    if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.red)
                    {
                        //落子点为无子或对方棋子
                        if (pieces[ChosenY, ChosenX].side == Player_side.blank || pieces[ChosenY, ChosenX].side == Player_side.black)
                            return true;
                    }
                    else if (pieces[theboard.getSelectedY(), theboard.getSelectedX()].side == Player_side.black)
                    {
                        //落子点为无子或对方棋子
                        if (pieces[ChosenY, ChosenX].side == Player_side.blank || pieces[ChosenY, ChosenX].side == Player_side.red)
                            return true;
                    }
                }
            }
            return false;
        }
    }
    class Soldier : Piece
    {
        public int number_horizontal;
        public Soldier(char letter_horizontal, int vertical, Player_side side)
            : base(letter_horizontal, vertical)
        {
            number_horizontal = LetterTonumber_swtich(letter_horizontal);
            this.type = Piece_type.Soldier;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            Piece[,] pieces = new Piece[10, 9];
            pieces = theboard.getPiece();
            if (Math.Abs(ChosenY - theboard.getSelectedY()) != 1 && ChosenX == theboard.getSelectedX())//兵每次只能走一格
            {
                return false;
            }
            if (Math.Abs(ChosenX - theboard.getSelectedX()) != 1 && ChosenY == theboard.getSelectedY())
            {
                return false;
            }
            else
            {
                if (this.side == Player_side.red)
                {
                    if (ChosenX % 2 != 0 && ChosenY > 4)//红方兵过河前不能横行
                        return false;
                    if (ChosenY > theboard.getSelectedY())//红方兵不能后退
                        return false;


                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.red)
                            return false;
                        return true;
                    }
                }
                if (this.side == Player_side.black)
                {
                    if (ChosenX % 2 != 0 && ChosenY < 5)//黑方兵过河前不能横行
                        return false;
                    if (ChosenY < theboard.getSelectedY())//黑方兵不能后退
                        return false;
                    else
                    {
                        if (pieces[ChosenY, ChosenX].side == Player_side.black)
                            return false;
                        return true;
                    }

                }
            }
            return false;
        }
    }
    class Blank : Piece
    {
        public Blank(char letter_horizontal, int vertical, Player_side side)
          :base(letter_horizontal, vertical)
        {
            this.type = Piece_type.blank;
            this.side = side;
        }
        public override bool ValidMove(int ChosenX, int ChosenY, GameBoard theboard)
        {
            throw new NotImplementedException();
        }
    }
}





