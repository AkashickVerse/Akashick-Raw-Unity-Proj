using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sahaj garg www.embracingearth.space
//Raw input structure from etherscan.io under results , i.e- each index.
//Linked to Block_ViewModel.cs , make any changes there. do not change this.

[System.Serializable]
public class Block_DataModel
{
    public string blockNumber;
    public string timeStamp;
    public string hash;
    public string nonce;
    public string blockHash;
    public string transactionIndex;
    public string from;
    public string to;
    public string value;
    public string gas;
    public string gasPrice;
    public string isError;
    public string txreceipt_status;
    public string input;
    public string contractAddress;
    public string cumulativeGasUsed;
    public string gasUsed;
    public string confirmations;
}
