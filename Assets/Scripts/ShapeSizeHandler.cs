using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSizeHandler : MonoBehaviour
{
    public void OnMouseDrag() {
        if(transform.position.x < 400)
            transform.localScale = new Vector3(45,45,1);
        else
            transform.localScale = new Vector3(20,20,1);

    }
}
// ピースを元サイズで置いておくとデカすぎるので最初置かれているエリアにドロップすると小さくなるようにしたかった。
