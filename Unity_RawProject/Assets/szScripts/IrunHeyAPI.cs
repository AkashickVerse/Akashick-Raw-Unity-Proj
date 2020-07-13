
//sahaj garg www.embracingearth.space

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

public class IrunHeyAPI : MonoBehaviour
{
    //References
    public HeyAPI heyAPI;
    public BlockDataHolderB blockHolderPrefab;
    public fillbigtexewallonfirstopen fillbigtexewallonfirstopenn;

    public UnityEvent gotnewblock;
    public VerseLift verselift;

    //Data container where the key is the Block Number and the value is the active GameObject with matching block number.
    public static Dictionary<int, BlockDataHolderB> _content = new Dictionary<int, BlockDataHolderB>();

    //Timers
    public float delayBeforeStart = 20;
    public float refreshRate = 15;

    int zPos;
    float rotfix;
    string utf8;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        while (true) {
            yield return RefreshData();
            yield return new WaitForSeconds(refreshRate);
  
        }
    }


    IEnumerator RefreshData()
    {
        Block_DataModel[] data = null;
        StartCoroutine(heyAPI.CallAPIProcess(outcome => data = outcome));

        //Wait until data has landed before proceeding.
        while (data == null)
            yield return null;

        //List<BlockDataHolderB> newBlocks = new List<BlockDataHolderB>();

        for (int i = 0; i < data.Length; i++)
        {
            var tmpData = new Block_ViewModel(data[i]);
            if (!_content.ContainsKey(tmpData.blockNumber))
            {

                    //creating the spiral--var circleSpeed = 1;
                    var forwardSpeed = 1;
                    var circleSize = 23;
                    var circleGrowSpeed = 0.1;


                    var xPos = Mathf.Sin(i * 0.1f) * circleSize;
                    var yPos = Mathf.Cos(i * 0.1f) * circleSize;

                    zPos = zPos + forwardSpeed;

                    Quaternion rot = Quaternion.Euler(0, rotfix, 0);
                    BlockDataHolderB holder = Instantiate(blockHolderPrefab, new Vector3(xPos, zPos, yPos), rot);
                    rotfix += 5.7f;

                //////
                ///

                //string tmpcheck = tmpData.blockNumber.ToString();
                //if (GameObject.Find("tmpcheBlockHolderPrefab(Clone)")) 
                //{
                //We can pass in the index of an object along with it.
                 utf8 = holder.Setup(tmpData, _content.Count);
                _content.Add(tmpData.blockNumber, holder);
                yield return new WaitForSeconds(0.07f);   //to add delay in spawning
                fillbigtexewallonfirstopenn.TextFill(_content.Count, tmpData.blockNumber, utf8);
                
                //newBlocks.Add(holder);
                //Debug.Log($"Added block of id {tmpData.blockNumber}");
                gotnewblock.Invoke();
                //}
            }

        }

        verselift.Updatepos(zPos-21); //lift the verse relative to highest block in the spiral.


    }


    //You can store and cycle through only new blocks if you want
    //for (int i = 0; i < newBlocks.Count; i++)
    //{
    //    //The current index will be equals to the content dictionary count - new blocks count.
    //    Debug.Log($"Block of id {newBlocks[i].data.blockNumber} is at dictionary index {_content.Count - newBlocks.Count + i}.");
    //}

    //BlockDataHolderB lastItem = transform.GetChild(transform.childCount - 1).GetComponent<BlockDataHolderB>();
    //To access an object in the dictionary, you can use a blockNumber -> 
    // Debug.Log($"{_content[lastItem.data.blockNumber]}");

    //Below is how to handle the entire data as a whole, by looping through those.
    //Or you can loop through those using foreach
    //foreach (var kvp in _content)
    //    Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value.data.input}");

    //foreach(BlockDataHolderB holder in _content.Values)
    //     Debug.Log($"Value: {holder.data.input}");

    //Check content based on its index
    // int index = 0;
    //foreach (BlockDataHolderB holder in _content.Values)
     //Debug.Log($"Item {holder.data.blockNumber} is at index {index++} out of {_content.Count}.");

    //Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~");

    //Get the first item
    //var holder = _content.First();

    //Get the first item with --
    //var holder = _content.First(o => int.Parse(o.Value.data.gasUsed) > 300);

    //void GetBlockList(EtherScanAPIReply_Model.)

}


