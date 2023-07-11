using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMenu : MonoBehaviour
{
    [SerializeField] AudioSource backGroundSource;
    [SerializeField] AudioClip backGroundClip;
    public static bool IsMusicOn;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("ismusicon"))
        {
            PlayerPrefs.SetString("ismusicon","true");
            IsMusicOn = true;
        }else if (PlayerPrefs.HasKey("ismusicon") && PlayerPrefs.GetString("ismusicon") == "true")
        {
            IsMusicOn = true;
        }else if (PlayerPrefs.HasKey("ismusicon") && PlayerPrefs.GetString("ismusicon") == "false")
        {
            IsMusicOn = false;
        }


    }
    private void Update()
    {

        if (PlayerPrefs.GetString("ismusicon") == "true")
        {
            IsMusicOn=true;
        }else if (PlayerPrefs.GetString("ismusicon") == "false")
        {
            IsMusicOn = false;
        }


        if (IsMusicOn && !backGroundSource.isPlaying)
        {
            backGroundSource.clip = backGroundClip;
            backGroundSource.Stop();
            backGroundSource.Play();
        }
        else if(!IsMusicOn)
        {
            backGroundSource.Stop();
        }
    }
}
