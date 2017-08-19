using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlphabetCollection {

    public AlphabetKey[] alphabetKeys;

    public AlphabetKey FindAlphabetKeyByCharacter(char c)
    {
        foreach(AlphabetKey ak in alphabetKeys)
        {
            if (ak.alphaKey == c)
                return ak;
        }
        return null;
    } 

}
