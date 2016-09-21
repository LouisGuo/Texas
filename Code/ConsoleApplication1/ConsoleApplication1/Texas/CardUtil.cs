using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Texas
{
    public enum CardsType
    {
        TongHuaShun = 9,
        SiTiao = 8,
        ManTangHon = 7,
        TongHua = 6,
        ShunZi = 5,
        SanTiao = 4,
        LiangDui = 3,
        YiDui = 2,
        GaoPai = 1

    }
    public class CardUtil
    {
        public static void BubbleSort<T>(List<T> arrayList) where T : IComparable<T>
        {
            for (int i = 0; i < arrayList.Count - 1; i++)
            {
                for (int j = 0; j < arrayList.Count - i - 1; j++)
                {
                    if (arrayList[j].CompareTo(arrayList[j + 1]) > 0)
                    {
                        T temp = arrayList[j];
                        arrayList[j] = arrayList[j + 1];
                        arrayList[j + 1] = temp;
                    }
                }
            }
        }

        public static double GetWeight(List<Card> cardList, out CardsType cardsType)
        {
            string result = "";
            List<Card> countList = new List<Card>();

            cardsType = new CardsType();
            BubbleSort(cardList);

            int A_Sum = 0, B_Sum = 0, D_Sum = 0, S_Sum = 0;
            List<CardSum> cardSumList = new List<CardSum>();

            foreach (var item in cardList)
            {
                switch (item.Hua)
                {
                    case Color.A:
                        A_Sum++;
                        break;
                    case Color.B:
                        B_Sum++;
                        break;
                    case Color.D:
                        D_Sum++;
                        break;
                    case Color.S:
                        S_Sum++;
                        break;
                }

                bool EXIT = false;
                foreach (var carSum in cardSumList)
                {
                    if (carSum.Num == item.Num)
                    {
                        carSum.Sum++;
                        EXIT = true;
                        break;
                    }
                }
                if (!EXIT)
                {
                    cardSumList.Add(new CardSum() { Num = item.Num, Sum = 1 });
                }
            }


            int Four = 0, Three = 0, Two = 0, One = 0;
            foreach (var item in cardSumList)
            {
                switch (item.Sum)
                {
                    case 4:
                        Four++;
                        break;
                    case 3:
                        Three++;
                        break;
                    case 2:
                        Two++;
                        break;
                    case 1:
                        One++;
                        break;
                }
            }

            BubbleSort(cardSumList);
            int[] card5 = new int[5];

            bool ISSHUNZI = false;
            if (cardSumList.Count >= 5 && cardSumList[0].Num + 1 == cardSumList[1].Num && cardSumList[1].Num + 1 == cardSumList[2].Num && cardSumList[2].Num + 1 == cardSumList[3].Num && cardSumList[3].Num + 1 == cardSumList[4].Num)
            {
                ISSHUNZI = true;
                for (int i = 0; i < 5; i++)
                {
                    card5[i] = cardSumList[i].Num;
                }
            }
            if (cardSumList.Count >= 6 && cardSumList[1].Num + 1 == cardSumList[2].Num && cardSumList[2].Num + 1 == cardSumList[3].Num && cardSumList[3].Num + 1 == cardSumList[4].Num && cardSumList[4].Num + 1 == cardSumList[5].Num)
            {
                ISSHUNZI = true;
                for (int i = 1; i < 6; i++)
                {
                    card5[i - 1] = cardSumList[i].Num;
                }
            }
            if (cardSumList.Count >= 7 && cardSumList[2].Num + 1 == cardSumList[3].Num && cardSumList[3].Num + 1 == cardSumList[4].Num && cardSumList[4].Num + 1 == cardSumList[5].Num && cardSumList[5].Num + 1 == cardSumList[6].Num)
            {
                ISSHUNZI = true;
                for (int i = 2; i < 7; i++)
                {
                    card5[i - 2] = cardSumList[i].Num;
                }
            }


            if (Four == 1)
            {
                cardsType = CardsType.SiTiao;
                foreach (var item in cardSumList)
                {
                    if (item.Sum == 4)
                    {
                        cardSumList.Remove(item);
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        break;
                    }
                }
                CardSum lastOne = cardSumList[cardSumList.Count - 1];
                countList.Add(new Card() { Num = lastOne.Num });

            }
            else if (Three == 1 && Two > 0)
            {
                cardsType = CardsType.ManTangHon;
                foreach (var item in cardSumList)
                {
                    if (item.Sum == 3)
                    {
                        cardSumList.Remove(item);
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        break;
                    }
                }
                for (int i = cardSumList.Count - 1; i >= 0; i--)
                {
                    if (cardSumList[i].Sum == 2)
                    {
                        countList.Add(new Card() { Num = cardSumList[i].Num });
                        countList.Add(new Card() { Num = cardSumList[i].Num });
                        cardSumList.RemoveAt(i);
                        break;
                    }
                }



            }
            else if (ISSHUNZI && (A_Sum > 4 || B_Sum > 4 || D_Sum > 4 || S_Sum > 4))
            {
                cardsType = CardsType.TongHuaShun;

                for (int i = 5; i >= 0; i--)
                {
                    countList.Add(new Card() { Num = card5[i] });
                }


            }
            else if (A_Sum > 4 || B_Sum > 4 || D_Sum > 4 || S_Sum > 4)
            {
                cardsType = CardsType.TongHua;

                if (A_Sum > 4)
                {
                    for (int i = cardList.Count - 1; i >= 0; i--)
                    {
                        if (cardList[i].Hua == Color.A && countList.Count < 5)
                        {
                            countList.Add(new Card() { Num = cardList[i].Num });
                        }
                    }
                }
                else if (B_Sum > 4)
                {
                    for (int i = cardList.Count - 1; i >= 0; i--)
                    {
                        if (cardList[i].Hua == Color.B && countList.Count < 5)
                        {
                            countList.Add(new Card() { Num = cardList[i].Num });
                        }
                    }
                }
                else if (D_Sum > 4)
                {
                    for (int i = cardList.Count - 1; i >= 0; i--)
                    {
                        if (cardList[i].Hua == Color.D && countList.Count < 5)
                        {
                            countList.Add(new Card() { Num = cardList[i].Num });
                        }
                    }
                }
                if (S_Sum > 4)
                {
                    for (int i = cardList.Count - 1; i >= 0; i--)
                    {
                        if (cardList[i].Hua == Color.S && countList.Count < 5)
                        {
                            countList.Add(new Card() { Num = cardList[i].Num });
                        }
                    }
                }

            }
            else if (ISSHUNZI)
            {
                cardsType = CardsType.ShunZi;
                for (int i = 4; i >= 0; i--)
                {
                    countList.Add(new Card() { Num = card5[i] });
                }
            }
            else if (Three == 1 && cardSumList.Count == 5)
            {
                cardsType = CardsType.SanTiao;


                foreach (var item in cardSumList)
                {
                    if (item.Sum == 3)
                    {
                        cardSumList.Remove(item);
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        break;
                    }
                }
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 1].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 2].Num });

            }
            else if (Two >= 2)
            {
                cardsType = CardsType.LiangDui;

                for (int i = cardSumList.Count - 1; i >= 0; i--)
                {
                    if (cardSumList[i].Sum == 2 && countList.Count < 4)
                    {
                        countList.Add(new Card() { Num = cardSumList[i].Num });
                        countList.Add(new Card() { Num = cardSumList[i].Num });
                        cardSumList.RemoveAt(i);
                    }
                }
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 1].Num });
            }
            else if (Two == 1 && cardSumList.Count == 6)
            {
                cardsType = CardsType.YiDui;

                foreach (var item in cardSumList)
                {
                    if (item.Sum == 2)
                    {
                        cardSumList.Remove(item);
                        countList.Add(new Card() { Num = item.Num });
                        countList.Add(new Card() { Num = item.Num });
                        break;
                    }
                }
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 1].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 2].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 3].Num });
            }
            else if (cardSumList.Count == 7)
            {
                cardsType = CardsType.GaoPai;
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 1].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 2].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 3].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 4].Num });
                countList.Add(new Card() { Num = cardSumList[cardSumList.Count - 5].Num });
            }

            result = result + (int)cardsType + ".";
            foreach (var item in countList)
            {
                if (item.Num > 9)
                {
                    result = result + item.Num;
                }
                else
                {
                    result = result + "0" + item.Num;
                }
            }


            return Double.Parse(result);
        }
    }
}
