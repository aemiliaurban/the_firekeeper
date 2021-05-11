//using raylib_cs;
//using system;
//using system.collections;

//namespace helloworld
//{
//    static class program
//    {
//        public static void not_main()
//        {
//            int room_width = 800;
//            int room_height = 480;
//            raylib.initwindow(room_width, room_height, "the firekeeper");

//            while (!raylib.windowshouldclose())
//            {
//                raylib.begindrawing();
//                int grid = 32;
//                int map_w = room_width / grid;
//                int map_h = room_height / grid;
//                int[,] map = new int[map_w, map_h];

//                for (int i = 0; i < map_w; i++)
//                    for(int j = 0; j < map_h; j++)
//                    {
//                        double mid = map_h * 0.5;
//                        if (j == mid) { map[i, j] = 0; }
//                        else { map[i, j] = 1; }
//                    }


//                raylib.clearbackground(color.white);

//                raylib.drawtext("hello, world!", 12, 12, 20, color.black);

//                raylib.enddrawing();
//            }

//            raylib.closewindow();
//        }
//    }
//}