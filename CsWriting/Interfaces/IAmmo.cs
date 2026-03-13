using System;
using CsWriting.Enums;

namespace CsWriting.Interfaces
{
    public interface IAmmo : ICraftable
    {
        public AmmoType Type { get; }
        public int Amount { get; }


        public void Use(IGun gun);
        public void Add(int amount);
        public void ShowAmount();
    }
}
