using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    // [SerializeField] GameObject GameScene;
    [SerializeField] GameObject MenuScene;
    [SerializeField] GameObject KakuninScene;
    [SerializeField] GameObject ClearPanel;

    // Start is called before the first frame update
    // void Start()
    // {
    //     BackToMenu();
    // }


    // ゲーム画面のメニューボタンが押されたときの表示切替
    public void MenuButton()
    {
        MenuScene.SetActive(true);
    }

    // メニュー画面の戻るボタンが押されたときの表示切替
    public void BackButton()
    {
        MenuScene.SetActive(false);
    }

    // メニュー画面のゲームを終わるボタンが押されたときの表示切替
    public void GameEndButton()
    {
        KakuninScene.SetActive(true);
    }

    // 確認画面の続けるボタンが押されたときの表示切替
    public void ContinueButton()
    {
        KakuninScene.SetActive(false);
        MenuScene.SetActive(false);
    }

    // クリア演出確認用
    public void ClearButton()
    {
        ClearPanel.SetActive(true);
    }


}
