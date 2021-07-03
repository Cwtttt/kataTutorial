using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class AgedBrie : GeneralItem
    {
        public AgedBrie(int itemQuality) 
            : base(itemQuality) { }

        public override void Update(int sellIn)
        {
            if (Quality.LessThan50())
            {
                Quality.Increase();
            }

            if (sellIn < 0)
            {
                if (Quality.LessThan50())
                {
                    Quality.Increase();
                }
            }
        }
    }
}
