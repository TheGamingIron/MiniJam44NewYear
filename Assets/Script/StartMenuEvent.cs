using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuEvent : MonoBehaviour
{
    public TextManager curTextManager;
    public GameObject turnoffThis;


    private void Update()
    {
        if (curTextManager.textEnd)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void StartGame()
    {
        curTextManager.ToggleShowText();        
        turnoffThis.SetActive(false);        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    


}
