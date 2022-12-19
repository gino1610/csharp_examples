namespace GameOfLife
{
    public class Cell
    {
        public bool isAlive { get; set; } = false;
        public int neighborCount { get; set; } = 0;
        public uint coordinates { get; set; }
        
    }
}
