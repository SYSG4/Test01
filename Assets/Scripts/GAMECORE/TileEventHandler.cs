using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TileEventHandler : MonoBehaviour
{
    int[,,,] TileUse = new int[2,31,4,6]{
        // A-0,B-0はデバッグ用の盤面(ほぼ全域白)
        {
            {
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
            },
            {
                //A-1
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
                {0,0,1,1,1,1},
                {0,0,0,0,1,0},
            },
            {
                {0,0,1,1,1,1},
                {0,0,0,1,1,1},
                {0,1,1,1,1,1},
                {0,0,0,0,1,1},
            },
            {
                {0,0,0,0,0,0},
                {0,0,0,1,1,1},
                {0,1,1,1,1,1},
                {1,1,1,1,1,1},
            },
            {
                {0,1,1,1,0,0},
                {1,1,1,1,1,1},
                {0,0,1,1,1,0},
                {0,0,1,1,0,0},
            },
            {
                // A-5
                {0,0,1,1,1,1},
                {0,0,1,1,1,1},
                {1,1,1,1,1,0},
                {0,0,0,0,1,0},
            },
            {
                {0,0,1,1,1,0},
                {0,1,1,1,1,1},
                {0,1,1,1,0,0},
                {0,1,1,1,0,0},
            },
            {
                {0,0,0,0,1,1},
                {0,1,1,1,1,0},
                {0,1,1,1,1,0},
                {1,1,1,1,0,0},
            },
            {
                {1,1,1,1,0,0},
                {0,1,1,1,0,0},
                {0,1,1,1,1,1},
                {0,0,1,1,0,0},
            },
            {
                {1,1,1,1,0,0},
                {1,1,1,1,1,1},
                {1,1,1,0,0,0},
                {0,1,0,0,0,0},
            },
            {
                // A-10
                {0,1,1,0,0,0},
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
                {0,1,1,1,0,0},
            },
            {
                {0,0,1,0,0,0},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,0,1,1,1,0},
            },
            {
                {0,0,0,0,0,0},
                {1,1,1,1,1,0},
                {1,1,1,1,1,1},
                {0,0,1,1,1,0},
            },
            {
                {1,1,1,1,1,1},
                {0,1,1,1,1,0},
                {0,1,1,1,0,0},
                {0,0,0,1,0,0},
            },
            {
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
                {0,0,1,1,1,0},
                {0,0,1,1,0,0},
            },
            {
                // A-15
                {0,0,0,0,0,0},
                {0,1,1,1,1,1},
                {1,1,1,1,0,0},
                {1,1,1,1,1,0},
            },
            {
                {0,0,0,0,0,0},
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
            },
            {
                {0,1,1,1,1,0},
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
                {0,1,0,0,0,0},
            },
            {
                {0,0,0,1,1,0},
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,0,0},
            },
            {
                {0,0,1,1,1,1},
                {0,1,1,1,1,0},
                {0,1,1,1,1,0},
                {0,0,1,1,0,0},
            },
            {
                // A-20
                {0,0,0,0,0,0},
                {0,1,1,1,1,1},
                {0,1,1,1,1,0},
                {0,0,1,1,1,1},
            },
            {
                {0,0,0,1,1,0},
                {0,1,1,1,1,1},
                {0,0,1,1,1,0},
                {0,1,1,1,0,0},
            },
            {
                {0,1,1,1,1,1},
                {0,1,1,1,0,0},
                {0,1,1,1,0,0},
                {0,1,0,1,0,0},
            },
            {
                {0,1,1,1,1,0},
                {0,0,1,1,1,1},
                {0,0,0,1,1,0},
                {0,0,1,1,1,0},
            },
            {
                {0,0,1,1,1,1},
                {0,0,1,1,1,0},
                {0,1,1,1,0,0},
                {0,1,1,1,0,0},
            },
            {
                // A-25
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
                {0,1,1,1,0,0},
                {0,0,1,0,0,0},
            },
            {
                {0,0,0,1,1,1},
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
                {0,0,1,0,0,0},
            },
            {
                {0,0,1,1,0,0},
                {0,0,1,1,0,0},
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
            },
            {
                {0,1,1,0,0,0},
                {0,1,1,1,1,1},
                {0,1,1,1,1,0},
                {0,1,1,0,0,0},
            },
            {
                {0,1,1,1,1,0},
                {0,0,1,1,1,1},
                {0,0,1,1,1,1},
                {0,0,1,0,0,0},
            },
            {
                // B-30
                {0,0,0,1,0,0},
                {0,0,1,1,1,0},
                {0,1,1,1,1,1},
                {0,1,1,1,1,0},
            },
        },
        // A盤面終わり
        // ===========================================================================================================================================
        // B盤面ここから
        {
            {
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
            },
            {
                // B-1
                {0,1,1,1,1,0},
                {1,1,1,1,0,0},
                {1,1,1,1,0,0},
                {1,1,1,1,1,1},
            },
            {
                {1,0,1,1,1,0},
                {1,0,1,1,1,0},
                {1,1,1,1,1,1},
                {1,1,1,1,0,0},
            },
            {
                {1,0,0,0,1,1},
                {1,0,0,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,0},
            },
            {
                {0,1,1,0,1,0},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
            },
            {
                // B-5
                {1,1,1,0,0,0},
                {1,1,1,1,1,0},
                {1,1,1,1,1,1},
                {1,0,1,1,1,0},
            },
            {
                {1,1,1,1,1,0},
                {1,1,1,0,0,0},
                {1,1,1,1,1,0},
                {0,1,1,1,1,1},
            },
            {
                {0,1,1,1,0,0},
                {1,1,1,1,1,0},
                {1,1,1,1,1,1},
                {1,1,1,1,0,0},
            },
            {
                {0,1,1,1,1,0},
                {0,1,1,1,1,1},
                {0,0,1,1,1,0},
                {1,1,1,1,1,1},
            },
            {
                {0,1,1,1,1,0},
                {1,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,0,0},
            },
            {
                // B-10
                {0,0,1,1,1,1},
                {1,1,1,1,1,1},
                {0,0,1,1,1,1},
                {0,1,1,1,0,1},
            },
            {
                {1,1,1,0,0,0},
                {1,1,1,0,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
            },
            {
                {1,1,1,1,0,0},
                {0,0,1,1,1,1},
                {1,1,1,1,1,1},
                {0,1,1,1,0,1},
            },
            {
                {0,0,0,1,1,1},
                {1,1,1,1,1,1},
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
            },
            {
                {0,0,1,1,1,1},
                {0,0,0,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,0,1},
            },
            {
                // B-15
                {0,1,1,1,1,0},
                {1,1,1,1,1,1},
                {1,1,1,1,1,0},
                {1,1,1,0,0,0},
            },
            {
                {0,1,1,1,1,0},
                {0,1,1,1,0,0},
                {1,1,1,1,1,1},
                {1,1,1,1,1,0},
            },
            {
                {0,1,1,0,0,0},
                {1,1,1,1,1,1},
                {1,1,1,1,1,0},
                {1,1,1,1,1,0},
            },
            {
                {0,1,1,1,1,0},
                {1,1,1,1,1,0},
                {1,1,1,1,1,1},
                {0,1,0,1,1,0},
            },
            {
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
                {1,1,1,1,1,0},
                {0,0,1,1,1,1},
            },
            {
                // B-20
                {0,1,0,0,0,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,0,1,0},
            },
            {
                {0,1,1,1,0,0},
                {1,1,1,1,0,0},
                {1,1,1,1,1,0},
                {1,1,1,1,1,1},
            },
            {
                {1,0,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,0},
                {0,0,1,1,0,0},
            },
            {
                {0,1,0,0,1,1},
                {1,1,1,1,1,1},
                {0,1,1,1,1,1},
                {0,0,1,1,1,1},
            },
            {
                {0,0,0,0,1,0},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,0,1},
            },
            {
                // B-25
                {0,1,1,1,1,0},
                {1,1,1,1,1,1},
                {0,1,1,1,0,0},
                {0,1,1,1,1,1},
            },
            {
                {0,1,1,1,1,1},
                {0,0,1,1,1,1},
                {0,1,1,1,1,1},
                {0,0,1,1,1,1},
            },
            {
                {1,1,0,1,1,0},
                {1,1,1,1,0,0},
                {1,1,1,1,1,1},
                {1,1,1,1,0,0},
            },
            {
                {0,1,1,1,1,0},
                {0,1,1,1,1,0},
                {1,1,1,1,1,0},
                {0,1,1,1,1,1},
            },
            {
                {1,0,0,0,0,0},
                {1,1,1,1,1,0},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
            },
            {
                // B-30
                {0,0,0,0,1,1},
                {0,1,1,1,1,1},
                {0,1,1,1,1,1},
                {1,1,1,1,1,1},
            },
        }
    };

    [SerializeField] TextMeshProUGUI Stagetext;
    [SerializeField] TextMeshProUGUI Timer;
    [SerializeField] GameObject UIMObj;

    [SerializeField] Sprite S,A,B,C,SYukkuri,AYukkuri,BYukkuri,CYukkuri,SText,AText,BText,CText;

    GameObject[] Pieces;
    ChangerCanvas CC;
    double time,delay;
    bool stop = true;
    int type , stage;
    void Start()
    {
        CC = GameObject.Find("ChangerCanvas").GetComponent<ChangerCanvas>();
        if(StaticVar.gameMode == 0){
            stop = true;
            Timer.text = "FreePlay";
            Debug.Log("Set Timer Text");
        }else
            StaticVar.stage = CC.stages[CC.stageCount -1];

        if(CC.stageCount == 1)
            delay = 3;
        else
            delay = 1;
        time = 0;
        Pieces = GameObject.FindGameObjectsWithTag("Piece");
        stage = StaticVar.stage;
        if(StaticVar.type == "N"){
            type = 0;
            Stagetext.text = $"N-{stage}";
        }else{
            type = 1;
            Stagetext.text = $"H-{stage}";
        }
        TileUpdate();
        Debug.Log($"Type:{type} Stage:{stage}");
    }
    private void Update()
    {
        if(stop == false){
            time += Time.deltaTime;
            Timer.text = ($"{Math.Floor(time/60)}:{Math.Round(time % 60 ,2 ,  MidpointRounding.AwayFromZero).ToString("00.00")}");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // time = 0;
            // stop = false;
            // stage += 1;
            // if (stage == 31)
            // {
            //     type = 1 - type;
            // }
            // stage = stage % 31;
            // if (type == 0)
            //     Stagetext.text = $"N-{stage}";
            // else
            //     Stagetext.text = $"H-{stage}";

            CC.clearTime[CC.stageCount - 1] = time;
            StaticVar.stage = CC.stages[CC.stageCount];
            Debug.Log($"index:{CC.stageCount} Stage:{CC.stages[CC.stageCount]}");
            CC.stageCount += 1;
            CC.SceneChange($"Next {CC.stageCount}","Play");
        }

        if(StaticVar.gameMode == 1 && delay > 0)
            delay -= 1*Time.deltaTime;
        else if(delay <= 0 && StaticVar.stage == stage)
            stop = false;

    }

    private void TileUpdate()
    {
        for (int i = 0; i < TileUse.GetLength(2); i++)
        {
            for (int j = 0; j < TileUse.GetLength(3); j++)
            {
                if (TileUse[type, stage, i, j] == 0)
                {
                    GameObject.Find($"Tile{i}{j}").transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = new Color32(0,85,34,255);
                    GameObject.Find($"Tile{i}{j}").tag = "Nonuse";
                }
                else
                {
                    GameObject.Find($"Tile{i}{j}").transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                    GameObject.Find($"Tile{i}{j}").GetComponent<Renderer>().material.color = new Color32(0,85,34,255);
                    GameObject.Find($"Tile{i}{j}").tag = "Use";
                }
            }
        }
    }

    public void Cleardecision()
    {
        for (int i = 0; i < TileUse.GetLength(2); i++)
        {
            for (int j = 0; j < TileUse.GetLength(3); j++)
            {
                if (GameObject.Find($"Tile{i}{j}").tag == "Use")
                {
                    Debug.Log("return");
                    return;
                }
            }
        }
        // これ以降にクリア時の処理を書く
        stop = true;
        if(StaticVar.gameMode == 0)
            UIMObj.GetComponent<UIManeger>().ClearButtonFP();
        else if(CC.stageCount < 10){
            CC.clearTime[CC.stageCount - 1] = time;
            StaticVar.stage = CC.stages[CC.stageCount];
            Debug.Log($"index:{CC.stageCount} Stage:{CC.stages[CC.stageCount]}");
            CC.stageCount += 1;
            CC.SceneChange($"Next {CC.stageCount}","Play");
        }else{
            CC.clearTime[CC.stageCount - 1] = time;
            StaticVar.stage = 0;
            UIMObj.GetComponent<UIManeger>().ClearButtonTA();
            // ここにTA終了時のタイム、評価等のテキストを更新するための処理を書く。
            double total = 0;
            for(int i = 0; i < 10; i++){
                GameObject.Find($"TimeText{i}").GetComponent<TextMeshProUGUI>().text = $"{Math.Floor(CC.clearTime[i]/60)}:{Math.Round(CC.clearTime[i] % 60 ,2 ,  MidpointRounding.AwayFromZero).ToString("00.00")}";
                total +=  CC.clearTime[i];
            }
            GameObject.Find($"TimeTextTotal").GetComponent<TextMeshProUGUI>().text = $"{Math.Floor(total/60)}:{Math.Round(total % 60 ,2 ,  MidpointRounding.AwayFromZero).ToString("00.00")}";

            //タイムで区切ってスコア評価をつける、動的にゆっくりの画像差し替え、テキストの変更。
            // 暫定基準値Normal S:1:30  A:2:30  B:3:30    hard S:2:30  A:4:00   B:5:30    GMTime  N-1:02.30  H-2:15.70
            if(StaticVar.type == "N"){
                // Normal時
                if(total < 90){
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = S;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = SYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = SText;
                }else if(total < 150){
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = A;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = AYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = AText;
                }else if(total < 210){
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = B;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = BYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = BText;
                }else{
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = C;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = CYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = CText;
                }
            }else{
                // Hard時
                if(total < 150){
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = S;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = SYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = SText;
                }else if(total < 240){
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = A;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = AYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = AText;
                }else if(total < 330){
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = B;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = BYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = BText;
                }else{
                    GameObject.Find("Rank").GetComponent<SpriteRenderer>().sprite = C;
                    GameObject.Find("表情差分").GetComponent<SpriteRenderer>().sprite = CYukkuri;
                    GameObject.Find("ResultText").GetComponent<SpriteRenderer>().sprite = CText;
                }
            }
        }
    }

    public void ResetButton() {
        TileUpdate();
        for(int i = 0; i < Pieces.GetLength(0); i++){
            Pieces[i].GetComponent<PositionReset>().Reset();
            Pieces[i].GetComponent<DropParent>().Settarget();
            Pieces[i].GetComponent<ShapeSizeHandler>().OnMouseDrag();
        }
    }
}

// using UnityEngine.SceneManagement;
// SceneManager.LoadScene (SceneManager.GetActiveScene().name);

// スコアやタイムの保持について https://www.sejuku.net/blog/69991