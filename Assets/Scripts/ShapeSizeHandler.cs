using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSizeHandler : MonoBehaviour
{
    public void OnMouseDrag() {
        if(transform.position.x < 12)
            transform.localScale = new Vector3(3,3,1);
        else
            transform.localScale = new Vector3(2,2,1);

    }
}
// ピースを元サイズで置いておくとデカすぎるので最初置かれているエリアにドロップすると小さくなるようにしたかった。
