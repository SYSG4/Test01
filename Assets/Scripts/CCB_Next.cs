using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CCB_Next : MonoBehaviour
{
    ChangerCanvas CC;
    string[] SceneName;
    private void Start() {
        CC = GameObject.Find("ChangerCanvas").GetComponent<ChangerCanvas>();
        SceneName = name.Split('-');
    }
    public void SwitchScene()
    {
        StaticVar.stage += 1;
        StaticVar.stage = StaticVar.stage % 31;
        if(StaticVar.stage == 0)
            StaticVar.stage = 1;
        CC.SceneChange(SceneName[2],SceneName[1]);
    }
}
