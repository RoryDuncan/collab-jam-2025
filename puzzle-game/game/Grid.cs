using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Rect = MonoGame.Extended.RectangleF;

namespace puzzle_game.game;

public class Grid<CellType>
{
    protected int Rows { get; set; } = 6;
    protected int Cols { get; set; } = 6;
    public int Length => Rows * Cols;
    protected Cell<CellType>[,] Cells { get; set; }
    public Grid()
    {
        Cells = new Cell<CellType>[Rows, Cols];
    }

    public void SetCell(int row, int col, CellType value)
    {
        Cells[row, col].Value = value;
    }

    public CellType GetCell(int row, int col)
    {
        return Cells[row, col].Value;
    }

    public void Draw(SpriteBatch spriteBatch, int offsetX = 0, int offsetY = 0)
    {
        ForEachCell((rect, row, col, value) => {

            var offsetRect = new Rect(
                rect.X + offsetX,
                rect.Y + offsetY,
                rect.Width,
                rect.Height);

            spriteBatch.DrawRectangle(offsetRect, Microsoft.Xna.Framework.Color.White);
        });
    }

    public void ForEachCell(Action<Rect, int, int, CellType> task)
    {

        const int size = 50;
        const int margin = 4;
        const int container = size + margin;

        CellType value;
        int row;
        int col;
        Rect rect = new Rect {
                    Width = size,
                    Height = size,
                };
        for (row = 0; row < Rows; ++row)
        {
            for (col = 0; col < Cols; ++col)
            {
                value = Cells[row, col].Value;

                task(rect with {
                    X = col * container,
                    Y = row * container,
                }, row, col, value);
            }
        }
    }


    public void Initialize(CellType data)
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                Cells[row, col] = new Cell<CellType>(data);
            }
        }
    }

}

public record Cell<TData>(TData initialValue = default)
{
    public TData Value { get; set; } = initialValue;
}

