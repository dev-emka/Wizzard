using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{

    //GameObject Pipil;
    public GameObject txts;
    [SerializeField] Text[] values1 = new Text[50];
  
    List<int>valueInt1= new List<int>(50);
   
  
    private void Awake()
    {
       // Pipil = transform.GetChild(2).gameObject;
        
    }

    private void Start()
    {
        CardValues1();
        GetToText();
       

    }
    void Update()
    {
        //Pipil.GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)*0.5f;
    }

    private void OnEnable()
    {
        TouchController.SwipeEvent += MoveSwipFnc;
        TouchController.SwipeEndEvent += SWipeMoveEnded;
    }
    private void OnDisable()
    {
        TouchController.SwipeEvent-= MoveSwipFnc;
        TouchController.SwipeEndEvent -= SWipeMoveEnded;
    }
    void GetToText()
    {
       for(int i = 0; i < 30; i++)
        {
            GameObject txt = Instantiate(txts, transform.GetChild(2).GetChild(0));
            
            txt.name = "Values " + i.ToString();
            values1[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values1[i].text = valueInt1[i].ToString();
        }
        
        for(int j = 30; j < values1.Length; j++)
        {
            GameObject txt = Instantiate(txts, transform.GetChild(2).GetChild(1));
            
            txt.name = "Values " + j.ToString();
            values1[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values1[j].text = valueInt1[j].ToString();
        }
        
    }
    void CardValues1()
    {
        
        for(int i=1;i<=50;i+=2) 
        {
            int sayi=i*2;
            valueInt1.Add(sayi);
            valueInt1.Add(sayi+1);
            
        }
    }

    
    

    void MoveSwipFnc(Vector2 MoveSwiping)
    {
        
    }
    void SWipeMoveEnded(Vector2 MoveSwiping)
    {
        
    }
}
