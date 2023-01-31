using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangerCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextBox;
    Vector3 DefaultPos = new Vector3((float)296.446,510,-5),ChangePos = new Vector3((float)296.446,(float)166.6453,-5),TargetPos;
    string TargetScene;
    double delay;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        TargetPos = DefaultPos;
        delay = 1;
        Debug.Log("Start");
    }

    private void Update() {
        if(transform.position == ChangePos){
            //n秒遅延させる処理
                delay = delay - 1* Time.deltaTime;
                if(delay > 0){
                    // Debug.Log(delay);
                    return;
                }
                TargetPos = DefaultPos;
                SceneManager.LoadScene(TargetScene,LoadSceneMode.Single);
            }
        delay = 1;
        transform.position = Vector3.MoveTowards(transform.position,TargetPos,300*Time.deltaTime);
    }

    public void SceneChange(string text,string targetScene){
        TargetPos = ChangePos;
        TextBox.text = text;
        TargetScene = targetScene;
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
