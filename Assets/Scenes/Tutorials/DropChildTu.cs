using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChildTu : MonoBehaviour
{
    DropParentTu DropParent;
    Vector2[,] tilepos;
    string[] target = new string[2];
    [SerializeField] int TileLength;

    // Update is called once per frame
    void Start(){
        GameObject parent = transform.parent.gameObject;
        DropParent = parent.GetComponent<DropParentTu>();
        tilepos = DropParent.tilepos;
    }


    private void OnMouseDown() {
        DropParent.OnMouseDown();
    }
    private void OnMouseDrag() {
        DropParent.OnMouseDrag();
        transform.parent.gameObject.GetComponent<ShapeSizeHandlerTu>().OnMouseDrag();
    }
    public void ParentDrag(out int ti, out int tj)
    {
        ti= 40;
        tj= 4;
        float nx,ny;
        int flagx,flagy;
        nx = transform.position.x;
        ny = transform.position.y;

        for(int i=0; i < TileLength;i++){
            for(int j=0; j < TileLength;j++){
                flagx = (int)((tilepos[i,j].x - nx) / (1.4 * 15));
                flagy = (int)((tilepos[i,j].y - ny) / (1.4 * 15));

                if(flagx == 0 && flagy == 0 && GameObject.Find($"Tile{i}{j}").tag == "Use"){
                    ti = i;
                    tj = j;
                    return;
                }
            }
        }
    }

    private void OnMouseUp() {
        DropParent.OnMouseUp();
    }
}
