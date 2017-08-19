using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language {

    public Dictionary<string, string> languageDictionary = new Dictionary<string, string>();
    public AlphabetCollection ac;

    public string RandomizeWord(string word)
    {
        char[] chArray = word.ToCharArray();
        for (int i = 0; i < chArray.Length; i++)
        {
            if (i == 0)
            {
                chArray[i] = char.ConvertFromUtf32(Random.Range(97, 122))[0];                
            }
            else
            {
                char[] allowedKeys = ac.FindAlphabetKeyByCharacter(chArray[i-1]).allowedFollowKeys;  
                //Add handling for double letter, triple vowel, and other edge cases to form more fluid random words.              
                chArray[i] = allowedKeys[Random.Range(0, allowedKeys.Length)];
            }
        }        
        AddTranslation(word, new string(chArray));
        return new string(chArray);
    }

    public string RandomizeSentence(string sentence)
    {
        string[] words = sentence.Split(null);
        sentence = "";
        for(int i = 0; i < words.Length; i++)
        {
            if(!languageDictionary.ContainsKey(words[i]))
                words[i] = RandomizeWord(words[i]);
            else
            {
                words[i] = languageDictionary[words[i]];
            }
            if (i != words.Length - 1)
                sentence += words[i] + " ";
            else
                sentence += words[i];       
        }       
        PrintDictionary();
        return sentence;
    }

    public bool AddTranslation(string key, string pair)
    {
        if (!languageDictionary.ContainsKey(key))
        {
            languageDictionary.Add(key, pair);
            return true;
        }
        return false;
    }

    public void PrintAlphabet()
    {
        Debug.Log(ac.alphabetKeys.Length);
    }

    public void PrintDictionary()
    {
        foreach(string key in languageDictionary.Keys)
        {
            Debug.Log(key + " " + languageDictionary[key]);
        }       
    }
}
