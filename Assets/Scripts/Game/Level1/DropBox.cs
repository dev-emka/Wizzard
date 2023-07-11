using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropBox : MonoBehaviour,IDropHandler
{
    [SerializeField] Sprite[] karisimlar = new Sprite[11];
    bool ilkkarisim,ikincikarisim;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        

        if (dropped.name == "iksirblue"&&!ilkkarisim)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[7];
            dropped.GetComponent<Dragiksir>().isBos = true;
            dropped.name = "bossise";
            transform.GetChild(0).gameObject.name = "mavikirmizi";
            ilkkarisim = true;
        }
        else if(dropped.name == "iksirpurple"&& !ilkkarisim)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[5];
            dropped.GetComponent<Dragiksir>().isBos = true;
            dropped.name = "bossise";
            ilkkarisim = true;
            transform.GetChild(0).gameObject.name = "morkirmizi";
        }
        else if(dropped.name == "iksirgreen"&& !ilkkarisim)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[6];
            dropped.GetComponent<Dragiksir>().isBos = true;
            dropped.name = "bossise";
            ilkkarisim = true;
            transform.GetChild(0).gameObject.name = "yesilkirmizi";
        }


        GameObject dropped2 = eventData.pointerDrag;
        if (!ilkkarisim)
            return;

        switch (transform.GetChild(0).gameObject.name)
        {
            case "mavikirmizi":
                
                
                
                if (dropped2.name == "iksirpurple" || dropped2.name == "iksirgreen")
                {
                    transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[Random.Range(0, 4)];
                    dropped2.name = "bossise";
                    transform.GetChild(0).gameObject.name = "karisim3";
                    ikincikarisim= true;
                }
                
                
                break;
            case "morkirmizi":
               
                if(dropped2.name == "iksirgreen" || dropped2.name == "iksirblue")
                {
                    transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[Random.Range(0, 4)];
                    dropped2.name = "bossise";
                    ikincikarisim= true;

                    transform.GetChild(0).gameObject.name = "karisim3";
                }
                break;
            case "yesilkirmizi":
                if (dropped2.name == "iksirblue" || dropped2.name == "iksirpurple")
                {
                    transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[Random.Range(0, 4)];
                    dropped2.name = "bossise";
                    ikincikarisim= true;

                    transform.GetChild(0).gameObject.name = "karisim3";
                }
                break;
        }

        GameObject dropped3 = eventData.pointerDrag;

        if (!ikincikarisim)
            return;

        if (transform.GetChild(0).gameObject.name == "karisim3")
        {
            if(dropped3.name == "iksirblue")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[4];
                dropped3.name = "bossise";
                transform.GetChild(0).gameObject.name = "trueReply";
            }else if (dropped3.name == "iksirpurple")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[4];
                dropped3.name = "bossise";
                transform.GetChild(0).gameObject.name = "trueReply";
            }else if(dropped3.name == "iksirgreen")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = karisimlar[4];
                dropped3.name = "bossise";
                transform.GetChild(0).gameObject.name = "trueReply";
            }
        }
       
    }

}
