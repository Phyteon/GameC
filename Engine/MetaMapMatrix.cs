using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Game.Engine.Interactions;
using Game.Engine.Skills;

namespace Game.Engine
{
    [Serializable]
    class MetaMapMatrix
    {
        private MapMatrix[] matrix;
        private int MapsCnt;
        private GameSession parentSession;

        public List<Interaction> QuestElements { get; private set; } // shared between all maps
        
        private List<Interaction> interactionList;

        private int lastNumber;
        private int currentNumber;

        public static Random rng = new Random();



        public MetaMapMatrix(GameSession parent)
        {
            List<MapMatrix> Matrix;
            parentSession = parent;
            BlockSetFactory fact = new BlockSetFactory();
            MapBlock.LoadBlocks();
            MapBlock.LoadPathBlocks(@"..\..\Engine\PathBlocks.txt");

            MapBlock[] BlockSet;
            Matrix = new List<MapMatrix>();
            MapsCnt = 0;
            Random rng = new Random();
            MapMatrix board;

            int SparePortals = 0;
            int PortalsToPlace = 0;
            bool port1;
            bool port2;

            MapBlock tmpB;

            //Hub
            MapBlock.LoadBlocks();
            int BasicBlocksCount = MapBlock.MapBlocks.Count;
            Matrix.Add(new MapMatrix(MapBlock.PathBlocks[0], MapsCnt, false, parent));
            MapsCnt++;

            //BPath            
            {
                //First Board
                BlockSet = new MapBlock[4];
                BlockSet[0] = MapBlock.PathBlocks[1];
                BlockSet[1] = MapBlock.PathBlocks[2];
                BlockSet[2] = MapBlock.PortalFillings[rng.Next(MapBlock.PortalFillings.Count)];
                BlockSet[3] = MapBlock.PortalFillings[rng.Next(MapBlock.PortalFillings.Count)];
                Matrix.Add(new MapMatrix(BlockSet, MapsCnt, 2, parent));
                MapsCnt++;

                port1 = false;
                port2 = false;

                for (int i = 2; i < Matrix[1].Height - 2; i++)
                {
                    for (int j = 2; j < Matrix[1].Width - 2; j++)
                    {
                        if (Matrix[1].Matrix[i, j] == 2999)
                        {
                            if (!port1 && !port2)
                            {
                                if (rng.Next(2) == 0)
                                {
                                    Matrix[1].Matrix[i, j] = 2000;
                                    port1 = true;
                                }
                                else
                                {
                                    Matrix[1].Matrix[i, j] = 2002;
                                    port2 = true;
                                }
                            }
                            else if (!port1)
                            {
                                Matrix[1].Matrix[i, j] = 2000;
                                port1 = true;
                                break;
                            }
                            else
                            {
                                Matrix[1].Matrix[i, j] = 2002;
                                port2 = true;
                                break;
                            }
                        }
                    }
                }

                //Second Board 
                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(3), MapsCnt, 3, parent));
                Matrix[MapsCnt].SetPortals(new int[2] { MapsCnt - 1, MapsCnt + 1 });
                MapsCnt++;

                //Third Board
                BlockSet = new MapBlock[4];
                BlockSet[0] = MapBlock.PathBlocks[3];
                BlockSet[1] = MapBlock.PathBlocks[4];

                while (true)
                {
                    tmpB = MapBlock.MapBlocks[rng.Next(BasicBlocksCount)];
                    if (tmpB.Height <= 8 && tmpB.Width <= 7 && tmpB.Portals >= 1)
                    {
                        break;
                    }
                }
                BlockSet[2] = new MapBlock(tmpB);

                while (true)
                {
                    tmpB = MapBlock.MapBlocks[rng.Next(BasicBlocksCount)];
                    if (tmpB.Height <= 8 && tmpB.Width <= 7)
                    {
                        break;
                    }
                }
                BlockSet[3] = new MapBlock(tmpB);

                PortalsToPlace = 1;
                SparePortals = 0;  
                foreach (MapBlock block in BlockSet)
                {
                    for (int i = 0; i < block.Width; i++)
                    {
                        for (int j = 0; j < block.Height; j++)
                        {
                            if (block.Matrix[j, i] == 2999)
                            {
                                if (PortalsToPlace > 0)
                                {
                                    block.Matrix[j, i] = 2002;
                                    PortalsToPlace--;
                                }
                                else
                                {
                                    block.Matrix[j, i] = 4000;
                                    block.Portals--;
                                    SparePortals++;
                                }
                            }
                        }
                    }
                }

