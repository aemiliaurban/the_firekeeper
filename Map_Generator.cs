using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Map_Generation
{
    public class Window
    {
        public static int width = 1600;
        public static int height = 960;
        public static int grid = 32;
    }
    public class CA
    {
        public int[,] ca()
        {
            float floor_chance = 0.75f;
            int[,] map = new int[Window.height/2, Window.width/2];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    double r = new Random().NextDouble();
                    if (new Random().NextDouble() < floor_chance) { map[i, j] = 1; }
                }
            }
            return map;
        }
        public (int dx, int dy)[] moves = { (1, 0), (-1, 0), (0, 1), (0, -1) };
        public int neighbor_treshold = 4;
        public int map_generation_number = 3;
        public int get_neighbors(int x, int y, int[,] map)
        {
            int wall_neighbor = 0;
            foreach ((int dx, int dy) in moves)
            {
                (int a, int z) = (x + dx, y + dy);
                if (a < 0 && z < 0) { a += map.GetLength(0); z += map.GetLength(1); }
                else if (a > map.GetLength(0) - 1 && z > map.GetLength(1) - 1)
                { a = 0; z = 0; }
                else if (a < 0) { a += map.GetLength(0); }
                else if (z < 0) { z += map.GetLength(1); }
                else if (a > map.GetLength(0) - 1) { a = 0; }
                else if (z > map.GetLength(1) - 1) { z = 0; }
                if (map[a, z] == 1) { wall_neighbor += 1; }
            }
            return wall_neighbor;
        }
        public int[,] new_generation_map(int[,] map)
        {
            int[,] new_map = new int[map.GetLength(0), map.GetLength(1)];
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    int wall_neighbors = get_neighbors(x, y, map);
                    if (map[x, y] == 1)
                    {
                        if (wall_neighbors > neighbor_treshold) { new_map[x, y] = 1; }
                        else { new_map[x, y] = 0; }
                    }
                    else
                    {
                        if (wall_neighbors <= neighbor_treshold) { new_map[x, y] = 1; }
                        else { new_map[x, y] = 0; }
                    }
                }
            }
            return new_map;
        }
        public int[,] map_ready(int[,] map)
        {
            for (int i = 0; i < map_generation_number; i++)
            { map = new_generation_map(map); }
            return map;
        }
        public void to_bmp(int[,] map)
        {
            Bitmap bmp = new Bitmap(Window.width/Window.grid, Window.height/Window.grid, PixelFormat.Format16bppRgb555);
            for (int x = 0; x < bmp.Width; x++) {
                for (int y = 0; y < bmp.Height; y++) {
                    if (map[x, y] == 0) {
                        int red = 225;
                        int green = 225;
                        int blue = 225;
                        bmp.SetPixel(x, y, Color.FromArgb(0, red, green, blue)); }
                    else {
                        int red = map[x, y];
                        int green = map[x, y];
                        int blue = map[x, y];
                        bmp.SetPixel(x, y, Color.FromArgb(0, red, green, blue)); }
                }
            }
            Bitmap resize = new Bitmap(1600, 960);
            using (Graphics g = Graphics.FromImage(resize))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(bmp, 0, 0, 1600, 960);
            }
            resize.Save("myfile.png", ImageFormat.Png);
        }
    }

    static class Map_gen
    {
        public static void notMain()
        {
        }
    }
}
