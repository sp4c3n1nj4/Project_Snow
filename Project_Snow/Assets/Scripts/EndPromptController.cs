using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PromptData
{
    public float index;

    public Vector3 position;
    public float scale;
    public bool capital;
}

public class EndPromptController : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private PromptData[] promptData;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject endPrompt;
    [SerializeField]
    TextMeshProUGUI endText;

    private void UpdatePrompt(Vector3 postion, float scale, bool capital)
    {
        endPrompt.transform.position = player.transform.position + postion;
        endPrompt.transform.localScale = Vector3.one * scale;

        if (capital)
        {
            endText.text = "GIVE UP";
        }
    }

    public void AdvancePrompt()
    {
        for (int i = 0; i < promptData.Length; i++)
        {
            if (promptData[i].index.Equals(index))
            {
                UpdatePrompt(promptData[i].position, promptData[i].scale, promptData[i].capital);
            }
        }

        index += 1;
    }
}
