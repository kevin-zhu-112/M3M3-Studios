using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue log) {
        dialogueBox.SetActive(true);
        nameText.text = log.name;

        sentences.Clear();

        foreach (string sentence in log.sentences) {
            sentences.Enqueue(sentence);
        }

        StartCoroutine(DisplayNextSentence());
    }

    IEnumerator DisplayNextSentence() {
        while(sentences.Count != 0) {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            yield return new WaitForSeconds(4.0f);
            if (sentences.Count == 0) {
                dialogueBox.SetActive(false);
            }
        }
    }
}
