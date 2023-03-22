using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField]
    private WeatherController weather;
    [SerializeField]
    private EndPromptController promptCont;
    [SerializeField]
    private Image fadeOut;

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
        if (Input.GetKeyDown(KeyCode.X))
        {
            fadeOut.gameObject.SetActive(true);
            StartCoroutine(FadeOut(4f));
        }

        prompt.transform.position = location + gameObject.transform.position;

        if (Input.GetKeyDown(key))
        {
            AdvanceAnimation(climbingData[index].animation.ToString(), climbingData[index].speed);         
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
            weather.AdvanceWeather();
            promptCont.AdvancePrompt();
        }      
    }

    private void CheckAnimationTimer()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= climbingData[index].repeatAnimation && !anim.IsInTransition(0))
        {
            print("animation over");
            anim.SetTrigger("HangIdle");
            OnAnimationEnd();
        }
    }
    
    private void AdvanceAnimation(string name, int speed)
    {
        prompt.SetActive(false);
        anim.SetTrigger(name);
        anim.speed = speed;
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


    IEnumerator FadeOut(float time)
    {
        for (int i = 0; i < 255; i++)
        {
            yield return new WaitForSeconds(time/255);

            print(i);
            var tempColor = fadeOut.color;
            tempColor.a = i/255f;
            fadeOut.color = tempColor;          
        }
    }
}
