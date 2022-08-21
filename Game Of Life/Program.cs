using System;

class Program
{


    public static void Main()
    {

        while (true )
        {
            Console.WriteLine("Cap");
        }

        int M = 10, N = 10;



        int[,] lifeField = new int[M, N];   


        bool resume = true;
        while (resume) { 
        try
        {
            Console.WriteLine("Conway’s Game of Life");


            Console.WriteLine("Generate random cells or insert them from text file?\n1-Insert random\n2-Insert from .txt\n>");
            int ans = Convert.ToInt32(Console.ReadLine());
                switch (ans)
                {
                    case 1:

                        for (int i = 0; i < M; i++)
                        {
                            for (int j = 0; j < N; j++)
                            {
                                Random rnd = new Random();
                                int state = rnd.Next(0, 2);
                                lifeField[i, j] = state;
                                
                            }
                            
                        }

                        printOrg(M, N, lifeField);


                        while (true)
                        {

                            lifeField = nextGeneration(lifeField, M, N);
                            
                            printFuture(lifeField, M, N);
                            Thread.Sleep(2000);
                        }


                        break;
                    case 2:


                        String input = File.ReadAllText(@"C:\Users\Kedi\source\repos\Game Of Life\Game Of Life\bin\Debug\net6.0\field.txt");

                        int ii = 0;
                        int jj = 0;
                        
                        foreach (var row in input.Split('\n'))
                        {
                            jj = 0;
                            foreach (var col in row.Trim().Split(' '))
                            {
                                lifeField[ii, jj] = int.Parse(col.Trim());
                                jj++;
                            }
                            ii++;
                        }


                        printOrg(M, N, lifeField);


                        while (true)
                        {
                            

                            lifeField =  nextGeneration(lifeField, M, N);
                            
                            printFuture(lifeField, M, N);

                            Thread.Sleep(2000);
                        }

                        break;

                    default:
                        throw new Exception();
                }

        }
        catch (FormatException e)
        {
            Console.WriteLine("\nPlease insert only int numbers (1 or 2)");
            resume = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }




    }





    }



    static void printOrg(int M, int N, int[,] grid)
    {
        Console.WriteLine("Original Generation");
        for (int i = 0; i < M; i++)
        {
            
            for (int j = 0; j < N; j++)
            {
                
                if (grid[i, j] == 0)
                    Console.Write("- ");
                else
                    Console.Write("O ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }


    static int[,] nextGeneration(int[,] grid,
                               int M, int N)
    {
        int[,] future = new int[M, N];
        int prevoiusCell = 0;

        for (int l = 1; l < M - 1; l++)
        {
            for (int m = 1; m < N - 1; m++)
            {
                
                




                int aliveNeighbours = 0;
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        aliveNeighbours +=
                                grid[l + i, m + j];

                aliveNeighbours -= grid[l, m];
                aliveNeighbours -= prevoiusCell;

                if ((grid[l, m] == 1) && (aliveNeighbours < 2))
                {
                    future[l, m] = 0;
                    prevoiusCell = 0;
                }


                else if ((grid[l, m] == 1) && (aliveNeighbours > 3))
                {
                    future[l, m] = 0;
                    prevoiusCell = 0;
                }


                else if ((grid[l, m] == 0) && (aliveNeighbours == 3))
                {
                    future[l, m] = 1;
                    prevoiusCell = 0;
                }

                else
                {
                    future[l, m] = grid[l, m];

                }
            }

        }
        return future;
    }
    static void printFuture(int[,] future, int M, int N) { 
        Console.WriteLine("New Generation");
        for (int i = 0; i < M; i++)
        {
         
            
            for (int j = 0; j < N; j++)
            {
                if (future[i, j] == 0)
                    Console.Write("- ");
                else
                    Console.Write("O ");
               
            }
            Console.WriteLine();
        }
    }
}