using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int aVsB = 0;
            int bVsC = 0;
            int cVsA = 0;
            string setA, setB, setC;
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
                List<string> sets = new List<string>() { "Set 1", "Set 2", "Set 3" };
                r = random.Next(sets.Count);
                setA = sets[r];
                sets.RemoveAt(r);


                r = random.Next(sets.Count);
                setB = sets[r];
                sets.RemoveAt(r);


                r = random.Next(sets.Count);
                setC = sets[r];
                sets.RemoveAt(r);

                // Set 1 > Set 2 > Set 3 > Set 1 > Set 2> Set 3> Set 1

                // comparing sets who wins
                if (setA == "Set 1")
                {
                    if (setB == "Set 2") // A=Set 1 B=Set 2 C=Set 3
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
                else if (setA == "Set 2")
                {
                    if (setB == "Set 1") // A=Set 2 B=Set 1 C=Set 3
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
                else if (setA == "Set 3")
                {
                    if (setB == "Set 1") // A=Set 3 B= Set 1 C=Set 2
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
                List<int> healths = new List<int>() { 60, 80, 100 };
                r = random.Next(healths.Count);
                hpA = healths[r];
                healths.RemoveAt(r);

                r = random.Next(healths.Count);
                hpB = healths[r];
                healths.RemoveAt(r);

                r = random.Next(healths.Count);
                hpC = healths[r];
                healths.RemoveAt(r);

                // WRITING ARCHERS
                Console.WriteLine($"A: ({ax},{ay})  {setA}  Health:{hpA}  ");

                Console.WriteLine($"B: ({bx},{by})  {setB}  Health:{hpB}  ");

                Console.WriteLine($"C: ({cx},{cy})  {setC}  Health:{hpC}  ");
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

                            Console.WriteLine($"Round 1: A-C \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Non-fighter     Health:{hpB}   Score:{scoreB}\r\nC: Defeated  Health:{hpC}  Score:{scoreC}\r\n");

                            if (disAB <= 15)
                            {
                                hpB -= 25;
                                hpA = 0;
                                calculatedScore = 10 * (Math.Abs(ax - bx) + Math.Abs(ay - by)) + (100 - hpB); // TEMP
                                scoreB += calculatedScore;
                                Console.WriteLine($"Round 2: B-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Defeated  Health:{hpC}  Score:{scoreC}\r\n");

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

                            Console.WriteLine($"Round 1: C-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Non-fighter     Health:{hpB}   Score:{scoreB}\r\nC: Survivor  Health:{hpC}  Score:{scoreC}\r\n");

                            if (disBC <= 15)
                            {
                                hpB -= 25;
                                hpC = 0;
                                calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpB); // TEMP
                                scoreB += calculatedScore;
                                Console.WriteLine($"Round 2: B-C \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Defeated  Health:{hpC}  Score:{scoreC}\r\n");

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

                            Console.WriteLine($"Round 1: A-B \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Non-fighter  Health:{hpC}  Score:{scoreC}\r\n");
                            if (disAC <= 0)
                            {
                                hpC -= 25;
                                hpA = 0;
                                calculatedScore = 10 * (Math.Abs(cx - ax) + Math.Abs(cy - ay)) + (100 - hpC); // TEMP
                                scoreC += calculatedScore;
                                Console.WriteLine($"Round 2: C-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Survivor  Health:{hpC}  Score:{scoreC}\r\n");

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
                            Console.WriteLine($"Round 1: B-A \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Non-fighter  Health:{hpC}  Score:{scoreC}\r\n");

                            if (disBC<=15)
                            {
                                hpC -= 25;
                                hpB = 0;
                                calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpC); // TEMP
                                scoreC+=calculatedScore;
                                Console.WriteLine($"Round 2: C-B \r\n\r\nA: Defeated     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Survivor  Health:{hpC}  Score:{scoreC}\r\n");

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
                            Console.WriteLine($"Round 1: B-C \r\n\r\nA: Non-fighter     Health:{hpA}  Score:{scoreA} \r\nB: Survivor     Health:{hpB}   Score:{scoreB}\r\nC: Defeated  Health:{hpC}  Score:{scoreC}\r\n");

                            if (disAB<=15)
                            {
                                hpA -= 25;
                                hpB = 0;
                                calculatedScore = 10 * (Math.Abs(bx - ax) + Math.Abs(by - ay)) + (100 - hpA); // TEMP
                                scoreA+=calculatedScore;
                                Console.WriteLine($"Round 2: A-B \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Defeated  Health:{hpC}  Score:{scoreC}\r\n");

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
                            Console.WriteLine($"Round 1: C-B \r\n\r\nA: Non-fighter     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Survivor  Health:{hpC}  Score:{scoreC}\r\n");

                            if (disAC<=15)
                            {
                                hpA -= 25;
                                hpC = 0;
                                calculatedScore = 10 * (Math.Abs(bx - cx) + Math.Abs(by - cy)) + (100 - hpA); // TEMP
                                scoreA += calculatedScore;
                                Console.WriteLine($"Round 2: A-C \r\n\r\nA: Survivor     Health:{hpA}  Score:{scoreA} \r\nB: Defeated     Health:{hpB}   Score:{scoreB}\r\nC: Defeated  Health:{hpC}  Score:{scoreC}\r\n");

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
