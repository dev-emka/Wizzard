using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController6 : MonoBehaviour
{
    [SerializeField] Text[] values7 = new Text[49];
    List<int> valueInt7 = new List<int>(49);
    public GameObject Text;

    private void Start()
    {
        CardValues7();
        GetToText();
    }


    void GetToText()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(0));

            txt.name = "Values " + i.ToString();
            values7[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values7[i].text = valueInt7[i].ToString();
        }

        for (int j = 30; j < values7.Length; j++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(1));

            txt.name = "Values " + j.ToString();
            values7[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values7[j].text = valueInt7[j].ToString();
        }

    }
    void CardValues7()
    {
        valueInt7.Add(4);
        valueInt7.Add(5);
        valueInt7.Add(6);
        valueInt7.Add(7);
        valueInt7.Add(12);
        valueInt7.Add(13);
        valueInt7.Add(14);
        valueInt7.Add(15);
        valueInt7.Add(20);
        valueInt7.Add(21);
        valueInt7.Add(22);
        valueInt7.Add(23);
        valueInt7.Add(28);
        valueInt7.Add(29);
        valueInt7.Add(30);
        valueInt7.Add(31);
        valueInt7.Add(36);
        valueInt7.Add(37);
        valueInt7.Add(38);
        valueInt7.Add(39);
        valueInt7.Add(44);
        valueInt7.Add(45);
        valueInt7.Add(46);
        valueInt7.Add(47);
        valueInt7.Add(52);
        valueInt7.Add(53);
        valueInt7.Add(54);
        valueInt7.Add(55);
        valueInt7.Add(60);
        valueInt7.Add(61);
        valueInt7.Add(62);
        valueInt7.Add(63);
        valueInt7.Add(68);
        valueInt7.Add(69);
        valueInt7.Add(70);
        valueInt7.Add(71);
        valueInt7.Add(76);
        valueInt7.Add(77);
        valueInt7.Add(78);
        valueInt7.Add(79);
        valueInt7.Add(84);
        valueInt7.Add(85);
        valueInt7.Add(86);
        valueInt7.Add(87);
        valueInt7.Add(92);
        valueInt7.Add(93);
        valueInt7.Add(94);
        valueInt7.Add(95);
        valueInt7.Add(100);
    }
}
