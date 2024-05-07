using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameTransfer : MonoBehaviour
{
    public InputField nameInput;

    public string playerName;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyInExit();
        playerName = nameInput.text;
    }

    public void DestroyInExit()//since this object has served its purpose, we can destroy it so a new name transfer object can come in
    {
        if(SceneManager.GetActiveScene().name == "Exit")
        {
            Destroy(this.gameObject);
        }
    }
}
