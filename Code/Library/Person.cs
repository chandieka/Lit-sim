using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Person : Block
    {
        new public static readonly Color color = Color.Blue;

        //public override Func<Block[,], Block[,]> Function => _ => _; // TODO

        public Person()
            : base()
        {

        }
    }
}
