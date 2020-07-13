using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//sahaj garg www.embracingearth.space
//Optimising Raw input from Block_DataModel.cs
public class Block_ViewModel 
{
    public int blockNumber;
    //public string timeStamp;
    //public string hash;
    //public int nonce;
    //public string blockHash;
    //public int transactionIndex;
    //public string from;
    //public string to;
    //public string value;
    //public string gas;
    //public string gasPrice;
    //public bool isError;
    //public string txreceipt_status;
    public string input;
    //public string contractAddress;
    //public string cumulativeGasUsed;
    //public string gasUsed;
    //public string confirmations;


    public Block_ViewModel (Block_DataModel data)
    {
        blockNumber = int.Parse(data.blockNumber);
        //timeStamp = data.timeStamp;
        //nonce = int.Parse(data.nonce);
        //transactionIndex = int.Parse(data.transactionIndex);
        input = data.input;
    }
}
