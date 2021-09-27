using GildedRoseKata.ItemProcessors;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class RefactoredGildedRose
    {
        IList<Item> Items;
        public RefactoredGildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var processor = ItemProcessorFactory.GetProcessor(item.Name);
                processor.Process(item);
            }
        }
    }
}
