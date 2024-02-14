using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace YandexTraining
{
    internal class Program
    {
        const string LOCAL_INPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\input.txt";
        const string SERVER_INPUT_FILE = "input.txt";

        static List<string> ReadInput() => File.Exists(LOCAL_INPUT_FILE)
            ? File.ReadAllLines(LOCAL_INPUT_FILE).ToList()
            : File.ReadAllLines(SERVER_INPUT_FILE).ToList();

        static void Solve()
        {
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            StreamReader f = new StreamReader("input.txt");

            int K = ConvertStringToListOfInt32(f.ReadLine())[0];

            for (int testNumber = 0; testNumber < K; testNumber++)
            {
                var testData = ConvertStringToListOfInt32(f.ReadLine());
                int N = testData[0];

                int guardId = 1;                
                List<(int Time, bool GuardCame)> events = new(2 * N);                
                for (int i = 1; i < testData.Count; i += 2)
                {
                    events.Add((testData[i] + 1, true));
                    events.Add((testData[i + 1] + 1, false));
                    
                    ++guardId;
                }
                testData = null;
                
                events.Sort((a, b) =>
                {
                    if (a.Time != b.Time)
                    {
                        return a.Time.CompareTo(b.Time);
                    }

                    return b.GuardCame.CompareTo(a.GuardCame);
                });

                bool foundAnswer = false;
                int lastTimeGuardCameOrLeft = -1;                
                int guardsOnDuty = 0;                
                int cantFire = 0;
                
                for (int i = 0; i < events.Count; i++)
                {
                    if (events[i].GuardCame)
                    {
                        if (events[i].Time == 1)
                        {                            
                            ++guardsOnDuty;
                            lastTimeGuardCameOrLeft = 1;
                            continue;
                        }
                        
                        if (guardsOnDuty == 0)
                        {
                            Console.WriteLine("Wrong Answer");
                            foundAnswer = true;
                            break;
                        }
                        
                        if (guardsOnDuty == 1 && lastTimeGuardCameOrLeft != events[i].Time)
                        {
                            cantFire++;
                        }
                        
                        ++guardsOnDuty;
                        lastTimeGuardCameOrLeft = events[i].Time;
                        continue;
                    }
                   
                    if (events[i].Time == 10001 && guardsOnDuty == 1 && lastTimeGuardCameOrLeft != 10001)
                    {
                        cantFire++;
                    }
                    
                    --guardsOnDuty;
                    lastTimeGuardCameOrLeft = events[i].Time;
                }
                
                if (foundAnswer)
                {
                    continue;
                }

                if (cantFire != guardId - 1)
                {
                    Console.WriteLine("Wrong Answer");
                    continue;
                }

                Console.WriteLine("Accepted");
            }            
        }

        static void Main(string[] args)
        {
            Solve();
        }
    }
}