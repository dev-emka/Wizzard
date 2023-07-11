using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class TouchController : MonoBehaviour
{
    public delegate void TouchEventDelegate(Vector2 swipePos);
    public static event TouchEventDelegate SwipeEvent;
    public static event TouchEventDelegate SwipeEndEvent;

    Vector2 TouchMove;
    public int minSwipeMove = 20;

    
    
    void MoveSwipe()
    {
        if (SwipeEvent != null)
        {
            SwipeEvent(TouchMove);
        }
    }

    void MoveSwipeEnd()
    {
        if (SwipeEndEvent != null)
        {
            SwipeEndEvent(TouchMove);
        }
    }

    
    string SwipeTouch(Vector2 SwipeMove)
    {
        string direction = "";
        if (math.abs(SwipeMove.x) > math.abs(SwipeMove.y))
        {
            direction = (SwipeMove.x >= 0) ? "sað" : "sol";
        }
        else
        {
            direction = (SwipeMove.y >= 0) ? "yukarý" : "aþaðý";
        }
        return direction;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                TouchMove = Vector2.zero;
               
            }else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                TouchMove += touch.deltaPosition;
                if(TouchMove.magnitude>minSwipeMove)
                {
                    MoveSwipe();
                    
                }
            }else if (touch.phase == TouchPhase.Ended)
            {
                MoveSwipeEnd();
            }
        }

        
    }
}
