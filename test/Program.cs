using System;
using System.Collections.Generic;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int aVsB = 0;
            int bVsC = 0;
            int cVsA = 0;
            int setA, setB, setC;
            Random random = new Random();
            int r;
            int ax, ay, bx, by, cx, cy;
            int hpA, hpB, hpC;
            double disAB, disAC, disBC;
            int scoreA = 0;
            int scoreB = 0;
            int scoreC = 0;
            Console.WriteLine("Enter the location of A:");
            Console.Write("AX: ");
            ax = Convert.ToInt32(Console.ReadLine());

            Console.Write("AY: ");
            ay = Convert.ToInt32(Console.ReadLine());

            if (ax <= 10 && -10 <= ax && -10 <= ay && ay <= +10)
            {

                bx = random.Next(-10, 11);
                cx = random.Next(-10, 11);
                by = random.Next(-10, 11);
                cy = random.Next(-10, 11);

                // 0,0 == 14,14
                Console.WriteLine("   +----------^----------+\r\n 10|..........|..........|\r\n  9|..........|..........|\r\n  8|..........|..........|\r\n  7|..........|..........|\r\n  6|..........|..........|\r\n  5|..........|..........|\r\n  4|..........|..........|\r\n  3|..........|..........|\r\n  2|..........|..........|\r\n  1|..........|..........|\r\n  0|----------+---------->\r\n -1|..........|..........|\r\n -2|..........|..........|\r\n -3|..........|..........|\r\n -4|..........|..........|\r\n -5|..........|..........|\r\n -6|..........|..........|\r\n -7|..........|..........|\r\n -8|..........|..........|\r\n -9|..........|..........|\r\n-10|..........|..........|\r\n   +---------------------+\r\n    098765432101234567890\r\n");
                Console.SetCursorPosition(ax+14,-ay+14);
                Console.Write("A");
                Console.SetCursorPosition(bx + 14, -by + 14);
                Console.Write("B");
                Console.SetCursorPosition(cx + 14, -cy + 14);
                Console.Write("C");
                Console.SetCursorPosition(0, 28);


                // COORDINATE PLANE AND SHOWN ARCHERS


                // randomly assign sets
                setA = random.Next(1, 4);
                if (setA == 1)
                {
                    setB = random.Next(2, 4);
                    setC = setB == 2 ? 3 : 2;

                }
                else if (setA == 2)
                {
                    setB = random.Next(1, 3);
                    setB = setB == 1 ? 1 : 3;
                    setC = setB == 1 ? 3 : 1;

                }
                else
                {
                    setB = random.Next(1, 3);
                    setC = setB == 1 ? 2 : 1;
                }

                // Set 1 > Set 2 > Set 3 > Set 1 > Set 2> Set 3> Set 1

                // comparing sets who wins
                if (setA == 1)
                {
                    if (setB ==2) // A=Set 1 B=Set 2 C=Set 3
                    {
                        aVsB = 1;
                        bVsC = 1;
                        cVsA = 1;
                    }
                    else // A=Set 1 B=Set 3 C=Set 2
                    {
                        aVsB = 0;
                        bVsC = 0;
                        cVsA = 0;
                    }
                }
                else if (setA == 2)
                {
                    if (setB == 1) // A=Set 2 B=Set 1 C=Set 3
                    {
                        aVsB = 0;
                        bVsC = 0;
                        cVsA = 0;
                    }
                    else // A=Set 2 B=Set 3 C=Set 1
                    {
                        aVsB = 1;
                        bVsC = 1;
                        cVsA = 1;
                    }
                }
                else if (setA == 3)
                {
                    if (setB == 1) // A=Set 3 B= Set 1 C=Set 2
                    {
                        aVsB = 1;
                        bVsC = 1;
                        cVsA = 1;
                    }
                    else // A=Set 3 B=Set 2 C=Set 1
                    {
                        aVsB = 0;
                        bVsC = 0;
                        cVsA = 0;
                    }
                }




                // randomly assign healths
                hpA = random.Next(3, 6) * 20;
                if (hpA == 60)
                {
                    hpB = random.Next(4, 6) * 20;
                    hpC = hpB == 80 ? 100 : 80;
                }
                else if (hpA == 80)
                {
                    hpB = random.Next(1, 3) == 1 ? 60 : 100;
                    hpC = hpB == 60 ? 100 : 60;
                }
                else
                {
                    hpB = random.Next(3, 5) * 20;
                    hpC = hpB == 60 ? 80 : 100;
                }
                // WRITING ARCHERS
                Console.WriteLine($"A: ({ax},{ay}) Set {setA}  Health:{hpA}  ");

                Console.WriteLine($"B: ({bx},{by}) Set {setB}  Health:{hpB}  ");

                Console.WriteLine($"C: ({cx},{cy}) Set {setC}  Health:{hpC}  ");
                Console.WriteLine("");

                Console.WriteLine("------------------------------------------------");

                Console.WriteLine("");



                // GETTING DISTANCE BETWEEN PLAYERS
                disAB = Math.Sqrt(Math.Pow(ax - bx, 2) + Math.Pow(ay - by, 2));
                disBC = Math.Sqrt(Math.Pow(cx - bx, 2) + Math.Pow(cy - by, 2));
                disAC = Math.Sqrt(Math.Pow(ax - cx, 2) + Math.Pow(ay - cy, 2));

                double minimum = disAB;

                if (disAC <= minimum)
                {
                    minimum = disAC;
                }
                if (disBC < minimum)
                {
                    minimum = disBC;
                }
                if (minimum > 15)
                {
                    Console.WriteLine("Tie! There's no winner");
                }
                else
                {

                    // SCORE DEFINITION

                    int calculatedScore;
                    // FIND WHO IS MINIMUM AND FIGHTING
                    if (minimum == disAC)
                    {
                        if (cVsA == 0)
                        {
                            hpA -= 25;
                            hpC = 0;
                            calculatedScore = 10 * (Math.Abs(ax - cx) + Math.Abs(ay - cy)) + (100 - hpA); // TEMP
                            scoreA += calculatedScore;

                            Console.WriteLine($"Round 1: A-C \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Non-fighter     Health:{hpB}   Score:{scoreB}\r\nC: Defeated     Health:{hpC}  Score:{scoreC}\r\n");

                            if (disAB <= 15)
                            {
                                hpB -= 25;
                                hpA = 0;
                                calculatedScore = 10 * (Math.Abs(ax - bx) + Math.Abs(ay - by)) + (100 - hpB); // TEMP
                                scoreB += calculatedScore;
                                Console.WriteLine($"Round 2: B-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Defeated     Health:{hpC}  Score:{scoreC}\r\n");

                                if (scoreA>scoreB)
                                {
                                    Console.WriteLine($"A has the maximum score ({scoreA})");
                                    // END
                                }
                                else
                                {
                                    Console.WriteLine($"B has the maximum score ({scoreB})");
                                    // END
                                }
                            }
                            else
                            {
                                // too distant / a has max score

                                Console.WriteLine("Round 2: B-A \r\n");
                                Console.WriteLine("Too distant, no attack");
                                Console.WriteLine($"A has the maximum score ({scoreA})");
                                //END
                            }
                        }
                        else
                        {
                            hpC -= 25;
                            hpA = 0;
                            calculatedScore = 10 * (Math.Abs(ax - cx) + Math.Abs(ay - cy)) + (100 - hpC); // TEMP
                            scoreC += calculatedScore;

                            Console.WriteLine($"Round 1: C-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Non-fighter     Health:{hpB}   Score:{scoreB}\r\nC: Survivor     Health:{hpC}  Score:{scoreC}\r\n");

                            if (disBC <= 15)
                            {
                                hpB -= 25;
                                hpC = 0;
                                calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpB); // TEMP
                                scoreB += calculatedScore;
                                Console.WriteLine($"Round 2: B-C \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Defeated     Health:{hpC}  Score:{scoreC}\r\n");

                                if (scoreB > scoreC)
                                {
                                    Console.WriteLine($"B has the maximum score ({scoreB})");
                                    // END
                                }
                                else
                                {
                                    Console.WriteLine($"C has the maximum score ({scoreC})");
                                    // END
                                }

                            }
                            else
                            {
                                // too distant / C has max score

                                Console.WriteLine("Round 2: B-C \r\n");
                                Console.WriteLine("Too distant, no attack");
                                Console.WriteLine("");
                                Console.WriteLine($"C has the maximum score ({scoreC})");
                                // END
                            }

                        }
                    }
                    else if (minimum == disAB)
                    {
                        if (aVsB==1)
                        {
                            hpA -= 25;
                            hpB = 0;
                            calculatedScore = 10 * (Math.Abs(bx - ax) + Math.Abs(by - ay)) + (100 - hpA); // TEMP
                            scoreA += calculatedScore;

                            Console.WriteLine($"Round 1: A-B \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Non-fighter     Health:{hpC}  Score:{scoreC}\r\n");
                            if (disAC <= 0)
                            {
                                hpC -= 25;
                                hpA = 0;
                                calculatedScore = 10 * (Math.Abs(cx - ax) + Math.Abs(cy - ay)) + (100 - hpC); // TEMP
                                scoreC += calculatedScore;
                                Console.WriteLine($"Round 2: C-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Survivor     Health:{hpC}  Score:{scoreC}\r\n");

                                if (scoreA > scoreC)
                                {
                                    Console.WriteLine($"A has the maximum score ({scoreA})");
                                    // END
                                }
                                else
                                {
                                    Console.WriteLine($"C has the maximum score ({scoreC})");

                                    // END
                                }
                            }
                            else
                            {
                                // TOO DISTANT / A has max score

                                Console.WriteLine("Round 2: C-A \r\n");
                                Console.WriteLine("Too distant, no attack");

                                Console.WriteLine("");
                                Console.WriteLine($"A has the maximum score ({scoreA})");
                                // END
                            }
                        }
                        else
                        {
                            hpB -= 25;
                            hpA = 0;
                            calculatedScore = 10 * (Math.Abs(bx - ax) + Math.Abs(by - ay)) + (100 - hpB); // TEMP
                            scoreB += calculatedScore;
                            Console.WriteLine($"Round 1: B-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Non-fighter     Health:{hpC}  Score:{scoreC}\r\n");

                            if (disBC<=15)
                            {
                                hpC -= 25;
                                hpB = 0;
                                calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpC); // TEMP
                                scoreC+=calculatedScore;
                                Console.WriteLine($"Round 2: C-B \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Survivor     Health:{hpC}  Score:{scoreC}\r\n");

                                if (scoreB>scoreC)
                                {
                                    Console.WriteLine($"B has the maximum score ({scoreB})");

                                    // END
                                }
                                else
                                {
                                    Console.WriteLine($"C has the maximum score ({scoreC})");

                                    // END
                                }
                            }
                            else
                            {
                                // too distant no attack / b has the max score

                                Console.WriteLine("Round 2: C-B \r\n");
                                Console.WriteLine("Too distant, no attack");

                                Console.WriteLine("");
                                Console.WriteLine($"B has the maximum score ({scoreB})");
                                // end
                            }
                        }
                    }
                    else if (minimum==disBC)
                    {
                        if (bVsC == 1)
                        {
                            hpB -= 25;
                            hpC = 0;
                            calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpB); // TEMP
                            scoreB+=calculatedScore;
                            Console.WriteLine($"Round 1: B-C \r\n\r\nA: Non-fighter     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Defeated     Health:{hpC}  Score:{scoreC}\r\n");

                            if (disAB<=15)
                            {
                                hpA -= 25;
                                hpB = 0;
                                calculatedScore = 10 * (Math.Abs(bx - ax) + Math.Abs(by - ay)) + (100 - hpA); // TEMP
                                scoreA+=calculatedScore;
                                Console.WriteLine($"Round 2: A-B \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Defeated     Health:{hpC}  Score:{scoreC}\r\n");

                                if (scoreA>scoreB)
                                {
                                    Console.WriteLine($"A has the maximum score ({scoreA})");

                                    // end
                                }
                                else
                                {
                                    Console.WriteLine($"B has the maximum score ({scoreB})");

                                    // end
                                }
                            }
                            else
                            {
                                // too distant no attack / b has the max score
                                Console.WriteLine("Round 2: A-B \r\n");
                                Console.WriteLine("Too distant, no attack");

                                Console.WriteLine("");
                                Console.WriteLine($"B has the maximum score ({scoreB})");
                                // end
                            }
                        }
                        else
                        {
                            hpC-= 25;
                            hpB = 0;
                            calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpC); // TEMP
                            scoreC+=calculatedScore;
                            Console.WriteLine($"Round 1: C-B \r\n\r\nA: Non-fighter     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Survivor     Health:{hpC}  Score:{scoreC}\r\n");

                            if (disAC<=15)
                            {
                                hpA -= 25;
                                hpC = 0;
                                calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpA); // TEMP
                                scoreA += calculatedScore;
                                Console.WriteLine($"Round 2: A-C \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Defeated     Health:{hpC}  Score:{scoreC}\r\n");

                                if (scoreA>scoreC)
                                {
                                    Console.WriteLine($"A has the maximum score ({scoreA})");

                                    // END
                                }
                                else
                                {
                                    Console.WriteLine($"C has the maximum score ({scoreC})");

                                    // END
                                }
                            }
                            else
                            {
                                // too distant no attack / C has the max score

                                Console.WriteLine("Round 2: A-C \r\n");
                                Console.WriteLine("Too distant, no attack");

                                Console.WriteLine("");
                                Console.WriteLine($"C has the maximum score ({scoreC})");

                                // end
                            }
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Please enter valid coordinates");
            }


            Console.Read();

        }
    }
}
