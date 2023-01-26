using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParent : MonoBehaviour
{
    public float nx, ny, nz;
    public int reverse = 1;
    public Color32 Default, Active;
    //インスペクターから通常時とドラッグ中の色、透明の設定用
    public static MoveParent instance;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // 現在の座標を取得
        nx = transform.eulerAngles.x;
        ny = transform.eulerAngles.y;
        nz = transform.eulerAngles.z;
    }

    public void OnMouseDown()
    {
        // オブジェクトをクリック(押し込み)時
        
        // クリックしたオブジェクトを半透明化する
        sr.sharedMaterial.color = Default;
    }

    public void OnMouseDrag()
    {
        // ドラッグ中
        // カーソル位置にオブジェクトを移動させる
        Vector3 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,10);
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        transform.position = objectWorldPoint;

        sr.sharedMaterial.color = Active;

        // Q,W,E,A,S,Dキー入力を受けて各回転軸の座標を書き換える
        if (Input.GetKeyDown(KeyCode.W))
        {
            nx = Mathf.Repeat(nx += 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            nx = Mathf.Repeat(nx -= 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ny = Mathf.Repeat(ny += 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ny = Mathf.Repeat(ny -= 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            nz = Mathf.Repeat(nz += (90 * reverse), 360);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            nz = Mathf.Repeat(nz -= (90 * reverse), 360);
        }
    }

    public void OnMouseUp()
    {
        // オブジェクトをクリック(離した)時

        // 透明度を戻す
        sr.sharedMaterial.color = Default;
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }

    public void Update()
    {
        // 書き換えられた座標をに応じて実際にオブジェクトを回転させる、上はアニメーションあり、下はアニメーション無し。
        // 回転時にピースが背景に食い込む場合はアニメーション無し推奨

        transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(nx, ny, nz), 90 * Time.deltaTime));
        // transform.eulerAngles = new Vector3(nx,ny,nz);
    }
}
