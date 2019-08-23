using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class Othello : Form
    {
        public const int GameDisplay = 640;
        public const int GridWidth = GameDisplay / 8;

        public const int Black = BoardMain.Black;
        public const int White = BoardMain.White;
        public const int None = BoardMain.None;

        BoardMain GameBoard = new BoardMain();



        public Othello()
        {
            InitializeComponent();

            GameBoard.ResetBoard();

        }

        private void DrawBoard(object sender, PaintEventArgs e)
        {
            SolidBrush greenBrush = new SolidBrush(Color.DarkGreen);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            //Board
            e.Graphics.FillRectangle(greenBrush, 0, 0, GameDisplay, GameDisplay);
            //Grid Line
            for (int i = 0; i < 9; i++)
            {
                e.Graphics.FillRectangle(blackBrush, i*GridWidth - 1, 0, 2, GameDisplay);
                e.Graphics.FillRectangle(blackBrush, 0, i * GridWidth - 1, GameDisplay, 2);
            }
            //Stone
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(GameBoard.Color(x, y) == BoardMain.Black)
                    {
                        e.Graphics.FillEllipse(blackBrush, x * GridWidth + 10, y * GridWidth +10, GridWidth - 20, GridWidth - 20);
                    }else if (GameBoard.Color(x, y) == BoardMain.White)
                    {
                        e.Graphics.FillEllipse(whiteBrush, x * GridWidth + 10, y * GridWidth + 10, GridWidth - 20, GridWidth - 20);
                    }
                }
            }


        }

        private void MouseClicked(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = panel1.PointToClient(sp);

            int posX, posY;
            GameBoard.GetGridPosition(cp.X, cp.Y, GameDisplay, out posX, out posY);

            if (GameBoard.CanPlace(GameBoard.CurrentColor, posX, posY) == true)
            {
                GameBoard.Place(GameBoard.CurrentColor, posX, posY);
                GameBoard.Turn++;
                GameBoard.ChangeTurn();

                panel1.Refresh();
                CurrentColorDisplayPanel.Refresh();

                LabelAmount.Text = string.Format("黒:{0} 白:{1}", GameBoard.GetAmount(Black), GameBoard.GetAmount(White));
                TurnLabel.Text = string.Format("{0}", GameBoard.Turn);
                TipLabel.Text = "";

                if (GameBoard.CheckGameEnd() == true)
                {
                    if (GameBoard.GetAmount(Black) > GameBoard.GetAmount(White))
                    {
                        TipLabel.Text = "黒の勝利でゲームは終了しました";
                    } else if (GameBoard.GetAmount(Black) < GameBoard.GetAmount(White))
                    {
                        TipLabel.Text = "白の勝利でゲームは終了しました";
                     }
                    else if (GameBoard.GetAmount(Black) == GameBoard.GetAmount(White))
                    {
                        TipLabel.Text = "引き分けでゲームは終了しました";
                    }
                }
                else
                {
                    if (GameBoard.CanPlaceMyColor(GameBoard.CurrentColor) == false) {
                        GameBoard.Turn++;
                        GameBoard.ChangeTurn();
                        TipLabel.Text = string.Format("{0}番目の手はスキップされました", GameBoard.Turn - 1);
                    }
                    else
                    {
                        TipLabel.Text = "";
                    }
                }
            }
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = panel1.PointToClient(sp);

            int posMouseX = cp.X;
            int posMouseY = cp.Y;
            int posX, posY;
            GameBoard.GetGridPosition(posMouseX, posMouseY, GameDisplay, out posX, out posY);

            Position.Text = string.Format("X:{0} Y:{1}", posX, posY);
            MousePos.Text = string.Format("({0},{1})", posMouseX, posMouseY);

            if (GameBoard.CanPlace(GameBoard.CurrentColor, posX, posY) == true)
            {
                CanPlaceLabel.Text = "置けます";
            } else
            {
                CanPlaceLabel.Text = "置けません";
            }
        }

        private void MouseLeft(object sender, EventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = panel1.PointToClient(sp);

            int posMouseX = cp.X;
            int posMouseY = cp.Y;
            int posX, posY;
            GameBoard.GetGridPosition(posMouseX, posMouseY, GameDisplay, out posX, out posY);

            Position.Text = string.Format("X:-1 Y:-1", posX, posY);
            MousePos.Text = string.Format("(-1,-1)", posMouseX, posMouseY);
            CanPlaceLabel.Text = "範囲外です";
        }

        private void DrawCurrentColor(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            if (GameBoard.CurrentColor == Black)
            {
                e.Graphics.FillEllipse(blackBrush, 0, 0, 50, 50);
            } else if (GameBoard.CurrentColor == White)
            {
                e.Graphics.FillEllipse(blackBrush, 0, 0, 50, 50);
                e.Graphics.FillEllipse(whiteBrush, 2, 2, 50-4, 50-4);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            GameBoard.ResetBoard();

            panel1.Refresh();
            CurrentColorDisplayPanel.Refresh();

            LabelAmount.Text = "黒:0 白:0";
            TurnLabel.Text = "0";
            TipLabel.Text = "";
        }
    }


    public class BoardMain
    {
        private int[,] Board = new int[8, 8];
        public const int Black = 0;
        public const int White = 1;
        public const int None = -1;
        public int CurrentColor = Black;

        public int Turn = 0;

        private int[,] DirectionVector = {
            {0, -1}, //UP
            {1, -1}, //UP RIGHT
            {1, 0}, //RIGHT
            {1, 1}, //DOWN RIGHT
            {0, 1}, //DOWN
            {-1, 1}, //DOWN LEFT
            {-1, 0}, //LEFT
            {-1, -1}, //UP LEFT
        };


        // Functions //
        public void ChangeTurn()
        {
            CurrentColor = OppositeColor(CurrentColor);
        }

        public void ResetBoard()
        {
            for(int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    this.Board[x, y] = None;
                }
            }

            this.Board[3, 3] = White;
            this.Board[3, 4] = Black;
            this.Board[4, 3] = Black;
            this.Board[4, 4] = White;

            this.Turn = 0;
            this.CurrentColor = Black;
        }

        public int Color(int _x, int _y)
        {
            return this.Board[_x,_y];
        }

        public Boolean CanPlace(int _myColor, int _x, int _y)
        {
            for(int i = 0; i < 8; i++)
            {
                int tempX = _x;
                int tempY = _y;

                tempX += this.DirectionVector[i, 0];
                tempY += this.DirectionVector[i, 1];

                if(this.CheckBoardRange(tempX, tempY) == false)
                {
                    continue;
                }

                if(this.Board[_x,_y]==Black || this.Board[_x, _y] == White)
                {
                    return false;
                }

                if (this.Board[tempX, tempY] == this.OppositeColor(_myColor))
                {
                    while (true)
                    {
                        tempX += this.DirectionVector[i, 0];
                        tempY += this.DirectionVector[i, 1];

                        if (this.CheckBoardRange(tempX, tempY) == false)
                        {
                            break;
                        }

                        if (this.Board[tempX, tempY] == _myColor)
                        {
                            return true;
                        }else if (this.Board[tempX, tempY] == this.OppositeColor(_myColor))
                        {
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }

            return false;
        }

        public void Place(int _myColor, int _x, int _y)
        {
            for(int i=0; i<8; i++)
            {
                int tempX = _x + DirectionVector[i,0];
                int tempY = _y + DirectionVector[i, 1];

                if(CheckBoardRange(tempX, tempY) == false)
                {
                    continue;
                }

                if (this.Board[tempX, tempY] == this.OppositeColor(_myColor))
                {
                    int count = 1;
                    this.Board[_x, _y] = _myColor;

                    while (true)
                    {
                        tempX += DirectionVector[i, 0];
                        tempY += DirectionVector[i, 1];

                        if (CheckBoardRange(tempX, tempY) == false)
                        {
                            break;
                        }

                        if (this.Board[tempX, tempY] == _myColor)
                        {
                            tempX = _x;
                            tempY = _y;
                            for(int j=0; j<count; j++)
                            {
                                tempX += DirectionVector[i, 0];
                                tempY += DirectionVector[i, 1];
                                this.Board[tempX, tempY] = _myColor;
                            }
                            break;
                        }
                        else if(this.Board[tempX, tempY] == None)
                        {
                            break;
                        }

                        count++;
                    }
                }
                else
                {
                    continue;
                }


            }
        }

        public void GetGridPosition(int _MousePosX, int _MousePosY, int _DisplaySize, out int PosX, out int PosY)
        {
            int GridSize = _DisplaySize / 8;

            if (_MousePosX == 0)
            {
                PosX = 0;
            }
            else if (_MousePosX > _DisplaySize)
            {
                PosX = -1;
            }
            else
            {
                PosX = (int)(_MousePosX / GridSize);
            }

            if (_MousePosY == 0)
            {
                PosY = 0;
            }
            else if (_MousePosY > _DisplaySize)
            {
                PosY = -1;
            }
            else
            {
                PosY = (int)(_MousePosY / GridSize);
            }
        }

        public Boolean CheckGameEnd()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(this.CanPlace(Black, x, y)==true || this.CanPlace(White, x, y) == true)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Boolean CanPlaceMyColor(int _myColor)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (this.CanPlace(_myColor, x, y) == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetAmount(int _color)
        {
            int count = 0;
            for(int x=0; x<8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (this.Board[x, y] == _color)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int OppositeColor(int _color)
        {
            if (_color == Black)
            {
                return White;
            }
            else if(_color == White)
            {
                return Black;
            }
            else
            {
                return None;
            }
        }

        private Boolean CheckBoardRange(int _x, int _y)
        {
            if(_x>7 || _x<0 || _y>7 || _y < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
