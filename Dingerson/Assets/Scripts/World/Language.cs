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
            chArray[i] = char.ConvertFromUtf32(Random.Range(97, 122))[0];
        }
        Debug.Log(new string(chArray) + " from " + word);
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
        Debug.Log(sentence);
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
}
