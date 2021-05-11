using Raylib_cs;
using Map_Generation;
using System;
using System.Collections;
using System.Numerics;

namespace helloworld
{
    static class Graphic_Window
    {
        public static void Main()
        {
            int width = Map_Generation.Window.width;
            int height = Map_Generation.Window.height;
            CA m = new CA();
            int[,] map = m.map_ready(m.ca());
            m.to_bmp(map);
            Raylib.InitWindow(width, height, "The FireKeeper");
            Texture2D dungeon = Raylib.LoadTexture("myfile.png");
            Vector2 v = new Vector2(0,0);
            while (!Raylib.WindowShouldClose())
            {
                //float scrolling = 
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawTextureEx(dungeon, v, 0.0f, 4.0f, Color.RAYWHITE);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}