using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TileEventHandler : MonoBehaviour
{
    int[,,,] TileUse = new int[2,4,4,6]{
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
    [SerializeField] TextMeshProUGUI Timer;

    GameObject[] Pieces;
    double time;
    bool stop = false;
    public int type, stage;
    void Start()
    {
        time = 0;
        Pieces = GameObject.FindGameObjectsWithTag("Piece");
    }
    private void Update()
    {
        if(stop == false)
            time += Time.deltaTime;
            Timer.text = time.ToString("0:00.00");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            time = 0;
            stop = false;
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
            for(int i = 0; i < Pieces.GetLength(0); i++){
                Pieces[i].GetComponent<PositionReset>().Reset();
                Pieces[i].GetComponent<DropParent>().Settarget();
                Pieces[i].GetComponent<ShapeSizeHandler>().OnMouseDrag();
            }
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
        stop = true;
        GameObject.Find("Clearbox").GetComponent<Renderer>().material.color = Color.red;
    }
}

// using UnityEngine.SceneManagement;
// SceneManager.LoadScene (SceneManager.GetActiveScene().name);
