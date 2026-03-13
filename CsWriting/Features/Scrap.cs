using System;
using CsWriting.Interfaces;

namespace CsWriting.Features
{
    public class Scrap : IItem
    {
        public Scrap() { }
        public void Pick(Inventory inventory)
        {
            inventory.PutScrap();
        }
    }
}