using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float nx,nz;
    int reverse = 1;
    void OnMouseDrag(){
        if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("W");
            Mathf.Repeat(nx += 180, 360);
            reverse = reverse * -1;
        }if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log("S");
            Mathf.Repeat(nx -= 180, 360);
            reverse = reverse * -1;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("A");
            Mathf.Repeat(nz += (90 * reverse), 360);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("D");
            Mathf.Repeat(nz -= (90 * reverse), 360);
        }
        transform.rotation = (Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(nx,0,nz),0.5f));
    }
    
}
