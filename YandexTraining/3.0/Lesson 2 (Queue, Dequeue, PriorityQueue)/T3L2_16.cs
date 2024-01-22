using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L2_16
    {
        class Node
        {
            public int Value;
            public Node Next;
        }

        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static string GetAnswer((string Cmd, int Arg)[] cmds)
        {
            Node front = null;
            Node back = null;
            int count = 0;

            StringBuilder sB = new();

            foreach (var cmd in cmds)
            {
                switch (cmd.Cmd)
                {
                    case "push":
                        Node newNode = new Node() { Value = cmd.Arg };

                        if (front is null)
                        {
                            front = newNode;
                            back = front;
                            ++count;
                            sB.AppendLine("ok");
                            break;
                        }

                        back.Next = newNode;
                        back = back.Next;
                        ++count;
                        sB.AppendLine("ok");
                        break;
                    case "pop":
                        if (front is not null)
                        {
                            sB.AppendLine($"{front.Value}");
                            front = front.Next;
                            --count;
                            break;
                        }

                        sB.AppendLine("error");
                        break;
                    case "front":
                        if (front is not null)
                        {
                            sB.AppendLine(front.Value.ToString());
                            break;
                        }

                        sB.AppendLine("error");
                        break;
                    case "size":
                        sB.AppendLine(count.ToString());
                        break;
                    case "clear":
                        front = null;
                        back = null;
                        count = 0;
                        sB.AppendLine("ok");
                        break;
                    default:
                        sB.AppendLine("bye");
                        return sB.ToString();                        
                }
            }

            return sB.ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            (string Cmd, int Arg)[] cmds = new (string Cmd, int Arg)[input.Length];

            string[] cmdArg;

            for (int i = 0; i < input.Length; i++)
            {
                cmdArg = input[i].Split(" ");

                cmds[i].Cmd = cmdArg[0];

                if (cmdArg[0] == "push")
                {
                    cmds[i].Arg = int.Parse(cmdArg[1]);
                }
            }

            Console.WriteLine(GetAnswer(cmds));
        }
    }
}
