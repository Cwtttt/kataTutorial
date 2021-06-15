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
                if (IsAgedBrie(Items[i]) || IsBackstagePasses(Items[i]))
                {
                    if (QualityLessThan50(Items[i]))
                    {
                        IncreaseQuality(Items[i]);

                        if (IsBackstagePasses(Items[i]))
                        {
                            if (Items[i].SellIn < 11 && Items[i].Quality < 50)
                            {
                                IncreaseQuality(Items[i]);
                            }

                            if (Items[i].SellIn < 6 && Items[i].Quality < 50)
                            {
                                IncreaseQuality(Items[i]);
                            }
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality > 0)
                    {
                        if (!IsSulfuras(Items[i]))
                        {
                            DecreaseQuality(Items[i]);
                        }
                    }
                }

                if (!IsSulfuras(Items[i]))
                {
                    DecreaseSellIn(Items[i]);
                }

                if (Items[i].SellIn < 0)
                {
                    if (IsAgedBrie(Items[i]))
                    {
                        if (QualityLessThan50(Items[i]))
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                    else if (IsBackstagePasses(Items[i]))
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                    else
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (!IsSulfuras(Items[i]))
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
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
    }
}
