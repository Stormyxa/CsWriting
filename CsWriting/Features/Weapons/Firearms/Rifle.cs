using System;
using CsWriting.Enums;
using CsWriting.Enums.FirearmModels;
using CsWriting.Features.Weapons.Base;

namespace CsWriting.Features.Weapons.Firearms
{
    public class Rifle(RifleModel rifleModel) : FirearmBase<RifleModel>(rifleModel)
    {
        public override AmmoType AmmoType { get; } = AmmoType.RifleType;

        public override int MagazineCapacity { get; } = 30;

        public void MagDump()
        {
            while (base.CurrentAmmo >= 1)
            {
                base.Shoot();
            }
            Console.WriteLine("Mag dumped everything! Out of ammo.");
        }
    }
}
