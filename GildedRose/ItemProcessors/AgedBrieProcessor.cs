namespace GildedRoseKata.ItemProcessors
{
    public class AgedBrieProcessor : IItemProcessor
    {
        public void Process(Item item)
        {
            item.SellIn--;

            if (item.Quality < 50)
            {
                item.Quality++;
            }

            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
