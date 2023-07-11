using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController1 : MonoBehaviour
{
    [SerializeField] Text[] values2 = new Text[50];
    List<int> valueInt2 = new List<int>(50);
    public GameObject Text;

    private void Start()
    {
        CardValues2();
        GetToText();
    }
    void GetToText()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(0));

            txt.name = "Values " + i.ToString();
            values2[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values2[i].text = valueInt2[i].ToString();
        }

        for (int j = 30; j < values2.Length; j++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(1));

            txt.name = "Values " + j.ToString();
            values2[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values2[j].text = valueInt2[j].ToString();
        }

    }
    void CardValues2()
    {
        for (int f = 1; f < 100; f += 2)
        {
            valueInt2.Add(f);
           
        }
    }
}
