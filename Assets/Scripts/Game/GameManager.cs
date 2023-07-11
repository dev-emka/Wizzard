using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEditor.AssetImporters;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] cards = new GameObject[7];
    [SerializeField] Text talkTxt;
    [SerializeField] InputField usernameField;
    [SerializeField] ParticleSystem inputeffect,kapieffec;
    [SerializeField] GameObject startBtn,kapi,arka,skipbtn;
    float delay=0.08f;
    Wizzard wizzard;

    string[] talkStr = new string[2] {"Ho�geldin"+"\n"+"Demek B�y�c� olmak isteyen yeni ��renci sensin. hehehehe"+"\n"+"Bu hi� kolay olmayacak. �ncelikle t�m ad�mlar� ba�ar�l� bir �ekilde tamamlaman gerekiyor"
        ,"Welcome"+"\n"+"So the new student who wants to be a magician is you. hehehehe"+"\n"+"This will not be easy. First you have to complete all the steps successfully"};
    string[] nameWhat = new string[2]{"�ncelikle �smin nedir veya bir takma ad�n var m�?","first of all what is your name or do you have a nickname"};

    private void Start()
    {
        startBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        if (PlayerPrefs.HasKey("username"))
        {
            PlayGame();
        }
        else
        {
            wizzard = GameObject.FindObjectOfType<Wizzard>();
            wizzard.StartScreenAnim();
        }
    }
    private void Update()
    {
        startBtn.GetComponent<Button>().interactable=(usernameField.text!="")?true:false;
        skipbtn.gameObject.SetActive(wizzard.isTalk);
    }
    public void StartScreen()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "T�rk�e")
            {
                startBtn.transform.GetChild(0).GetComponent<Text>().text = "Oyna";
            }else if (PlayerPrefs.GetString("language") == "English")
            {
                startBtn.transform.GetChild(0).GetComponent<Text>().text = "Start";
            }
        }
        StartCoroutine(WriteToText());
        
        wizzard.isGamePlay = false;
    }

    IEnumerator WriteToText()
    {
        if (PlayerPrefs.GetString("language") == "T�rk�e")
        {
            wizzard.isTalk = true;
            foreach (char i in talkStr[0])
            {
                talkTxt.text += i.ToString();
                yield return new WaitForSeconds(delay);
                if (talkTxt.text == "Ho�geldin" + "\n" + "Demek B�y�c� olmak isteyen yeni ��renci sensin.")
                {
                    wizzard.SmileSound();
                }
            }
            talkTxt.text = "";
            foreach (char i in nameWhat[0])
            {

                talkTxt.text += i.ToString();
                yield return new WaitForSeconds(delay);
            }
            wizzard.isTalk = false;
            inputeffect.Stop();
            inputeffect.Play();
            usernameField.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
            startBtn.GetComponent<RectTransform>().DOScale(1, 0.1f);
            wizzard.transform.DOMoveX(150, 0.5f);
            kapi.transform.DORotate(new Vector3(0, 180, 0), 1f);
            arka.gameObject.SetActive(true);
            kapieffec.Play();
        }
        else if (PlayerPrefs.GetString("language") == "English")
        {
            wizzard.isTalk = true;
            foreach (char i in talkStr[1])
            {
                talkTxt.text += i.ToString();
                yield return new WaitForSeconds(delay);
                if (talkTxt.text == "Welcome" + "\n" + "So the new student who wants to be a magician is you.")
                {
                    wizzard.SmileSound();
                }
            }
            talkTxt.text = "";
            foreach (char i in nameWhat[1])
            {

                talkTxt.text += i.ToString();
                yield return new WaitForSeconds(delay);
            }
            wizzard.isTalk = false;
            inputeffect.Stop();
            inputeffect.Play();
            usernameField.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
            startBtn.GetComponent<RectTransform>().DOScale(1, 0.1f);
            wizzard.transform.DOMoveX(150, 0.5f);
            kapi.transform.DORotate(new Vector3(0, 180, 0), 1f);
            arka.gameObject.SetActive(true);
            kapieffec.Play();

        }
        
        

    }

    void SavedUsername()
    {
        PlayerPrefs.SetString("username", usernameField.text);
    }
    
    public void PlayGame()
    {
        SavedUsername();
        arka.transform.DOScale(15, 2f).OnComplete(()=>SceneManager.LoadScene(2));
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
