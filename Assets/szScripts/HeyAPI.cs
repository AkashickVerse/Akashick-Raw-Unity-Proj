using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
//sahaj garg www.embracingearth.space
public class HeyAPI : MonoBehaviour
{

    //Akashick.Crypto Ethereum MainNet ART Address 
    public string WEB_URL = "http://api.etherscan.io/api?module=account&action=txlist&address=0x5D4F634A8c585b9A4B15fd99511D23F0bbfDd1f5&startblock=0&endblock=99999999&sort=asc&apikey=WJTWK63X8WZ95D67JSGJ6NPP5ISZZKNM84";

    //Rinkeby testnet acc1
    //public string WEB_URL = "http://api-rinkeby.etherscan.io/api?module=account&action=txlist&address=0x5D4F634A8c585b9A4B15fd99511D23F0bbfDd1f5&startblock=0&endblock=99999999&sort=asc&apikey=WJTWK63X8WZ95D67JSGJ6NPP5ISZZKNM84";

    // Mainnet - china incident address
    //public string WEB_URL = "http://api.etherscan.io/api?module=account&action=txlist&address=0x44938b01da1feb3f6fa1cf38870ee564e25d9bf3&startblock=0&endblock=99999999&sort=asc&apikey=WJTWK63X8WZ95D67JSGJ6NPP5ISZZKNM84";

    public float delayBetweenEachFailedAttempt = 5.1f;
    public Text consol;
    public Color instantcolor;
    public Color targetcolor;
    float flo = 0;

    [SerializeField] [Range(0f, 1f)] float lerptime;
    // Calling the API and Getting response 
    public IEnumerator CallAPIProcess(Action<Block_DataModel[]> outcome)
    {
        // WWWForm form = new WWWForm();
        //UnityWebRequest rq = UnityWebRequest.Post(WEB_URL, form);
        UnityWebRequest rq = UnityWebRequest.Get(WEB_URL);

        {
            yield return rq.SendWebRequest();

            // rq.downloadHandler.text;
            //  Debug.Log(rq.downloadHandler.text);
            // string jsonResult = System.Text.Encoding.UTF8.GetString(rq.downloadHandler.data);
            string jsonResult = System.Text.Encoding.UTF8.GetString(rq.downloadHandler.data);
            // Debug.Log(jsonResult);

            EtherScanAPIReply_Model data = JsonUtility.FromJson<EtherScanAPIReply_Model>(jsonResult);
            if (data == null) {
                Debug.LogError($"Null data. Response code: {rq.responseCode}.");
                yield return new WaitForSeconds(delayBetweenEachFailedAttempt);
                consol.text = "INVALID API REPLY, RETRYING..";
                flo = 0; lerptime = 0;
                StartCoroutine(CallAPIProcess(outcome));
                yield break;
            }
            outcome?.Invoke(data.result);
            consol.text = "LIVE PING ON ETH-RINKEBY TESTNET";
            //consol.text = "LIVE PING ON ETHEREUM MAINNET";
            lerptime = 0; flo = 1;
            //Debug.Log("Live Ping on Ethereum MainNet");

        }
    }
    public void Update()
    {
        if (flo == 1)
        {
            lerptime += Time.deltaTime / 11.0f;
            consol.color = Color.Lerp(instantcolor, targetcolor, lerptime);
        }
    }

}