using System;
using CsWriting.Interfaces;
using CsWriting.Enums;

namespace CsWriting.Features.AmmoTypes
{
    public class RifleAmmo : IAmmo
    {
        public AmmoType Type { get; } = AmmoType.RifleType;
        public int Amount { get; private set; } = 0;

        public void ShowAmount()
        {
            Console.WriteLine($"You have {Amount} ammo in your ammobox.");
        }

        public void Add(int amount)
        {
            Amount += amount;
        }

        public void Craft(Inventory inventory)
        {
            if (inventory.ScrapCount >= 1)
            {
                Amount += 30;
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
            Amount -= 30;

            Console.WriteLine("Successfully disassembled your bullet.");
        }

        public void Use(IGun weapon)
        {
            string weaponModel = weapon.Model; // let's store the weapon model here

            int currentChamber = weapon.CurrentAmmo; // let's store the current amount of ammo in chamber here
            int requiredAmmo = weapon.MagazineCapacity - currentChamber; // let's see how many ammo do we need to load in order to get full mag
                                                                         // I have already messed up on BaseGun ( rifle now ).

            if (requiredAmmo == 0) // full already check! // DEBUGGED: IF WE HAVE 0 AMMO IT WILL SAY SAME AS WE HAVE
                                   // 30 - 0 = 30 AND 30 = 30 => WE GET THAT ONE
                                   // WE NEED THAT ONLY WHEN WE HAVE REQUIRED AMMO == 30, BC IF WE HAVE 30
                                   // 30 - 30 = 0, HERE WAS THE LOGICAL ERROR
                                   // if (requiredAmmo == weapon.GetMagazineCapacity()) FIXING THAT
                                   // if we DONT need anything, it means we have required ammo 0, bc we would have full mag
            {
                Console.WriteLine($"Your {weaponModel}'s ammo chamber is full already!");
                return; // WE DON'T NEED TO SAY THAT WE ADDED 0 BULLETS
            }

            if (Amount <= 0) // no ammo // we start from the LOWEST!!! so every check should be taken until the desired result
            {
                Console.WriteLine($"No ammo to load into a {weaponModel}.");
            }
            else if (Amount >= 1 && Amount <= weapon.MagazineCapacity) // we have less or equal to the capacity, so we will add Amount and set to 0
            {
                weapon.AddAmmo(Amount);
                Console.WriteLine($"Successfully loaded {Amount} ammo in your {weaponModel}!");

                Amount = 0;
            }
            else if (Amount > weapon.MagazineCapacity)
            {
                weapon.AddAmmo(requiredAmmo); // get's as much as possible, bc we have more than the capacity
                Console.WriteLine($"Successfully loaded {requiredAmmo} ammo in your {weaponModel}!");

                Amount -= requiredAmmo;
            }
            else // if something goes wrong...
            {
                Console.WriteLine("ERROR!!! CHECK PUBLIC VOID USE !!!");
                Console.WriteLine($"{Amount}: AMMO IN AMMO STACK");
                Console.WriteLine($"{weapon.CurrentAmmo}: AMMO IN CHAMBER RN");
                Console.WriteLine($"{weapon.MagazineCapacity}: CURRENT MAGAZINE CAPACITY");
            }
        }

    }
}
