using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretManager : MonoBehaviour
{
    [SerializeField] GameObject MainScene;
    [SerializeField] GameObject TimeScene;
    [SerializeField] GameObject GMScene;
    [SerializeField] GameObject GirlScene;
    

    // メインに戻るときの表示切替
    public void MainButton()
    {
        TimeScene.SetActive(false);
        GMScene.SetActive(false);
        GirlScene.SetActive(false);
    }

    // TimeSceneを表示
    public void TimeButton()
    {
        TimeScene.SetActive(true);
    }

    // メインに戻るときの表示切替
    public void GMButton()
    {
        GMScene.SetActive(true);
    }

    // メインに戻るときの表示切替
    public void GirlButton()
    {
        GirlScene.SetActive(true);
    }




    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
