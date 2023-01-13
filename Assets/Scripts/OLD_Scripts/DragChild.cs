// MoveChildに統合
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChild : MonoBehaviour
{
    private GameObject parent;

    private void Start() {
        parent = transform.parent.gameObject;
    }
    void OnMouseDrag()
    {
        Debug.Log("OnMouseDrag");
        Vector2 objectScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        parent.transform.position = objectWorldPoint;
    }
}