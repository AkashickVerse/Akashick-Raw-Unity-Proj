using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiral : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    int zPos;
    float rotfix;
    void Start()
    {

        for (int i = 0; i < 125; i++)
        {
            var circleSpeed = 1;
            var forwardSpeed = 1; 
            var circleSize = 23;
            var circleGrowSpeed = 0.1;
            

            var xPos = Mathf.Sin(i * 0.1f) * circleSize;
            var yPos = Mathf.Cos(i * 0.1f) * circleSize;
            
            zPos = zPos + forwardSpeed;

            Quaternion rot = Quaternion.Euler(0, rotfix, 0);
            Instantiate(obj, new Vector3(xPos, zPos, yPos), rot);
            rotfix += 5.7f;
        }

    }
}
