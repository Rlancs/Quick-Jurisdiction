using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CriminalArray : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attorneyText;
    [SerializeField] private TextMeshProUGUI prosecutorText;
    [SerializeField] private GameObject attorneyBubble;
    [SerializeField] private GameObject prosecutorBubble;

    [SerializeField] private Controller controllerScript;
    [SerializeField] private List<GameObject> criminalArray;
    [SerializeField] private GameObject winMenu;
    private string [,] attorneyDialogue = new string[5, 3];
    private string [,] prosecutorDialogue = new string[5, 3];
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        criminalArray[index].SetActive(true);
        PopulateArrays();
    }

    // Displays dialogue from the attorney
    public IEnumerator AttorneyDialogue()
    {
        while (true)
        {
            // Chooses a random index from 0 to 2 to pick dialogue from
            int random = Random.Range(0, 3);
            string dialogue = attorneyDialogue[index, random];
            attorneyText.text = dialogue;
            // Chooses a random number of seconds to wait from 5 to 10
            random = Random.Range(5, 11);
            yield return new WaitForSeconds(random);
        }
    }

    // Displays dialogue from the prosecutor
    public IEnumerator ProsecutorDialogue()
    {
        while (true)
        {
            // Chooses a random index from 0 to 2 to pick dialogue from
            int random = Random.Range(0, 3);
            string dialogue = prosecutorDialogue[index, random];
            prosecutorText.text = dialogue;
            // Chooses a random number of seconds to wait from 5 to 10
            random = Random.Range(5, 11);
            yield return new WaitForSeconds(random);
        }
    }

    // If there is dialogue present, the speech bubble is shown. Otherwise, it is hidden.
    private void Update()
    {
        if (attorneyText.text == "")
        {
            attorneyBubble.SetActive(false);
        }
        else
        {
            attorneyBubble.SetActive(true);
        }

        if (prosecutorText.text == "")
        {
            prosecutorBubble.SetActive(false);
        }
        else
        {
            prosecutorBubble.SetActive(true);
        }
    }

    public void NewCriminal()
    {
        // If there is another criminal left, the current one is removed and the next is put on trial
        if (index != criminalArray.Count - 1)
        {
            criminalArray[index].SetActive(false);
            index++;
            criminalArray[index].SetActive(true);
            attorneyText.text = "";
            prosecutorText.text = "";
        }
        // If there are no more criminals, the game is won
        else
        {
            criminalArray[index].SetActive(false);
            winMenu.SetActive(true);
            controllerScript.gameEnd = true;
            attorneyText.text = "";
            prosecutorText.text = "";
            Time.timeScale = 0f;
        }
    }

    // Loads the 2D arrays with dialogue for each criminal
    private void PopulateArrays()
    {
        // Attorney Dialogue
        attorneyDialogue[0, 0] = "He can't help it! Its in his nature";
        attorneyDialogue[0, 1] = "They're just a little guy";
        attorneyDialogue[0, 2] = "Goblins have rights too";
        attorneyDialogue[1, 0] = "They're elderly citizens, we should respect them";
        attorneyDialogue[1, 1] = "Its only a misunderstanding, probably";
        attorneyDialogue[1, 2] = "They need the money for their children and grandkids";
        attorneyDialogue[2, 0] = "He's a big softie!";
        attorneyDialogue[2, 1] = "Its an honest mistake";
        attorneyDialogue[2, 2] = "He's been out of prison for months, this is just an accident";
        attorneyDialogue[3, 0] = "Technically 'Arm Dealing' isn't a legally defined crime";
        attorneyDialogue[3, 1] = "He was deceived! This isn't fair on him";
        attorneyDialogue[3, 2] = "Look at how upset he is...";
        attorneyDialogue[4, 0] = "Are you kidding me? They're only a child";
        attorneyDialogue[4, 1] = "They won't do it again. Promise";
        attorneyDialogue[4, 2] = "Boys are gonna be boys";

        // Prosecutor Dialogue
        prosecutorDialogue[0, 0] = "Goblins are evil beings";
        prosecutorDialogue[0, 1] = "He'll be stealing the crown jewels next!";
        prosecutorDialogue[0, 2] = "This rampaging little gremlin has gone too far";
        prosecutorDialogue[1, 0] = "They're literal godmothers to a crime family. Lock them up!";
        prosecutorDialogue[1, 1] = "If they're free on the streets, no bank is safe";
        prosecutorDialogue[1, 2] = "Older criminals are more wise and dangerous";
        prosecutorDialogue[2, 0] = "He's got a nasty criminal past as a gambler";
        prosecutorDialogue[2, 1] = "I despise those who litter. They're the worst criminals";
        prosecutorDialogue[2, 2] = "Honestly that moustache is stupid";
        prosecutorDialogue[3, 0] = "He has a bag of severed arms. SEVERED ARMS!!";
        prosecutorDialogue[3, 1] = "Who knows who he's killed";
        prosecutorDialogue[3, 2] = "Don't let him fool you, those tears are an act";
        prosecutorDialogue[4, 0] = "This child is too dangerous to run free";
        prosecutorDialogue[4, 1] = "Where are this kid's parents?";
        prosecutorDialogue[4, 2] = "He's responsible for the worst building fires in the last decade";
    }
}
