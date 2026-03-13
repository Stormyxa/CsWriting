using System;
using CsWriting.Interfaces;
using CsWriting.Enums;

namespace CsWriting.Features.Guns
{
    public class Rifle(string model, int magazineCapacity, bool hasFlashlight) : IGun
    {
        public string Model { get; } = model;
        public AmmoType AmmoType { get; } = AmmoType.RifleType;
        public int MagazineCapacity { get; } = magazineCapacity;
        public bool HasFlashlight { get; } = hasFlashlight;

        public int CurrentAmmo { get; private set; } = 0;

        public void ShowChamberAmmo()
        {
            Console.WriteLine($"Your {Model} has {CurrentAmmo} bullets chambered in at the moment.");
        }

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
            ammo.Use(this);
        }

        public void Unload(IAmmo ammo)
        {
            ammo.Add(CurrentAmmo);
            CurrentAmmo = 0;
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

        public void MagDump()
        {
            while (CurrentAmmo >= 1)
            {
                Shoot();
            }
            Console.WriteLine("Mag dumped everything! Out of ammo.");
        }
    }
}
