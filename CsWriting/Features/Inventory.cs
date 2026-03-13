using System;

namespace CsWriting.Features
{
    public class Inventory(string name)
    {
        public string Name { get; } = name;
        public int ScrapCount { get; private set; } = 0;

        public void ShowScrapCount()
        {
            if (ScrapCount == 0)
            {
                Console.WriteLine($"There is no scrap in your '{Name}' inventory.");
            }
            else if (ScrapCount == 1)
            {
                Console.WriteLine($"There is only 1 piece of scrap in your '{Name}' inventory.");
            }
            else
            {
                Console.WriteLine($"There are {ScrapCount} scrap pieces in your '{Name}' inventory.");
            }
        }
        public void PutScrap()
        {
            ScrapCount++;
            Console.WriteLine("Put 1 scrap into your inventory.");
        }
        public void UseUpScrap()
        {
            ScrapCount--;
            Console.WriteLine("Used up 1 scrap from inventory.");
        }
    }
}
