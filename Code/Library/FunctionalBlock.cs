using System;

namespace Library
{
    [Serializable]
    public abstract class FunctionalBlock : Block
    {
        public abstract void Function(Block[,] grid, int x, int y);
    }
}
