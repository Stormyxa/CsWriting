using System;
using CsWriting.Enums;
using CsWriting.Interfaces;

namespace CsWriting.Features.Weapons.Base
{
    public abstract class FirearmBase(FirearmModel model) : IWeapon
    {
        public FirearmModel Model { get; } = model; // for now we DECIDE the model, okey
        public abstract AmmoType AmmoType { get; }
        public abstract int MagazineCapacity { get; }

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
    }
}
