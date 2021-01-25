using System;
using System.Collections.Generic;
using System.Text;



namespace Game.Engine
{
    // Avalible faces:
    // 0 - No face
    // 1 - faces right
    // 2 - faces down

    class MapBlock
    {
        public int[,] Matrix { get; set; }
        public int[] MovesX { get; protected set; }
        public int[] MovesY { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public int Face { get; protected set; }
        public int Portals { get; set; }

        // Constructor
        public MapBlock(int[] movesX, int[] movesY, int face, int portals, int[,] matrix)
        {
            MovesX = movesX;
            MovesY = movesY;
            Matrix = matrix;
            Height = matrix.GetLength(0);
            Width = matrix.GetLength(1);
            Face = face;
            Portals = portals;
        }
        public MapBlock(MapBlock ToCopy)
        {
            MovesX = ToCopy.MovesX;
            MovesY = ToCopy.MovesY;
            Matrix = (int[,]) ToCopy.Matrix.Clone();
            Height = ToCopy.Matrix.GetLength(0);
            Width = ToCopy.Matrix.GetLength(1);
            Face = ToCopy.Face;
            Portals = ToCopy.Portals;
        }


        public void FlipY()
        {
            int[,] temp = new int[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    temp[i, Width - j - 1] = Matrix[i, j];
                }
            }
            Matrix = temp;
        }

        public void FlipX()
        {
            int[,] temp = new int[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    temp[Height - i - 1, j] = Matrix[i, j];
                }
            }
            Matrix = temp;
        }

