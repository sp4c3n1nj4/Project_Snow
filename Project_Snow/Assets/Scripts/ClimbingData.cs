using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum AnimationTriggers
{
    RopeClimb,
    WallClimb
}

[Serializable]
public class ClimbingData
{
    public KeyCode keyPrompt;

    public AnimationTriggers animation;

    public int repeatAnimation;

    public float delay;

    public Vector3 position;

    public bool advanceDialogue;

}
