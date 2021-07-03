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
                if (IsGeneric(item))
                {
                    return new Generic(item.Quality);

                }
                else if (IsAgedBrie(item))
                {
                    return new AgedBrie(item.Quality);
                }
                else if (IsBackstagePasses(item))
                {
                    return new BackPass(item.Quality);
                }

                return new Generic(item.Quality);
            }

            private bool IsAgedBrie(Item item)
            {
                return item.Name == "Aged Brie";
            }

            private bool IsBackstagePasses(Item item)
            {
                return item.Name == "Backstage passes to a TAFKAL80ETC concert";
            }

            private bool IsGeneric(Item item)
            {
                return !(IsAgedBrie(item) || IsBackstagePasses(item));
            }
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                if (IsSulfuras(item)) continue;
                item.SellIn--;
                var good = new GoodCategory().BuildFor(item);
                good.Update(item.SellIn);
                item.Quality = good.Quality.Amount;
            }
        }

        private bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
