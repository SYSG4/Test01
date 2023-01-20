using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    // Start is called before the first frame update
    MoveParent me;
    Vector2 startpos;
    void Start()
    {
        me = this.GetComponent<MoveParent>();
        startpos = transform.position;
    }

    public void Reset(){
        transform.position = startpos;
        me.reverse = 1;
        me.nx = 0;
        me.ny = 0;
        me.nz = 0;
    }
}
