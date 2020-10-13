using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentRarity { Common, Uncommon, Rare, VeryRare, Legendary, Artifact }
public enum EquipmentSlot { Head, Chest, Belt, Gloves, Boots, Ring, Necklace }

[System.Serializable]
public class Equipment
{
    public string Name = "Item";
    public int Value = 0;
    public EquipmentRarity Rarity = EquipmentRarity.Uncommon;
    public EquipmentSlot Slot = EquipmentSlot.Ring;

    public Equipment()
    {

    }
    public Equipment(string n, int v, EquipmentRarity r, EquipmentSlot s)
    {
        Name = n;
        Value = v;
        Rarity = r;
        Slot = s;
    }
    public Equipment(Equipment old)
    {
        Name = old.Name;
        Value = old.Value;
        Rarity = old.Rarity;
        Slot = old.Slot;
    }
}