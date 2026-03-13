using System;
using System.Text.Encodings.Web;
using CsWriting.Enums;
using CsWriting.Features.Weapons.Base;
using CsWriting.Interfaces;

namespace CsWriting.Features.AmmoTypes
{
    public abstract class AmmoBase(AmmoType type) : IAmmo
    {
        public AmmoType Type { get; } = type;
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
                Console.WriteLine($"Not enough scrap to craft an ammo type of {type}!");
                return;
            }

            inventory.UseUpScrap(); // -1 scrap
            Amount += PackSize; // + pack size
            Console.WriteLine($"Successfully created an ammo type of {type}.");
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
            Console.WriteLine($"Successfully disassembled an ammo type of {type}.");
        }

        public void ShowAmount()
        {
            switch (Amount)
            {
                case 0:
                    Console.WriteLine($"No ammo type of {type} in your inventory!");
                    break;
                case 1:
                    Console.WriteLine($"There is only 1 bullet type of {type} in your inventory!");
                    break;
                default:
                    Console.WriteLine($"There are {Amount} bullets in your inventory!");
                    break;
            }
        }
    }
}
