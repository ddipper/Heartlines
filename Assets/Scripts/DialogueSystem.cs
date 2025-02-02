using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//TODO: add scip cooldown
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private string[] lines;
    [SerializeField] private float speedText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private int index;
    
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void ScipTextClick()
    {
        if (dialogueText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    private void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
