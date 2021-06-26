using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class AgedBrie : GeneralItem
    {
        public AgedBrie(int itemQuality, int sellIn) 
            : base(itemQuality, sellIn) { }

        public override void Update()
        {
            if (Quality.LessThan50())
            {
                Quality.Increase();
            }

            SellIn--;

            if (SellIn < 0)
            {
                if (Quality.LessThan50())
                {
                    Quality.Increase();
                }
            }
        }
    }
}
