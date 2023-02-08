using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalStage1 : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("NormalStageScene1", LoadSceneMode.Single);
    }
}
