using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSizeHandlerTu : MonoBehaviour
{
    public void OnMouseDrag() {
        if(transform.position.x < 300)
            transform.localScale = new Vector3(45,45,1);
        else
            transform.localScale = new Vector3(24,24,1);

    }
}
// ピースを元サイズで置いておくとデカすぎるので最初置かれているエリアにドロップすると小さくなるようにしたかった。