                board = new MapMatrix(BlockSet, MapsCnt, 2, parent);
                Matrix.Add(board);
                MapsCnt++;
            }

            //MaPath  
            {
                Matrix[0].SetPortals(MapsCnt);
                //Druid
                Matrix.Add(new MapMatrix(new MapBlock[2] { MapBlock.PathBlocks[5], MapBlock.PathBlocks[6] }, MapsCnt, 5, parent));
                Matrix[MapsCnt].SetPortals(new int[2] { 0, 8 });
                MapsCnt++;

                //Animals
                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(new MapBlock[1] { MapBlock.PathBlocks[7] }, 1), MapsCnt, 1, parent));
                Matrix[MapsCnt].SetPortals(4);
                MapsCnt++;

                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(new MapBlock[1] { MapBlock.PathBlocks[8] }, 1), MapsCnt, 1, parent));
                Matrix[MapsCnt].SetPortals(4);
                MapsCnt++;

                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(new MapBlock[1] { MapBlock.PathBlocks[9] }, 1), MapsCnt, 1, parent));
                Matrix[MapsCnt].SetPortals(4);
                MapsCnt++;

                // random map
                int MLabLength = 8;
                (int[], MapMatrix[]) BoardWeb = MapMatrix.PrepareMatrixWeb(MLabLength, 4, 1, ref MapsCnt, parent);
                foreach (MapMatrix bor in BoardWeb.Item2) Matrix.Add(bor);

                // Temple
                BlockSet = new MapBlock[2] { MapBlock.PathBlocks[10], MapBlock.PathBlocks[11] };
                BlockSet[1].SetPortals(BoardWeb.Item1[0]);
                BlockSet[0].SetPortals(MapsCnt + 3);
                Matrix.Add(new MapMatrix(BlockSet, MapsCnt, 4, parent));
                Matrix[MapsCnt].SetPortals(new int[2] { MapsCnt + 1, MapsCnt + 2 });
                MapsCnt++;

                //Witches
                BlockSet = new MapBlock[3] { MapBlock.PathBlocks[12], MapBlock.PathBlocks[13], MapBlock.PathBlocks[14] };
                Matrix.Add(new MapMatrix(BlockSet, MapsCnt, 1, parent));
                Matrix[MapsCnt].SetPortals(MapsCnt - 1);
                MapsCnt++;

                //Elfs
                BlockSet = new MapBlock[2] { MapBlock.PathBlocks[16], MapBlock.PathBlocks[17] };
                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(BlockSet, 1), MapsCnt, 1, parent));
                Matrix[MapsCnt].SetPortals(MapsCnt - 2);
                MapsCnt++;

                //Big Portal
                BlockSet = new MapBlock[1] { MapBlock.PathBlocks[15] };
                BlockSet[0].SetPortals(0);
                Matrix.Add(new MapMatrix(BlockSet, MapsCnt, 2, parent));
                Matrix[MapsCnt].SetPortals(MapsCnt - 1);
                MapsCnt++;
            }

            //PPath
            {
                Matrix[0].SetPortals(MapsCnt);
                //Pilars
                BlockSet = new MapBlock[1] { MapBlock.PathBlocks[18] };
                Matrix.Add(new MapMatrix(BlockSet, MapsCnt, 2, parent));
                Matrix[MapsCnt].SetPortals(MapsCnt + 1);
                MapsCnt++;

                //Random Web
                int MLabLength = 3;
                (int[], MapMatrix[]) BoardWeb = MapMatrix.PrepareMatrixWeb(MLabLength, MapsCnt - 1, 2, ref MapsCnt, parent);
                foreach (MapMatrix bor in BoardWeb.Item2) Matrix.Add(bor);

                //Ridle
                BlockSet = new MapBlock[1] { MapBlock.PathBlocks[19] };
                Matrix.Add(new MapMatrix(BlockSet, MapsCnt, 1, parent));
                Matrix[MapsCnt].SetPortals(BoardWeb.Item1[0]);
                MapsCnt++;

                //Choose room
                BlockSet = new MapBlock[1] { MapBlock.PathBlocks[20] };
                BlockSet[0].SetPortals(new int[2] { 0, MapsCnt + 1});
                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(BlockSet, 3), MapsCnt, 3, parent));
                Matrix[MapsCnt].SetPortals(BoardWeb.Item1[1]);
                MapsCnt++;

                //Priest
                BlockSet = new MapBlock[1] { MapBlock.PathBlocks[21] };
                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(BlockSet, 2), MapsCnt, 2, parent));
                Matrix[MapsCnt].SetPortals(new int[2] { 0, MapsCnt - 1});
                MapsCnt++;
            }

            //MiPath
            {
                Matrix[0].SetPortals(MapsCnt);

                //Random Web
                int MLabLength = 10;
                (int[], MapMatrix[]) BoardWeb = MapMatrix.PrepareMatrixWeb(MLabLength, 0, 1, ref MapsCnt, parent);
                foreach (MapMatrix bor in BoardWeb.Item2) Matrix.Add(bor);

                //Exit
                Matrix.Add(new MapMatrix(fact.RandomBlocksSet(BlockSet, 2), MapsCnt, 2, parent));
                Matrix[MapsCnt].SetPortals(new int[2] { 0, BoardWeb.Item1[0] });
                MapsCnt++;
            }

            //Random Dungeon
            {
                Matrix[2].SetPortals(MapsCnt);

                //Random Web
                int MLabLength = 30;
                (int[], MapMatrix[]) BoardWeb = MapMatrix.PrepareMatrixWeb(MLabLength, 2, 0, ref MapsCnt, parent);
                foreach (MapMatrix bor in BoardWeb.Item2) Matrix.Add(bor);
            }
            matrix = Matrix.ToArray();
            LoadInteractions();
        }

        public MapMatrix GetCurrentMatrix(int codeNumber)
        {
            // get the currently used board
            lastNumber = currentNumber;
            currentNumber = codeNumber;
            return matrix[codeNumber];
        }




        // Dodane do przeanalizowania
        public void AddMonsterToRandomMap(Monsters.MonsterFactories.MonsterFactory factory)
        {
            int mapNumber = currentNumber;
            while (mapNumber == currentNumber) mapNumber = Index.RNG(0, MapsCnt); // random map other than the current one
            while (true)
            {
                int x = Index.RNG(2, matrix[mapNumber].Width - 2);
                int y = Index.RNG(2, matrix[mapNumber].Height - 2);
                if (!matrix[mapNumber].ValidPlace(x, y))
                {
                    continue;
                }
                matrix[mapNumber].Matrix[y, x] = 1000;
                matrix[mapNumber].MonDict.Add(matrix[mapNumber].Width * y + x, factory);
                break;
            }
        }
        public void AddInteractionToRandomMap(Interaction interaction)
        {
            int mapNumber = currentNumber;
            while (mapNumber == currentNumber) mapNumber = Index.RNG(0, MapsCnt); // random map other than the current one
            while (true)
            {
                int x = Index.RNG(2, matrix[mapNumber].Width - 2);
                int y = Index.RNG(2, matrix[mapNumber].Height - 2);
                if (!matrix[mapNumber].ValidPlace(x, y))
                {
                    continue;
                }
                if (matrix[mapNumber].Interactions.ContainsKey(matrix[mapNumber].Width * y + x)) continue;
                matrix[mapNumber].Interactions.Add(matrix[mapNumber].Width * y + x, interaction);
                matrix[mapNumber].Matrix[y, x] = 3000 + Int32.Parse(interaction.Name.Replace("interaction", ""));
                break;
            }
        }
        private void LoadInteractions()
        {

            interactionList = new List<Interaction>();
            QuestElements = Index.MainQuestFactory.CreateInteractionsGroup(parentSession);
            foreach (MapMatrix map in matrix) interactionList.AddRange(map.Interactions.Values);
        }


        // Dodane przeanalizowane
        public int GetPreviousMatrixCode()
        {
            // for display when portal hopping
            // each board has its own individual code, which is used by portals to remember which portal leads where
            // example: let's say we have a board with code 34
            // this means that portals leading to that board will be encoded as 2034 value everywhere in the game
            return lastNumber;
        }
    }
}
