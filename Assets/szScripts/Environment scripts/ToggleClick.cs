using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleClick : MonoBehaviour
{   //sahaj garg
    public Material hoverColor;
    public Material basicColor;
    public GameObject Screentextmesh;
    public MeshRenderer rend;
    void Start()
    {
        Screentextmesh.gameObject.SetActive(false);
    }

    void OnMouseOver()
    {   
        if (Input.GetMouseButtonDown(0))
        {   
        //  rend = this.GetComponent<MeshRenderer>();
            //open individual brick textwall
            Screentextmesh.gameObject.SetActive(true);
            /*
            //disable big text wall 
            var bigtextwall = Resources
            .FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(g => g.CompareTag("FullBigtextwallLayout"));
            bigtextwall.gameObject.SetActive(false);
            */
        }
    }

    // change the whole material of the object if its getting shared between many, instead of color.
    // so other objects not hovered can still share GPU Instancing material for OPTIMISATION~!
    void OnMouseEnter()
    {     
        rend.material = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material = basicColor;
    }

}
