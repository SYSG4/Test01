using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardStage1 : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("HardStageScene1", LoadSceneMode.Single);
    }
}
