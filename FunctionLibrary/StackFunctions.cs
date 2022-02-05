using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class StackQueue
    {
        private List<int> Stack;
        private List<int> ReversedStack;
        public StackQueue()
        {
            Stack = new List<int>();
            ReversedStack = new List<int>();
        }

        public bool Empty()
        {
            return Stack.Count == 0 && ReversedStack.Count == 0;
        }

        public int Peek()
        {
            if (Empty())
                return -1;
            if (ReversedStack.Count > 0)
                return ReversedStack.Last();
            else
                return Stack.First();
        }

        public void Enqueue(int num)
        {
            Stack.Add(num);
        }

        public int Dequeue()
        {
            if (ReversedStack.Count > 0)
            {
                int num = ReversedStack.Last();
                ReversedStack.RemoveAt(ReversedStack.Count - 1);
                return num;
            }
            else if (Stack.Count > 0)
            {
                PopulateReversedStack();
                return Dequeue();
            }
            else
                return -1;
        }

        private void PopulateReversedStack()
        {
            for (int i = Stack.Count - 1; i >= 0; i--)
            {
                ReversedStack.Add(Stack[i]);
            }
            Stack.Clear();
        }

        public void Print()
        {
            Console.WriteLine(new string('-',50));
            for (int i = ReversedStack.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(ReversedStack[i]);
            }
            for (int i = 0; i < Stack.Count; i++)
            {
                Console.WriteLine(Stack[i]);
            }
            Console.WriteLine(new string('-', 50));
        }
    }
    public class StackFunctions
    {
        public char[] Stack { get; set; }
        private List<int> Indices;
        private int length = 0;
        public StackFunctions(int l)
        {
            Stack = new char[l];
            Indices = new List<int>();
        }

        public void Push(char c)
        {
            Stack[length++] = c;
        }

        public char Pop()
        {
            if(length > 0)
                return Stack[--length];
            return '\0';
        }

        public bool IsValidParantheses(string s)
        {
            foreach (var character in s)
            {
                if(character == '[' || character == '{' || character == '(')
                {
                    Push(character);
                }
                else
                {
                    char c = Pop();
                    if((c == '[' && character == ']') || (c == '{' && character == '}') || (c == '(' && character == ')'))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return length == 0; 
        }

        public string MakeValid(string s)
        {
            string str = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                char character = s[i];
                if(character == '(')
                {
                    Push(character);
                    Indices.Add(i);
                }
                else if(character == ')')
                {
                    char c = Pop();
                    if(c == '(')
                    {
                        Indices.RemoveAt(Indices.Count - 1);
                    }
                    else
                    {
                        Indices.Add(i);
                    }
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (!Indices.Contains(i))
                {
                    str = str + s[i];
                }
            }
            return str;
        }
    }
}
