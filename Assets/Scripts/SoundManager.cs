using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    AudioSource audioSource;
    public new bool enabled;
    //Toggle toggle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //toggle = GetComponent<Toggle>();

        enabled = true;
        audioSource.volume = 1.0f;
    }

    void Update()
    {

        if (true)//toggle.enabled)
        {
            audioSource.volume = 0.5f;
        }
        else
        {
            audioSource.volume = 0.0f;
        }
    }

}

