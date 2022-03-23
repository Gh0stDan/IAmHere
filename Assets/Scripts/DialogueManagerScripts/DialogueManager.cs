using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Dialogue dialogue;
    Queue<string> sentences;
    public GameObject dialoguePanel;
    public GameObject dialoguePanelInstructions;
    public Text displayText;
    public Text nameText;
    string activeSentence;
    public float typingSpeed;

    bool dialoguePanelStatus;
    float dialogeLength;

    //private Collider collisionConfirmation;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogeLength = dialogue.sentenceLengthReal;
        //dialoguePanel.SetActive(false);
        //dialoguePanelStatus = false;
    }

    /*void Update()
    {
        OnTriggerStay();
    }*/

    // Update is called once per frame
    public void StartDialogue()
    {
        nameText.text = dialogue.nameChar;
        sentences.Clear();

        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count < 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));

    }
    void EndDialogue()
    {

    }


    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter(Collider collisionActive)
    {

        if (collisionActive.CompareTag("Player"))
        {
            dialoguePanelInstructions.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider collisionConfirmation)
    {

        if (collisionConfirmation.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && dialoguePanelStatus == false)

            {
                dialoguePanel.SetActive(true);
                dialoguePanelStatus = true;
                dialoguePanelInstructions.SetActive(false);
                StartDialogue();


            }
            else if (Input.GetKey(KeyCode.E) && displayText.text == activeSentence && dialoguePanelStatus == true)
            {
                DisplayNextSentence();
            }
            else if (Input.GetKey(KeyCode.R) && sentences.Count == 0 && dialoguePanelStatus == true && displayText.text == activeSentence)
            {
                dialoguePanel.SetActive(false);
                dialoguePanelStatus = false;
                dialoguePanelInstructions.SetActive(true);


            }

        }


    }

    private void OnTriggerExit(Collider collisionDisable)
    {

        if (collisionDisable.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            dialoguePanelStatus = false;
            dialoguePanelInstructions.SetActive(false);
            StopAllCoroutines();
        }


    }



}
