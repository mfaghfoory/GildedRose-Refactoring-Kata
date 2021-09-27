namespace GildedRoseKata.ItemProcessors
{
    public class DefaultProcessor : IItemProcessor
    {
        public void Process(Item item)
        {
            item.SellIn--;

            var iteration = item.SellIn >= 0 ? 1 : 2;

            for (int i = 0; i < iteration; i++)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }
    }
}
