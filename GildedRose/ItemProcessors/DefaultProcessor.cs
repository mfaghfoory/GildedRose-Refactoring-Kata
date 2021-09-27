namespace GildedRoseKata.ItemProcessors
{
    public class DefaultProcessor : IItemProcessor
    {
        public void Process(Item item)
        {
            item.SellIn--;

            if (item.Quality > 0)
            {
                var qualityShouldDecrease = item.SellIn >= 0 ? 1 : 2;
                item.Quality -= qualityShouldDecrease;
            }
        }
    }
}
