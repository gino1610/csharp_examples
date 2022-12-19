namespace GameOfLife
{
    public class Generation
    {
        public static int MaxRows { get; set; }
        public static int MaxColumns { get; set; }

        private const int SHIFTER = 16;
        private const int MASK = 1<<16;

        public List<List<Cell>> SpaceMap;

        public Generation(int Rows, int Columns)
        {
            MaxRows = Rows;
            MaxColumns = Columns;
        }

        public void initSpaceMap()
        {
            var spaceMap = new List<List<Cell>>();

            for (uint ii = 0; ii < MaxRows; ii++)
            {
                var spaceMapRow = new List<Cell>();
                for (uint jj = 0; jj < MaxColumns; jj++)
                {
                    var cell = new Cell();
                    cell.coordinates = (ii << SHIFTER) + jj;
                    // Console.WriteLine((cell.coordinates >> SHIFTER).ToString() + " " + (cell.coordinates%MASK).ToString());
                    spaceMapRow.Add(cell);
                }
                // Console.WriteLine("########");

                spaceMap.Add(spaceMapRow);
            }

            this.SpaceMap = spaceMap;
        }

        public void preLoadSpaceMap(bool[] data)
        {
            for (int ii = 0; ii < data?.Length; ii++)
            {
                int currentRow = ii / MaxRows;
                int currentCol = ii % MaxRows;
                var spaceMapRow = this.SpaceMap?[currentRow];
                var cell = spaceMapRow?[currentCol] ?? new Cell();
                cell.isAlive = data[ii];
            }
        }

        public void printSpaceMap(int societyId, int generationCount)
        {
            Console.WriteLine("Society: " + societyId +", Gen: " + generationCount);
            for (int ii = 0; ii < this.SpaceMap?.Count; ii++)
            {
                var spaceMapRow = this.SpaceMap[ii];
                for (int jj = 0; jj < spaceMapRow?.Count; jj++)
                {
                    Cell cell = spaceMapRow[jj];
                    // Console.Write(cell.isAlive ? "*" + cell.neighborCount.ToString() : ".");
                    Console.Write(cell.isAlive ? "*" : ".");
                    Console.Write(cell.neighborCount.ToString());
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void neighborCount()
        {
            for (int ii = 0; ii < this.SpaceMap?.Count; ii++)
            {
                var spaceMapRow = this.SpaceMap[ii];
                for (int jj = 0; jj < spaceMapRow?.Count; jj++)
                {
                    Cell cell = spaceMapRow[jj];
                    cell.neighborCount = computeNeighborCount(ref this.SpaceMap, cell);
                }
            }
        }

        public bool advanceGeneration()
        {
            bool isExtinctSociety = true;
            for (int ii = 0; ii < this.SpaceMap?.Count; ii++)
            {
                var spaceMapRow = this.SpaceMap[ii];
                for (int jj = 0; jj < spaceMapRow?.Count; jj++)
                {
                    Cell cell = spaceMapRow[jj];
                    if (cell.neighborCount == 2)
                        cell.isAlive = cell.isAlive;
                    else
                        cell.isAlive = cell.neighborCount == 3;

                    if (isExtinctSociety && cell.isAlive)
                        isExtinctSociety = false;

                    // reset neighbor Count
                    cell.neighborCount = 0;
                }
            }
            return isExtinctSociety;
        }

        public static int computeNeighborCount(ref List<List<Cell>> spaceMap, Cell cell)
        {
            int count = 0;
            int row = (int) cell.coordinates >> SHIFTER;
            int col = (int) cell.coordinates % MASK;

            for (int ii = row - 1; ii <= row+1 && ii < MaxRows; ii++ )
            {
                if (ii < 0) continue;

                for (int jj = col-1; jj <= col+1 && jj < MaxColumns; jj++)
                {
                    if (jj < 0 || (ii == row && jj == col)) continue;

                    var rowMap = spaceMap[ii];
                    var cellMap = rowMap?[jj];
                    if (cellMap?.isAlive ?? false)
                        count++;
                }
            }
            return count;
        }
    }
}
