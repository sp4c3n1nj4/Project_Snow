using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public enum Characters
{
    char1,
    char2
}

[System.Serializable]
public class DialogueList
{
    public string[] dialogue;

    public float[] delay;

    public Characters[] speaker;
}

public class DialogueController : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private float charDelay = 0.1f;
    [SerializeField]
    private DialogueList[] dialogue;
    [SerializeField]
    private TextMeshProUGUI subtitleText;
    [SerializeField]
    private TextMeshProUGUI speakerText;

    public void AdvanceDialogue()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        subtitleText.gameObject.transform.parent.gameObject.SetActive(true);

        for (int i = 0; i < dialogue[index].dialogue.Length; i++)
        {
            StartCoroutine(DisplayDialogueLine(dialogue[index].dialogue[i], dialogue[index].speaker[i].ToString()));
            yield return new WaitForSeconds(dialogue[index].delay[i] + dialogue[index].dialogue[i].Length * charDelay);
        }

        subtitleText.gameObject.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator DisplayDialogueLine(string text, string speaker)
    {
        speakerText.text = speaker;
        subtitleText.text = "";

        foreach (char c in text)
        {
            subtitleText.text += c;
            yield return new WaitForSeconds(charDelay);
        }      
    }
}
