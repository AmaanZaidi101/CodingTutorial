using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    //instead of using a list we could also use a hashmap(dictionary) like we did with Monarchy2 class
    //class Letter
    //{
    //    internal char alphabet;
    //    internal bool isEnd;
    //    internal Dictionary<char,Letter> childrenNodes;
    //    public Letter()
    //    {
    //        childrenNodes = new List<Letter>();
    //    }
    //}
    class Letter
    {
        internal char alphabet;
        internal bool isEnd;
        internal List<Letter> childrenNodes;
        public Letter()
        {
            childrenNodes = new List<Letter>();
        }
    }
    public class Trie : ITrie
    {
        Letter root;
        public Trie()
        {
            root = new Letter();
        }
        public void Insert(string word)
        {
            InsertWithDFS(root, word);
        }

        private void InsertWithDFS(Letter currentRoot, string word, int index=0)
        {
            if (word.Length == index)
            { 
                currentRoot.isEnd = true;
                return;
            }

            bool flag = false;

            foreach (var child in currentRoot.childrenNodes)
            {
                if (word[index] == child.alphabet)
                {
                    InsertWithDFS(child, word, index + 1);
                    flag = true;
                }
            }

            if (!flag)
            {
                while(index < word.Length)
                {
                    var letter = new Letter();
                    letter.alphabet = word[index];
                    currentRoot.childrenNodes.Add(letter);
                    currentRoot = letter;
                    index++;
                }
                currentRoot.isEnd = true;
            }
        }

        public bool Search(string word)
        {
            var firstLetter = root.childrenNodes.FirstOrDefault(x => x.alphabet == word[0]);
            if (firstLetter == null)
                return false;
            return SearchWithDFS(firstLetter,word,0);
        }

        private bool SearchWithDFS(Letter currentRoot, string word, int index = 0, bool onlyPrefix = false)
        {
            if (currentRoot.alphabet != word[index])
                return false;
            if (index == word.Length - 1)
                return onlyPrefix? true: currentRoot.isEnd;
            foreach (var child in currentRoot.childrenNodes)
            {
                if(SearchWithDFS(child, word, index + 1,onlyPrefix))
                    return true;
            }
            return false;
        }

        public bool StartsWith(string prefeix)
        {
            var firstLetter = root.childrenNodes.FirstOrDefault(x => x.alphabet == prefeix[0]);
            if (firstLetter == null)
                return false;
            return SearchWithDFS(firstLetter, prefeix, 0,true);
        }
    }

    class Letter2
    {
        internal bool isEnd;
        internal Dictionary<char, Letter2> childrenNodes;
        public Letter2()
        {
            childrenNodes = new Dictionary<char, Letter2>();
        }

    }
    public class Trie2 : ITrie
    {
        Dictionary<char, Letter2> letters = new Dictionary<char, Letter2>();
        public void Insert(string word)
        {
            int index = 0;
            var currentChildren = letters;
            var lastSetOfChildren = currentChildren;
            while(index != word.Length)
            {
                lastSetOfChildren = currentChildren;
                if (currentChildren.ContainsKey(word[index]))
                {
                    currentChildren = currentChildren[word[index]].childrenNodes;
                }
                else
                {
                    var newChild = new Letter2();
                    currentChildren.Add(word[index], newChild);
                    currentChildren = newChild.childrenNodes;
                }
                index++;
            }
            lastSetOfChildren[word[--index]].isEnd = true;
        }

        public bool Search(string word)
        {
            return SearchWord(word);
        }

        public bool StartsWith(string prefix)
        {
            return SearchWord(prefix, true);
        }

        private bool SearchWord(string word, bool isPrefix = false)
        {
            if (string.IsNullOrWhiteSpace(word))
                return true;

            int index = 0;
            var currentChildren = letters;
            var lastSetOfChildren = currentChildren;
            while (index != word.Length)
            {
                lastSetOfChildren = currentChildren;
                if (currentChildren.ContainsKey(word[index]))
                {
                    currentChildren = currentChildren[word[index]].childrenNodes;
                }
                else
                {
                    return false;
                }
                index++;
            }
            return isPrefix ? true : lastSetOfChildren[word[--index]].isEnd;
        }
    }
}
