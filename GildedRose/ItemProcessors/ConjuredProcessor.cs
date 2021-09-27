namespace GildedRoseKata.ItemProcessors
{
    public class ConjuredProcessor : IItemProcessor
    {
        public void Process(Item item)
        {
            item.SellIn--;

            for (int i = 0; i < 2; i++)
            {
                if (item.Quality > 0)
                    item.Quality--;
            }
        }
    }
}
