using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public bool showDialogue;
    public Vector2 scr;
    public string[] dlgText;
    public int index, optionsIndex;


    [Header("Quest UI Elements")]
    public GameObject dialogueTextBox;
    public GameObject acceptButton, declineButton, nextDialogue, closeButton;
    Text t;
    //public Text goldRewardText, xpRewardText;
    QuestGiver questGiver;

    // Update is called once per frame
    void OnGUI()
    {
        //if (showDialogue)
        //{

        //    //if screen measure units is not at 16:9 ration
        //    if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
        //    {
        //        scr.x = Screen.width / 16;
        //        scr.y = Screen.height / 9;
        //    }

        //    GUI.Box(new Rect(0, scr.y * 6, scr.x * 16, scr.y * 3), dlgText[index]);
        //    if (!(index + 1 >= dlgText.Length - 1 || index == optionsIndex))
        //    {
        //        if (GUI.Button(new Rect(scr.x * 15f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Next"))
        //        {
        //            index++;
        //        }
        //    }
        //    else if (index == optionsIndex)
        //    {
        //        if (GUI.Button(new Rect(scr.x * 13f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Accept"))
        //        {
        //            index++;

        //        }
        //        if (GUI.Button(new Rect(scr.x * 14f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Decline"))
        //        {
        //            index = dlgText.Length - 1;

        //        }
        //    }
        //    else
        //    {
        //        if (GUI.Button(new Rect(scr.x * 15f, scr.y * 8.5f, scr.x, scr.y * 0.5f), "Bye"))
        //        {
        //            index = 0;
        //            showDialogue = false;
        //            Movement.canMove = true;
        //            //we are not doing this for our game
        //            //Cursor.lockState = CursorLockMode.Locked;
        //            //Cursor.visible = false;
        //            //enable camera and player movement
        //        }
        //    }

        //}
    }
    void Start()
    {
        t = dialogueTextBox.GetComponent<Text>();
        questGiver = GetComponent<QuestGiver>();
    }

    void Update()
    {
        //

        if (showDialogue)
        {

            dialogueTextBox.SetActive(true);

            t.text = dlgText[index];

            if (!(index + 1 >= dlgText.Length - 1 || index == optionsIndex))
            {
                nextDialogue.SetActive(true);

            }
            else if (index == optionsIndex)
            {
                questGiver.OpenQuestWindow();
                declineButton.SetActive(true);
                acceptButton.SetActive(true);

                nextDialogue.SetActive(false);
            }
            else
            {

                closeButton.SetActive(true);

                declineButton.SetActive(false);
                acceptButton.SetActive(false);

                nextDialogue.SetActive(false);


            }
        }


    }

    public void Next()
    {
        index++;
    }

    public void Close()
    {
        index = 0;
        showDialogue = false;
        closeButton.SetActive(false);
        dialogueTextBox.SetActive(false);
        Movement.canMove = true;
        Debug.Log("AT THE END");
    }

    public void Accept()
    {
        index++;
    }

    public void Decline()
    {
        index = dlgText.Length - 1;
    }
}
