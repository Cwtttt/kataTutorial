using csharp.Inventory.Abstract;

namespace csharp.Inventory
{
    public class Sulfuras : GeneralItem
    {
        public Sulfuras(int itemQuality, int sellIn) 
            : base(itemQuality, sellIn) { }
        public override void Update()
        {

        }
    }
}
