using csharp.Inventory;
using csharp.Inventory.Abstract;
using System.Collections.Generic;

namespace csharp
{
    public partial class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public class GoodCategory
        {
            public GeneralItem BuildFor(Item item)
            {
                if (IsSulfuras(item))
                {
                    return new Sulfuras(item.Quality, item.SellIn);

                }
                else if (IsGeneric(item))
                {
                    return new Generic(item.Quality, item.SellIn);

                }
                else if (IsAgedBrie(item))
                {
                    return new AgedBrie(item.Quality, item.SellIn);
                }
                else if (IsBackstagePasses(item))
                {
                    return new BackPass(item.Quality, item.SellIn);
                }

                return new Generic(item.Quality, item.SellIn);
            }

            private bool IsAgedBrie(Item item)
            {
                return item.Name == "Aged Brie";
            }

            private bool IsBackstagePasses(Item item)
            {
                return item.Name == "Backstage passes to a TAFKAL80ETC concert";
            }

            private bool IsSulfuras(Item item)
            {
                return item.Name == "Sulfuras, Hand of Ragnaros";
            }

            private bool IsGeneric(Item item)
            {
                return !(IsAgedBrie(item) || IsBackstagePasses(item) || IsSulfuras(item));
            }
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                var good = new GoodCategory().BuildFor(item);
                good.Update();
                item.SellIn = good.SellIn;
                item.Quality = good.Quality.Amount;
            }
        }
    }
}
