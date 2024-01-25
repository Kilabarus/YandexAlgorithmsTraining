using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;


namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            const string INPUT_FILE = "input.txt";

            return File.ReadAllLines(INPUT_FILE).ToList();
        }

        static void WriteOutput(string output)
        {
            const string OUTPUT_FILE = "output.txt";

            File.WriteAllText(OUTPUT_FILE, output);
        }

        static string Solve(List<string> input)
        {            
            StringBuilder output = new StringBuilder();

            Dictionary<string, int> bankAccounts = new Dictionary<string, int>();

            foreach (var str in input)
            {
                string[] s = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string operation = s[0];

                switch (operation)
                {
                    case "DEPOSIT":
                        {
                            string name = s[1];
                            int sum = int.Parse(s[2]);

                            if (!bankAccounts.ContainsKey(name))
                            {
                                bankAccounts.Add(name, 0);
                            }

                            bankAccounts[name] += sum;
                            break;
                        }
                    case "WITHDRAW":
                        {
                            string name = s[1];
                            int sum = int.Parse(s[2]);

                            if (!bankAccounts.ContainsKey(name))
                            {
                                bankAccounts.Add(name, 0);
                            }

                            bankAccounts[name] -= sum;
                            break;
                        }
                    case "BALANCE":
                        {
                            string name = s[1];

                            if (!bankAccounts.ContainsKey(name))
                            {
                                output.AppendLine("ERROR");
                                break;
                            }

                            output.AppendLine(bankAccounts[name].ToString());
                            break;
                        }
                    case "TRANSFER":
                        {
                            string nameFrom = s[1];
                            string nameTo = s[2];
                            int sum = int.Parse(s[3]);

                            if (!bankAccounts.ContainsKey(nameFrom))
                            {
                                bankAccounts.Add(nameFrom, 0);                                
                            }

                            if (!bankAccounts.ContainsKey(nameTo))
                            {
                                bankAccounts.Add(nameTo, 0);                                
                            }

                            bankAccounts[nameFrom] -= sum;
                            bankAccounts[nameTo] += sum;

                            break;
                        }
                    case "INCOME":
                        {
                            int p = int.Parse(s[1]);

                            foreach (var name in bankAccounts.Keys.Where(x => bankAccounts[x] > 0))
                            {
                                bankAccounts[name] += (int)Math.Floor(bankAccounts[name] / 100.0 * p);
                            }

                            break;
                        }
                }
            }

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}