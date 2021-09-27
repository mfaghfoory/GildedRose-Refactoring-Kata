namespace GildedRoseKata.ItemProcessors
{
    public class ConjuredProcessor : IItemProcessor
    {
        public void Process(Item item)
        {
            item.SellIn--;

            if (item.Quality > 0)
                item.Quality -= 2;
        }
    }
}
