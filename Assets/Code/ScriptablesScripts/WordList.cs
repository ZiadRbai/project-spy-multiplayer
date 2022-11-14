using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName = "Scriptables/Word List")]
public class WordList : ScriptableObject
{
    [SerializeField][TextArea(0, 50)]
    [Tooltip("Please use the following format : \n word1, word2, word3 etc... ")]
    string words;


    string customWords = "";

    public string GetRandomWord()
    {
        List<string> wordlist = StringToList(words).Concat(StringToList(customWords)).ToList();

        return wordlist[Random.Range(0,wordlist.Count)];
    }

    private List<string> StringToList(string str)
    {
        return str.Split(", ").ToList();
    }
}
