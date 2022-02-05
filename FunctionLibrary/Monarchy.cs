using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    class FamilyTree
    {
        public string Name { get; set; }
        public List<FamilyTree> Children { get; set; }
        public bool IsAlive { get; set; }
        public FamilyTree(string name)
        {
            Name = name;
            IsAlive = true;
        }
    }

    //damn this could've been done with a hashmap
    public class Monarchy : IMonarchy
    {
        private FamilyTree Head;
        public Monarchy(string head)
        {
            Head = new FamilyTree(head);
        }
        
        public void Birth(string child, string parent)
        {
            var par = FindFamilyMemberBFS(parent);
                if(par == null)
                    Console.WriteLine("Parent not found in family tree");
                else
                {
                    var ch = new FamilyTree(child);
                if (par.Children == null)
                {
                    par.Children = new List<FamilyTree>();
                    par.Children.Add(ch);
                }
                else
                    par.Children.Add(ch);
                }
            
        }

        private FamilyTree FindFamilyMemberBFS(string parent)
        {
            Queue<FamilyTree> queue = new Queue<FamilyTree>();
            queue.Enqueue(Head);
            while(queue.Count > 0)
            {
                var familyMember = queue.Dequeue();
                if(familyMember.Name == parent)
                {
                    return familyMember;
                }
                if (familyMember.Children != null)
                {
                    foreach (var child in familyMember.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
            return null;
        }

        public void Death(string name)
        {
            if (Head == null)
            {
                Console.WriteLine("No Family tree found");
                return;
            }
            var famMember = FindFamilyMemberBFS(name);
            if (famMember == null)
                Console.WriteLine(name + " not found in the family tree");
            else
                famMember.IsAlive = false;
        }

        List<string> succession;
        public List<string> GetOrderOfSuccession()
        {
            succession  = new List<string>();
            TraverseFamilyDFS(Head);
            return succession;
        }

        private void TraverseFamilyDFS(FamilyTree head)
        {
            if (head == null)
                return;
            if(head.IsAlive)
                succession.Add(head.Name);
            if(head.Children != null)
            {
                foreach (var child in head.Children)
                {
                    TraverseFamilyDFS(child);
                }
            }
            
        }
    }

    public class FamilyMember
    {
        internal string name;
        internal List<string> children;
        internal bool isAlive;
        public FamilyMember(string n)
        {
            isAlive = true;
            name = n;
            children = new List<string>();
        }
    }
    public class Monarchy2 : IMonarchy
    {
        
        private Dictionary<string, FamilyMember> parentChildren = new Dictionary<string, FamilyMember>();
        public Monarchy2(string head)
        {
            var member = new FamilyMember(head);
            parentChildren.Add(head, member);
        }
        public void Birth(string child, string parent)
        {
            if(!parentChildren.ContainsKey(parent))
                Console.WriteLine("Parent not found in the family tree");

            var ch = new FamilyMember(child);

            parentChildren[parent].children.Add(child);
            parentChildren.Add(child, ch);
        }

        public void Death(string name)
        {
            if(!parentChildren.ContainsKey(name))
                Console.WriteLine("Family memer not found");

            parentChildren[name].isAlive = false;
        }

        List<string> successors;
        public List<string> GetOrderOfSuccession()
        {
            successors = new List<string>();
            TraverseFamilyDFS(parentChildren.Keys.FirstOrDefault());
            return successors;
        }

        private void TraverseFamilyDFS(string head)
        {
            if (head == null)
                return;
            if(parentChildren[head].isAlive)
                successors.Add(head);
            foreach (var child in parentChildren[head].children)
            {
                TraverseFamilyDFS(parentChildren[child].name);
            }
        }
    }
}
