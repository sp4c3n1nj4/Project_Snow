using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool idle;

    [SerializeField]
    private Animator anim;

    private void Start()
    {
        PlayAnimation("RopeClimb");
    }

    private void PlayAnimation(string name)
    {
        anim.SetTrigger(name);
    }

    private void ButtonPrompt()
    {

    }
    
}
