using System;
using CsWriting.Enums;
using CsWriting.Features.Weapons.Base;

namespace CsWriting.Features.Weapons.Firearms
{
    public class Rifle(FirearmModel model) : FirearmBase(model)
    {
        public override AmmoType AmmoType { get; } = AmmoType.RifleType;

        public override int MagazineCapacity { get; } = 30;

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
