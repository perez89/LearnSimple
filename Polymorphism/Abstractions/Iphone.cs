using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Abstractions
{
    public abstract class Iphone
    {
        private void SelfCertificate()
        {
            Console.WriteLine("SelfCertificate");
        }

        public void SelfPrivateKey()
        {
            Console.WriteLine("SelfPrivateKey");
        }

        public void Call()
        {
            Console.WriteLine("Call Method: This method provides Calling features");
        }

        public virtual void Messages()
        {
            Console.WriteLine("Call Method: This method provides Messages features Iphone");
        }

        //Abstract Method kept as Private   
        public abstract void Model();
    }
}
