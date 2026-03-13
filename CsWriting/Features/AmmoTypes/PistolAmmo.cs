using System;
using CsWriting.Enums;

namespace CsWriting.Features.AmmoTypes
{
    public class PistolAmmo : AmmoBase
    {
        public override AmmoType Type { get; } = AmmoType.PistolType;
        public override int PackSize { get; } = 7;
    }
}
