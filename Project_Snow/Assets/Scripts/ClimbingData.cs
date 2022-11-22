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
    public KeyCode keycode;

    public AnimationTriggers trigger;

    public float delay;

    public Vector3 position;

}
