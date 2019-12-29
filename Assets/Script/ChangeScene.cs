using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public float timeToChange;
    public int nextScene;

    private void Start()
    {
        StartCoroutine(ChangeNextScene());
    }

    IEnumerator ChangeNextScene()
    {
        yield return new WaitForSeconds(timeToChange);
        SceneManager.LoadScene(nextScene);
        
    }
}
