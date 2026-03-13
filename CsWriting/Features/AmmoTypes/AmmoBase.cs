using System;
using CsWriting.Enums;
using CsWriting.Interfaces;

namespace CsWriting.Features.AmmoTypes
{
    public abstract class AmmoBase : IAmmo
    {
        public abstract AmmoType Type { get; } // each inherited class will decide his Type on his own
        public int Amount { get; private set; } = 0;
        public abstract int PackSize { get; }

        public void Add(int amount)
        {
            Amount += amount;
        }

        public void Craft(Inventory inventory)
        {
            if (inventory.ScrapCount <= 0)
            {
                Console.WriteLine($"Not enough scrap to craft an ammo Type of {Type}!");
                return;
            }

            inventory.UseUpScrap(); // -1 scrap
            Amount += PackSize; // + pack size
            Console.WriteLine($"Successfully created an ammo Type of {Type}.");
        }

        public void Disassemble(Inventory inventory)
        {
            if (Amount < PackSize) // example: we have 5 bullets and max is 7, so it will get it.
            {
                Console.WriteLine($"No ammo in inventory '{inventory.Name}' to disassemble!");
                return;
            }

            inventory.PutScrap(); // +1 scrap
            Amount -= PackSize;
            Console.WriteLine($"Successfully disassembled an ammo Type of {Type}.");
        }

        public int Take(int needed) // tells how much to load
        {
            int toLoad = Math.Min(needed, Amount);
            Amount -= toLoad;
            return toLoad;
        }

        public void ShowAmount()
        {
            switch (Amount)
            {
                case 0:
                    Console.WriteLine($"No ammo Type of {Type} in your inventory!");
                    break;
                case 1:
                    Console.WriteLine($"There is only 1 bullet Type of {Type} in your inventory!");
                    break;
                default:
                    Console.WriteLine($"There are {Amount} bullets in your inventory!");
                    break;
            }
        }
    }
}
