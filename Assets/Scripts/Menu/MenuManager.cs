using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    GameObject SelectLanguage,MenuScreen,TxtPanel,BtnPanel,OynaBtn,CikisBtn,AyarlarBtn,TurkishBtn,EnglishBtn,asa1,asa2;
    [SerializeField] GameObject settingpanel,mainmenubtn;
    [SerializeField] Text leveltext, usernametxt,detailname,detaillevel;

    [SerializeField]ParticleSystem MenuEffect;

    int kademe=0;

    public bool isopenSetting=false; 
   

    Vector2 StartBtnGirisKonum = new Vector2(50, 0);
    Vector2 ExitBtnGirisKonum = new Vector2(-50, 0);
    Vector2 SettingBtnGirisKonum = new Vector2(0, 50);
    
    Vector2 StartBtnBaslangicKonum = new Vector2(-1000, 0);
    Vector2 ExitBtnBaslangicKonum = new Vector2(1000, 0);
    Vector2 SettingBtnBaslangicKonum = new Vector2(0, -1000);
    private void Awake()
    {
        #region GameObjeAtamalari
        OynaBtn = GameObject.Find("OynaBtn");
        CikisBtn = GameObject.Find("CikisBtn");
        AyarlarBtn = GameObject.Find("AyarlarBtn");
        SelectLanguage = GameObject.Find("SelectLanguage");
        MenuScreen = GameObject.Find("MenuScreen");
        TxtPanel = GameObject.Find("TxtPanel");
        BtnPanel = GameObject.Find("BtnPanel");
        asa1 = GameObject.Find("asa1");
        asa2 = GameObject.Find("asa2");


        #endregion
        #region BtnKonumlar
        asa1.SetActive(false);
        asa2.SetActive(false);
        asa1.GetComponent<RectTransform>().anchoredPosition = new Vector3(1000, 0, 0);
        asa2.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1000, 0, 0);
        OynaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        AyarlarBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        CikisBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        OynaBtn.GetComponent<RectTransform>().anchoredPosition = StartBtnBaslangicKonum;
        CikisBtn.GetComponent<RectTransform>().anchoredPosition = ExitBtnBaslangicKonum;
        AyarlarBtn.GetComponent<RectTransform>().anchoredPosition = SettingBtnBaslangicKonum;
        BtnPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        TxtPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        SelectLanguage.GetComponent<RectTransform>().localScale = Vector3.zero;
        MenuScreen.GetComponent<RectTransform>().localScale = Vector3.zero;
        settingpanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        #endregion

        
    }
    
    private void Start()
    {
        DilAyarlari();
        Debug.Log(PlayerPrefs.GetString("language"));


        //SelectLanguage.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    private void DilAyarlari()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            SelectLanguage.GetComponent<RectTransform>().DOScale(0, 0);
            if(!isopenSetting)
                MenuAcilis();

            if (PlayerPrefs.GetString("language") == "English")
            {
                OynaBtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Play";
                CikisBtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Exit";
                AyarlarBtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Settings";
                mainmenubtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Main Menu";
                if (PlayerPrefs.HasKey("username"))
                {
                    usernametxt.gameObject.SetActive(true);
                    leveltext.gameObject.SetActive(true);
                    usernametxt.text = "Username: " + PlayerPrefs.GetString("username");
                    leveltext.text = "Level: " + "Begginer/" + kademe.ToString();
                }
                else if (!PlayerPrefs.HasKey("username"))
                {
                    usernametxt.text = "Username: Not Yet";
                    leveltext.text = "Level: Not Yet";
                }
            }
            else if (PlayerPrefs.GetString("language") == "Türkçe")
            {
                OynaBtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Oyna";
                CikisBtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Çýkýþ";
                AyarlarBtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Ayarlar";
                mainmenubtn.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Ana Menü";
                if (PlayerPrefs.HasKey("username"))
                {
                    usernametxt.gameObject.SetActive(true);
                    leveltext.gameObject.SetActive(true);

                    usernametxt.text = "Kullanýcý Adý: " + PlayerPrefs.GetString("username");
                    leveltext.text = "Seviye: " + "Acemi/" + kademe.ToString();
                }
                else if (!PlayerPrefs.HasKey("username"))
                {
                    usernametxt.text = "Kullanýcý Adý: Henüz Yok";
                    leveltext.text = "Seviye: Henüz Yok";
                }
            }

        }
        else if (!PlayerPrefs.HasKey("language"))
        {
            DilSecimEkrani();
            MenuScreen.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    private void Update()
    {
        if (!isopenSetting)
        {
            settingpanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        DilAyarlari();
    }
    public void SelectTurkisBtn()
    {
        PlayerPrefs.SetString("language", "Türkçe");
        SelectLanguage.GetComponent<RectTransform>().DOScale(0, 0.2f);
        MenuEffect.Stop();
        MenuEffect.Play();
    }
    public void SelectEnglishBtn()
    {
        PlayerPrefs.SetString("language", "English");
        SelectLanguage.GetComponent<RectTransform>().DOScale(0, 0.2f);
        MenuEffect.Stop();
        MenuEffect.Play();
   
    }

    public void SelectSettingsBtn()
    {
        isopenSetting = true;
        detaillevel.gameObject.SetActive(PlayerPrefs.HasKey("levelen") && PlayerPrefs.HasKey("leveltr"));
        detailname.gameObject.SetActive(PlayerPrefs.HasKey("levelen") && PlayerPrefs.HasKey("leveltr"));

        detaillevel.text = (PlayerPrefs.GetString("language") == "English") ? "Level: " + PlayerPrefs.GetString("levelen") : "Seviye: " + PlayerPrefs.GetString("leveltr");
        detailname.text = (PlayerPrefs.GetString("language") == "English") ? "Username: " + PlayerPrefs.GetString("username") : "Kullanýcý Adý: " + PlayerPrefs.GetString("username");
        MenuScreen.GetComponent<RectTransform>().DOScale(0, .4f).OnComplete(() =>
       {
           settingpanel.GetComponent<RectTransform>().DOScale(1, 1);
       });
        
    }
    public void BackMenuBtnSelect()
    {
        MenuAcilis();
        isopenSetting = false;
        
    }
    void MenuAcilis()
    {

        MenuScreen.GetComponent<RectTransform>().DOScale(1, 0.3f);
        BtnPanel.GetComponent<RectTransform>().DOScale(1, 1.5f).SetEase(Ease.OutBack);
        TxtPanel.GetComponent<RectTransform>().DOScale(1, 1.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            OynaBtn.GetComponent<RectTransform>().localScale = Vector3.one;
            AyarlarBtn.GetComponent<RectTransform>().localScale = Vector3.one;
            CikisBtn.GetComponent<RectTransform>().localScale = Vector3.one;
            OynaBtn.GetComponent<RectTransform>().DOAnchorPos(StartBtnGirisKonum, 0.5f).SetEase(Ease.OutBack);
            CikisBtn.GetComponent<RectTransform>().DOAnchorPos(ExitBtnGirisKonum, 0.5f).SetEase(Ease.OutBack);
            AyarlarBtn.GetComponent<RectTransform>().DOAnchorPos(SettingBtnGirisKonum, 0.5f).SetEase(Ease.OutBack);
        });
    
    }
    void DilSecimEkrani()
    {
        if (PlayerPrefs.GetString("language")==null||PlayerPrefs.GetString("language")==""||!PlayerPrefs.HasKey("language"))
        {
            SelectLanguage.GetComponent<RectTransform>().DOScale(1, 1.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                asa1.SetActive(true);
                asa2.SetActive(true);
                asa1.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.5f).SetEase(Ease.OutBack);
                asa2.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-148, 0), 1.5f).SetEase(Ease.OutBack);
            });
        }
        
    }
    public void SelectedStartBtn()
    {
        if (PlayerPrefs.HasKey("leveltr") || PlayerPrefs.HasKey("levelen"))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void SelectedExitBtn()
    {
        
        Application.Quit();
       
    }
}
