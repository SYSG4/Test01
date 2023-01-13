using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParent : MonoBehaviour
{
    public float nx, ny, nz;
    int reverse = 1;
    public static MoveParent instance;
    SpriteRenderer sr;
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        // オブジェクトをクリック(押し込み)時

        // 現在の座標を取得
        nx = transform.eulerAngles.x;
        ny = transform.eulerAngles.y;
        nz = transform.eulerAngles.z;

        // クリックしたオブジェクトを半透明化する
        sr.sharedMaterial.color = new Color32(255, 255, 255, 150);
    }

    public void OnMouseDrag()
    {
        // ドラッグ中

        // カーソル位置にオブジェクトを移動させる
        Vector2 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        transform.position = objectWorldPoint;


        // Q,W,E,A,S,Dキー入力を受けて各回転軸の座標を書き換える
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            nx = Mathf.Repeat(nx += 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            nx = Mathf.Repeat(nx -= 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            ny = Mathf.Repeat(ny += 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            ny = Mathf.Repeat(ny -= 180, 360);
            reverse = reverse * -1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            nz = Mathf.Repeat(nz += (90 * reverse), 360);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            nz = Mathf.Repeat(nz -= (90 * reverse), 360);
        }
    }

    public void OnMouseUp() {
        // オブジェクトをクリック(離した)時

        // 透明度を戻す
        sr.sharedMaterial.color = new Color(255, 255, 255,255);
    }

    public void Update(){
        // 書き換えられた座標をに応じて実際にオブジェクトを回転させる、上はアニメーションあり、下はアニメーション無し。
        // 描画バグ対策のためアニメーション無し推奨

        // transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(nx, ny, nz), 1f));
        transform.eulerAngles = new Vector3(nx,ny,nz);
    }
}
