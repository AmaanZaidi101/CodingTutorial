using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    class Node
    {
        public int val;
        public Node next;
    }

    public class DoubleNode
    {
        public int val;
        public DoubleNode next;
        public DoubleNode prev;
        public DoubleNode child;
    }

    public class DoublyLinkedList
    {
        static DoubleNode start = null;
        public static void CreateLinkedList(Dictionary<int,object> vals, DoubleNode current)
        {

            DoubleNode prev = null;
            bool firstTime = true;
            foreach (var key in vals.Keys)
            {
                if (firstTime && start == null)
                {
                    current = new DoubleNode();
                    firstTime = false;
                }
                else if (firstTime)
                    firstTime = false;
                else
                    current = new DoubleNode();
                
                current.val = key;
                current.prev = prev;

                
                if (prev != null)
                    prev.next = current;

                if ((Dictionary<int, object>)vals[key] == null)
                {
                    current.child = null;
                }
                else
                {
                    current.child = new DoubleNode();
                    current.child.val = ((Dictionary<int, object>)(vals[key])).Keys.First();
                    current.child.prev = null;
                    CreateLinkedList((Dictionary<int, object>)(vals[key]),current.child);
                }

                if (start == null)
                    start = current;


                prev = current;
            }
            prev.next = current;
            current.next = null;
        }

        public static void FlattenLinkedList(DoubleNode current, DoubleNode next, bool isChild=false)
        {
            DoubleNode prev = null;

            if(current == null)
                current = start;
            
            while (current != null)
            {
                if(current.child != null)
                {
                    current.child.prev = current;
                    FlattenLinkedList(current.child,current.next, true);
                    current.next = current.child;
                    current.child = null;
                }
                prev = current;
                current = current.next;
            }
            if (isChild)
            {
                prev.next = next;
                next.prev = prev;
            }
        }

        public static void Print(DoubleNode current=null, int tabs=0)
        {
            if (current == null)
                current = start;
            string tab = "";

            if (tabs > 0)
            {
                tab = new string(' ', tabs * 4 + 3);
                Console.WriteLine(tab + "↓");
            }
            Console.Write(tab);
            int count = 0;
            List<DoubleNode> children = new List<DoubleNode>();
            List<DoubleNode> parent = new List<DoubleNode>();
            List<int> t = new List<int>();
            while(current != null)
            {
                Console.Write(current.val+" -> ");
                if (current.child != null)
                {
                    parent.Add(current);
                    children.Add(current.child);
                    t.Add(count);
                }
                current = current.next;
                count++;
            }
            Console.WriteLine();
            for (int i = 0; i < children.Count; i++)
            {
                Console.WriteLine("Children of " +parent[i].val);
                Print(children[i], t[i]);
            }
        }

        public static void PrintAgain()
        {
            DoubleNode current = start;
            while (current !=null)
            {
                Console.Write(current.val + " ->");
                if (current.child != null)
                {
                    Console.WriteLine("Failed");
                    break;
                }
                current = current.next;
            }
        }
    }
    public class LinkedList
    {
         static Node start = null;
        public static void CreateLinkedList(int[] vals)
        {
            Node current = start;
            Node prev = null;
            foreach (var val in vals)
            {
                current = new Node();
                current.val = val;
                if (prev != null)
                {
                    prev.next = current;
                }
                else
                {
                    start = current;
                }
                prev = current;
            }
            prev.next = null;
        }

        public static void PrintLinkedList()
        {
            Node current = start;
            while(current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }

        public static void ReverseLinkedList()
        {
            Node current = start;
            Node prev = null;
            Node next;
            while(current != null)
            {
                next = current.next; //save current's next 
                current.next = prev; //set current's next to prev (reverse)
                prev = current; //save current as previous
                current = next; //update pointer
            }
            start = prev;
        }

        public static void ReverseLinkedListPartially(int m, int n)
        {
            int i = 1;
            Node current = start;
            Node prev = null, next;
            Node mNode=null,mMinusOne=null,nNode=null;
            if (m <= 0 || n <= 0)
                return;
            while(current != null && i<=n)
            {
                next = current.next; 
                if(i >m && i <= n)
                {
                    current.next = prev;
                }
                else if(i == m - 1)
                {
                    mMinusOne = current;
                }
                if (i == m)
                {
                    mNode = current;
                }
                else if (i == n)
                {
                    nNode = current;
                }
                prev = current;
                current = next;
                i++;
            }
            if (mMinusOne != null)
            { 
                mMinusOne.next = nNode;
            }
            else
            {
                start = prev;
            }
            if (mNode != null)
            {
                mNode.next = current;
            }
        }
    }
    public class CycledNode
    {
        public int val;
        public CycledNode next;
        public bool cycleStart;
    }
    public class CycleLinkedList
    {
        static CycledNode start = null;
        public static void CreateLinkedList(Dictionary<int,bool> vals)
        {
            CycledNode current = start;
            CycledNode prev = null;
            CycledNode cycleStart=null;
            foreach (var key in vals.Keys)
            {
                current = new CycledNode();
                current.val = key;
                current.cycleStart = vals[key];


                if (start == null)
                {
                    start = current;
                }
                else
                {
                    prev.next = current;
                }

                if (current.cycleStart)
                {
                    cycleStart = current;
                }

                prev = current;
            }
            prev.next = cycleStart;
        }

        public static void DetectCycle()
        {
            Dictionary<CycledNode, int> dictionary = new Dictionary<CycledNode, int>();
            CycledNode current = start;
            while (current != null)
            {
                if (dictionary.ContainsKey(current))
                {
                    Console.WriteLine($"Cycle starts at {current.val}");
                    break;
                }
                else
                {
                    dictionary.Add(current, current.val);
                }
                current = current.next;
            }
        }

        public static void TortoiseAndHare()
        {
            CycledNode hare = start, tortoise = start;
            bool started = true;
            
            while(hare != null)
            {
                if(hare == tortoise && !started)
                {
                    Console.WriteLine("Cycle detected");
                    CycledNode pointer1 = start;
                    CycledNode pointer2 = hare;
                    while(pointer1 != pointer2)
                    {
                        pointer1 = pointer1.next;
                        pointer2 = pointer2.next;
                    }
                    Console.WriteLine($"Cycle begins at {pointer1.val}");
                    break;
                }
                else
                {
                    hare = hare.next.next;
                    tortoise = tortoise.next;
                    started = false;
                }
            }
        }

        public static void PrintLinkedList()
        {
            CycledNode current = start;
            int count = 1;
            while (current != null && count < 17)
            {
                Console.WriteLine(current.val);
                current = current.next;
                count++;
            }
        }
    }
}
