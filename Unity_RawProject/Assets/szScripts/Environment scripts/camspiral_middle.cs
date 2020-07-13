using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camspiral_middle : MonoBehaviour
{
    public float panSpeed = 20f;
    public float speed;

    void Update()
    {

            //speed = camspiralmoov.speed;
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            transform.position = pos;
        }
}
