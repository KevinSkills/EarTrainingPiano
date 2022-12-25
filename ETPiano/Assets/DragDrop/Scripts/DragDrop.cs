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
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private Canvas canvas;

    public ItemSlot connectedTo;

    Transform startParent;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake() {

        canvas = GameObject.FindWithTag("LogicCanvas").GetComponent<Canvas>();

        startParent = transform.parent;

        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        if(connectedTo != null) connectedTo.disconnect();
        transform.parent = startParent;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public virtual void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public virtual void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

}
