using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionMaker : MonoBehaviour
{
    public GameObject samplePrefabExplosion;
    public GameObject playerObj;
    public List<GameObject> allExplosionsObj = new List<GameObject>();
    public GameObject retryText;
    public TextManager textMan;

    public int poolCount = 30;
    public float explosionSpawnDuration;
    float explosionTimer = 0.0f;
    float switchSceneTimer = 0.0f;

    private void Start()
    {
        explosionSpawnDuration = Random.Range(0.5f, 1.5f);
        for (int i =0; i < poolCount; ++i)
        {
            allExplosionsObj.Add(Instantiate(samplePrefabExplosion));
            allExplosionsObj[i].GetComponent<ExplosionObject>().curMaker = this;
            allExplosionsObj[i].SetActive(false);                
        }

    }

    private void SpawnNewExplosion()
    {
        Vector3 randLoc = new Vector3(playerObj.transform.position.x + Random.Range(-30, 30), playerObj.transform.position.y + Random.Range(-15, 15), 0);
        for (int i =0; i < allExplosionsObj.Count; ++i)
        {
            if (!allExplosionsObj[i].activeInHierarchy)
            {
                allExplosionsObj[i].SetActive(true);
                allExplosionsObj[i].transform.position = randLoc;
                break;
            }
        }

    }

    private void Update()
    {
        explosionTimer += Time.deltaTime;
        if (explosionTimer > explosionSpawnDuration)
        {
            SpawnNewExplosion();
            explosionSpawnDuration = Random.Range(0.5f, 1.5f);
            if (retryText.activeInHierarchy)
            {
                retryText.SetActive(false);
            }
            explosionTimer = 0.0f;
        }
        if (textMan.textEnd)
        {
            switchSceneTimer += Time.deltaTime;
            if (switchSceneTimer > 5.0f)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void RestartGame()
    {
        retryText.SetActive(true);
    }


}
