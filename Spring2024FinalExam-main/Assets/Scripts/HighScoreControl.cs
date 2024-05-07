using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{

    private string secretKey = "mySecretKey";
    public string addScoreURL =
            "http://localhost/ward96/addscore.php?";
    public string highscoreURL =
             "http://localhost/ward96/display.php";
    private Text nameTextInput;
    private Text scoreTextInput;
    public Text nameResultText;
    public Text scoreResultText;

    public PlayerMovement playerMovementScript;
    public NameTransfer nameTransferScript;

    public bool isInExit; //bool to control if the player is in exit to avoid null reference on start because the other objects dont exist

    // Start is called before the first frame update
    void Start()
    {
        if (!isInExit)
        {
            playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
            nameTransferScript = GameObject.Find("playerNameSaver").GetComponent<NameTransfer>();
        }

        if (scoreResultText != null && nameResultText !=null)
        {
            GetScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //nameTextInput.text = nameTransferScript.playerName;
        //scoreTextInput.text = playerMovementScript.scoreText.text;

        if (playerMovementScript != null && playerMovementScript.score >= 5)
        {
           SendScore();
           SceneManager.LoadScene("Exit");//switch to exit scene if score of 5 has been reached
        }
    }

    public void SendScore()
    {
        StartCoroutine(PostScores(nameTransferScript.playerName, Convert.ToInt32(playerMovementScript.scoreText.text)));
        print("score sent?");
        //nameTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
        //scoreTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
    }

    public void GetScore()
    {
        nameResultText.text = "Player: \n \n";
        scoreResultText.text = "Score: \n \n";
        StartCoroutine(GetScores());
    }
    public void SendScoreBtn()
    {
        StartCoroutine(PostScores(nameTextInput.text,
           Convert.ToInt32(scoreTextInput.text)));
        nameTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
        scoreTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
    }

    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(highscoreURL);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the high score: "
                    + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++)
                {
                    if (i % 2 == 0)
                        nameResultText.text +=
                                            splitData[i];
                    else
                        scoreResultText.text +=
                                            splitData[i];
                }
            }
        }
    }

    IEnumerator PostScores(string name, int score)
    {
        string hash = HashInput(name + score + secretKey);
        string post_url = addScoreURL + "name=" +
               UnityWebRequest.EscapeURL(name) + "&score="
               + score + "&hash=" + hash;
        UnityWebRequest hs_post = UnityWebRequest.PostWwwForm(post_url, hash);
        yield return hs_post.SendWebRequest();
        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: "
                    + hs_post.error);
    }

    public string HashInput(string input)
    {
        SHA256Managed hm = new SHA256Managed();
        byte[] hashValue =
                hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
        string hash_convert =
                 BitConverter.ToString(hashValue).Replace("-", "").ToLower();
        return hash_convert;
    }
}
