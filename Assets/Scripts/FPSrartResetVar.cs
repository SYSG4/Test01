using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSrartResetVar : MonoBehaviour
{
    public void ResetStVars(){
        StaticVar.type = "N";
        StaticVar.stage = 1;
        StaticVar.gameMode = 0;
    }
}
