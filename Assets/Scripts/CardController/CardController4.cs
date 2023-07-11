using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController4 : MonoBehaviour
{
    public GameObject Text;
    [SerializeField] Text[] values5 = new Text[48];
    List<int> valueInt5 = new List<int>(48);

    private void Start()
    {
        CardValues5();
        GetToText();
    }
    void GetToText()
    {
        for (int i = 0; i < 28; i++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(0));

            txt.name = "Values " + i.ToString();
            values5[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values5[i].text = valueInt5[i].ToString();
        }

        for (int j = 28; j < values5.Length; j++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(1));

            txt.name = "Values " + j.ToString();
            values5[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values5[j].text = valueInt5[j].ToString();
        }

    }
    void CardValues5()
    {
        for (int i = 16; i < 32; i++)
        {
            valueInt5.Add(i);
            
            if (i == 31)
            {
                for (int j = 48; j < 64; j++)
                {
                    valueInt5.Add(j);
                    
                    if (j == 63)
                    {
                        for (int z = 80; z < 96; z++)
                        {
                            valueInt5.Add(z);
                           
                        }

                    }
                }
            }

        }
    }
}
