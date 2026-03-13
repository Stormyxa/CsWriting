using System;
using CsWriting.Interfaces;
using CsWriting.Enums;
using CsWriting.Features.Weapons.Base;

namespace CsWriting.Features.Weapons.Firearms
{
    public class Pistol(FirearmModel model) : FirearmBase(model)
    {
        public override AmmoType AmmoType { get; } = AmmoType.PistolType;

        public override int MagazineCapacity { get; } = 7;
    }
}
