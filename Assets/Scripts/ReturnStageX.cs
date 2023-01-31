using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStageX : MonoBehaviour
{
    public void SwitchScene(){
        Debug.Log($"{StaticVar.type} {StaticVar.stage}");
    if(StaticVar.stage< 11)
            SceneManager.LoadScene("NormalStageScene1~10", LoadSceneMode.Single);
        else if(StaticVar.stage< 21)
            SceneManager.LoadScene("NormalStageScene11~20", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("NormalStageScene", LoadSceneMode.Single);
    }
}
