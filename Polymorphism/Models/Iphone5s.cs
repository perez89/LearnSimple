using Polymorphism.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class iPhone5s : Iphone
    {

        public void LaunchDate()
        {
            Console.WriteLine("Launch Date: This iPhone was launched on 20-September-2013");
        }


        public override void Model()
        {           
            Console.WriteLine("Model: The model of this iPhone is iPhone5s");
        }

        public new virtual void Messages() {
            Console.WriteLine("Messages Method: This method provides Messages features iPhone5s");
        }
    }
}
