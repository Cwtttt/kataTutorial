using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class BackPass : GeneralItem
    {
        public BackPass(int itemQuality, int sellIn) 
            : base(itemQuality, sellIn) { }
        public override void Update()
        {
            if (Quality.LessThan50())
            {
                Quality.Increase();
                if (SellIn < 11 && Quality.LessThan50())
                {
                    Quality.Increase();
                }

                if (SellIn < 6 && Quality.LessThan50())
                {
                    Quality.Increase();
                }
            }

            SellIn--;

            if (SellIn < 0)
            {
                Quality.Reset();
            }
        }
    }
}
