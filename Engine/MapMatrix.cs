using System;
using System.Collections.Generic;
using System.Text;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Monsters;
using System.Windows;
using Game.Engine.Interactions;
using System.Windows.Controls;

namespace Game.Engine
{
    // Recomended blocks sets:
    // 0 - 1 Huge
    // 1 - 1 Big, 2 Small
    // 2 - 2 Medium, 2 Small
    // 3 - 6 Small

    [Serializable]
    class MapMatrix
    {
        public int[,] Matrix { get; set; }
        static public int SWidth { get; protected set; } = 25;
        static public int SHeight { get; protected set; } = 20;
        public int Width { get; protected set; } = SWidth;
        public int Height { get; protected set; } = SHeight;
        public int Number { get; private set; }
        public int Portals { get; set; }

        static Random rng = MetaMapMatrix.rng;
        private GameSession parentSession;


        public Dictionary<int, MonsterFactory> MonDict; // key - position number on board, value - monster factory located there
        public Dictionary<int, Monster> MemorizedMonsters { get; set; } // for keeping exactly the same monster between battles 
        public Dictionary<int, Interaction> Interactions { get; private set; } // same as MonDict, but for interactions


        public MapMatrix(MapBlock[] Blocks, int num, int portals, GameSession parent)
        {
            parentSession = parent;
            Number = num;
            int r = 0;
            while (Portals < portals && r < 100)
            {
                Portals = 0;
                Matrix = new int[Height, Width];

                // external walls
                for (int y = 2; y < Height - 1; y++)
                {
                    Matrix[y, 1] = -1;
                    Matrix[y, Width - 2] = -1;
                }
                for (int x = 1; x < Width - 1; x++) // = is for edges
                {
                    Matrix[1, x] = -1;
                    Matrix[Height - 2, x] = -1;
                }

                // Puting down building blocks
                PutDownBlocks(Blocks);

                MapBlock.LoadFillings();

                //Filling with missing portals
                if (Portals < portals)
                {
                    MapBlock[] PortalFillings = new MapBlock[portals - Portals];
                    for (int i = 0; i < portals - Portals; i++)
                    {
                        PortalFillings[i] = MapBlock.PortalFillings[rng.Next(MapBlock.PortalFillings.Count)];
                    }
                    PutDownBlocks(PortalFillings);
                }
                if (portals < Portals)
                {
                    for (int i = 2; i < Height - 2; i++)
                    {
                        for (int j = 2; j < Width - 2; j++)
                        {
                            if (Matrix[i, j] == 2999)
                            {
                                Matrix[i, j] = 3999;
                                Portals--;
                                if (portals >= Portals) break;
                            }
                        }
                        if (portals >= Portals) break;
                    }
                }
                r++;
            }
            FillTheGaps(MapBlock.Fillings);

            for (int i = 2; i < Height - 2; i++)
            {
                for (int j = 2; j < Width - 2; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        if (Matrix[i, j + 1] == -1 && Matrix[i, j - 1] == -1 && Matrix[i + 1, j] == -1 && Matrix[i - 1, j] == -1) Matrix[i, j] = -1;
                        Matrix[i, j] = 1;
                    }
                }
            }

            // initialize 
            Initialize();
            MemorizedMonsters = new Dictionary<int, Monster>();
        }

        public MapMatrix(MapBlock block, int num, bool flip, GameSession parent)
        {
            parentSession = parent;
            Number = num;
            Matrix = new int[Height, Width];

            // external walls
            for (int y = 2; y < Height - 1; y++)
            {
                Matrix[y, 1] = -1;
                Matrix[y, Width - 2] = -1;
            }
            for (int x = 1; x < Width - 1; x++) // = is for edges
            {
                Matrix[1, x] = -1;
                Matrix[Height - 2, x] = -1;
            }

            if (flip) FlipBlock(block);

            // Puting down building blocks
            PlaceBlock(block, (2,2), false, false);
     
            // Filling gaps
            MapBlock.LoadFillings();
            FillTheGaps(MapBlock.Fillings);

            for (int i = 2; i < Height - 2; i++)
            {
                for (int j = 2; j < Width - 2; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        if (Matrix[i, j + 1] == -1 && Matrix[i, j - 1] == -1 && Matrix[i + 1, j] == -1 && Matrix[i - 1, j] == -1) Matrix[i, j] = -1;
                        Matrix[i, j] = 1;
                    }
                }
            }

