namespace GildedRoseKata.ItemProcessors
{
    public class AgedBrieProcessor : IItemProcessor
    {
        public void Process(Item item)
        {
            item.SellIn--;

            if (item.Quality < 50)
            {
                var qualityShouldIncrease = item.SellIn >= 0 ? 1 : 2;
                item.Quality += qualityShouldIncrease;
            }
        }
    }
}
