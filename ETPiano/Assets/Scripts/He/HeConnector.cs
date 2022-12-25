using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeConnector : MonoBehaviour
{
    public RectTransform r1;

    public RectTransform r2;

    public GameObject connectedTo;

    public RectTransform lineRect;




    private void Start()
    {
        
    }

    private void Update()
    {

        UpdateLine(GetScreenCoordinates(r1).position, GetScreenCoordinates(r2).position);
    }

    private void UpdateLine(Vector3 pointA, Vector3 pointB)
    {
        
       


        //PointA and PointB determined before this
        Vector3 midpoint = (pointA + pointB) / 2; //used to position line
        float pointDistance = (pointA - pointB).magnitude; //used for height of line

        //really need to figure out what all this does one of these days. Not even my first game using it...
        float angle = Mathf.Atan2(pointB.x - pointA.x, pointA.y - pointB.y);
        if (angle < 0.0) { angle += Mathf.PI * 2; }
        angle *= Mathf.Rad2Deg;

        float lineWidth = 1f;
        lineRect.position = midpoint; //move to midpoint, then expand to the correct size around it
        lineRect.sizeDelta =  new Vector2(lineWidth, pointDistance);
        
        lineRect.rotation = Quaternion.Euler(0, 0, angle); //rotate around the mid point

    }


    public Rect GetScreenCoordinates(RectTransform uiElement)
    {
        var worldCorners = new Vector3[4];
        uiElement.GetWorldCorners(worldCorners);
        var result = new Rect(
                      worldCorners[0].x,
                      worldCorners[0].y,
                      worldCorners[2].x - worldCorners[0].x,
                      worldCorners[2].y - worldCorners[0].y);
        return result;
    }


}
