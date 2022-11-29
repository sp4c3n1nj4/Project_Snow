using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private enum State 
    { 
        idle,
        moving,
        pause
    }

    private State state;
    private int index = 0;

    [SerializeField]
    private ClimbingData[] climbingData;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject prompt;
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private DialogueController controller;

    private void Start()
    {
        ButtonPrompt(climbingData[index].keyPrompt.ToString());
    }

    private void Update()
    {
        if(state.Equals(State.idle))
            CheckPromptInput(climbingData[index].keyPrompt, climbingData[index].position);
        else if(state.Equals(State.moving))
            CheckAnimationTimer();
    }

    private void CheckPromptInput(KeyCode key, Vector3 location)
    {
        prompt.transform.position = Camera.main.WorldToScreenPoint(location);

        if (Input.GetKeyDown(key))
        {
            AdvanceAnimation(climbingData[index].animation.ToString());           
        }
    }

    private void ButtonPrompt(string key)
    {        
        promptText.text = key;
        prompt.SetActive(true);
        state = State.idle;

        if (climbingData[index].advanceDialogue)
        {
            controller.AdvanceDialogue();
        }      
    }

    private void CheckAnimationTimer()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 2 && !anim.IsInTransition(0))
        {
            anim.SetTrigger("Idle");
            OnAnimationEnd();
        }
    }
    
    private void AdvanceAnimation(string name)
    {
        prompt.SetActive(false);
        anim.SetTrigger(name);
        state = State.moving;
    }

    private void OnAnimationEnd()
    {
        float time = climbingData[index].delay;
        if (time == 0f)
        {
            index += 1;
            if (climbingData.Length <= index)
            {
                EndOffArray();
                return;
            }
            ButtonPrompt(climbingData[index].keyPrompt.ToString());
        }
        else
        {
            index += 1;
            StartCoroutine(IdleDelay(time));
        }       
    }

    IEnumerator IdleDelay(float time)
    {
        state = State.pause;
        yield return new WaitForSeconds(time);

        if (climbingData.Length <= index)
            EndOffArray();
        else
            ButtonPrompt(climbingData[index].keyPrompt.ToString());
    }

    private void EndOffArray()
    {
        Debug.LogError("End of Array reached");
    }

}
