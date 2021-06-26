using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class Generic : GeneralItem
    {
        public Generic(int itemQuality, int sellIn) 
            : base(itemQuality, sellIn) { }
        public override void Update()
        {
            if (Quality.GreaterThan0())
            {
                Quality.Degrade();
            }

            SellIn--;

            if (SellIn < 0)
            {
                if (Quality.GreaterThan0())
                {
                    Quality.Degrade();
                }
            }
        }
    }
}
