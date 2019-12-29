using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RythmManager : MonoBehaviour
{
    public GameObject[] allPoint;
    public GameObject[] allPointNote;
    public float score;
    public Text scoreText,comboText;
    int combo;
    float rythmTime;
    int curIndex;
    public List<float> allNoteRhythm = new List<float>();

    private void Awake()
    {
        for (int i = 0; i < 100; ++i)
        {
            allNoteRhythm.Add(Random.Range(0.5f, 1.5f));
        }
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        if (Time.time - rythmTime > allNoteRhythm[curIndex])
        {
            rythmTime = Time.time;
            int curStrip = Random.Range(0, 3);
            Instantiate(allPoint[curStrip]);
        }
        

    }

    public void IncrementScore()
    {
        combo++;
        score += 15.0f + (combo * Random.Range(2.0f,5.0f));
        if (score >= 2020.0f)
        {
            SceneManager.LoadScene(6);
        }
    }

}
