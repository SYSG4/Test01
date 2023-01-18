using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropParent : MonoBehaviour
{
    public GameObject[] child;
    // 子オブジェクトを配列で格納、ピースの大きさ次第で数が変わる。アタッチ後インスペクターから子オブジェクトの指定必須。
    public Vector3[,] tilepos = new Vector3[4, 4];
    // 盤面の１つ１つのタイルの位置を格納するための変数。
    string[] target;
    // ドラッグ中近にあるタイルを格納する変数。(赤色に変える処理に使う)
    void Start()
    {
        target = Enumerable.Repeat("Null",child.GetLength(0) + 1).ToArray();
        // 変数の初期化、子オブジェクトの数に合わせて要素数を変える。

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
                flagx = (int)((tilepos[i, j].x - nx) / 1.4);
                flagy = (int)((tilepos[i, j].y - ny) / 1.4);

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
