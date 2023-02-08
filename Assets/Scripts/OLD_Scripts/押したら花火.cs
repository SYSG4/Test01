using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 押したら花火 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem particle;
    [SerializeField] GameObject hanabi;
    [SerializeField] GameObject hanabi2;
    [SerializeField] GameObject hanabi3;
    [SerializeField] GameObject hanabi4;

    // int count = 1;

    // 1. 再生
    public void Play()
    {
        hanabi.SetActive(true);
        particle.Play();
        if(hanabi == true)
        {
            hanabi2.SetActive(true);
        }

        if(hanabi2 == true)
        {
            hanabi3.SetActive(false);
        }

        if(hanabi3 == true)
        {
            hanabi4.SetActive(false);
        }
        // hanabi.SetActive(false);
    }

    // 2. 一時停止
    private void Pause()
    {
        particle.Pause();
    }

    // 3. 停止
    private void Stop()
    {
        particle.Stop();
    }
}

