using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sahajgargwww.embracingearth.space
public class camswitch_outer : MonoBehaviour
{

    public GameObject spiralcam;
    public GameObject flycamdragon;
    public GameObject flycameraonly;
    bool toggleBool = true;
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            toggleBool = !toggleBool;
            spiralcam.SetActive(toggleBool);
            flycamdragon.GetComponent<flycam>().enabled = !toggleBool;
            flycameraonly.SetActive(!toggleBool);

        }
    }
}
