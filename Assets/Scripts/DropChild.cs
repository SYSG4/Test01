using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChild : MonoBehaviour
{
    Vector3[,] tilepos = DropParent.tilepos;
    int[] target = new int[2];
    void Start()
    {
        for(int i=0; i < tilepos.GetLength(0);i++){
            for(int j=0; j < tilepos.GetLength(1);j++ ){
                tilepos[i,j] = GameObject.Find($"Tile{i}{j}").transform.position;
            }
        }
    }

    // Update is called once per frame
    public int[] ParentDrag()
    {
        float nx,ny;
        int flagx,flagy;
        nx = transform.position.x;
        ny = transform.position.y;

        for(int i=0; i < tilepos.GetLength(0);i++){
            for(int j=0; j < tilepos.GetLength(1);j++){
                flagx = (int)((tilepos[i,j].x - nx) / 1.5);
                flagy = (int)((tilepos[i,j].y - ny) / 1.5);

                if(flagx == 0 && flagy == 0){
                    target = new int[]{i,j};
                }else{
                    target = null;
                }
            }
        }
        return target;
    }
}
