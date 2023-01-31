using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalStage3 : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("NormalStageScene3", LoadSceneMode.Single);
    }
}
