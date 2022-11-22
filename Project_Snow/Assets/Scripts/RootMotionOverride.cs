using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotionOverride : MonoBehaviour
{
    private GameObject parent;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    private void OnAnimatorMove()
    {
        parent.transform.position += animator.deltaPosition;
    }
}
