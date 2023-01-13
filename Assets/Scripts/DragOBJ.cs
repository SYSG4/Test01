using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOBJ : MonoBehaviour
{
    float posx, posy, difx, dify;
    bool fit = false;

    void Update(){
        if(fit == true){
            GameObject.Find("Drop").GetComponent<Renderer>().material.color = Color.green;
        }else{
            GameObject.Find("Drop").GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        Vector2 position = GameObject.Find("Drop").transform.position;
        posx = position.x;
        posy = position.y;

        difx = transform.position.x - posx;
        dify = transform.position.y - posy;

        if(difx > -5 && difx < 5 && dify > -5 && dify < 5){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }else{
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        Vector2 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        transform.position = objectWorldPoint;
        fit = false;
    }
    
    void OnMouseUp()
    {
        Vector2 position = GameObject.Find("Drop").transform.position;
        if(difx > -5 && difx < 5 && dify > -5 && dify < 5){
            transform.position = position;
            fit = true;
        }
    }
}