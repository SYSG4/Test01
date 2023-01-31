using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChild : MonoBehaviour
{
    private GameObject parent;
    private MoveParent MoveParent;
    private void Start() {
        parent = transform.parent.gameObject;
        MoveParent = parent.GetComponent<MoveParent>();
    }

    private void OnMouseDown() {
        MoveParent.OnMouseDown();
    }
    void OnMouseDrag(){
        MoveParent.OnMouseDrag();
        parent.GetComponent<ShapeSizeHandler>().OnMouseDrag();
    }
    private void OnMouseUp() {
        MoveParent.OnMouseUp();
    }
    private void Update() {
        MoveParent.Update();
    }
}
// 子オブジェクトのアタッチ用、操作に応じて親オブジェクトのスクリプト(MoveParent.cs)の関数を実行。親オブジェクトを動かせば子オブジェクトは勝手についていく。