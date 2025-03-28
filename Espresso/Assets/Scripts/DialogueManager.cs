using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    
    private Queue<string> _sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = _sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
