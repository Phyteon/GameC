using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    class BlockSetFactory
    {
        public MapBlock[] RandomBlocksSet(MapBlock[] SetBlocks, int portals)
        {
            int PortCnt = 0;
            int MaxSurface = (MapMatrix.SHeight - 4) * (MapMatrix.SWidth - 4);
            int SurfaceTaken = 0;
            foreach (MapBlock block in SetBlocks)
            {
                PortCnt += block.Portals;
                SurfaceTaken += block.Height * block.Width;
            }

            Random rng = MetaMapMatrix.rng;
            MapBlock tmp;
            List<MapBlock> blocks = new List<MapBlock>(SetBlocks);
            if (!MapBlock.LoadBlocks()) return blocks.ToArray();
            int count = MapBlock.MapBlocks.Count;

            int a = 0;
            //filling list
            while(a < 100)
            {
                tmp = MapBlock.MapBlocks[rng.Next(count)];
                if(tmp.Height < MapMatrix.SWidth*2/3 && tmp.Width < MapMatrix.SHeight*2/3) tmp.RandomRotate();
                PortCnt += tmp.Portals;
                SurfaceTaken += tmp.Height * tmp.Width;
                if(SurfaceTaken >= MaxSurface - 9 * (portals - PortCnt) && portals - PortCnt > 0 && a < 100)
                {
                    PortCnt = 0;
                    SurfaceTaken = 0;
                    blocks = new List<MapBlock>(SetBlocks);
                    a++;
                }
                else
                {
                    blocks.Add(tmp);
                    if (portals - PortCnt <= 0 && SurfaceTaken > MaxSurface) break;
                }
            }

            MapBlock[] ret = new MapBlock[blocks.Count];
            for (int i = 0; i < blocks.Count; i++)
            {
                ret[i] = new MapBlock(blocks[i]);
            }

            return ret;
        }

        public MapBlock[] RandomBlocksSet(int portals)
        {
            return RandomBlocksSet(new MapBlock[0], portals);
        }
    }
}
