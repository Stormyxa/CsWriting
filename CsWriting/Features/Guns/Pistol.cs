using System;
using CsWriting.Interfaces;
using CsWriting.Enums;

namespace CsWriting.Features.Guns
{
    public class Pistol(string model) : IGun
    {
        public string Model { get; } = model;
        public AmmoType AmmoType { get; } = AmmoType.PistolType;

        public int CurrentAmmo { get; private set; } = 0;

        public int MagazineCapacity { get; } = 7;

        public void AddAmmo(int amount)
        {
            CurrentAmmo += amount;

            if (CurrentAmmo > MagazineCapacity)
            {
                Console.WriteLine("ERROR!!! CHECK PUBLIC VOID ADDAMMO!!!");
            }
        }

        public void Reload(IAmmo ammo)
        {
            if (ammo.Type == AmmoType.PistolType)
            {
                ammo.Use(this);
            }
            else
            {
                Console.WriteLine($"Wrong ammo type. Required type: {AmmoType}");
            }
        }

        public void Shoot()
        {
            if (CurrentAmmo >= 1)
            {
                CurrentAmmo--;
                Console.WriteLine("Pew!");
            }
            else
            {
                Console.WriteLine("Out of ammo. Reload your gun!");
            }
        }

        public void ShowChamberAmmo()
        {
            Console.WriteLine($"Your {Model} has {CurrentAmmo} bullets chambered in at the moment.");
        }

        public void Unload(IAmmo ammo)
        {
            ammo.Add(CurrentAmmo);
            CurrentAmmo = 0;
        }
    }
}
