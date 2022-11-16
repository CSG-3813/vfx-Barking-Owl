/***
 * Author: Andrew Nguyen
 * Created: 11-16-22
 * Modified: 11-16-22
 * Description: Manages line of sight
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SightLine : MonoBehaviour
{
    public Transform Eyepoint;
    private bool IsTargetInSight = false;
    public string TargetTag = "Player";
    public float FieldOfView = 45f;

    public bool IsTargetInSightLine { get; set; } = false;

    public Vector3 LastKnownSighting { get; set; } = Vector3.zero;

    private SphereCollider ThisCollider;

    private void Awake()
    {
        ThisCollider = GetComponent<SphereCollider>();
        LastKnownSighting = transform.position;
    }

    private bool TargetInFOV(Transform target)
    {
        Vector3 DirToTarget = target.position - Eyepoint.position;
        float angle = Vector3.Angle(Eyepoint.forward, DirToTarget);

        if (angle <= FieldOfView)
        {
            return true;
        }

        return false;
    }

    private bool HasClearLineOfSightToTarget(Transform target)
    {
        RaycastHit info;

        Vector3 DirToTarget = (target.position - Eyepoint.position).normalized;

        if (Physics.Raycast(Eyepoint.position, DirToTarget, out info, ThisCollider.radius))
        {
            if (info.transform.CompareTag(TargetTag))
            {
                return true;
            }
        }

        return false;
    }

    private void UpdateSight(Transform target)
    {
        IsTargetInSightLine = HasClearLineOfSightToTarget(target) && TargetInFOV(target);
        if (IsTargetInSightLine)
        {
            LastKnownSighting = target.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(TargetTag))
        {
            Debug.Log("Player spotted"); 
            UpdateSight(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(TargetTag))
        {
            IsTargetInSightLine = false;
        }
    }
}
