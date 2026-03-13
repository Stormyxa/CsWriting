using CsWriting.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsWriting.Interfaces
{
    public interface ICraftable
    {
        public void Craft(Inventory inventory);
        public void Disassemble(Inventory inventory);
    }
}
