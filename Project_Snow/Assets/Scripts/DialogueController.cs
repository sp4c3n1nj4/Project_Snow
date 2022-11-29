using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueList
{
    public string[] dialogue;

    public float[] delay;
}

public class DialogueController : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private DialogueList[] dialogue;
    [SerializeField]
    private TextMeshProUGUI subtitleText;

    public void AdvanceDialogue()
    {
        StartCoroutine(PlayDialogue());
    }

    private void DisplayDialogueLine(string text)
    {
        subtitleText.text = text;
    }

    IEnumerator PlayDialogue()
    {
        subtitleText.gameObject.transform.parent.gameObject.SetActive(true);

        for (int i = 0; i < dialogue[index].dialogue.Length; i++)
        {
            DisplayDialogueLine(dialogue[index].dialogue[i]);
            yield return new WaitForSeconds(dialogue[index].delay[i]);
        }

        subtitleText.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
