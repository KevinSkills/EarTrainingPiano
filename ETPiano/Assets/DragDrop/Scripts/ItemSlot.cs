/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlot : HeObject, IDropHandler {
    public bool connected = false;

    

    
    public virtual void OnDrop(PointerEventData eventData) {



        
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;



            DragDrop dp = eventData.pointerDrag.GetComponent<DragDrop>();
            dp.connectedTo = this;
            

            connected = true;

            
        }

    }

    public void disconnect()
    {
        connected = false;
    }



}
