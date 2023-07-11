using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizzard : MonoBehaviour
{
    Rigidbody2D myrb;
    Animator myanim;
    GameObject MagicStake;
    GameManager gameManager;
    [SerializeField] AudioClip[] TalkClips;
    [SerializeField] AudioClip smileClips;
    AudioSource audioSource;

    public float speed;

    public bool isLookRight, isGamePlay;
    public bool isTalk;
    private void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
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
        gameObject.transform.DOMoveX(0, 1.5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            gameManager.StartScreen();
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
        if (!isTalk)
        {
            return;
        }
        else if (isTalk)
        {
            audioSource.clip = smileClips;
            audioSource.Stop();
            audioSource.Play();
        }
    }
}
