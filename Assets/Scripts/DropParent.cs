using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropParent : MonoBehaviour
{
    public GameObject[] child;
    public Vector3[,] tilepos = new Vector3[3, 3];
    // 配列で格納 Childs[変数] で呼び出す
    string[] target;
    void Start()
    {
        target = Enumerable.Repeat("Null",child.GetLength(0) + 1).ToArray();

        for (int i = 0; i < tilepos.GetLength(0); i++)
        {
            for (int j = 0; j < tilepos.GetLength(1); j++)
            {
                tilepos[i, j] = GameObject.Find($"Tile{i}{j}").transform.position;
            }
        }
    }

    void Settarget(){
        target = Enumerable.Repeat("Null",child.GetLength(0) + 1).ToArray();
        for(int i = 0; i < child.GetLength(0); i ++){
            child[i].GetComponent<DropChild>().ParentDrag(out int ti, out int tj);
            target[i+1] = $"Tile{ti}{tj}";
        }
    }

    public void OnMouseDrag()
    {
        float nx, ny;
        int flagx, flagy;
        nx = transform.position.x;
        ny = transform.position.y;


        Settarget();
        for (int i = 0; i < tilepos.GetLength(0); i++)
        {
            for (int j = 0; j < tilepos.GetLength(1); j++)
            {
                flagx = (int)((tilepos[i, j].x - nx) / 1.5);
                flagy = (int)((tilepos[i, j].y - ny) / 1.5);

                if (flagx == 0 && flagy == 0)
                {
                    target[0] = $"Tile{i}{j}";
                }

                if(target.Contains($"Tile{i}{j}")){
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.red;
                }else{
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }
}
// GameObject.Find($"").GetComponent<Renderer>().material.color = Color.white; コピー用
