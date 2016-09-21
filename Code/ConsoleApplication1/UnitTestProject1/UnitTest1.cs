using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleApplication1.Texas;
using System.Data.SqlClient;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SiTiaoTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=2,Hua=Color.D},
                new Card(){Num=2,Hua=Color.S},
                new Card(){Num=2,Hua=Color.B},
                new Card(){Num=2,Hua=Color.A},
                new Card(){Num=6,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.SiTiao);
            Assert.AreEqual(weight, 8.0202020207);
        }

        [TestMethod]
        public void ManTangHonTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=2,Hua=Color.D},
                new Card(){Num=2,Hua=Color.S},
                new Card(){Num=2,Hua=Color.B},
                new Card(){Num=7,Hua=Color.A},
                new Card(){Num=6,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.ManTangHon);
            Assert.AreEqual(weight, 7.0202020707);
        }

        [TestMethod]
        public void TongHuaTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=6,Hua=Color.D},
                new Card(){Num=2,Hua=Color.S},
                new Card(){Num=9,Hua=Color.B},
                new Card(){Num=2,Hua=Color.B},
                new Card(){Num=11,Hua=Color.B},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.B},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.TongHua);
            Assert.AreEqual(weight, 6.1109070602);
        }

        [TestMethod]
        public void ShunZiTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=2,Hua=Color.D},
                new Card(){Num=3,Hua=Color.S},
                new Card(){Num=4,Hua=Color.B},
                new Card(){Num=5,Hua=Color.A},
                new Card(){Num=6,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.ShunZi);
            Assert.AreEqual(weight, 5.0706050403);
        }

        [TestMethod]
        public void SanTiaoTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=2,Hua=Color.D},
                new Card(){Num=2,Hua=Color.S},
                new Card(){Num=2,Hua=Color.B},
                new Card(){Num=3,Hua=Color.A},
                new Card(){Num=12,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.SanTiao);
            Assert.AreEqual(weight, 4.0202021207);
        }

        [TestMethod]
        public void LiangDuiTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=2,Hua=Color.D},
                new Card(){Num=2,Hua=Color.S},
                new Card(){Num=3,Hua=Color.B},
                new Card(){Num=8,Hua=Color.A},
                new Card(){Num=6,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.LiangDui);
            Assert.AreEqual(weight, 3.0606020208);
        }

        [TestMethod]
        public void YiDuiTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=11,Hua=Color.D},
                new Card(){Num=12,Hua=Color.S},
                new Card(){Num=4,Hua=Color.B},
                new Card(){Num=2,Hua=Color.A},
                new Card(){Num=6,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.YiDui);
            Assert.AreEqual(weight, 2.0606121107);
        }

        [TestMethod]
        public void GaoPaiTest()
        {
            List<Card> cardList = new List<Card>()
            {
                new Card(){Num=2,Hua=Color.D},
                new Card(){Num=12,Hua=Color.S},
                new Card(){Num=11,Hua=Color.B},
                new Card(){Num=3,Hua=Color.A},
                new Card(){Num=4,Hua=Color.S},
                new Card(){Num=7,Hua=Color.B},
                new Card(){Num=6,Hua=Color.D},
            };
            CardsType ct = new CardsType();
            double weight = CardUtil.GetWeight(cardList, out ct);
            Assert.AreEqual(ct, CardsType.GaoPai);
            Assert.AreEqual(weight, 1.1211070604);
        }

        [TestMethod]
        public void TrigerTest()
        {
            using (SqlConnection conn = new SqlConnection(""))
            {
            }
        }
    }
}
