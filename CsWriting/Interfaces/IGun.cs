using CsWriting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsWriting.Interfaces
{
    public interface IGun
    {
        public string Model { get; }
        public AmmoType AmmoType { get; }
        public int CurrentAmmo { get; }
        public int MagazineCapacity { get; }


        public void AddAmmo(int amount);
        public void ShowChamberAmmo();
        public void Shoot();
        public void Reload(IAmmo ammo);
        public void Unload(IAmmo ammo);
    }
}
