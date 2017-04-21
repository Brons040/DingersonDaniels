using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource {

    public ResourceType type;
    public int amount;

    public Resource(ResourceType newType, int newAmount)
    {
        type = newType;
        this.amount = newAmount;
    }
	
}
