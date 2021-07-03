namespace csharp.Inventory.Abstract
{
    public abstract class GeneralItem
    {
        public Quality Quality{ get; internal set; }
        public GeneralItem(int itemQuality)
        {
            Quality = new Quality(itemQuality);
        }
        public abstract void Update(int sellIn);
    }
}
