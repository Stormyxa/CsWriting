using System;
using CsWriting.Enums;
using CsWriting.Enums.FirearmModels;
using CsWriting.Features.Weapons.Base;

namespace CsWriting.Features.Weapons.Firearms
{
    public class Pistol(PistolModel model) : FirearmBase<PistolModel>(model)
    {
        public override AmmoType AmmoType { get; } = AmmoType.PistolType;

        public override int MagazineCapacity { get; } = 7;
    }
}
