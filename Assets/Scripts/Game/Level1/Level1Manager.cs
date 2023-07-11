using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] Text talkTxt,leveltxt,overtxt1,overtxt2,findtxt;
    [SerializeField] GameObject acilisEkran, sise1, sise2, sise3, overPanel,skipBtn,replaybtn,homebtn;
    string sise1txt,sise2txt, sise3txt;
    string[] talkstr = new string[2] {"Bu 4 þiþenin içinde 4 farklý sývý var. Bu 4 sývýdan hangisi zehirli bulmalýsýn. Unutma sadece 3 hakkýn var hehehehhehe", "There are 4 different liquids in these 4 bottles. Which of these 4 liquids should you find poisonous? Remember you only have 3 rights hehehehhehehhe" };
    float delay = 0.07f;
    [SerializeField]Wizzard1 wizzard1;

    private void Awake()
    {
       
        if (!PlayerPrefs.HasKey("leveltr")&&!PlayerPrefs.HasKey("levelen"))
        {
            PlayerPrefs.SetString("leveltr", "Acemi/0");
            PlayerPrefs.SetString("levelen", "Begginer/0");
        }else if (PlayerPrefs.HasKey("leveltr")&&PlayerPrefs.HasKey("levelen"))
        {
            if (PlayerPrefs.GetString("language") == "Türkçe")
            {
                leveltxt.text = "Seviye: " + PlayerPrefs.GetString("leveltr").ToString();
            }else if (PlayerPrefs.GetString("language") == "English")
            {
                leveltxt.text = "Level: " + PlayerPrefs.GetString("levelen").ToString();
            }
        }
       
    }
    private void Start()
    {
        acilisEkran.GetComponent<CanvasGroup>().DOFade(0, 0.4f).SetDelay(0.1f).OnComplete(() => {
            Destroy(acilisEkran);
            wizzard1 = GameObject.FindObjectOfType<Wizzard1>();
            wizzard1.StartScreenAnim();
        });
    }

    private void Update()
    {
        findtxt.text = (PlayerPrefs.GetString("language") == "English") ? "Find The Toxic One" : "Zehirli Olaný Bul";
        skipBtn.gameObject.SetActive(wizzard1.isTalk);
        sise1txt = sise1.GetComponent<Image>().sprite.name;
        sise2txt = sise2.GetComponent<Image>().sprite.name;
        sise3txt = sise3.GetComponent<Image>().sprite.name;

        if (sise1txt != "bossise" && sise2txt != "bossise" && sise3txt != "bossise" && sise1txt != "4lukarýsým" && sise2txt != "4lukarýsým" && sise3txt != "4lukarýsým")
        {
            GameOverScreen();
        }
    }

    public void StartScreen()
    {
        talkTxt.GetComponentInParent<CanvasGroup>().DOFade(1,0.2f);
        StartCoroutine(WriteToText());
    
        wizzard1.isGamePlay = false;
    }
    IEnumerator WriteToText()
    {

        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "Türkçe")
            {
                wizzard1.isTalk = true;
                foreach (char cg in talkstr[0])
                {
                    talkTxt.text += cg.ToString();
                    yield return new WaitForSeconds(delay);
                    if (talkTxt.text == "Bu 4 þiþenin içinde 4 farklý sývý var. Bu 4 sývýdan hangisi zehirli bulmalýsýn.")
                    {
                        talkTxt.text = "";
                        
                    }
                    if (talkTxt.text == " Unutma sadece 3 hakkýn var")
                    {
                        wizzard1.issmile = true;
                        wizzard1.SmileSound();

                    }
                }
                wizzard1.issmile = false;
                wizzard1.isTalk = false;
                talkTxt.GetComponentInParent<CanvasGroup>().DOFade(0, .2f).OnComplete(() => wizzard1.AfterTalkScreen());
            }
            else if (PlayerPrefs.GetString("language") == "English")
            {
                wizzard1.isTalk = true;
                foreach(char ct in talkstr[1])
                {
                    talkTxt.text += ct.ToString();
                    yield return new WaitForSeconds(delay);
                    if(talkTxt.text== "There are 4 different liquids in these 4 bottles. Which of these 4 liquids should you find poisonous?")
                    {
                        talkTxt.text = "";
                        
                    }
                    if (talkTxt.text == " Remember you only have 3 rights")
                    {
                        wizzard1.issmile = true;
                        wizzard1.SmileSound();
                    }
                }
                wizzard1.issmile = false;
                wizzard1.isTalk = false;
                talkTxt.GetComponentInParent<CanvasGroup>().DOFade(0, .2f).OnComplete(()=>wizzard1.AfterTalkScreen());
            }
        }

    }
    void GameOverScreen()
    {
        homebtn.transform.GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetString("language") == "English") ? "Main Menu" : "Ana Menu";
        replaybtn.transform.GetChild(0).GetComponent<Text>().text = (PlayerPrefs.GetString("language") == "English") ? "Replay" : "Tekrar Oyna";
        overtxt1.text = (PlayerPrefs.GetString("language") == "English") ? "Game Over":"Oyun Bitti";
        overtxt2.text = (PlayerPrefs.GetString("language") == "English") ? "Level: "+PlayerPrefs.GetString("levelen"):"Seviye: "+PlayerPrefs.GetString("leveltr");
        overPanel.SetActive(true);
        overPanel.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        wizzard1.GameOverMove();
    }

    public void ReplayBtnSlct()
    {
        SceneManager.LoadScene(2);
    }

    public void HomeBtnSlct()
    {
        SceneManager.LoadScene(0);
    }
    public void SkipTextDown()
    {
        delay = 0.0001f;
    }

    public void SkipTextUp()
    {
        delay = 0.07f;
    }

}
