// MoveParentに統合
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragParent : MonoBehaviour
{
    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        Vector2 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        transform.position = objectWorldPoint;
    }
}