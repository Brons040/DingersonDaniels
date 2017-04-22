using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment  {

	public enum EquipmentType
    {
        Head,
        Shoulder,
        Chest,
        Legs,
        Feet,
        Weapon
    }

    public enum Rarity
    {
        Mythic,
        Epic,
        Rare,
        Uncommon,
        Common
    }

    public string name;
    public EquipmentType type;
    public Rarity rarity;
    public Attribute[] attributeMods;

    public Equipment(Attribute[] newMods, EquipmentType newType, Rarity newRarity)
    {
        attributeMods = newMods;
        type = newType;
        rarity = newRarity;
    }

}
