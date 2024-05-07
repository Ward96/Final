using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameLoad : MonoBehaviour
{
    private NameTransfer NameTransferScript;
    public Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        NameTransferScript = GameObject.Find("playerNameSaver").GetComponent<NameTransfer>();
        nameText.text = NameTransferScript.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
