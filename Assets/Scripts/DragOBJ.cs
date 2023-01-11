using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOBJ : MonoBehaviour
{
    float posx, posy, difx, dify;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }
    void OnMouseDrag()
    {
        Debug.Log("OnMouseUp");
        Vector2 position = GameObject.Find("Drop").transform.position;
        posx = position.x;
        posy = position.y;

        difx = transform.position.x - posx;
        dify = transform.position.y - posy;

        if(difx > -5 && difx < 5 && dify > -5 && dify < 5){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }else{
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        Debug.Log(difx);
        Debug.Log(dify);

        Debug.Log("OnMouseDrag");
        Vector2 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        transform.position = objectWorldPoint;
    }
    void OnMouseUp()
    {
        Vector2 position = GameObject.Find("Drop").transform.position;
        if(difx > -5 && difx < 5 && dify > -5 && dify < 5){
            transform.position = position;
        }
    }
}