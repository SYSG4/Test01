using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropParent : MonoBehaviour
{
    public GameObject[] child;
    // 子オブジェクトを配列で格納、ピースの大きさ次第で数が変わる。アタッチ後インスペクターから子オブジェクトの指定必須。
    public Vector2[,] tilepos = new Vector2[4, 4];
    // 盤面の１つ１つのタイルの位置を格納するための変数。
    string[] target;
    // ドラッグ中近にあるタイルを格納する変数。(赤色に変える処理に使う)
    bool ERflag;

    void Start()
    {
        target = Enumerable.Repeat("Null", child.GetLength(0) + 1).ToArray();
        // 変数の初期化、子オブジェクトの数に合わせて要素数を変える。

        for (int i = 0; i < tilepos.GetLength(0); i++)
        {
            for (int j = 0; j < tilepos.GetLength(1); j++)
            {
                tilepos[i, j] = GameObject.Find($"Tile{i}{j}").transform.position;
            }
        }
    }

    void Settarget()
    {
        target = Enumerable.Repeat("Tile404", child.GetLength(0) + 1).ToArray();
        for (int i = 0; i < child.GetLength(0); i++)
        {
            child[i].GetComponent<DropChild>().ParentDrag(out int ti, out int tj);
            target[i + 1] = $"Tile{ti}{tj}";
        }
    }

    public void OnMouseDown()
    {
        ERflag = false;
        Debug.Log(ERflag);
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

                if (GameObject.Find($"Tile{i}{j}").tag == "Inactive")
                    continue;

                if (target.Contains($"Tile{i}{j}"))
                {
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }

    public void OnMouseUp()
    {
        if (target[0] != "Tile404")
        {
            Vector2 targetTile = GameObject.Find(target[0]).transform.position;
            transform.position = new Vector2(targetTile.x, targetTile.y);

            try
            {
                for (int i = 0; i < target.GetLength(0); i++)
                {
                    if (GameObject.Find(target[i]).tag == "Inactive" || target[i] == "Null")
                    {
                        ERflag = true;
                        Debug.Log(ERflag);
                    }
                }
            }
            catch
            {
                ERflag = true;
                Debug.Log($"{ERflag}:Error");
            }
        }
        // 現状親オブジェクトが盤面上にないと(子オブジェクトだけ盤面上にある場合は)ドロップ時に盤面に吸着しない。
    }


}
// GameObject.Find($"").GetComponent<Renderer>().material.color = Color.white; コピー用
