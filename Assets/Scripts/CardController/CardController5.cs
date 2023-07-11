using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController5 : MonoBehaviour
{
    [SerializeField] Text[] values6 = new Text[48];
    List<int> valueInt6 = new List<int>(48);
    public GameObject Text;


    private void Start()
    {
        CardValues6();
        GetToText();
    }
    void GetToText()
    {
        for (int i = 0; i < 28; i++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(0));

            txt.name = "Values " + i.ToString();
            values6[i] = txt.transform.GetChild(0).GetComponent<Text>();
            values6[i].text = valueInt6[i].ToString();
        }

        for (int j = 28; j < values6.Length; j++)
        {
            GameObject txt = Instantiate(Text, transform.GetChild(2).GetChild(1));

            txt.name = "Values " + j.ToString();
            values6[j] = txt.transform.GetChild(0).GetComponent<Text>();

            values6[j].text = valueInt6[j].ToString();
        }

    }
    void CardValues6()
    {
        valueInt6.Add(8);
        valueInt6.Add(9);
        valueInt6.Add(10);
        valueInt6.Add(11);
        valueInt6.Add(12);
        valueInt6.Add(13);
        valueInt6.Add(14);
        valueInt6.Add(15);
        valueInt6.Add(24);
        valueInt6.Add(25);
        valueInt6.Add(26);
        valueInt6.Add(27);
        valueInt6.Add(28);
        valueInt6.Add(29);
        valueInt6.Add(30);
        valueInt6.Add(31);
        valueInt6.Add(40);
        valueInt6.Add(41);
        valueInt6.Add(42);
        valueInt6.Add(43);
        valueInt6.Add(44);
        valueInt6.Add(45);
        valueInt6.Add(46);
        valueInt6.Add(47);
        valueInt6.Add(56);
        valueInt6.Add(57);
        valueInt6.Add(58);
        valueInt6.Add(59);
        valueInt6.Add(60);
        valueInt6.Add(61);
        valueInt6.Add(62);
        valueInt6.Add(63);
        valueInt6.Add(72);
        valueInt6.Add(73);
        valueInt6.Add(74);
        valueInt6.Add(75);
        valueInt6.Add(76);
        valueInt6.Add(77);
        valueInt6.Add(78);
        valueInt6.Add(79);
        valueInt6.Add(88);
        valueInt6.Add(89);
        valueInt6.Add(90);
        valueInt6.Add(91);
        valueInt6.Add(92);
        valueInt6.Add(93);
        valueInt6.Add(94);
        valueInt6.Add(95);
    }
}
