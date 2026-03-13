using System;
using CsWriting.Enums;

namespace CsWriting.Features.AmmoTypes
{
    public class RifleAmmo : AmmoBase
    {
        public override AmmoType Type { get; } = AmmoType.RifleType;
        public override int PackSize { get; } = 30;
    }
}
