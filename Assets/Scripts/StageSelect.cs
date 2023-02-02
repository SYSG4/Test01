using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    GameObject child;
    ChangerCanvas CC;
    [SerializeField] Sprite SpriteNormal,SpriteHard;
    void Start() {
        CC = GameObject.Find("ChangerCanvas").GetComponent<ChangerCanvas>();
        child  = transform.GetChild(0).gameObject;
        if(StaticVar.type == "N"){
            // GetComponent<Image>().color = new Color32(0,255,255,255);
            GetComponent<Image>().sprite = SpriteNormal;
            child.GetComponent<Text>().color = new Color32(0,0,0,255);
            // Debug.Log("Set color SkyBlue");
        }else{
            // GetComponent<Image>().color = new Color32(255,0,0,255);
            GetComponent<Image>().sprite = SpriteHard;
            child.GetComponent<Text>().color = new Color32(255,255,255,255);
            // Debug.Log("Set color Red");
        }

        if(StaticVar.stage < 11)
            child.GetComponent<Text>().text = $"{int.Parse(name.Substring(5))}";
        else if(StaticVar.stage < 21)
            child.GetComponent<Text>().text = $"{int.Parse(name.Substring(5)) + 10}";
        else
            child.GetComponent<Text>().text = $"{int.Parse(name.Substring(5)) + 20}";
    }
    public void Onclick(){
        string stage;
        if(StaticVar.type == "N")
            stage = "Normal";
        else
            stage = "Hard";
        StaticVar.stage = int.Parse(child.GetComponent<Text>().text);
        Debug.Log($"Static:stage  Set string:{StaticVar.stage}");
        CC.SceneChange($"{stage}Mode Stage{StaticVar.stage}","Play");

        // 以下遊び
        gameObject.AddComponent<Rigidbody2D>().gravityScale = 40;
        transform.position += new Vector3(0,0,10);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-8000,-2000));
        gameObject.GetComponent<Rigidbody2D>().AddTorque(5,ForceMode2D.Impulse);
    }
    
}
