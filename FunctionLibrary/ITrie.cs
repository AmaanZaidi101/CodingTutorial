using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    interface ITrie
    {
        void Insert(string word);
        bool Search(string word);
        bool StartsWith(string prefeix);
    }
}
