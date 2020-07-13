using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camspiralmoov : MonoBehaviour
{/// <summary>
///////////sahaj garg www.embracingearth.space
/// //////////// lookattargetcam
// wasd to rotate and move
//click for mouse rotate
//scroll to zoom
/// </summary>
    public float panSpeed = 20f;
    public static float speed;

    //private const float Y_ANGLE_MIN = -360.0f;
    //private const float Y_ANGLE_MAX = 360.0f;

    public Transform lllookAt;
    public Transform llcamTransform;
    public float distance = 45.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    public float zoomsensitivity = 75f;
    public float minFov = 10f;
    public float maxFov = 180f;

    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    Vector3 dir;

    void Update()
    {
      
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += (speed * Time.deltaTime) * sensitivityX;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= (speed * Time.deltaTime) * sensitivityX;
            }
            if (Input.GetKey("a"))
            {
                //pos.x += speed * Time.deltaTime;
                currentX += (0.2f * sensitivityY);
            }
            if (Input.GetKey("d"))
            {
                //pos.x -= speed * Time.deltaTime;
                currentX -= (0.2f * sensitivityY);
            }

            transform.position = pos;
            ////////////////////////////////////////
            if (Input.GetMouseButton(0))
            {
                currentX += Input.GetAxis("Mouse X") * 3;
                currentY += Input.GetAxis("Mouse Y");
                //currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            }
            //////////////////xoomzoom
            distance += Input.GetAxis("Mouse ScrollWheel") * zoomsensitivity;
            if (Input.GetKey(KeyCode.Q))
            {
                distance += 0.01f*zoomsensitivity;
            }
            if (Input.GetKey(KeyCode.E))
            {
                distance -= 0.01f*zoomsensitivity;
            }

            //distance = Mathf.Clamp(distance, minFov, maxFov);
            //llcamTransform.position = distance;
      
    }
    
    private void Start()
    {
        //llcamTransform = transform;
    }
    private void LateUpdate()
    {
            dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            llcamTransform.LookAt(lllookAt.position);
            llcamTransform.position = lllookAt.position + rotation * dir;
      
    }
}

