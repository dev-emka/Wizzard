using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropBox4 : MonoBehaviour,IDropHandler
{
    [SerializeField] Sprite[] karisimlar = new Sprite[11];
    bool ilkkarisim, ikincikarisim;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
       

        if (dropped.name == "iksirred" && !ilkkarisim)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[6];
            dropped.GetComponent<Dragiksir>().isBos = true;
            dropped.name = "bossise";
            ilkkarisim = true;
            transform.GetChild(0).gameObject.name = "yesilkirmizi";
        }
        else if (dropped.name == "iksirblue" && !ilkkarisim)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[8];
            dropped.GetComponent<Dragiksir>().isBos = true;
            dropped.name = "bossise";
            ilkkarisim=true;
            transform.GetChild(0).gameObject.name = "maviyesil";
        }
        else if (dropped.name == "iksirpurple" && !ilkkarisim)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[10];
            dropped.GetComponent<Dragiksir>().isBos = true;
            dropped.name = "bossise";
            ilkkarisim = true;
            transform.GetChild(0).gameObject.name = "moryesil";
        }


        GameObject dropped2 = eventData.pointerDrag;
        if (!ilkkarisim)
            return;

        switch (transform.GetChild(0).gameObject.name)
        {
            case "yesilkirmizi":



                if (dropped2.name == "iksirpurple" || dropped2.name == "iksirblue")
                {
                    transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[Random.Range(0, 4)];
                    dropped2.name = "bossise";
                    ikincikarisim = true;

                    transform.GetChild(0).gameObject.name = "karisim3";
                }


                break;
            case "moryesil":

                if (dropped2.name == "iksirblue" || dropped2.name == "iksirred")
                {
                    transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[Random.Range(0, 4)];
                    dropped2.name = "bossise";
                    ikincikarisim = true;

                    transform.GetChild(0).gameObject.name = "karisim3";
                }
                break;
            case "maviyesil":
                if (dropped2.name == "iksirred" || dropped2.name == "iksirpurple")
                {
                    transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[Random.Range(0, 4)];
                    dropped2.name = "bossise";
                    ikincikarisim = true;

                    transform.GetChild(0).gameObject.name = "karisim3";
                }
                break;
        }

        GameObject dropped3 = eventData.pointerDrag;

        if (!ikincikarisim)
            return;

        if (transform.GetChild(0).gameObject.name == "karisim3")
        {
            if (dropped3.name == "iksirblue")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[4];
                dropped3.name = "bossise";
                transform.GetChild(0).gameObject.name = "trueReply";
            }
            else if (dropped3.name == "iksirpurple")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[4];
                dropped3.name = "bossise";
                transform.GetChild(0).gameObject.name = "trueReply";
            }
            else if (dropped3.name == "iksirgreen")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[4];
                dropped3.name = "bossise";
                transform.GetChild(0).gameObject.name = "trueReply";
            }
        }

    }

}
