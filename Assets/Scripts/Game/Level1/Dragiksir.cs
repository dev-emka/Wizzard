using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragiksir : MonoBehaviour,IBeginDragHandler, IEndDragHandler,IDragHandler
{
    float deltaX, deltaY;
    bool oveAllowed;
    [HideInInspector]public Transform parentAfterDrag;
    public Image ýmage;
    public Sprite bossise;
    public Transform paneltr;

    public bool isBos;
    private void Awake()
    {
        paneltr = transform.parent;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite.name != "bossise"||gameObject.name!="bossise")
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            ýmage.raycastTarget = false;
        }
        else
        {
            Debug.Log("bu þiþe boþ");
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.SetParent(paneltr);
        ýmage.raycastTarget = true;
        if (gameObject.name == "bossise")
        {
            gameObject.GetComponent<Image>().sprite = bossise;
        }
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite.name != "bossise")
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                 if (touch.phase == TouchPhase.Moved)
                 {
                    transform.position = touchPos;
                    transform.rotation = Quaternion.Euler(0, 0, 120);
                    
                 }
            }
        }
    }
}
