using UnityEngine;
using UnityEngine.UI;

public class UGImageChanger : MonoBehaviour
{
    int num = 0;
    [SerializeField] GameObject UGImg;
    [SerializeField] Sprite[] Imgs ;
    void Start()
    {
        num = 0;
    }

    public void Onclick() {
        Debug.Log("imgChanged");
        num += 1;
        num = num % Imgs.GetLength(0);
        UGImg.GetComponent<Image>().sprite = Imgs[num];
    }
}
