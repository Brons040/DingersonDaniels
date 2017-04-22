using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute {

	public enum AttributeType
    {
        Strength,
        Intelligence,
        Dexterity,
        Fortitude,
        Default
    }

    public AttributeType type;
    public int amount;

    public Attribute(AttributeType newType, int newAmount)
    {
        type = newType;
        amount = newAmount;
    }

}
