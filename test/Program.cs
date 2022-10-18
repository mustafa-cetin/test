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
            Random random = new Random();
            int r;
            int ax, ay, bx, by, cx, cy;

            Console.Write("X: ");
            ax = Convert.ToInt32(Console.ReadLine());

            Console.Write("Y: ");
            ay = Convert.ToInt32(Console.ReadLine());

            if (ax <= 10 && -10 <= ax && -10 <= ay && ay <= +10)
            {

                bx = random.Next(-10, 11);
                cx = random.Next(-10, 11);
                by = random.Next(-10, 11);
                cy = random.Next(-10, 11);


                // COORDINATE PLANE AND SHOWN ARCHERS

                string setA, setB, setC;

                // randomly assign sets
                List<string> sets = new List<string>() { "set1", "set2", "set3" };
                r = random.Next(sets.Count);
                setA = sets[r];
                sets.RemoveAt(r);


                r = random.Next(sets.Count);
                setB = sets[r];
                sets.RemoveAt(r);


                r = random.Next(sets.Count);
                setC = sets[r];
                sets.RemoveAt(r);

                int aVsB, bVsC, cVsA;
                // set1 > set2 > set3 > set1 > set2> set3> set1

                // comparing sets who wins
                if (setA == "set1")
                {
                    if (setB == "set2") // A=set1 B=set2 C=set3
                    {
                        aVsB = 1;
                        bVsC = 1;
                        cVsA = 1;
                    }
                    else // A=set1 B=set3 C=set2
                    {
                        aVsB = 0;
                        bVsC = 0;
                        cVsA = 0;
                    }
                }
                else if (setA == "set2")
                {
                    if (setB == "set1") // A=set2 B=set1 C=set3
                    {
                        aVsB = 0;
                        bVsC = 0;
                        cVsA = 0;
                    }
                    else // A=set2 B=set3 C=set1
                    {
                        aVsB = 1;
                        bVsC = 1;
                        cVsA = 1;
                    }
                }
                else if (setA == "set3")
                {
                    if (setB == "set1") // A=set3 B= set1 C=set2
                    {
                        aVsB = 1;
                        bVsC = 1;
                        cVsA = 1;
                    }
                    else // A=set3 B=set2 C=set1
                    {
                        aVsB = 0;
                        bVsC = 0;
                        cVsA = 0;
                    }
                }




                // randomly assign healths
                int hpA, hpB, hpC;
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


                // GETTING DISTANCE BETWEEN PLAYERS
                double disAB = Math.Sqrt(Math.Pow(ax - bx, 2) + Math.Pow(ay - by, 2));
                double disBC = Math.Sqrt(Math.Pow(cx - bx, 2) + Math.Pow(cy - by, 2));
                double disAC = Math.Sqrt(Math.Pow(ax - cx, 2) + Math.Pow(ay - cy, 2));

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
                    int scoreA = 0;
                    int scoreB = 0;
                    int scoreC = 0;

                    int calculatedScore;
                    // FIND WHO IS MINIMUM
                    if (minimum == disAC)
                    {
                        if (setA > setC)
                        {
                            hpA -= 25;
                            hpC = 0;
                            calculatedScore = 10 * (Math.Abs(ax - cx) + Math.Abs(ay - cy)) + (100 - hpA); // TEMP
                            scoreA += calculatedScore;

                            // WRITE ROUND 1 TEXT    

                            if (disAB <= 15)
                            {
                                hpB -= 25;
                                hpA = 0;
                                calculatedScore = 10 * (Math.Abs(ax - bx) + Math.Abs(ay - by)) + (100 - hpB); // TEMP
                                scoreB += calculatedScore;
                                // WRITE ROUND 2 TEXT
                            }
                            else
                            {
                                // too distant / a has max score
                            }
                        }
                        else
                        {
                            hpC -= 25;
                            hpA = 0;
                            calculatedScore = 10 * (Math.Abs(ax - cx) + Math.Abs(ay - cy)) + (100 - hpC); // TEMP
                            scoreC += calculatedScore;

                            // WRITE ROUND 1 TEXT

                            if (disBC <= 15)
                            {
                            }
                            else
                            {
                                // too distant / C has max score
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
