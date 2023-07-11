using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingScreenManager : MonoBehaviour
{
    [SerializeField] GameObject ChangeTurkish,ChangeEnglish,DeleteBtn;
    [SerializeField] Text musictxt,musicbtntxt,detailname,detailLevel;

    MenuManager menuManager;

    private void Awake()
    {
        menuManager = GameObject.FindObjectOfType<MenuManager>();
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "English")
            {
                DeleteBtn.transform.GetChild(0).GetComponent<Text>().text = "Reset Player";
                musictxt.text = "Music: ";
                musicbtntxt.text = (SoundManagerMenu.IsMusicOn) ? "On" : "Off";
                ChangeTurkish.GetComponent<Button>().interactable = true;
                ChangeEnglish.GetComponent<Button>().interactable = false;
                if (PlayerPrefs.HasKey("username"))
                {
                    detailname.gameObject.SetActive(true);
                    detailLevel.gameObject.SetActive(true);
                    detailname.text = "Username: " + PlayerPrefs.GetString("username").ToString();
                    detailLevel.text = "Level: " + "Begginer/0";
                }else if (!PlayerPrefs.HasKey("username"))
                {
                    detailname.gameObject.SetActive(false);
                    detailLevel.gameObject.SetActive(false);
                }
                
            }
            else if (PlayerPrefs.GetString("language") == "Türkçe")
            {
                DeleteBtn.transform.GetChild(0).GetComponent<Text>().text = "Oyuncu Sýfýrla";
                musictxt.text = "Müzik: ";
                musicbtntxt.text = (SoundManagerMenu.IsMusicOn) ? "Açýk" : "Kapalý";
                ChangeTurkish.GetComponent<Button>().interactable = false;
                ChangeEnglish.GetComponent<Button>().interactable = true;
                if (PlayerPrefs.HasKey("username"))
                {
                    detailname.gameObject.SetActive(true);
                    detailname.text = "Kullanýcý Adý: " + PlayerPrefs.GetString("username").ToString();
                    detailLevel.text = "Seviye: " + "Acemi/0";
                }else if (!PlayerPrefs.HasKey("username"))
                {
                    detailname.gameObject.SetActive(false);
                    detailLevel.gameObject.SetActive(false);
                }
            }
        }
    }
    public void TurkishBtnChange()
    {
        PlayerPrefs.SetString("language", "Türkçe");
    }
    
    public void EnglishBtnChange()
    {
        PlayerPrefs.SetString("language", "English");
    }
    public void MusicOnBtn()
    {
        PlayerPrefs.SetString("ismusicon", (SoundManagerMenu.IsMusicOn) ? "false" : "true");
    }

    public void ResetPlayer()
    {
        menuManager.isopenSetting = false;
        PlayerPrefs.DeleteAll();
    }
}
