using Polymorphism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Iphone5SE x = new Iphone5SE();
            x.Messages();
            x.Model();


            x.Call();
            x.SelfPrivateKey();

            x.Model();
            var iphone5s = new iPhone5s();
            iphone5s.Call();
            iphone5s.Model();
            iphone5s.LaunchDate();
            iphone5s.Messages();
            Console.ReadKey();
        }
    }
}
