using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragX : MonoBehaviour
{
    float posx, posy, difx, dify;
        void OnMouseUp()
    {
        Vector2 position = GameObject.Find("Drag").transform.position;
        posx = position.x;
        posy = position.y;

        difx = transform.position.x - posx;
        dify = transform.position.y - posy;

        Debug.Log(difx);
        Debug.Log(dify);

        if(difx > -10 && difx < 10 && dify > -10 && dify < 10){
            transform.position = position;
        }
    }
}