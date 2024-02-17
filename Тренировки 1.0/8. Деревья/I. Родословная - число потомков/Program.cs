using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


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

        static List<string> GetListOfStringArgs(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
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
            public string Value;            
            public List<Node> Children;
            public Node Parent;
        }

        class FamilyTree
        {            
            Dictionary<string, Node> _personNode = new();

            public void Add(string child, string parent)
            {
                Node parentNode;
                Node childNode;

                if (!_personNode.TryGetValue(parent, out parentNode))
                {
                    parentNode = new() { Value = parent, Children = new() };
                    
                    _personNode.Add(parent, parentNode);                    
                }

                if (!_personNode.TryGetValue(child, out childNode))
                {
                    childNode = new() { Value = child, Children = new() };

                    _personNode.Add(child, childNode);
                }
                
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            public string InfixTraversal()
            {
                Node root = _personNode.Values.First();

                while (root.Parent is not null)
                {
                    root = root.Parent;
                }

                Dictionary<string, int> childrenCount = new();
                InfixTraversal(root, childrenCount);

                StringBuilder sb = new();

                foreach (var parent in childrenCount.OrderBy(p => p.Key))
                {
                    sb.AppendLine($"{parent.Key} {parent.Value}");
                }

                return sb.ToString();
            }

            private int InfixTraversal(Node node, Dictionary<string, int> childrenCount)
            {
                int sum = 0;

                if (node.Children.Count > 0)
                {                    
                    foreach (var childNode in node.Children)
                    {
                        sum += InfixTraversal(childNode, childrenCount);
                    }
                }

                sum += node.Children.Count;
                childrenCount.Add(node.Value, sum);
                
                return sum;
            }
        }

        static string Solve(List<string> input)
        {
            FamilyTree tree = new();

            (int N, _, _, _, _, _, _, _) = GetTupleOfInt32Args(input[0]);
            foreach (var line in input.Skip(1).Take(N - 1))
            {
                var args = GetListOfStringArgs(line);
                tree.Add(args[0], args[1]);
            }

            AnswerBuilder.Append(tree.InfixTraversal());

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