using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class Generic : GeneralItem
    {
        public Generic(int itemQuality) 
            : base(itemQuality) { }
        public override void Update(int sellIn)
        {
            if (Quality.GreaterThan0())
            {
                Quality.Degrade();
            }

            if (sellIn < 0)
            {
                if (Quality.GreaterThan0())
                {
                    Quality.Degrade();
                }
            }
        }
    }
}
