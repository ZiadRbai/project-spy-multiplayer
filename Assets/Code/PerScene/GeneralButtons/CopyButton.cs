using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CopyButton : MonoBehaviour, IButton
{
    [SerializeField] private TMP_Text textToCopy;
    public void OnClick()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = textToCopy.text;
        textEditor.SelectAll();
        textEditor.Copy();
    }
}
