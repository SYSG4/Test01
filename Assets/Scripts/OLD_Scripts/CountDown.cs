using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour
{
    double count;
    [SerializeField] Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 3.999;
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        
        if (count >= 1)
            text.text = $"{Math.Floor(count).ToString("0")}";
        else
        {
            text.text = "Start!";
        }
        if (count < 0)
            this.gameObject.SetActive(false);
    }
}
