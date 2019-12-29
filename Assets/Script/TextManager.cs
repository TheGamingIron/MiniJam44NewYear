using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public List<TextDisplay> allText = new List<TextDisplay>();
    public bool showText = false;
    public bool textEnd = false;

    float curTextTimer,textDelayTimer;
    int curTextIndex = 0;
    bool moveNextText = false;


    public void Start()
    {
        
    }

    public void ToggleShowText()
    {
        showText = !showText;
    }

    private void Update()
    {
        if (showText)
        {
            if (!moveNextText)
            {
                if (!allText[curTextIndex].textObject.gameObject.activeInHierarchy)
                {
                    allText[curTextIndex].textObject.gameObject.SetActive(true);
                }

                if ((Time.time - curTextTimer) > allText[curTextIndex].textSpeed)
                {
                    allText[curTextIndex].textObject.text += allText[curTextIndex].textToDisplay[allText[curTextIndex].curTextIndex];
                    curTextTimer = Time.time;
                    allText[curTextIndex].curTextIndex++;
                    if (allText[curTextIndex].curTextIndex > allText[curTextIndex].textToDisplay.Length - 1)
                    {
                        moveNextText = true;

                    }
                }
            }
            else
            {
                textDelayTimer += Time.deltaTime;
                if (textDelayTimer > allText[curTextIndex].textEndDuration)
                {
                    textDelayTimer = 0.0f;
                    if (allText[curTextIndex].turnOffTextDone)
                    {
                        allText[curTextIndex].textObject.gameObject.SetActive(false);
                    }
                    curTextIndex++;                    
                    if (curTextIndex > allText.Count - 1)
                    {
                        showText = false;
                        textEnd = true;

                    }
                    moveNextText = false;
                }
            }
            
        }
    }



}
