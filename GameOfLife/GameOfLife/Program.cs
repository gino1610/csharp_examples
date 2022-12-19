using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game of Life!");

            const int ROWS = 10;
            const int COLS = 10;

            var generation = new Generation(ROWS, COLS);

            var data = new bool[12][];
            data[0] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, true, true, true, true, false, false, false, false, false,
            };

            data[1] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, true, true, true, true, true, false, false, false, false,
            };

            data[2] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, true, true, true, true, true, true, false, false, false,
            };

            data[3] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, true, false, false, false, false, false, false, false,
                false, true, false, true, false, false, false, false, false, false,
                false, false, true, false, false, false, false, false, false, false,
            };

            data[4] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, true, false, false, false, false, false, false, false,
                false, true, true, true, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false,
            };

            data[5] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, true, true, true, false, true, true, true, false, false,
            };

            data[6] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                true, true, true, true, false, true, true, true, true, false,
                false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false,
            };

            data[7] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, true, false, false, false, false, false, false, false,
                false, false, false, true, false, false, false, false, false, false,
                false, true, true, true, false, false, false, false, false, false,
            };

            data[8] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, true, true, true, false, false, false,
                false, false, false, true, true, true, false, false, false, false,
            };

            data[9] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false,
                false, false, true, false, true, false, false, false, false, false,
                false, false, true, true, true, false, false, false, false, false,
                false, false, true, false, true, false, false, false, false, false,
            };

            data[10] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, false, false,
                false, false, true, false, true, false, false, false, false, false,
                false, false, true, false, true, false, false, false, false, false,
                false, false, true, true, true, false, false, false, false, false,
            };

            data[11] = new bool[]
            {
                false, false, false, false, false, false, false, false, false, false,
                false, false, true, true, false, false, false, false, false, false,
                false, false, true, true, false, false, false, false, false, false,
                false, false, false, false, true, true, false, false, false, false,
                false, false, false, false, true, true, false, false, false, false,
            };


            int generationCount;
            bool isExtinctSociety = false;
            for (int ii = 0; ii < 12; ii++)
            {
                generationCount = 0;
                generation.initSpaceMap();
                generation.preLoadSpaceMap(data[ii]);
                generation.neighborCount();
                generation.printSpaceMap(ii, generationCount);

                while (generationCount < 20 && !isExtinctSociety )
                {
                    isExtinctSociety = generation.advanceGeneration();
                    generation.neighborCount();
                    generation.printSpaceMap(ii, generationCount);
                    if (!isExtinctSociety)
                    {
                        generationCount++;
                    }
                }

            }
        }
    }
}
