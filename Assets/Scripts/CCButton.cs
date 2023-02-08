using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CCButton : MonoBehaviour
{
    ChangerCanvas CC;
    string[] SceneName;
    private void Start() {
        CC = GameObject.Find("ChangerCanvas").GetComponent<ChangerCanvas>();
        SceneName = name.Split('-');
    }
    public void SwitchScene()
    {
        if(StaticVar.gameMode == 0)
            CC.SceneChange(SceneName[2],SceneName[1]);
        else
            CC.SceneChange("Exit","Mainmenu");
    }
}
