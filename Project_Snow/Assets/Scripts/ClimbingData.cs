using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum AnimationTriggers
{
    HangIdle,
    HangJump,
    HangDrop,
    HangJumpLeft,
    HangJumpRight,
    HangMoveLeft,
    HangMoveRight,
    RopeClimbFast,
    RopeClimbSlow,
    RopeIdle,
    WallClimb

}

[Serializable]
public class ClimbingData
{
    public KeyCode keyPrompt;

    public AnimationTriggers animation;

    public float speed = 1;

    public int repeatAnimation;

    public float delay;

    public Vector3 position;

    public bool advanceDialogue;

}
