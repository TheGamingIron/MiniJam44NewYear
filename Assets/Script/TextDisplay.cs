using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class TextDisplay 
{
    public Text textObject;
    public string textToDisplay;
    public float textSpeed;
    public bool skippableText;
    public bool turnOffTextDone;
    public float textEndDuration;
    public int curTextIndex;
    
    public TextDisplay(Text _textObj,string strText,float speed,bool skippable)
    {
        textObject = _textObj;
        textToDisplay = strText;
        textSpeed = speed;
        skippableText = skippable;
        curTextIndex = 0;
        turnOffTextDone = true;
    }

    

}
