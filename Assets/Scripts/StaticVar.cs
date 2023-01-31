using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour
{
    public static int stage,gameMode;
    public static string type;

    private void Start() {
        stage=10;
        type="N";
        gameMode = 0;
        Debug.Log("StaticVar was running");
    }
}
