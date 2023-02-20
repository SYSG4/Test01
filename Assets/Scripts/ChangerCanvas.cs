using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ChangerCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextBox;
    [SerializeField] GameObject BTNNormal,BTNHard;
    public double[] clearTime = new double[10];
    public int[] stages = new int[10];
    Vector3 DefaultPos = new Vector3((float)296.446,510,-5),ChangePos = new Vector3((float)296.446,(float)166.6453,-5),TargetPos;
    string TargetScene;
    double delay;

    bool flag;

    int CCMode = 0;
    public int stageCount = 1;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        TargetPos = DefaultPos;
        delay = 3;
        // Debug.Log("Start");
        flag = true;
    }

    private void Update() {
        if(CCMode == 0){
            if(transform.position == ChangePos){
                //n秒遅延させる処理
                delay = delay - 1* Time.deltaTime;
                if(flag == true){
                    SceneManager.LoadScene(TargetScene,LoadSceneMode.Single);
                    flag = false;
                }
                if(delay > 0)
                    return;
                    
                TargetPos = DefaultPos;
                // SceneManager.LoadScene(TargetScene,LoadSceneMode.Single);
            }
            flag = true;
            delay = 1;
        }else{
            if(TargetPos == DefaultPos && transform.position != DefaultPos){
                delay = delay - 1* Time.deltaTime;
                TextBox.text = (Math.Floor(delay) + 1).ToString("0");
            }
                //n秒待たせる処理
            if(transform.position == ChangePos)
                if(flag == true){
                    BTNHard.SetActive(true);
                    BTNNormal.SetActive(true);
                    flag = false;
                }

                if(delay > 1)
                    return;
            }
        transform.position = Vector3.MoveTowards(transform.position,TargetPos,300*Time.deltaTime);
    }

    public void SceneChange(string text,string targetScene){
        CCMode = 0;
        TargetPos = ChangePos;
        TextBox.text = text;
        TargetScene = targetScene;
    }

    public void SceneChangeTA(){
        CCMode = 1;
        stageCount = 1;
        StaticVar.gameMode = 1;
        TargetPos = ChangePos;
        TextBox.text = "Time Attack";
        stages = new int[10];

        List<int> numbers = new List<int>();
        for (int i = 1; i <= 30; i++) {
            numbers.Add(i);
        }
        int j = 0;
        while (j < 10) {
            int index = UnityEngine.Random.Range(0, numbers.Count);
            stages[j] = numbers[index];
            // Debug.Log($"stage{j}:{stages[j]} = {numbers[index]}");
            numbers.RemoveAt(index);
            j++;
        }
    }

    public void ModeButtonN(){
        TargetPos = DefaultPos;
        delay = 3;
        SceneManager.LoadScene("Play",LoadSceneMode.Single);
        StaticVar.type = "N";

        BTNHard.SetActive(false);
        BTNNormal.SetActive(false);
    }

    public void ModeButtonH(){
        TargetPos = DefaultPos;
        delay = 3;
        SceneManager.LoadScene("Play",LoadSceneMode.Single);
        StaticVar.type = "H";

        BTNHard.SetActive(false);
        BTNNormal.SetActive(false);
    }
    public static ChangerCanvas instance;

    // シーン遷移時、遷移先に自身と同じオブジェクト(このスクリプトが貼ってあるオブジェクト?)があれば削除して重複を防ぐ
    void Awake()
    {
        CheckInstance();
    }
    void CheckInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // 重複処理ここまで。

}
