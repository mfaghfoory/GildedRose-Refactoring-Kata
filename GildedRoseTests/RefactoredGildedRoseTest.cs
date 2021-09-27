using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests
{
    public class RefactoredGildedRoseTest
    {


        /// <summary>
        /// Testing first four general rules
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quality"></param>
        /// <param name="sellIn"></param>
        /// <param name="expectedQuality"></param>
        [Theory]
        [InlineData("sample title", 10, 0, 8)] //Once the sell by date has passed, Quality degrades twice as fast
        [InlineData("sample title", 0, 10, 0)] //The Quality of an item is never negative
        [InlineData("Aged Brie", 49, 10, 50)] //"Aged Brie" actually increases in Quality the older it gets
        [InlineData("Aged Brie", 50, 10, 50)] //The Quality of an item is never more than 50
        public void Testing_First_Four_Rules(string name, int quality, int sellIn, int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item { Name = name, Quality = quality, SellIn = sellIn }
            };

            var gildedRose = new RefactoredGildedRose(items);
            gildedRose.UpdateQuality();


            Assert.Equal(expectedQuality, items[0].Quality);
        }

        /// <summary>
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        /// </summary>
        [Fact]
        public void Sulfuras_Never_Has_To_Be_Sold_Or_Decreases_In_Quality()
        {
            int quality = 10;
            int sellIn = 10;

            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = quality, SellIn = sellIn }
            };

            var gildedRose = new RefactoredGildedRose(items);
            gildedRose.UpdateQuality();


            Assert.Equal(quality, items[0].Quality);
            Assert.Equal(sellIn, items[0].SellIn);
        }

        /// <summary>
        /// Tests of "Backstage passes"
        /// </summary>
        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 49, 10, 50)] //"Backstage passes", like aged brie, increases in Quality as its SellIn value approaches
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 50, 10, 50)] //The Quality of an item is never more than 50 (base rule)
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 48, 10, 50)] //Quality increases by 2 when there are 10 days or less
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 47, 5, 50)] //Quality increases by 3 when there are 5 days or less
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 50, 0, 0)] //Quality drops to 0 after the concert
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 48, 2, 50)] //Quality should not more than 50
        public void Tests_Of_Backstage(string name, int quality, int sellIn, int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item { Name = name, Quality = quality, SellIn = sellIn }
            };

            var gildedRose = new RefactoredGildedRose(items);
            gildedRose.UpdateQuality();


            Assert.Equal(expectedQuality, items[0].Quality);
        }

        /// <summary>
        /// "Conjured" items degrade in Quality twice as fast as normal items
        /// </summary>
        [Fact]
        public void Conjured_Items_Degrade_In_Quality_Twice_As_Fast_As_Normal_Items()
        {
            var items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", Quality = 10, SellIn = 10 }
            };

            var gildedRose = new RefactoredGildedRose(items);
            gildedRose.UpdateQuality();


            Assert.Equal(8, items[0].Quality);
        }
    }
}
