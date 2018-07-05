using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbTestAssignment
{
    class Program
    {
       
        static void Main(string[] args)
        {
            fbLogin obj = new fbLogin();
            // test case 1 : facebook login process
            obj._fbSetup();

            // test case 2 : facebook story section verification
            obj._storyCheck();

            // test case 3 : facebook birthday verification 
            obj._BirthdayCheck();

            // test case 4 : facebook message verification
            obj._MessageCheck();

            Console.ReadKey();
        }
    }
}
