using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChild : MonoBehaviour
{
    DropParent DropParent;
    Vector3[,] tilepos;
    string[] target = new string[2];

    // Update is called once per frame
    void Start(){
        GameObject parent = transform.parent.gameObject;
        DropParent = parent.GetComponent<DropParent>();
        tilepos = DropParent.tilepos;
    }

    private void OnMouseDrag() {
        DropParent.OnMouseDrag();
    }
    public void ParentDrag(out int ti, out int tj)
    {
        Debug.Log($"Call Child! {name}");
        ti=404;
        tj=404;
        float nx,ny;
        int flagx,flagy;
        nx = transform.position.x;
        ny = transform.position.y;

        for(int i=0; i < tilepos.GetLength(0);i++){
            for(int j=0; j < tilepos.GetLength(1);j++){
                flagx = (int)((tilepos[i,j].x - nx) / 1.5);
                flagy = (int)((tilepos[i,j].y - ny) / 1.5);

                if(flagx == 0 && flagy == 0){
                    ti = i;
                    tj = j;
                    return;
                }else{
                    ti = 404;
                    tj = 404;
                }
            }
        }
    }
}
