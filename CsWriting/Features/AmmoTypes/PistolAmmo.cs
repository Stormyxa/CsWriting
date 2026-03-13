using System;
using CsWriting.Interfaces;
using CsWriting.Enums;

namespace CsWriting.Features.AmmoTypes
{
    public class PistolAmmo : IAmmo
    {
        public AmmoType Type { get; } = AmmoType.PistolType;
        public int Amount { get; private set; } = 0;


        public void Add(int amount)
        {
            Amount += amount;
        }

        public void Craft(Inventory inventory)
        {
            if (inventory.ScrapCount >= 1)
            {
                Amount += 7;
                inventory.UseUpScrap();
                Console.WriteLine("Successfully crafted 30 bullets!");
            }
            else
            {
                Console.WriteLine("Couldn't craft any ammo. No scrap.");
            }
        }

        public void Disassemble(Inventory inventory)
        {
            inventory.PutScrap();
            Amount -= 7;

            Console.WriteLine("Successfully disassembled your bullet.");
        }

        public void ShowAmount()
        {
            Console.WriteLine($"You have {Amount} ammo in your ammobox.");
        }

        public void Use(IWeapon weapon)
        {
            string weaponModel = (weapon.Model).ToString();

            int currentChamber = weapon.CurrentAmmo;
            int requiredAmmo = weapon.MagazineCapacity - currentChamber;

            if (requiredAmmo == 0)
            {
                Console.WriteLine($"Your {weaponModel}'s ammo chamber is full already!");
                return;
            }

            if (Amount <= 0)
            {
                Console.WriteLine($"No ammo to load into a {weaponModel}.");
            }
            else if (Amount >= 1 && Amount <= weapon.MagazineCapacity) 
            {
                weapon.AddAmmo(Amount);
                Console.WriteLine($"Successfully loaded {Amount} ammo in your {weaponModel}!");

                Amount = 0;
            }
            else if (Amount > weapon.MagazineCapacity)
            {
                weapon.AddAmmo(requiredAmmo);
                Console.WriteLine($"Successfully loaded {requiredAmmo} ammo in your {weaponModel}!");

                Amount -= requiredAmmo;
            }
            else
            {
                Console.WriteLine("ERROR!!! CHECK PUBLIC VOID USE !!!");
                Console.WriteLine($"{Amount}: AMMO IN AMMO STACK");
                Console.WriteLine($"{weapon.CurrentAmmo}: AMMO IN CHAMBER RN");
                Console.WriteLine($"{weapon.MagazineCapacity}: CURRENT MAGAZINE CAPACITY");
            }
        }
    }
}
