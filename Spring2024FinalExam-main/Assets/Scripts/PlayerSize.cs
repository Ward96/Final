using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSize : MonoBehaviour
{
    public GameObject playerSphere;
    public Slider playerSize;
    private float size = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSize()
    {
        size = playerSize.value;

        // scale by the magnification
        playerSphere.transform.localScale = new Vector3(size, size, size);
        // adjust vertical position so ball does not end up in or above the plane
        playerSphere.transform.localPosition = new Vector3(playerSphere.transform.localPosition.x, 0.5f * size, playerSphere.transform.localPosition.z);
    }
}
