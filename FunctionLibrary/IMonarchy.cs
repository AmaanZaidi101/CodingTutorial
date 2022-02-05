using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    interface IMonarchy
    {
        void Birth(string child, string parent);
        void Death(string name);
        List<string> GetOrderOfSuccession();
    }
}