            // initialize 
            Initialize();
            MemorizedMonsters = new Dictionary<int, Monster>();
        }








        private void PutDownBlocks(MapBlock[] Blocks)
        {
            foreach (MapBlock block in Blocks)
            {
                if (block.Height > Height || block.Width > Width) continue;
                (int, int) possition = FindRandomSpace(block);
                if (possition.Item1 == -1) continue;
                FlipBlock(block);

                bool flipY = false;
                bool flipX = false;

                if (possition.Item1 > (Height / 2))
                {
                    possition.Item1 = Height - 1 - possition.Item1;
                    flipX = true;
                }
                if (possition.Item2 > (Width / 2))
                {
                    possition.Item2 = Width - 1 - possition.Item2;
                    flipY = true;
                }
                PlaceBlock(block, possition, flipX, flipY);
                Portals += block.Portals;
            }
        }

        private (int, int) FindRandomSpace(MapBlock block)
        {
            (int, int) Error = (-1, -1); // when can't find fitting spot

            List<(int, int)> available = new List<(int, int)>();

            // For code clarity
            int y0 = 2;
            int x0 = 2;
            int ym = Height - 3;
            int xm = Width - 3;

            // Range so counter will stay in only one quater
            int xRange = (Width - 4 - block.Width) / 2;
            int yRange = (Height - 4 - block.Height) / 2;
            if (xRange < 0 || yRange < 0) return Error;


            // top left
            for (int i, n = 0; n < block.MovesY.Length; n++) // loop checks every available moveY 
            {
                i = block.MovesY[n];
                for (int j, m = 0; m < block.MovesX.Length; m++) // loop checks every available moveX
                {
                    j = block.MovesX[m];
                    bool blocked = false;
                    for (int a = 0; a < block.Height; a++)
                    {
                        for (int b = 0; b < block.Width; b++)
                        {
                            if (Matrix[y0 + i + a, x0 + j + b] != 0)
                            {
                                blocked = true;
                                break;
                            }
                        }
                        if (blocked) break;
                    }
                    if (!blocked) available.Add((y0 + i, x0 + j));
                }
            }

            // top right
            for (int i, n = 0; n < block.MovesY.Length; n++) 
            {
                i = block.MovesY[n];
                for (int j, m = 0; m < block.MovesX.Length; m++) 
                {
                    j = block.MovesX[m];
                    if (j == xRange) continue;
                    bool blocked = false;
                    for (int a = 0; a < block.Height; a++)
                    {
                        for (int b = 0; b < block.Width; b++)
                        {
                            if (Matrix[y0 + i + a, xm -j - b] != 0)
                            {
                                blocked = true;
                                break;
                            }
                        }
                        if (blocked) break;
                    }
                    if (!blocked) available.Add((y0 + i, xm - j));
                }
            }

            // bottom right
            for (int i, n = 0; n < block.MovesY.Length; n++) 
            {
                i = block.MovesY[n];
                if (i == yRange) continue;
                for (int j, m = 0; m < block.MovesX.Length; m++) 
                {
                    j = block.MovesX[m];
                    if (j == xRange) continue;
                    bool blocked = false;
                    for (int a = 0; a < block.Height; a++)
                    {
                        for (int b = 0; b < block.Width; b++)
                        {
                            if (Matrix[ym - i - a, xm - j - b] != 0)
                            {
                                blocked = true;
                                break;
                            }
                        }
                        if (blocked) break;
                    }
                    if (!blocked) available.Add((ym - i, xm - j));
                }
            }

            // bottom left
            for (int i, n = 0; n < block.MovesY.Length; n++) 
            {
                i = block.MovesY[n];
                if (i == yRange) continue;
                for (int j, m = 0; m < block.MovesX.Length; m++) 
                {
                    j = block.MovesX[m];
                    bool blocked = false;
                    for (int a = 0; a < block.Height; a++)
                    {
                        for (int b = 0; b < block.Width; b++)
                        {
                            if (Matrix[ym - i - a, x0 + j + b] != 0)
                            {
                                blocked = true;
                                break;
                            }
                        }
                        if (blocked) break;
                    }
                    if (!blocked) available.Add((ym - i, x0 + j));
                }
            }

            if (available.Count == 0) return Error;

            return available[rng.Next(available.Count)];
        }

        private void FillTheGaps(List<MapBlock> Fillings)
        {
            int i = 0;
            while(CheckHoles())
            {
                MapBlock block = Fillings[rng.Next(Fillings.Count)];
                if (i > 100) // it rng is not lucky
                {
                    int[] movesX = new int[(MapMatrix.SWidth - 4 - 2) / 2 + 1];
                    for (int a = 0; a < movesX.Length; a++) movesX[a] = a;
                    int[] movesY = new int[(MapMatrix.SHeight - 4 - 2) / 2 + 1];
                    for (int a = 0; a < movesY.Length; a++) movesY[a] = a;
                    block = new MapBlock(movesX, movesY, 0, 0, new int[2, 2] { { 1, 0 },{ 0, 1 } });
                    i = -1;
                }
                block.RandomRotate(); 
                (int, int) possition = FindRandomSpace(block);
                if (possition.Item1 == -1)
                {
                    if (i == -1) break; // in case of bug, to prevent infinite loop
                    i++;
                    continue;
                }
                FlipBlock(block);
                bool flipY = false;
                bool flipX = false;

                if (possition.Item1 > (Height / 2))
                {
                    possition.Item1 = Height - 1 - possition.Item1;
                    flipX = true;
                }
                if (possition.Item2 > (Width / 2))
                {
                    possition.Item2 = Width - 1 - possition.Item2;
                    flipY = true;
                }
                PlaceBlock(block, possition, flipX, flipY);
                Portals += block.Portals;
                i = 0;
            }
        }

        private bool CheckHoles()
        {
            return true;
        }

        private void FlipBlock(MapBlock block, int probX, int probY)
        {
            if (block.Face != 1) // = block is not facing right
            {
                if (rng.Next(100) < probY) block.FlipY();
            }
            if (block.Face != 2) // = block is not facing up
            {
                if (rng.Next(100) < probX) block.FlipX();
            }
        }

        private void FlipBlock(MapBlock block)
        {
            FlipBlock(block, 50, 50);
        }

        private void PlaceBlock(MapBlock block, (int, int) pos, bool flipX, bool flipY)
        {
            //Block is not flipped
            if (!flipX && !flipY)
            {
                for (int i = 0; i < block.Height; i++)
                {
                    for (int j = 0; j < block.Width; j++)
                    {
                        Matrix[i + pos.Item1, j + pos.Item2] = block.Matrix[i, j];
                    }
                }
            }
            else if (!flipX && flipY)
            {
                for (int i = 0; i < block.Height; i++)
                {
                    for (int j = 0; j < block.Width; j++)
                    {
                        Matrix[i + pos.Item1, Width - (j + 1 + pos.Item2)] = block.Matrix[i, j];
                    }
                }
            }
            else if (flipX && !flipY)
            {
                for (int i = 0; i < block.Height; i++)
                {
                    for (int j = 0; j < block.Width; j++)
                    {
                        Matrix[Height - (i + 1 + pos.Item1), j + pos.Item2] = block.Matrix[i, j];
                    }
                }
            }
            else if (flipX && flipY)
            {
                for (int i = 0; i < block.Height; i++)
                {
                    for (int j = 0; j < block.Width; j++)
                    {
                        Matrix[Height - (i + 1 + pos.Item1), Width - (j + 1 + pos.Item2)] = block.Matrix[i, j];
                    }
                }
            }
        }

        public void SetPortals(int[] numbers)
        {
            List<int> num = new List<int>();
            foreach (int n in numbers) num.Add(n);
            for (int i = 2; i < Height - 2; i++)
            {
                for (int j = 2; j < Width - 2; j++)
                {
                    if (Matrix[i, j] == 2999)
                    {
                        int n = rng.Next(num.Count);
                        Matrix[i, j] = 2000 + num[n];
                        num.RemoveAt(n);
                        if (num.Count == 0) break;
                    }
                }
                if (num.Count == 0) break;
            }
        }

        public void SetPortals(int number)
        {
            SetPortals(new int[1] { number });
        }







        // fill map with monster factories
        private void Initialize()
        {
            MonDict = new Dictionary<int, MonsterFactory>();
            Interactions = new Dictionary<int, Interaction>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (Matrix[y, x] == 1000)
                    {
                        MonDict.Add(y * Width + x, Index.RandomMonsterFactory());
                    }
                    if (3000 <= Matrix[y, x] && Matrix[y, x] <= 3999)
                    {
                        Interaction inter = Index.DrawInteraction(parentSession, Matrix[y, x]-3000);
                        Interactions.Add(Width * y + x, inter);
                        Matrix[y, x] = 3000 + Int32.Parse(inter.Name.Replace("interaction", ""));
                    }
                }
            }
        }

        // produce or hint monsters
        public Monster CreateMonster(int x, int y, int playerLevel)
        {
            if (MemorizedMonsters.ContainsKey(y * Width + x) && MemorizedMonsters[y * Width + x] != null) return MemorizedMonsters[y * Width + x];
            if (MonDict.ContainsKey(y * Width + x) && MonDict[y * Width + x] != null)
            {
                return MonDict[y * Width + x].Create();
            }
            return null;
        }
        public Image HintMonsterImage(int x, int y)
        {
            if (MemorizedMonsters.ContainsKey(y * Width + x) && MemorizedMonsters[y * Width + x] != null) return MemorizedMonsters[y * Width + x].GetImage();
            if (MonDict.ContainsKey(y * Width + x) && MonDict[y * Width + x] != null)
            {
                return MonDict[y * Width + x].Hint();
            }
            return null;
        }
        public bool ValidPlace(int x, int y)
        {
            // utility
            if (x < 1 || y < 1 || x > Width - 2 || y > Height - 2) return false;
            if (Matrix[y, x] > 2000) return false;
            if ((Matrix[y, x - 1] != 1 && Matrix[y, x + 1] != 1) && (Matrix[y - 1, x] == 1 && Matrix[y + 1, x] == 1)) return false;
            if ((Matrix[y - 1, x] != 1 && Matrix[y + 1, x] != 1) && (Matrix[y, x - 1] == 1 && Matrix[y, x + 1] == 1)) return false;
            return true;
        }






        // Static Methods
        static public (int[], MapMatrix[]) PrepareMatrixWeb(int size, int enter, int exits, ref int CurNum, GameSession parent)
        {           
            MapMatrix[] ToRet;
            BlockSetFactory fab = new BlockSetFactory();

            // auxiliary variables
            bool toBreak = false;
            bool first = true;

            if (size <= 1)
            {
                ToRet = new MapMatrix[1] { new MapMatrix(fab.RandomBlocksSet(2), CurNum, 2, parent) };
                ToRet[0].SetPortals(new int[2]{ enter, ++CurNum });
                return (new int[1] { CurNum }, ToRet);
            }

            int ProbabilityOfPathCancelation = 50;
            List<int> Exits = new List<int>();

            ToRet = new MapMatrix[size];
            int ExitsToPlace = exits;
            int MainPathLength = rng.Next((size + 2) / 4, size / 2 + 1);  // Main Path must be longer than 1/4 of graph and shorther than 1/2;
            int SideBoards = size - MainPathLength;
            int SidePaths = rng.Next(1, MainPathLength < SideBoards ? MainPathLength + 1 : SideBoards + 1);  // Number of portals from main path to side paths;
            int PlacedSidePaths = 0;
            int PlacedSidePortals = 0;
            int[] PortalsToPlace = new int[size];    // How many portals are to be placed on each board 
            int[,] ExistingConnections = new int[size,5]; // Moddified version of adjencity matrix, first field is for length, other fields are for pointing connection
            for (int i = 0; i < size; i++) for (int j = 0; j < 5; j++) ExistingConnections[i, j] = -1;
            //for (int i = 0; i < ExistingConnections.Length; i++) ExistingConnections[i] = new int[];
            for (int i = 0; i < PortalsToPlace.Length; i++) PortalsToPlace[i] = 2;
            while (PlacedSidePaths < SidePaths)  // Calculating main path
            {
                int n = rng.Next(MainPathLength);
                if(PortalsToPlace[n] == 2)
                {
                    int tmp = rng.Next(1, SidePaths - PlacedSidePaths > 2 ? 3 : 2);
                    PortalsToPlace[n] += tmp;
                    PlacedSidePaths += tmp;
                }
            }
            for(int i = MainPathLength; i < size; i++)  // Number of initial portals on each side boards
            {
                PortalsToPlace[i] += rng.Next(3);
            }

            for(int i = 0; i < size; i++)
            {
                ToRet[i] = new MapMatrix(fab.RandomBlocksSet(PortalsToPlace[i]), CurNum + i, PortalsToPlace[i], parent);
                while (ToRet[i].Portals < PortalsToPlace[i]) ToRet[i] = new MapMatrix(fab.RandomBlocksSet(PortalsToPlace[i]), CurNum + i, PortalsToPlace[i], parent); // To prevent bug
                ExistingConnections[i, 0] = ToRet[i].Portals;
            }

            //Setting down main path 
            first = true;
            for (int i = 0; i < MainPathLength; i++)
            {
                int[] portals = new int[ToRet[i].Portals];
                portals[0] = first ? enter : CurNum - 1 + i;
                portals[1] = (MainPathLength - 1 == i) ? (exits >= 0 ? CurNum + size : 1999) : CurNum + 1 + i;
                for (int j = 2; j < portals.Length; j++)
                {
                    portals[j] = CurNum + MainPathLength + j - 2 + PlacedSidePortals;
                    ToRet[portals[j] - CurNum].SetPortals(i+CurNum);
                    ExistingConnections[portals[j] - CurNum, 1] = i + CurNum;
                    PortalsToPlace[portals[j] - CurNum]--;
                }
                PlacedSidePortals += portals.Length - 2;
                for (int j = 0; j < portals.Length; j++) ExistingConnections[i, j+1] = portals[j];
                ToRet[i].SetPortals(portals);
                PortalsToPlace[i] -= 2;
                first = false;
            }
            if (exits > 0)
            {
                ExitsToPlace--;
                Exits.Add(CurNum + MainPathLength - 1);
            }

            //Setting down side paths
            for (int i = SidePaths + MainPathLength; i < size; i++)
            {
                toBreak = false;
                int n;
                int m;
                while(true)
                {
                    n = rng.Next(MainPathLength, i);
                    if (PortalsToPlace[n] > 0)
                    {
                        m = 1;
                        while (m < ExistingConnections[n, 0] + 1)
                        {
                            if (ExistingConnections[n, m] == -1) toBreak = true;
                            if (toBreak) break;
                            m++;
                        }
                        if (toBreak) break;
                    }
                }
                ToRet[i].SetPortals(CurNum + n);
                ExistingConnections[i,1] = n + CurNum;
                ToRet[n].SetPortals(CurNum + i);
                ExistingConnections[n,m] = i + CurNum;
                PortalsToPlace[n]--;
                PortalsToPlace[i]--;
            }

            // Adding additional connections
            int FreePortals = 0;
            foreach (int i in PortalsToPlace) FreePortals += i;
            for (int i = MainPathLength; i < size; i++)
            {
                for (int j = 2; j < ExistingConnections[i,0] + 1; j++)
                {
                    if(ExistingConnections[i,j] == -1)
                    {
                        if(ExitsToPlace > 0 && rng.Next(FreePortals - ExitsToPlace) <= 1)
                        {
                            PortalsToPlace[i]--;
                            FreePortals--;
                            ToRet[i].SetPortals(CurNum + size + (exits - ExitsToPlace));
                            ExistingConnections[i, j] = CurNum + (exits - ExitsToPlace);
                            ExitsToPlace--;
                            Exits.Add(CurNum + i);
                        }
                        else if (rng.Next(100) < ProbabilityOfPathCancelation)
                        {
                            PortalsToPlace[i]--;
                            FreePortals--;
                            ToRet[i].SetPortals(1999);
                            ExistingConnections[i, j] = -2;
                        }
                        else
                        {
                            int r = 0;
                            int n = i;
                            int m = 1;
                            toBreak = false;
                            while (r < 100)
                            {
                                do n = rng.Next(MainPathLength, size); while (n == i);
                                for (int k = 1; k < ExistingConnections[n, 0] + 1; k++)
                                {
                                    if (ExistingConnections[n, k] == i + CurNum) break;
                                    if (ExistingConnections[n, k] == -1)
                                    {
                                        toBreak = true;
                                        m = k;
                                        break;
                                    }
                                }
                                if (toBreak) break;
                                r++;
                            }
                            if (r == 100)
                            {
                                ToRet[i].SetPortals(1999);
                                PortalsToPlace[i]--;
                                FreePortals--;
                                ExistingConnections[i, j] = -2;
                                continue;
                            }
                            ToRet[i].SetPortals(CurNum + n);
                            ExistingConnections[i,j] = CurNum + n;
                            ToRet[n].SetPortals(CurNum + i);
                            ExistingConnections[n,m] = CurNum + i;
                            PortalsToPlace[n]--;
                            FreePortals--;
                            PortalsToPlace[i]--;
                            FreePortals--;
                        }
                    }
                }
            } 
            CurNum += size;
            return (Exits.ToArray(), ToRet);
        }


    }
}
