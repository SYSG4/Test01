using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector2 TargetPoint;
    void Start() {
        TargetPoint = transform.position;
        TargetPoint.x += 30;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,TargetPoint,0.01f);
    }
}
