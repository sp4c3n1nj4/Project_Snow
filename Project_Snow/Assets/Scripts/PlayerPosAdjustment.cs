using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosAdjustment : MonoBehaviour
{
    [SerializeField]
    private float wallOffset;

    private Vector3 raycastPoint;

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, WallRaycast() - wallOffset);
    }

    private float WallRaycast()
    {
        float z = 0;

        RaycastHit hitInfo;
        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hitInfo))
        {
            raycastPoint = hitInfo.point;
            z = hitInfo.point.z;
        }

        return z;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(raycastPoint, 0.2f);
    }
}
