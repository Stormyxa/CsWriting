using System;
using CsWriting.Enums;

namespace CsWriting.Interfaces
{
    public interface IAmmo : ICraftable
    {
        public AmmoType Type { get; }
        public int Amount { get; set; }
        public int PackSize { get; }


        public void Add(int amount);
        public void ShowAmount();
    }
}
