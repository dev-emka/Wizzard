using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizzard1 : MonoBehaviour
{
    Rigidbody2D myrb;
    Animator myanim;
    GameObject MagicStake;
    Level1Manager level1;
    [SerializeField] AudioClip[] TalkClips;
    [SerializeField] AudioClip smileClips;
    AudioSource audioSource;
    [SerializeField] AudioSource smileSource;

    [SerializeField] GameObject cevapPanel;
    public float speed;

    public bool isLookRight, isGamePlay;
    public bool isTalk,issmile;
    private void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        level1= GameObject.FindObjectOfType<Level1Manager>();
        MagicStake = GameObject.Find("sihirlidegnek");
        isLookRight = true;
        isGamePlay = false;
        isTalk = false;
        myrb = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizaontalSpeed = Input.GetAxis("Horizontal");
        float verticalSpeed = Input.GetAxis("Vertical");
        myanim.SetBool("isTalk", isTalk);
        myanim.SetBool("issmile", issmile);
        if (isTalk)
        {
            TalkSound();
        }
        else
        {
            audioSource.Stop();
        }

            //} else if (!isTalk)
        //{
        //    audioSource.Stop();
        //}
        
        
        
        //if (myanim != null||myrb!=null||isGamePlay)
        //{
        //    HorizontalMove(horizaontalSpeed, verticalSpeed);
        //    Flip(horizaontalSpeed);
        //}
    }

    public void StartScreenAnim()
    {
        gameObject.transform.DOMoveX(15, 1.5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            level1.StartScreen();
        });
    }
    private void HorizontalMove(float horizaontalSpeed, float verticalSpeed)
    {
        myrb.velocity = new Vector2(horizaontalSpeed * speed * Time.deltaTime, verticalSpeed * speed * Time.fixedDeltaTime);
        myanim.SetFloat("speed", Math.Abs(myrb.velocity.x));
       
    }

    void Flip(float xspeed)
    {
        if (xspeed > 0 && !isLookRight || xspeed < 0 && isLookRight)
        {
            isLookRight = !isLookRight;

            Vector3 looking = transform.localScale;

            looking.x *= -1;

            transform.localScale = looking;

        }
    }

    public void TalkSound()
    {
        if (!isTalk)
        {
            return;
        }else if(isTalk)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = TalkClips[UnityEngine.Random.Range(0, TalkClips.Length)];
                audioSource.Stop();
                audioSource.Play();
            }
        }
        

        
    }

    public void SmileSound()
    {
        if (!issmile)
        {
            return;
        }
        else if (issmile)
        {
            if (!smileSource.isPlaying)
            {
                smileSource.clip = smileClips;
                smileSource.Stop();
                audioSource.Stop();
                smileSource.Play();

            }
            
        }
    }public void StopSmileSound()
    {
        smileSource.Stop();
    }
    public void AfterTalkScreen()
    {
        gameObject.transform.DOMoveX(150, 1f).OnComplete(()=>cevapPanel.SetActive(true));
    }

    public void GameOverMove()
    {
        issmile = true;
        gameObject.transform.DOMoveX(16, 1f).OnComplete(() =>
        {
            
            SmileSound();
           
        });
        Invoke("StopSmileSound", 2f);
    }
}
