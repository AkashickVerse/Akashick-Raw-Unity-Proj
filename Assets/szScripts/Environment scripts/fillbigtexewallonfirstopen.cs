using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
//sahaj garg www.embracingearth.space
public class fillbigtexewallonfirstopen : MonoBehaviour
{
    public Transform contentt;
    Text t;
    public Scrollbar scrollcomponent;
    GameObject scroll;
    bool firstload = true;
    string txt = null;

    public GameObject newT;
    Vector3 Scalefix;
    int lastmessageindex;
    int i;


    void Start()
    {
        var bigtextwall = Resources
        .FindObjectsOfTypeAll<GameObject>()
        .FirstOrDefault(g => g.CompareTag("bigtextwall"));
        t = bigtextwall.GetComponent<Text>();

        //scrollbar of bigtextwall to end
        scroll = Resources
       .FindObjectsOfTypeAll<GameObject>()
       .FirstOrDefault(g => g.CompareTag("scrollbar"));
        scrollcomponent = scroll.GetComponent<Scrollbar>();

        Scalefix = new Vector3(1, 1, 1);
    }

    public void TextFill(int index, int blocknumber, string utf8)
    {
     //   if (lastmessageindex != IrunHeyAPI._content.Count) // to check if theres a new message since last text wall update
       // {
            txt = t.text;
         //   for (i = 0 ; i <= IrunHeyAPI._content.Count; i++)
            // foreach(BlockDataHolderB holder in IrunHeyAPI._content.Values)
           // {
           //     BlockDataHolderB holder = IrunHeyAPI._content.Values.ElementAt(i);
                if (txt.Length < 2000)//because one unity text cannot contain more than 65k vertices in a single mesh.
                {
                    txt += "\n--------------------------------\n" + "(" + index.ToString() + ")" + blocknumber.ToString() + ":\n" + utf8;
                }
                else if (txt.Length >= 2000)//so we spawn a new one and start adding from there
                {
                    newT = Instantiate(newT);
                    newT.transform.SetParent(contentt);
                    newT.transform.localScale = Scalefix;
                    t = newT.GetComponent<Text>();
                    txt = "";
                    txt += "\n--------------------------------\n" + "(" + index.ToString() + ")" + blocknumber.ToString() + ":\n" + utf8;
                }
                t.text = txt;

              //  lastmessageindex = holder.blockIndex;

               // if (firstload == true)
               // {
                    scrollcomponent.value = 0f;
               // }
            //}
           // firstload = false;
       // }
    }
}