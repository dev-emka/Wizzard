using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController2 : MonoBehaviour
{
    [SerializeField] Text[] values3 = new Text[37];

    List<int> valueInt3 = new List<int>(37);
    public GameObject Text;
    void CardValues3()
    {
        for (int y = 64; y < 101; y++)
        {
            valueInt3.Add(y);
            
        }
    }

    void GetToText()
    {
        for (int i = 0; i < valueInt3.Count/2; i++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(0));

            txt.name = "Values " + i.ToString();
            values3[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values3[i].text = valueInt3[i].ToString();
        }

        for (int j = valueInt3.Count/2; j < values3.Length; j++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(1));

            txt.name = "Values " + j.ToString();
            values3[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values3[j].text = valueInt3[j].ToString();
        }

    }

    private void Start()
    {
        CardValues3();
        GetToText();
    }

}
