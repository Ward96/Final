using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public GameObject player; // not needed, script attached to player
    public GameObject reward;
    //public GameObject death;
    public float movement = 4.0f;
    public float speed = 1.0f;
    public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update() 
    {
        // the actual movements are in separate functions so you can call those functions in edit mode and the update function in playmode
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveBack();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void MoveLeft() 
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.left);
    }

    public void MoveRight() 
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.right);
    }

    public void MoveForward()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.forward);
    }

    private void MoveBack()
    {
        this.transform.Translate(speed * movement * Time.deltaTime * Vector3.back);
    }

    private void UpdateScoreText()
    {
        // Update the UI Text with the current score
        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("reward"))
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject);
        }
        //else if (other.gameObject.CompareTag("death"))
        //{
            //Destroy(other.gameObject);
            //SceneManager.LoadScene("Exit");
        //}
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
