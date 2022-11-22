using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int index = 0;
    [SerializeField]
    private ClimbingData[] climbingData;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject prompt;
    [SerializeField]
    private TextMeshProUGUI promptText;

    private void Update()
    {
        CheckPromptInput(climbingData[index].keycode);
        CheckAnimationTimer();
    }

    private void CheckPromptInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            AdvanceAnimation(climbingData[index].trigger.ToString());
        }
    }
    private void ButtonPrompt(string key, Vector3 location)
    {
        prompt.transform.position = Camera.main.WorldToScreenPoint(location);
        promptText.text = name;
        prompt.SetActive(true);
    }

    private void CheckAnimationTimer()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
            OnAnimationEnd();
        }
    }
    
    private void AdvanceAnimation(string name)
    {
        prompt.SetActive(false);
        anim.SetTrigger(name);
    }

    private void OnAnimationEnd()
    {
        float time = climbingData[index].delay;


        if (time == 0f)
        {
            index += 1;
            ButtonPrompt(climbingData[index].keycode.ToString(), climbingData[index].position);
        }
        else
        {
            index += 1;
            StartCoroutine(IdleDelay(time));
        }
        
    }

    IEnumerator IdleDelay(float time)
    {
        yield return new WaitForSeconds(time);
        ButtonPrompt(climbingData[index].keycode.ToString(), climbingData[index].position);
    }

}
