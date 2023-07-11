using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CevapBox : MonoBehaviour, IDropHandler
{
   
    
    [SerializeField] Sprite cevapSise,bossise;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject Cevapdropped=eventData.pointerDrag;

        if (Cevapdropped.name == "trueReply")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = cevapSise;
            Cevapdropped.GetComponent<Image>().sprite = bossise;
        }
        else
        {
            
            transform.GetChild(0).GetComponent<Image>().sprite = Cevapdropped.transform.GetComponent<Image>().sprite;
        }
        

    }
}
