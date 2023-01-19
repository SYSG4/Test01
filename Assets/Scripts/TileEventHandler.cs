using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TileEventHandler : MonoBehaviour
{
    int[,,,] TileUse = new int[2, 4, 4, 6]{
        // A-0,B-0はデバッグ用の盤面
        {
            {
                //A-0
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
            },
            {
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
                {0,0,1,1,1,1},
                {0,0,0,0,1,0},
            },
            {
                {0,0,1,1,1,1},
                {0,0,0,1,1,1},
                {0,1,1,1,1,1},
                {0,0,0,0,1,1},
            },
            {
                {0,0,0,0,0,0},
                {0,0,0,1,1,1},
                {0,1,1,1,1,1},
                {1,1,1,1,1,1},
            },
        },
        {
            {
                // B-0
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
            },
            {
                {0,1,1,1,1,0},
                {1,1,1,1,0,0},
                {1,1,1,1,0,0},
                {1,1,1,1,1,1},
            },
            {
                {1,0,1,1,1,0},
                {1,0,1,1,1,0},
                {1,1,1,1,1,1},
                {1,1,1,1,0,0},
            },
            {
                {1,0,0,0,1,1},
                {1,0,0,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,0},
            },
        }
    };

    [SerializeField] TextMeshProUGUI Stagetext;
    public int type, stage;
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stage += 1;
            if (stage == 4)
            {
                type = 1 - type;
            }
            stage = stage % 4;
            if (type == 0)
                Stagetext.text = $"A-{stage}";
            else
                Stagetext.text = $"B-{stage}";

            TileUpdate();
        }
    }

    private void TileUpdate()
    {
        for (int i = 0; i < TileUse.GetLength(2); i++)
        {
            for (int j = 0; j < TileUse.GetLength(3); j++)
            {
                if (TileUse[type, stage, i, j] == 0)
                {
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.black;
                    GameObject.Find($"Tile{i}{j}").tag = "Nonuse";
                }
                else
                {
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.white;
                    GameObject.Find($"Tile{i}{j}").tag = "Use";
                }
            }
        }
    }

    public void Cleardecision()
    {
        for (int i = 0; i < TileUse.GetLength(2); i++)
        {
            for (int j = 0; j < TileUse.GetLength(3); j++)
            {
                if (GameObject.Find($"Tile{i}{j}").tag == "Use")
                {
                    GameObject.Find("Clearbox").GetComponent<Renderer>().material.color = Color.white;
                    return;
                }
            }
        }
        GameObject.Find("Clearbox").GetComponent<Renderer>().material.color = Color.red;
    }
}

// using UnityEngine.SceneManagement;
// SceneManager.LoadScene (SceneManager.GetActiveScene().name);
