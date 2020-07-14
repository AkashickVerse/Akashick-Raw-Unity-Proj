using System;
using System.Linq;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class BlockDataHolderB : MonoBehaviour
{   //sahaj garg www.embracingearth.space
    //Reads from block_viewmodel.cs and to do anything with any block properties here! 
    //Attach inside prefab of each block. 

    public Block_ViewModel data;
    public int blockIndex;
    public GameObject EmbeddTextMesh;// field for text to be embedded on brick
    public GameObject enbedtextcanvas; //todestroy canvas if no text for optimzation
    public GameObject ScreenTextMesh;
    public string fullutf8result;
    //fillbigtexewallonfirstopen fillbigtexewallonfirstopenn;

    //Text t;
    Text sceentext;
    TextMeshProUGUI scripttext;

    private void Awake()
    {
    /*    var bigtextwall = Resources
        .FindObjectsOfTypeAll<GameObject>()
        .FirstOrDefault(g => g.CompareTag("bigtextwall"));
        t = bigtextwall.GetComponent<Text>();   */

        sceentext = ScreenTextMesh.GetComponent<Text>();
        scripttext = EmbeddTextMesh.GetComponent<TMPro.TextMeshProUGUI>();
        /*
                var obj = Resources
                .FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(g => g.CompareTag("bixtextscreencontroller"));
                fillbigtexewallonfirstopenn = obj.GetComponent<fillbigtexewallonfirstopen>(); */
    }
    public string Setup(Block_ViewModel newData, int newBlockIndex)
    {
        data = newData;
        blockIndex = newBlockIndex;

        gameObject.name = data.blockNumber.ToString();

       //transform.position = Vector3.one * newBlockIndex;

        //Changing Hex to string
        //Debug.Log(data.input);
        string utf8result = ConvertHex(data.input);
        //Debug.Log(utf8result);

        //Adding the text to big text wall
        //t.text += "\n--------------------------------\n   ~" + data.blockNumber.ToString() + ":\n" + utf8result;

        //fullutf8result = System.Text.Encoding.UTF8.GetBytes(utf8result);
        fullutf8result = utf8result;
       // fillbigtexewallonfirstopenn.TextFill(blockIndex, data.blockNumber, fullutf8result);

        if (utf8result.Length == 0)//if no text delete textcanvas for optimisation
        {
            Destroy(enbedtextcanvas);
        }
        else { 
            //Adding full text to screentextwindow for click and view
            sceentext.text = newBlockIndex +" : " + data.blockNumber + ":\n" + utf8result;
     
            //Adding text as a scripture on the block
            if(utf8result.Length > 140)
            {
                utf8result = utf8result.Substring(0, 140); // we trim it embed text cannot display on blocks more due to space and design. we give users option to click and view full text.
                scripttext.text = utf8result;
            }
        }

        return fullutf8result;
    }
    static string ConvertHex(String hexString)
    {
        //Remove first letters 0x for crypto blockchain hex
        hexString = hexString.Substring(1);
        //Debug.Log(hexString);
        try
        {
            string ascii = string.Empty;

            for (int i = 1; i < hexString.Length; i += 2)
            {
                String hs = string.Empty;

                hs = hexString.Substring(i, 2);
                uint decval = System.Convert.ToUInt32(hs, 16);
                char character = System.Convert.ToChar(decval);
                //byte[] bytes = Encoding.Default.GetBytes(character.ToString());
                //string something = Encoding.UTF8.GetString(bytes);
                ascii += character;

            }
            return ascii;
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        return string.Empty;
    }

    //  borrowed
       public static byte[] StringToByteArray(String hex)
       {
           int NumberChars = hex.Length / 2;
           byte[] bytes = new byte[NumberChars];
           using (var sr = new StringReader(hex))
           {
               for (int i = 0; i < NumberChars; i++)
                   bytes[i] =
                     Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
           }
           return bytes;
       }
  
}       /*

    public static byte[] FromHex(string hex)
       {
        //hex = hex.Replace("-", "");
        hex = hex.Substring(2);
        byte[] raw = new byte[hex.Length / 2];

           for (int i = 0; i < raw.Length; i++)
           {
               raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
         //   byte[] bytes = Encoding.Default.GetBytes(raw[i].ToString());
           // string something = Encoding.UTF8.GetString(bytes);
        }

        return raw;
       }

   }
   /*
    public static string HextoString(string InputText)
    {
        // Remoce first letter 0 for crypto blockchain hex

        InputText = InputText.Substring(1);
        byte[] bb = Enumerable.Range(0, InputText.Length-1)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(InputText.Substring(x, 2), 16))
                    .ToArray();
        // return System.Text.Encoding.ASCII.GetString(bb);
        // or System.Text.Encoding.UTF7.GetString
        // or System.Text.Encoding.UTF8.GetString
        // or System.Text.Encoding.Unicode.GetString
        // or etc.

        return System.Text.Encoding.UTF8.GetString(bb);


    }
     

    #region Borrowed code from our lord and savior stackoverflow 

    /// <summary>
    /// Convert hex string to readable string
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToHexString(string str)
    {
      

        var sb = new StringBuilder();

        var bytes = Encoding.Unicode.GetBytes(str);
        foreach (var t in bytes)
        {
            sb.Append(t.ToString("X2"));
        }

        return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
    }


/// <summary>
    /// Convert readable string to hex string
    /// </summary>
    /// <param name="hexString"></param>
    /// <returns></returns>
    public static string FromHexString(string hexString)
    {

        if (hexString.Substring(0, 2) == "0x")
            hexString = hexString.Substring(2, hexString.Length - 2);

        var bytes = new byte[hexString.Length / 2];
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        }

        return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
    }

    #endregion
    */


