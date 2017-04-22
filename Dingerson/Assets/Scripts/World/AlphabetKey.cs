using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlphabetKey {

    public char alphaKey;
    public char[] allowedFollowKeys;

    public AlphabetKey(char key, char[] allowedKeys)
    {
        alphaKey = key;
        allowedFollowKeys = allowedKeys;
    }

}
