using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropParent : MonoBehaviour
{
    public GameObject[] child;
    public static Vector3[,] tilepos = new Vector3[3, 3];
    // 配列で格納 Childs[変数] で呼び出す
    int[][] target = new int[4][]{
        null,
        new int[2],
        new int[2],
        new int[2],
    };

    void Start()
    {
        for (int i = 0; i < tilepos.GetLength(0); i++)
        {
            for (int j = 0; j < tilepos.GetLength(1); j++)
            {
                tilepos[i, j] = GameObject.Find($"Tile{i}{j}").transform.position;
            }
        }
    }

    void OnMouseDrag()
    {
        float nx, ny;
        int flagx, flagy;
        nx = transform.position.x;
        ny = transform.position.y;

        target[1] = child[0].GetComponent<DropChild>().ParentDrag();
        target[2] = child[1].GetComponent<DropChild>().ParentDrag();
        target[3] = child[2].GetComponent<DropChild>().ParentDrag();

        for (int i = 0; i < tilepos.GetLength(0); i++)
        {
            for (int j = 0; j < tilepos.GetLength(1); j++)
            {
                flagx = (int)((tilepos[i, j].x - nx) / 1.5);
                flagy = (int)((tilepos[i, j].y - ny) / 1.5);

                if (flagx == 0 && flagy == 0)
                {
                    target[0] = new int[2] { i, j };
                }
                else
                {
                    target[0] = null;
                }

                for (int k = 0; k < 4; i++)
                {
                    Debug.Log($"Target{i}:{target[i]}");
                    if (target[k] != null)
                    {
                        GameObject.Find($"Tile{target[i][0]}{target[i][1]}").GetComponent<Renderer>().material.color = Color.red;
                    }
                    else
                    {
                        // GameObject.Find($"").GetComponent<Renderer>().material.color = Color.white;
                    }
                }
            }
        }

    }
}
