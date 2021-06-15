using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        [TestCase(31, 12, 30)]
        [TestCase(32, 8, 30)]
        [TestCase(50, 8, 50)]
        [TestCase(33, 5, 30)]
        [TestCase(50, 5, 50)]
        [TestCase(0, -1, 50)]
        public void assert_backstage_pass_quality(int expected, int sellin, int quality)
        {
            IList<Item> Items = 
                new List<Item>  
                { 
                    new Item 
                    { 
                        Name = "Backstage passes to a TAFKAL80ETC concert", 
                        SellIn = sellin, 
                        Quality = quality 
                    } 
                };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }

        [Test]
        [TestCase(31, 12, 30)]
        [TestCase(50, 12, 50)]
        [TestCase(50, -1, 50)]
        [TestCase(32, -1, 30)]
        public void assert_aged_brie_quality(int expected, int sellin, int quality)
        {
            IList<Item> Items =
                new List<Item>
                {
                    new Item
                    {
                        Name = "Aged Brie",
                        SellIn = sellin,
                        Quality = quality
                    }
                };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }

        [Test]
        [TestCase(80, 1, 80)]
        [TestCase(80, -1, 80)]
        public void assert_sulfuras_quality(int expected, int sellin, int quality)
        {
            IList<Item> Items =
                new List<Item>
                {
                    new Item
                    {
                        Name = "Sulfuras, Hand of Ragnaros",
                        SellIn = sellin,
                        Quality = quality
                    }
                };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }
    }
}
