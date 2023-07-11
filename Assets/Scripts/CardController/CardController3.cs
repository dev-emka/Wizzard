using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController3 : MonoBehaviour
{
    [SerializeField] Text[] values4 = new Text[37];
    List<int> valueInt4 = new List<int>(37);
    public GameObject Text;
    void CardValues4()
    {
        for (int h = 32; h < 64; h++)
        {
            valueInt4.Add(h);
            
            if (h == 63)
            {
                for (int z = 96; z < 101; z++)
                {
                    valueInt4.Add(z);
                   
                }
            }
        }
    }
    void GetToText()
    {
        for (int i = 0; i < valueInt4.Count / 2; i++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(0));

            txt.name = "Values " + i.ToString();
            values4[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values4[i].text = valueInt4[i].ToString();
        }

        for (int j = valueInt4.Count / 2; j < values4.Length; j++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(1));

            txt.name = "Values " + j.ToString();
            values4[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values4[j].text = valueInt4[j].ToString();
        }

    }

    private void Start()
    {
        CardValues4();
        GetToText();
    }
}
