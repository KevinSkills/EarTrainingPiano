using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeItemSlot : ItemSlot
{


    Vector2 pivotDir;

    Image image;

    public RectTransform positionToConnect;

    public delegate void GameObjectFunc(GameObject g);

    public GameObjectFunc onDrop;



    private void Awake()
    {
        image = gameObject.GetComponent<Image>();


        pivotDir = new Vector2(1 - positionToConnect.pivot.x, 1 - positionToConnect.pivot.y);
    }


    public override void OnDrop(PointerEventData eventData) //make child and position gameobject. Also clal onDrop functions
    {
        base.OnDrop(eventData);
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            RectTransform rt = eventData.pointerDrag.GetComponent<RectTransform>();
            rt.parent = transform;


            rt.pivot = pivotDir;


            rt.anchorMax = pivotDir;
            rt.anchorMin = pivotDir;
            print("pivot " + rt.pivot);
            

            rt.position = positionToConnect.position;

         


            if(onDrop != null)
            onDrop(eventData.pointerDrag.gameObject);
        }
    }






    public void Update()
    {
        if (connected) image.color = Color.green;
        else image.color = Color.red;
    }

}
