using System;
using CsWriting.Features;
using CsWriting.Features.Guns;
using CsWriting.Features.AmmoTypes;

namespace CsWriting;

public class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory("MyInventory");
        Rifle rifle = new Rifle("M4A1", 30, false); // I wanted to create a BaseGun and then rifle, but messed it up, so had to change base to rifle

        Scrap scrap1 = new Scrap();
        Scrap scrap2 = new Scrap();
        Scrap scrap3 = new Scrap();

        RifleAmmo rifleAmmo = new RifleAmmo();

        rifle.Reload(rifleAmmo); // can't here, no ammo

        rifleAmmo.Craft(inventory); // can't here, no scrap

        Console.WriteLine(); // skip for more explicit check

        scrap1.Pick(inventory);
        scrap2.Pick(inventory);
        scrap3.Pick(inventory); // got scrap

        rifleAmmo.Craft(inventory);
        rifleAmmo.Craft(inventory); // should work here
        rifleAmmo.Craft(inventory);

        rifleAmmo.ShowAmount(); // should have 90 ammo in rifleAmmo

        rifle.Reload(rifleAmmo); // should work here

        rifle.Reload(rifleAmmo); // already full, what will we get?
        rifle.ShowChamberAmmo(); // should be 30, right?

        Console.WriteLine();
        rifle.Shoot(); // pew! -1 bullet

        Console.WriteLine();
        rifle.ShowChamberAmmo(); // should be 29

        Console.WriteLine();
        rifleAmmo.ShowAmount(); // should be 60, bc we took away 30, but the shoot action shouldn't affect it

        Console.WriteLine();
        rifle.Unload(rifleAmmo); // unload 29 bullets, so we will have 60+29 = 89 bullets in rifleAmmo

        Console.WriteLine();
        rifleAmmo.ShowAmount(); // should be 89
        rifle.ShowChamberAmmo(); // should be 0

        Console.WriteLine();
        inventory.ShowScrapCount(); // i should have 0
        // "There are 3 scrap pieces in your 'MyInventory' inventory."
        // How? I crafted 90 bullets out of 3, let's see...
        // TIME TO FIX IT! ( addition: it's amazing
        // firstly I was only checking it logically as I see it and wrote comments
        // came after 2 hours to debug and now I just compare
        // the desired result and what I created
        // it's one of the main ideas?


        rifleAmmo.Disassemble(inventory); // disassemble 1 ammo
        inventory.ShowScrapCount(); // i should have only 1 scrap piece
        rifleAmmo.ShowAmount(); // i should i have 89 - 30 = 59 bullets

        Console.WriteLine();
        rifle.Shoot(); // no ammo to shoot
        rifle.Reload(rifleAmmo); // reloaded
        rifle.MagDump(); // less go!

        Console.WriteLine();
        rifle.ShowChamberAmmo(); // should be 0
        rifleAmmo.ShowAmount(); // should be 59
        // logical error in my previous notes here
        // why 59? we reloaded! meaning 59 - 30 = 29. Great!

        Pistol pistol = new Pistol("Glock17");
        pistol.Reload(rifleAmmo);
        rifle.Reload(rifleAmmo);
    }
}