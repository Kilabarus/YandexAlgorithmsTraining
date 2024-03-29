﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace YandexTraining
{
    internal class Program
    {
        const string LOCAL_INPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\input.txt";
        const string SERVER_INPUT_FILE = "input.txt";

        const string LOCAL_OUTPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\output.txt";
        const string SERVER_OUTPUT_FILE = "output.txt";

        static List<string> ReadInput() => File.Exists(LOCAL_INPUT_FILE)
            ? File.ReadAllLines(LOCAL_INPUT_FILE).ToList()
            : File.ReadAllLines(SERVER_INPUT_FILE).ToList();

        static void WriteOutput(string output)
        {
            string outputFile = File.Exists(LOCAL_OUTPUT_FILE)
                ? LOCAL_OUTPUT_FILE
                : SERVER_OUTPUT_FILE;

            File.WriteAllText(outputFile, output);
        }

        static List<int> GetListOfInt32Args(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
        }

        static (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) GetTupleOfInt32Args(string input)
        {
            var args = GetListOfInt32Args(input);

            return args.Count switch
            {
                8 => (args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]),
                7 => (args[0], args[1], args[2], args[3], args[4], args[5], args[6], 0),
                6 => (args[0], args[1], args[2], args[3], args[4], args[5], 0, 0),
                5 => (args[0], args[1], args[2], args[3], args[4], 0, 0, 0),
                4 => (args[0], args[1], args[2], args[3], 0, 0, 0, 0),
                3 => (args[0], args[1], args[2], 0, 0, 0, 0, 0),
                2 => (args[0], args[1], 0, 0, 0, 0, 0, 0),
                _ => (args[0], 0, 0, 0, 0, 0, 0, 0),
            };
        }

        static StringBuilder AnswerBuilder = new();

        class Node
        {
            public int Value;
            public Node Left, Right, Parent;
        }

        class SimpleBinarySearchTree
        {
            Node _root;

            public string GetInfixTraversalTwoChildrenParents()
            {
                if (_root is null)
                {
                    return "";
                }

                StringBuilder sb = new();
                GetInfixTraversalTwoChildrenParents(_root, sb);
                return sb.ToString();
            }

            private void GetInfixTraversalTwoChildrenParents(Node node, StringBuilder sb)
            {
                if (node.Left is not null)
                {
                    GetInfixTraversalTwoChildrenParents(node.Left, sb);
                }

                if (node.Left is not null && node.Right is not null)
                {
                    sb.AppendLine($"{node.Value}");                    
                }

                if (node.Right is not null)
                {
                    GetInfixTraversalTwoChildrenParents(node.Right, sb);
                }
            }

            public void Add(int value)
            {
                if (_root is null)
                {
                    _root = new Node() { Value = value };
                    return;
                }

                Add(_root, value);
            }

            private void Add(Node root, int value)
            {
                if (value < root.Value)
                {
                    if (root.Left is null)
                    {
                        root.Left = new Node() { Parent = root, Value = value };
                        return;
                    }

                    Add(root.Left, value);
                    return;
                }

                if (value > root.Value)
                {
                    if (root.Right is null)
                    {
                        root.Right = new Node() { Parent = root, Value = value };
                        return;
                    }

                    Add(root.Right, value);
                    return;
                }
            }
        }

        static string Solve(List<string> input)
        {
            SimpleBinarySearchTree bst = new();

            var args = GetListOfInt32Args(input[0]);
            for (int i = 0; i < args.Count; i++)
            {
                if (args[i] == 0)
                {
                    AnswerBuilder.Append($"{bst.GetInfixTraversalTwoChildrenParents()}");
                    break;
                }

                bst.Add(args[i]);
            }

            return AnswerBuilder.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}