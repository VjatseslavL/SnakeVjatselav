﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeVjatseslav
{
    class Program 
    {
           public void game_draw()
          {

            Console.Clear();
            Console.Title="Snake";
            Console.SetWindowSize(100, 25);

            Walls walls = new Walls(100, 25);
            walls.Draw();
            // Отрисовка точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            FoodCreator foodCreator = new FoodCreator(100, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();
            Score score = new Score(0, 1);// score =0, level=1
            score.speed = 400;
            score.ScoreWrite();

        while (true)
    {
        if (walls.IsHit(snake) || snake.IsHitTail())
    {
        break;
    }
                if (snake.Eat(food))
                {
                    score.ScoreUp();
                    score.ScoreWrite();
                    food = foodCreator.CreateFood();
                    food.Draw();
                    if (score.ScoreUp())
                    {
                        score.speed -= 10;
                    }
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Start start = new Start();
            if (start.choice() == 1)
            {
                Program prog = new Program();
                prog.game_draw();
            }
            else
            {
                start.Game_stop();
            }
            Console.ReadLine();

        }


        static void WriteGameOver()
        {
            int xOffset = 38;
            int yOffset = 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("==============================", xOffset, yOffset++);
            WriteText("     G A M E    O V E R "      , xOffset + 1, yOffset++);
            WriteText("Autor: Vjatseslav Luhvischyk ", xOffset + 1, yOffset++);
            WriteText("==============================", xOffset, yOffset++);
        }


        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
