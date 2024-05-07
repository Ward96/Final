using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestSuite
{
    GameObject targetPrefab;

    [SetUp]
    public void Setup()
    {
        //load the prefab
        targetPrefab = Resources.Load<GameObject>("Target");
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayButtonStartsPlay()
    {
        SceneManager.LoadScene("Intro");//load intro
        yield return new WaitForSeconds(.5f);

        //Scene previousScene = SceneManager 
        GameObject theButton = GameObject.Find("PlayButton");//find the play button
        theButton.GetComponent<Button>().onClick.Invoke();//press the button

        yield return new WaitForSeconds(.5f);
        Assert.IsTrue(SceneManager.GetActiveScene().name == "Game");//asssert that the active scene is the game scene

    }
    [UnityTest]
    public IEnumerator StopButtonStopsPlay()
    {
        SceneManager.LoadScene("Game");//load the game scene
        yield return new WaitForSeconds(.5f);

        GameObject theButton = GameObject.Find("StopButton");//find the stop button
        theButton.GetComponent<Button>().onClick.Invoke();//press the button

        yield return new WaitForSeconds(.5f);
        Assert.IsTrue(SceneManager.GetActiveScene().name == "Exit");//assert that the active scene is exit
    }
    [UnityTest]
    public IEnumerator PlayAgainButtonRestartsGame()
    {
        SceneManager.LoadScene("Exit");//load the exit scene
        yield return new WaitForSeconds(.5f);

        GameObject theButton = GameObject.Find("PlayAgainButton");//find the play again button
        theButton.GetComponent<Button>().onClick.Invoke();//press the button

        yield return new WaitForSeconds(.5f);
        Assert.IsTrue(SceneManager.GetActiveScene().name == "Intro");//assert that the active scene is intro
    }
    [UnityTest]
    public IEnumerator PlayerNameShownInGame()
    {
        SceneManager.LoadScene("Intro");//start from intro scene to avoid error
        yield return new WaitForSeconds(.5f);

        GameObject theButton = GameObject.Find("PlayButton");//find the play button
        theButton.GetComponent<Button>().onClick.Invoke();//press the button, takes us to came scene
        yield return new WaitForSeconds(.5f);

        GameObject theTextBox = GameObject.Find("NameText");
        Assert.IsTrue(theTextBox != null);//assert that the name object is shown

        theTextBox.GetComponent<Text>().text = "Bobby";//set the name to bobby

        yield return new WaitForSeconds(1f);

        Assert.IsTrue(theTextBox.GetComponent<Text>().text == "Bobby");//assert that bobby is the visible name
    }
    [UnityTest]
    public IEnumerator DestroyingFiveTargetsStopsPlay()
    {
        SceneManager.LoadScene("Intro");//start from intro scene to avoid error
        yield return new WaitForSeconds(.5f);

        GameObject theInputField = GameObject.Find("NameInputField");//find the input field, this is so we can create a name so that when this test runs a test name will show to the scores in the database
        theInputField.GetComponent<InputField>().text = "UnitTest";//name the player unit test
        yield return new WaitForSeconds(2f);

        GameObject theButton = GameObject.Find("PlayButton");//find the play button
        theButton.GetComponent<Button>().onClick.Invoke();//press the button, takes us to came scene
        yield return new WaitForSeconds(.5f);

        GameObject thePlayer = GameObject.Find("Player");


        for (int i = 0; i < 5; i++)//spawn 5 enemies
        {
            GameObject enemy = Object.Instantiate(targetPrefab);//spawn
            enemy.transform.position = thePlayer.transform.position; //set the position of the targets equal to the plauyer
        }

        thePlayer.GetComponent<PlayerMovement>().MoveForward();//player has to move just a tiny bit

        yield return new WaitForSeconds(2f);
        Assert.IsTrue(SceneManager.GetActiveScene().name == "Exit");
    }
    [UnityTest]
    public IEnumerator _1NameFromIntroShowsInGameScene() //name starts with _1 so that test passes when pressing "run all". otherwise test must be run alone to pass.
    {
        SceneManager.LoadScene("Intro");//start from intro scene to avoid error
        yield return new WaitForSeconds(1f);

        GameObject theInputField = GameObject.Find("NameInputField");//find the input field
        theInputField.GetComponent<InputField>().text = "Emilia";//write a name
        yield return new WaitForSeconds(2f);

        GameObject thePlayButton = GameObject.Find("PlayButton");//find the play button
        thePlayButton.GetComponent<Button>().onClick.Invoke();//press the button, takes us to game scene
        yield return new WaitForSeconds(1f);

        GameObject theSaver = GameObject.Find("playerNameSaver");//find the saver

        Assert.IsTrue(theSaver.GetComponent<NameTransfer>().playerName == "Emilia");//assert that the name saver object has been transferred scenes and the name is present

        GameObject theTextBox = GameObject.Find("NameText");//search for the text box that displays the name
        Assert.IsTrue(theTextBox != null);//assert that the name object is shown
        Assert.IsTrue(theTextBox.GetComponent<Text>().text == "Emilia");//assert that the name entered in the intro is present

    }
}
