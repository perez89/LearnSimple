using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Iphone5SE : iPhone5s
    {
        public new void Call()
        {
            Console.WriteLine("Call Method: This method provides Calling features Iphone5SE");
        }


        public override void Model()
        {
            Console.WriteLine("Model: The model of this iPhone is Iphone5SE");
        }

        public void Messages()
        {
            Console.WriteLine("Messages Method: This method provides Messages features Iphone5SE");
        }
    }
}
