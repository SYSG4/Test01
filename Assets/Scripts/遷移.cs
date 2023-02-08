using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 遷移 : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchScene()
    {
        SceneManager.LoadScene("page1", LoadSceneMode.Single);
    }

public void SwitchScene2()
    {
        SceneManager.LoadScene("page2", LoadSceneMode.Single);
    }

public void SwitchScene3()
    {
        SceneManager.LoadScene("page3", LoadSceneMode.Single);
    }

public void SwitchScene4()
    {
        SceneManager.LoadScene("page4", LoadSceneMode.Single);
    }

public void SwitchScene5()
    {
        SceneManager.LoadScene("page5", LoadSceneMode.Single);
    }
}
