using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileEventHandler : MonoBehaviour
{
    int[,,] TileUse = new int[4, 4, 4]{
        {
            {1,1,1,1},
            {1,1,1,1},
            {1,1,1,1},
            {1,1,1,1},
        },
        {
            {0,1,1,0},
            {1,1,1,1},
            {1,1,1,1},
            {0,1,1,0},
        },
        {
            {0,1,1,0},
            {0,1,1,0},
            {0,1,1,0},
            {0,1,1,0},
        },
        {
            {1,0,0,1},
            {1,0,0,1},
            {1,0,0,1},
            {1,0,0,1},
        },
    };

    int[,] TileActive = new int[4, 4];

    public int stage;
    void Start()
    {

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            stage = (stage += 1) % 4;
            TileUpdate();
        }
    }

    private void TileUpdate(){
        for (int i = 0; i < TileUse.GetLength(1); i++)
            {
                for (int j = 0; j < TileUse.GetLength(1); j++)
                {
                    if(TileUse[stage,i,j] == 0){
                        GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.black;
                        GameObject.Find($"Tile{i}{j}").tag = "Inactive";
                    }else{
                        GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.white;
                        GameObject.Find($"Tile{i}{j}").tag = "Active";
                    }
                }
            }
    }
}

// using UnityEngine.SceneManagement;
// SceneManager.LoadScene (SceneManager.GetActiveScene().name);
