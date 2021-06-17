 using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (IsSulfuras(Items[i]))
                {
                }
                else if (IsGeneric(Items[i]))
                {
                    HandleGeneric(Items[i]);
                }
                else if (IsAgedBrie(Items[i]))
                {
                    HandleAgedBrie(Items[i]);
                }
                else if (IsBackstagePasses(Items[i]))
                {
                    HandleBackPassQuality(Items[i]);
                }
            }
        }
       

        private void DecreaseQuality(Item item)
        {
            item.Quality--;
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality++;
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        private bool QualityLessThan50(Item item)
        {
            return item.Quality < 50;
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
        private void HandleGeneric(Item item)
        {
            if (item.Quality > 0)
            {
                DecreaseQuality(item);
            }

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    DecreaseQuality(item);
                }
            }
        }

        private void HandleBackPassQuality(Item item)
        {
            if (QualityLessThan50(item))
            {
                IncreaseQuality(item);
                if (item.SellIn < 11 && item.Quality < 50)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 6 && item.Quality < 50)
                {
                    IncreaseQuality(item);
                }
            }

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private void HandleAgedBrie(Item item)
        {
            if (QualityLessThan50(item))
            {
                IncreaseQuality(item);
            }

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                if (QualityLessThan50(item))
                {
                    IncreaseQuality(item);
                }
            }
        }
    }
}
