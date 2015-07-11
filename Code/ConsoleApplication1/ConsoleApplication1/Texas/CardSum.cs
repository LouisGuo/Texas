using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Texas
{
    class CardSum : IComparable<CardSum>//实现IComparable接口，用来后面的List排序
    {
        public int Num { set; get; }
        public int Sum { set; get; }
        public int CompareTo(CardSum other)
        {
            return this.Num.CompareTo(other.Num);
        }
    }
}
