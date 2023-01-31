using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStage : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("GameStageScene", LoadSceneMode.Single);
    }
}
