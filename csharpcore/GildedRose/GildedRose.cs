using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];

                if (currentItem.Name != AgedBrie && currentItem.Name != BackstagePass)
                {
                    if (currentItem.Quality > 0)
                    {
                        if (currentItem.Name != Sulfuras)
                        {
                            currentItem.Quality--;
                        }
                    }
                }
                else
                {
                    if (currentItem.Quality < 50)
                    {
                        currentItem.Quality++;

                        if (currentItem.Name == BackstagePass)
                        {
                            if (currentItem.SellIn < 11)
                            {
                                if (currentItem.Quality < 50)
                                {
                                    currentItem.Quality++;
                                }
                            }

                            if (currentItem.SellIn < 6)
                            {
                                if (currentItem.Quality < 50)
                                {
                                    currentItem.Quality++;
                                }
                            }
                        }
                    }
                }

                if (currentItem.Name != Sulfuras)
                {
                    currentItem.SellIn--;
                }

                if (currentItem.SellIn < 0)
                {
                    if (currentItem.Name != AgedBrie)
                    {
                        if (currentItem.Name != BackstagePass)
                        {
                            if (currentItem.Quality > 0)
                            {
                                if (currentItem.Name != Sulfuras)
                                {
                                    currentItem.Quality--;
                                }
                            }
                        }
                        else
                        {
                            currentItem.Quality -= currentItem.Quality;
                        }
                    }
                    else
                    {
                        if (currentItem.Quality < 50)
                        {
                            currentItem.Quality++;
                        }
                    }
                }
            }
        }
    }
}
