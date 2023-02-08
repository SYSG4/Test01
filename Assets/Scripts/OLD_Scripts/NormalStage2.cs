using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalStage2 : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("NormalStageScene2", LoadSceneMode.Single);
    }
}
