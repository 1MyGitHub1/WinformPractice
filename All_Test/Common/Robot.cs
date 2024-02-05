using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static All_Test.Form1;

namespace All_Test.Common
{
    public class Robot : Person
    {
        public override void Speak()
        {
            Console.WriteLine("大家好：我是机器人。");
        }
    }
}
