using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class BackPass : GeneralItem
    {
        public BackPass(int itemQuality) 
            : base(itemQuality) { }
        public override void Update(int sellIn)
        {
            if (Quality.LessThan50())
            {
                Quality.Increase();
                if (sellIn < 10 && Quality.LessThan50())
                {
                    Quality.Increase();
                }

                if (sellIn < 5 && Quality.LessThan50())
                {
                    Quality.Increase();
                }
            }

            if (sellIn < 0)
            {
                Quality.Reset();
            }
        }
    }
}
