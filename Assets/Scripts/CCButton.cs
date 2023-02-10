using UnityEngine;
using System.Threading.Tasks;

public class CCButton : MonoBehaviour
{
    ChangerCanvas CC;
    string[] SceneName;
    private void Start() {
        CC = GameObject.Find("ChangerCanvas").GetComponent<ChangerCanvas>();
        SceneName = name.Split('-');
    }
    public void SwitchScene()
    {
        if(StaticVar.gameMode == 0)
            CC.SceneChange(SceneName[2],SceneName[1]);
        else
            CC.SceneChange("Exit","Mainmenu");
            Task.Run(async delegate{
                await Task.Delay(1000);
                StaticVar.gameMode = 0;
            });
    }
}
