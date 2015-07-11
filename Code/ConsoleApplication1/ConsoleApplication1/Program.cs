using ConsoleApplication1.Texas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {

            List<Card> cardList = new List<Card>() 
            {
                new Card(){Num=2,Hua=Color.S},
                new Card(){Num=12,Hua=Color.S},
                new Card(){Num=6,Hua=Color.B},
                new Card(){Num=5,Hua=Color.A},
                new Card(){Num=6,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            
            double weight=CardUtil.GetWeight(cardList,out ct);


            Console.WriteLine("CardType:{0}======Weight: {1} ",ct.ToString(),weight);
            Console.Read();
        }


    }
}
