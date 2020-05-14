using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionDueToScreenSize : MonoBehaviour
{
    [SerializeField]
    public bool moveLeft;

    private void Awake()
    {
        MoveGameObject();
    }

    private void MoveGameObject()
    {
        int defaultScreenWidth = 1920;
        int currentScreenWidth = Screen.width;

        float differenceInScreenWidths = defaultScreenWidth - currentScreenWidth;

        if (differenceInScreenWidths == 0f) return;

        if (differenceInScreenWidths < 0) //if the difference is negative then we need to move the horizontal magenets inwards
        {
            float pixelsToMove = Mathf.Abs(differenceInScreenWidths / 2);

            //we know 100 pixels is equal to 1 unit so
            float unitsToMove = pixelsToMove / 100;

            if (moveLeft)
            {
                transform.position = new Vector2(transform.position.x + unitsToMove, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - unitsToMove, transform.position.y);
            }

        } else if (differenceInScreenWidths > 0) //if the difference is negative then we need to move the horizontal magenets outwards
        {
            float pixelsToMove = differenceInScreenWidths / 2;

            //we know 100 pixels is equal to 1 unit so
            float unitsToMove = pixelsToMove / 100;
            
            if (moveLeft)
            {
                transform.position = new Vector2(transform.position.x - unitsToMove, transform.position.y);
            } else
            {
                transform.position = new Vector2(transform.position.x + unitsToMove, transform.position.y);

            }
        }
    }
}
