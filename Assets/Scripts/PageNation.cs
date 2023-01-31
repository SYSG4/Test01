using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PageNation : MonoBehaviour
{

    void Start() {
        if(StaticVar.stage <= int.Parse(name.Substring(4)) && StaticVar.stage > int.Parse(name.Substring(4)) -10 )
            GetComponent<Image>().color -= new Color32(0,0,0,150);
    }
    public void Onclick(){
        StaticVar.stage = int.Parse(name.Substring(4));
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        Debug.Log($"Static:stage  Set int:{StaticVar.stage}");
    }
}
