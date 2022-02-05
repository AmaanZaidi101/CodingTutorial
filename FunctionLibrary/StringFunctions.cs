using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public static class StringFunctions
    {
        public static bool CompareStrings(string s1, string s2)
        {
            string res1 = string.Empty;
            string res2 = string.Empty;
            int skip = 0;

            for (int i = s1.Length-1; i >= 0; i--)
            {
                if (s1[i] == '#')
                {
                    skip++;
                    continue;
                }
                else if(skip != 0)
                {
                    skip--;
                    continue;
                }
                else
                {
                    res1 = s1[i] + res1;
                }
            }
            skip = 0;
            for (int i = s2.Length - 1; i >= 0; i--)
            {
                if (s2[i] == '#')
                {
                    skip++;
                    continue;
                }
                else if (skip != 0)
                {
                    skip--;
                    continue;
                }
                else
                {
                    res2 = s2[i] + res2;
                }
            }
            //Console.WriteLine($"{res1} {res2}");
            return res1 == res2;
        }

        //best approach
        public static bool CompareStringsWithStringBuilder(string s1, string s2)
        {
            var res1 = new StringBuilder(string.Empty);
            var res2 = new StringBuilder(string.Empty);
            int skip = 0;

            for (int i = s1.Length - 1; i >= 0; i--)
            {
                if (s1[i] == '#')
                {
                    skip++;
                    continue;
                }
                else if (skip != 0)
                {
                    skip--;
                    continue;
                }
                else
                {
                    res1.Insert(0,s1[i]);
                }
            }
            skip = 0;
            for (int i = s2.Length - 1; i >= 0; i--)
            {
                if (s2[i] == '#')
                {
                    skip++;
                    continue;
                }
                else if (skip != 0)
                {
                    skip--;
                    continue;
                }
                else
                {
                    res2.Insert(0, s2[i]);
                }
            }
            //Console.WriteLine($"{res1} {res2}");
            return res1.Equals(res2);
        }

        public static bool CompareStringsUsingStacks(string s1, string s2)
        {
            Stack<char> st1= new Stack<char>();
            Stack<char> st2 = new Stack<char>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != '#')
                    st1.Push(s1[i]);
                else if (st1.Count > 0)
                    st1.Pop();
            }
            for (int i = 0; i < s2.Length; i++)
            {
                if (s2[i] != '#')
                    st2.Push(s2[i]);
                else if (st2.Count > 0)
                    st2.Pop();
            }
            if (st1.Count == 0 && st2.Count == 0)
                return true;
            else
                return st1.SequenceEqual(st2);
        }

        //meh approach
        public static bool CompareStringsOptimized(string s1, string s2)
        {
            int p1 = s1.Length - 1;
            int p2 = s2.Length - 1;

            while(p1 >=0 || p2 >= 0)
            {

                if ((p1 >= 0 && s1[p1] == '#') || (p2 >= 0 && s2[p2] == '#'))
                {
                    if (p1 >= 0 && s1[p1] == '#')
                    {
                        int backCount = 2;
                        while (backCount > 0)
                        {
                            p1--;
                            backCount--;
                            if (p1 >= 0 && s1[p1] == '#')
                                backCount += 2;
                        }
                    }
                    if (p2 >= 0 && s2[p2] == '#')
                    {
                        int backCount = 2;
                        while (backCount > 0)
                        {
                            p2--;
                            backCount--;
                            if (p2 >= 0 && s2[p2] == '#')
                                backCount += 2;
                        }
                    }
                }
                else
                {
                    if ((p1 < 0 && p2 >= 0) || (p2 < 0 && p1 >= 0) || (p1 >=0 && p2 >=0 && s1[p1] != s2[p2]))
                        return false;
                    else
                    {
                        p1--;
                        p2--;
                    }
                }
            }

            return true;
        }
        
        public static int GetSubstringNoDuplicate(string s, bool onlyFirst=false)
        {
            int len = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                int index = s.IndexOf(ch, i + 1);
                if(index == -1)
                {
                    //Console.WriteLine("Adding "+s[i]);
                    len++;
                    continue;
                }
                string first = s.Substring(i, index - i);
                //Console.WriteLine("first "+first);
                int firstLen = len + GetSubstringNoDuplicate(first, true);
                if (onlyFirst)
                    return firstLen;
                //string second = s.Substring(index);
                //Console.WriteLine("second " + second);
                //int secondLen = GetSubstringNoDuplicate(second);
                string third = s.Substring(i+1);
                //Console.WriteLine("third " + third);
                int thirdLen = GetSubstringNoDuplicate(third);
                //len = Math.Max(Math.Max(firstLen, secondLen),thirdLen);
                len = Math.Max(firstLen, thirdLen);
                break;
            }
            //Console.WriteLine("For " +s+ " returning "+len);
            return len;
        }

        public static int GetSubstringNoDuplicateLengthFast(string s)
        {
            Dictionary<char, int> hashMap = new Dictionary<char, int>();
            int len = 0;
            int maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(hashMap.ContainsKey(s[i]))
                {
                    maxLen = Math.Max(maxLen, len);
                    i = hashMap[s[i]] + 1;
                    hashMap.Clear();
                    //Console.WriteLine("Clearing hashmap");
                    hashMap.Add(s[i], i);
                    //Console.WriteLine($"Adding {s[i]}, length is {1}");
                    len = 1;
                }
                else
                {
                    //Console.WriteLine($"Adding {s[i]}, length is {++len}");
                    len++;
                    hashMap.Add(s[i], i);
                }
            }
            maxLen = Math.Max(maxLen, len);
            return maxLen;
        }

        public static int GetSubstringNoDuplicateLengthSlidingWindow(string s)
        {
            int left = 0;
            int maxLen = 0;
            Dictionary<char, int> seenCharacters = new Dictionary<char, int>();
            for (int right = 0; right < s.Length; right++)
            {
                char ch = s[right];
                if (seenCharacters.ContainsKey(ch))
                {
                    if(left <= seenCharacters[ch])
                    {
                        left = seenCharacters[ch] + 1;
                    }
                }
                seenCharacters[ch] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            return maxLen;
        }
        public static int GetSubstringNoDuplicateLoop(string s, bool onlyFirst = false)
        {
            int len = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                int index = s.IndexOf(ch, i + 1);
                if (index == -1)
                {
                    //Console.WriteLine("Adding "+s[i]);
                    len++;
                    continue;
                }
                string first = s.Substring(i, index - i);
                //Console.WriteLine("first "+first);
                int firstLen = len + GetSubstringNoDuplicateLoop(first, true);
                if (onlyFirst)
                    return firstLen;
                //string second = s.Substring(index);
                //Console.WriteLine("second " + second);
                //int secondLen = GetSubstringNoDuplicate(second);
                string third = s.Substring(i + 1);
                //Console.WriteLine("third " + third);
                int thirdLen = GetSubstringNoDuplicateLoop(third);
                //len = Math.Max(Math.Max(firstLen, secondLen),thirdLen);
                len = Math.Max(firstLen, thirdLen);
                break;
            }
            //Console.WriteLine("For " +s+ " returning "+len);
            return len;
        }

        public static string GetSubstringNoDuplicateString(string s, bool onlyFirst=false)
        {
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                int index = s.IndexOf(ch, i + 1);
                if (index == -1)
                {
                    Console.WriteLine("Adding " + s[i]);
                    str += s[i];
                    continue;
                }
                string first = s.Substring(i, index - i);
                Console.WriteLine("first " + first);
                string firstSub = str + GetSubstringNoDuplicateString(first,true);
                if (onlyFirst)
                    return firstSub;
                string second = s.Substring(index);
                Console.WriteLine("second " + second);
                string secondSub = GetSubstringNoDuplicateString(second);
                string third = s.Substring(i + 1);
                Console.WriteLine("third " + third);
                string thirdSub = GetSubstringNoDuplicateString(third);
                int len = Math.Max(Math.Max(firstSub.Length, secondSub.Length), thirdSub.Length);
                str = len == firstSub.Length ? firstSub : (len == secondSub.Length) ? secondSub : thirdSub;
                break;
            }
            return str;
        }

        public static bool IsValidPalindrome(string s)
        {
            s = Regex.Replace(s,"[^A-Za-z0-9]", string.Empty).ToLower();
            //Console.WriteLine(s);
            //return CheckPalindrome1(s);
            //return CheckPalindrome2(s);
            return CheckPalindrome3(s);
        }
        private static bool CheckPalindrome1(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while(left <= right)
            {
                if(s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        private static bool CheckPalindrome2(string s)
        {
            int left;
            int right;
            if(s.Length % 2 == 0)
            {
                right = s.Length / 2;
                left = right - 1;
            }
            else
            {
                left = right = (int)Math.Floor(s.Length / 2M);
            }
            while (left > 0 && right < s.Length)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left--;
                right++;
            }
            return true;
        }

        private static bool CheckPalindrome3(string s)
        {
            return s.Equals(s.Reverse());
        }

        public static bool AlmostPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            bool flag = false;
            while (left <= right)
            {
                if (s[left] != s[right])
                {
                    if (!flag)
                    {
                        flag = true;
                        if(s[right-1] == s[left])
                        {
                            right--;
                        }
                        else if(s[left+1] == s[right])
                        {
                            left++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
