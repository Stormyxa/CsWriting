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
            if (ammo.Type != AmmoType) // maybe change ammotype to requiredammotype? or what?
            {
                Console.WriteLine($"Wrong ammo type for {Model}! Required: {AmmoType}!");
            }
            int requiredAmmo = MagazineCapacity - CurrentAmmo;
            if (requiredAmmo == 0)
            {
                Console.WriteLine($"Your {Model} is loaded already!");
                return;
            }

            int toLoad = Math.Min(requiredAmmo, MagazineCapacity);
            CurrentAmmo += toLoad; //TODO
            // change ammo use, gun now handles reload logic of itself, i wannt use the private set here :)
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