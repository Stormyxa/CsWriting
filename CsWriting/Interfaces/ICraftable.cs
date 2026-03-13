using System;
using CsWriting.Features;

namespace CsWriting.Interfaces
{
    public interface ICraftable
    {
        public void Craft(Inventory inventory);
        public void Disassemble(Inventory inventory);
    }
}