        public void RandomRotate()
        {
            Random rng = new Random();
            if (rng.Next(2) == 0)
            {
                int[,] tmp = new int[Width, Height];
                if (Face == 2)
                {
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            tmp[Width - j - 1, i] = Matrix[i, j];
                        }
                    }
                    Face = 1;
                }
                else
                {
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            tmp[j, Height - i - 1] = Matrix[i, j];
                        }
                    }
                    if (Face == 1) Face = 2;
                }

                Matrix = tmp;
                int a = Height;
                Height = Width;
                Width = a;
                int[] b = MovesX;
                MovesX = MovesY;
                MovesY = b;
            }
        }

        // ---------------------------- Static Part ----------------------------

        // Static Elements
        public static List<MapBlock> MapBlocks;
        public static List<MapBlock> PathBlocks;
        public static List<MapBlock> Fillings;
        public static List<MapBlock> PortalFillings;

        // Static Methods
        public static bool LoadFillings() // Read MapBlocks from file;
        {
            Fillings = new List<MapBlock>();
            PortalFillings = new List<MapBlock>();
            string[] lines;

            //Try Load file
            try
            {
                lines = System.IO.File.ReadAllLines(@"..\..\Engine\Fillings.txt");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to load map: " + ex.Message);
                return false;
            }

            //Convert file content to matrix
            foreach (string line in lines)
            {
                int i = 0;

                int face = 0;
                int height = 0;
                int width = 0;
                int portals = 0;
                int[,] temp = new int[0, 0];

                string[] values = line.Split(' ');

                foreach (string num in values)
                {
                    if (num == "") continue; // ignore padding

                    //Convert string to ints and add to matrix
                    if (Int32.TryParse(num, out int n))
                    {
                        if (i == 0) // setting right face
                        {
                            if (n < 0 || n > 2) break;
                            face = n;
                            i++;
                            continue;
                        }
                        else if (i == 1) // reading width
                        {
                            if (n < 0) break;
                            width = n;
                            i++;
                            continue;
                        }
                        else if (i == 2) // reading height
                        {
                            if (n < 0) break;
                            height = n;
                            temp = new int[height, width];
                            i++;
                            continue;
                        }
                        else if (i == 3) // reading height
                        {
                            if (n < 0) break;
                            portals = n;
                            i++;
                            continue;
                        }
                        else // filling the matrix
                        {
                            temp[(i-4) / width, (i - 4) % width] = n;
                            i++;
                        }
                    }
                    else break;

                    int[] movesX;
                    int[] movesY;
                    if (face == 1) movesX = new int[1] { 0 };
                    else
                    {
                        movesX = new int[(MapMatrix.SWidth - 4 - width) / 2 + 1];
                        for (int a = 0; a < movesX.Length; a++) movesX[a] = a;
                    }
                    if (face == 2) movesY = new int[1] { 0 };
                    else
                    {
                        movesY = new int[(MapMatrix.SHeight - 4 - height) / 2 + 1];
                        for (int a = 0; a < movesY.Length; a++) movesY[a] = a;
                    }

                    if (i == height * width + 4)
                    {
                        if(portals == 0) Fillings.Add(new MapBlock(movesX, movesY, face, 0, temp));
                        else PortalFillings.Add(new MapBlock(movesX, movesY, face, portals, temp));
                        break;
                    }
                }
            }
            if (Fillings.Count == 0) return false;
            return true;
        }

        public static bool LoadBlocks(string path, ref List<MapBlock> dest) // Read MapBlocks from file;
        {
            dest = new List<MapBlock>();
            string[] lines;

            //Try Load file
            try
            {
                lines = System.IO.File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to load map: " + ex.Message);
                return false;
            }

            //Convert file content to matrix
            foreach (string line in lines)
            {
                int metaCounter = 0;
                int xCounter = 0;
                int yCounter = 0;
                int arrCounter = 0;

                int face = 0;
                int height = 0;
                int width = 0;
                int[] movesX = new int[0];
                int[] movesY = new int[0];
                int[,] temp = new int[0,0];
                int portals = 0;

                string[] values = line.Split(' ');

                foreach (string num in values)
                {
                    if (num == "") continue; // ignore padding

                    //Convert string to ints and add to matrix
                    if (Int32.TryParse(num, out int n))
                    {
                        if (metaCounter == 0) // setting right face
                        {
                            if (n < 0 || n > 2) break;
                            face = n;
                            metaCounter++;
                            continue;
                        }
                        else if (metaCounter == 1) // reading width
                        {
                            if (n < 0) break;
                            width = n;
                            metaCounter++;
                            continue;
                        }
                        else if (metaCounter == 2) // reading height
                        {
                            if (n < 0) break;
                            height = n;
                            temp = new int[height, width];
                            metaCounter++;
                            continue;
                        }
                        else if (metaCounter == 3) // setting number of portals
                        {
                            if (n < 0) break;
                            portals = n;
                            metaCounter++;
                            continue;
                        }
                        // setting movesX array
                        else if (xCounter == 0)
                        {
                            if (n <= 0) break;
                            movesX = new int[n];
                            xCounter++;
                            continue;
                        }
                        else if (xCounter <= movesX.Length)
                        {
                            if (n < 0) break;
                            movesX[xCounter - 1] = n;
                            xCounter++;
                            continue;
                        }
                        // setting movesY array
                        else if (yCounter == 0)
                        {
                            if (n <= 0) break;
                            movesY = new int[n];
                            yCounter++;
                            continue;
                        }
                        else if (yCounter <= movesY.Length)
                        {
                            if (n < 0) break;
                            movesY[yCounter - 1] = n;
                            yCounter++;
                            continue;
                        }
                        else // filling the matrix
                        {
                            temp[arrCounter / width, arrCounter % width] = n;
                            arrCounter++;
                        }
                    }
                    else
                    {
                        break;
                    }

                    if (arrCounter == height * width)
                    {                        
                        dest.Add(new MapBlock(movesX, movesY, face, portals, temp));
                        break;
                    }
                }
            }
            if (dest.Count == 0) return false;
            return true;
        }                

        public static bool LoadBlocks()
        {
            return LoadBlocks(@"..\..\Engine\MapBlocks.txt", ref MapBlocks);
        }

        public static bool LoadPathBlocks(string path)
        {
            return LoadBlocks(path, ref PathBlocks);
        }

        public void SetPortals(int[] numbers)
        {
            Random rng = new Random();
            List<int> num = new List<int>();
            foreach (int n in numbers) num.Add(n);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
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
    }
}
