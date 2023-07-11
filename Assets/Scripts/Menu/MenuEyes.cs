using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEyes : MonoBehaviour
{
    bool Anim1;
    bool Anim2;
    bool Anim3;
    bool Anim4;
    private void Update()
    {
        EyesTurn();

    }

    private void EyesTurn()
    {
        if (gameObject.name == "eyes1"&&!Anim1)
        {
            Anim1 = true;
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(74, -8), 6f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            { transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 3f).OnComplete(() => Anim1 = false); }
            ) ;
        }
        
        if (gameObject.name == "eyes2"&&!Anim2)
        {
            Anim2 = true;
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(85, 22), 6f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            {
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 3f).OnComplete(() => Anim2 = false);
            }
            ) ;
        }
    
        if (gameObject.name == "eyes3"&&!Anim3)
        {
            Anim3 = true;
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(-68, -15), 6f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            { transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 3f).OnComplete(() => Anim3 = false); }
            
            ) ;
        }

        if (gameObject.name == "eyes4"&&!Anim4)
        {
            Anim4 = true;
            transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(-92, 18), 6f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
            { transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 3f).OnComplete(() => Anim4 = false); }
            ) ;
        }
    }
}
