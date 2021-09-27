namespace GildedRoseKata.ItemProcessors
{
    public static class ItemProcessorFactory
    {
        public static IItemProcessor GetProcessor(string name)
        {
            return name switch
            {
                "Aged Brie" => new AgedBrieProcessor(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasProcessor(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstageProcessor(),
                "Conjured Mana Cake" => new ConjuredProcessor(),
                _ => new DefaultProcessor()
            };
        }
    }
}
