using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour
{
    public Dropdown ColorDropdown;
    //public Text ColorText;
    public GameObject PlayerSphere;


    // Start is called before the first frame update
    void Start()
    {
        PlayerSphere.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChooseColor() // use in the change event for the dropdown
    {
        switch (ColorDropdown.value)
        {
            case 1:
                //ColorText.text = ColorDropdown.options[1].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                //ColorText.text = ColorDropdown.options[2].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 3:
                //ColorText.text = ColorDropdown.options[3].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.blue;
                break;
            default: // color if not one of the choices is selected
                //ColorText.text = ColorDropdown.options[0].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.black;
                break;
        }
    }
}
