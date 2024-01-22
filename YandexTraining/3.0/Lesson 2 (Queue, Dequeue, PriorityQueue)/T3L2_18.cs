using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L2_18
    {
        class Node
        {
            public int Value;
            public Node Next;
            public Node Prev;
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
            Node newNode;

            foreach (var cmd in cmds)
            {
                switch (cmd.Cmd)
                {
                    case "push_front":
                        newNode = new Node() { Value = cmd.Arg };

                        if (count == 0)
                        {
                            front = newNode;
                            back = newNode;
                        }
                        else
                        {
                            front.Prev = newNode;
                            newNode.Next = front;
                            front = newNode;
                        }

                        ++count;
                        sB.AppendLine("ok");
                        break;
                    case "push_back":
                        newNode = new Node() { Value = cmd.Arg };

                        if (count == 0)
                        {
                            front = newNode;
                            back = newNode;
                        }
                        else
                        {
                            back.Next = newNode;
                            newNode.Prev = back;
                            back = back.Next;
                        }

                        ++count;
                        sB.AppendLine("ok");
                        break;
                    case "pop_front":
                        if (count > 0)
                        {
                            sB.AppendLine(front.Value.ToString());
                            front = front.Next;
                            if (front is not null)
                            {
                                front.Prev = null;
                            }
                            --count;

                            break;
                        }

                        sB.AppendLine("error");
                        break;
                    case "pop_back":
                        if (count > 0)
                        {
                            sB.AppendLine(back.Value.ToString());
                            back = back.Prev;
                            if (back is not null)
                            {
                                back.Next = null;
                            }
                            --count;
                            break;
                        }

                        sB.AppendLine("error");
                        break;
                    case "front":
                        if (count > 0)
                        {
                            sB.AppendLine(front.Value.ToString());
                            break;
                        }

                        sB.AppendLine("error");
                        break;
                    case "back":
                        if (count > 0)
                        {
                            sB.AppendLine(back.Value.ToString());
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

                if (cmdArg[0] == "push_front" || cmdArg[0] == "push_back")
                {
                    cmds[i].Arg = int.Parse(cmdArg[1]);
                }
            }

            Console.WriteLine(GetAnswer(cmds));
        }
    }
}
