using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerseLift : MonoBehaviour
{
    public int counter = 0;
    public float movementStep = 0.1f;
    public Vector3 targetPosition;
    bool shouldweMove;
    public void Updatepos(float y)
    {
        targetPosition = new Vector3(0, y, 0);
        if (transform.position != targetPosition)
        {
            shouldweMove = true;
        }

    }

    public void Update()
    {

        if (shouldweMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementStep);

            if(transform.position == targetPosition)
            {
                shouldweMove = false;
            }
        }

    }
}
