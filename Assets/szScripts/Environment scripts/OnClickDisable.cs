using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sahaj garg
public class OnClickDisable : MonoBehaviour
{
    public GameObject obj;
    bool toggleBool = true;

    public void OnPointerEnter()
    {
        Debug.Log("ss");
        if (Input.GetMouseButtonDown(0))
        {
            toggleBool = !toggleBool;
            obj.gameObject.SetActive(toggleBool);
        }
        
    }
    
}
