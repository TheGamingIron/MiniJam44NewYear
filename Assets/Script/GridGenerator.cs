using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridGenerator : MonoBehaviour
{
    public int gridX, gridY;
    public GameObject gridNode;
    public bool[,] searched;
    public bool[,] wall;
    public List<int> evaluatedGrid = new List<int>();
    List<GameObject> evaluatedObj = new List<GameObject>();

    int startX, startY;
    int customIndexing;
    float customIndexingTimer;
    bool stopDFSRender;
    float speedInc = 1.0f;

    private void Awake()
    {
        startX = startY = 0;
        GenerateGrid();
        DFSGrid(startX, startY);
        Random.seed = 5;
        
    }

    private void Update()
    {
        if (!stopDFSRender)
        {
            if (Input.GetKey(KeyCode.S))
            {
                speedInc += Time.deltaTime * 20.0f;
            }

            customIndexingTimer += Time.deltaTime * speedInc;
            if (customIndexingTimer > 0.5f)
            {
             
                evaluatedObj[evaluatedGrid[customIndexing]].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                customIndexing++;
                customIndexingTimer = 0.0f;
                if (customIndexing > evaluatedGrid.Count - 1)
                {
                    stopDFSRender = true;
                    SceneManager.LoadScene(5);
                }
            }
        }        
    }
    private void GenerateGrid()
    {
        searched = new bool[gridY,gridX];
        wall = new bool[gridY, gridX];
        for (int j = 0; j < gridY; ++j)
        {            
            for (int i = 0; i < gridX; ++i)
            {
                Vector3 newPos = new Vector3(-gridX * 0.5f + i, 0, -gridY * 0.5f + j);
                GameObject curObj = Instantiate(gridNode);
                curObj.transform.position = newPos;
                evaluatedObj.Add(curObj);
                searched[j, i] = false;
                wall[j, i] = (Random.value > 0.9f) ? true : false;
                if (wall[j, i])
                {
                    curObj.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                }
            }
        }
    }

    private void DFSGrid(int x,int y)
    {
        searched[y, x] = true;
        evaluatedGrid.Add(y * gridX + x);
        if (y < gridY - 1)
        {
            if (!searched[y + 1, x] && !wall[y + 1,x])
            {
                DFSGrid(x, y + 1);
            }
        }
        if (y > 0)
        {
            if (!searched[y - 1, x] && !wall[y - 1, x])
            {
                DFSGrid(x, y - 1);
            }
        }

        if (x < gridX - 1)
        {
            if (!searched[y, x + 1] && !wall[y , x + 1])
            {
                DFSGrid(x + 1, y);
            }
        }

        if (x > 0)
        {
            if (!searched[y, x - 1] && !wall[y , x - 1])
            {
                DFSGrid(x - 1, y);
            }
        }

    }




}
