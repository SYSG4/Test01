using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CCButtonTA : MonoBehaviour
{
    ChangerCanvas CC;
    private void Start() {
        CC = GameObject.Find("ChangerCanvas").GetComponent<ChangerCanvas>();
    }
    public void SwitchScene()
    {
        CC.SceneChangeTA();
    }
}
