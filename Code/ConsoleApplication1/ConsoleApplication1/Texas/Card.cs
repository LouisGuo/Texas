using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Texas
{
    enum Color//花色定义
    {
        A,
        S,
        D,
        B
    }

    class Card:IComparable<Card> //实现IComparable接口，用来后面的cardList排序
    {
        public Color Hua { get; set; }// 牌的花色
        public int Num { get; set; } // 牌的大小，2—14


        public int CompareTo(Card other)
        {
            return this.Num.CompareTo(other.Num);

        }
    }
}
