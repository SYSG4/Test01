using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeButton : MonoBehaviour
{
    [SerializeField] Sprite Pushed;
    void Start() {
        if(StaticVar.type == name.Substring(0,1)){
            GetComponent<Image>().color -= new Color32(0,0,0,150);
            GetComponent<Image>().sprite = Pushed;
        }

        if(StaticVar.type == "N"){
            GameObject.Find("ModeText").GetComponent<Text>().text = "Normalモード";
        }else{
            GameObject.Find("ModeText").GetComponent<Text>().text = "Hardモード";
        }

    }
    public void Onclick(){
        StaticVar.type = name.Substring(0,1);
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        Debug.Log($"Static:type  Set string:{name.Substring(0,1)}");

    }
}
