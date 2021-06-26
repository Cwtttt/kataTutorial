namespace csharp.Inventory.Abstract
{
    public abstract class GeneralItem
    {
        public int SellIn { get; internal set; }
        public Quality Quality{ get; internal set; }
        public GeneralItem(int itemQuality, int sellIn)
        {
            SellIn = sellIn;
            Quality = new Quality(itemQuality);
        }
        public abstract void Update();
    }
}
