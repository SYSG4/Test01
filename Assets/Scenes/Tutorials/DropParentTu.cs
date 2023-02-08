using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropParentTu : MonoBehaviour
{
    public GameObject[] child;
    // 子オブジェクトを配列で格納、ピースの大きさ次第で数が変わる。アタッチ後インスペクターから子オブジェクトの指定必須。
    public Vector2[,] tilepos = new Vector2[4, 6];
    // 盤面の１つ１つのタイルの位置を格納するための変数。
    string[] target;
    // ドラッグ中近にあるタイルを格納する変数。(赤色に変える処理に使う)
    // bool ERflag;
    TileEventHandler tileEventHandler;
    Color32 tileDefault = new Color32(0,85,34,255),tileActive = Color.white;

    [SerializeField] int TileLength;
    void Start()
    {
        // 変数の初期化、子オブジェクトの数に合わせて要素数を変える。

        for (int i = 0; i < TileLength; i++)
        {
            for (int j = 0; j < TileLength; j++)
            {
                tilepos[i, j] = GameObject.Find($"Tile{i}{j}").transform.position;
            }
        }
    }

    public void Settarget()
    {
        target = Enumerable.Repeat("Tile404", child.GetLength(0) + 1).ToArray();
        for (int i = 0; i < child.GetLength(0); i++)
        {
            child[i].GetComponent<DropChildTu>().ParentDrag(out int ti, out int tj);
            target[i + 1] = $"Tile{ti}{tj}";
        }
    }

    public void OnMouseDown()
    {
        // ERflag = false;
        // Debug.Log(ERflag);
        try{
            for(int i = 0; i < target.GetLength(0); i++ ){
                GameObject.Find(target[i]).tag = "Use";
                // Debug.Log($"Object({target[i]}) set Use");
            }

        }catch{
            // Debug.Log("Target is Null");
        }
    }

    public void OnMouseDrag()
    {
        float nx, ny;
        int flagx, flagy;
        nx = transform.position.x;
        ny = transform.position.y;


        Settarget();
        for (int i = 0; i < TileLength; i++)
        {
            for (int j = 0; j < TileLength; j++)
            {
                flagx = (int)((tilepos[i, j].x - nx) / (1.4 * 15));
                flagy = (int)((tilepos[i, j].y - ny) / (1.4 * 15));

                if (flagx == 0 && flagy == 0 && GameObject.Find($"Tile{i}{j}").tag == "Use")
                {
                    target[0] = $"Tile{i}{j}";
                }

                if (GameObject.Find($"Tile{i}{j}").tag == "Nonuse")
                    continue;

                if (target.Contains($"Tile{i}{j}"))
                {
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = tileActive;
                }
                else
                {
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = tileDefault;
                }
            }
        }
    }

    public void OnMouseUp()
    {
        if (target.Contains("Tile404"))
        {
            // ドロップ時盤面に入らない場合。に元の位置に戻す処理
            for(int i =0; i < tilepos.GetLength(0); i++)
                for(int j = 0; j < tilepos.GetLength(1); j++)
                    if (target.Contains($"Tile{i}{j}"))
                        GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = new Color32(0,85,34,255);

            this.GetComponent<PositionReset>().Reset();
            Settarget();
            GetComponent<ShapeSizeHandlerTu>().OnMouseDrag();
        }
        else
        {
            Vector2 targetTile = GameObject.Find(target[0]).transform.position;
            transform.position = new Vector2(targetTile.x, targetTile.y);

            for(int i = 0; i < target.GetLength(0); i++ ){
                GameObject.Find(target[i]).tag = "Active";
                GameObject.Find(target[i]).GetComponent<Renderer>().material.color = new Color32(0,85,34,255);
            }
        }
    }
}