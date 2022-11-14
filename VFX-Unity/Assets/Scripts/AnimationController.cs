/***
 * Author: Andrew Nguyen
 * Created: 11-14-22
 * Modified: 11-14-22
 * Description: Manages animations for chick
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]

public class AnimationController : MonoBehaviour
{
    private NavMeshAgent thisNavMeshAgent;
    private Animator thisAnimator;

    public float runVelocity = 0.1f;
    public string animationRunParameter;
    public string animationSpeedParameter;
    private float MaxSpeed;

    private void Awake()
    {
        thisNavMeshAgent = GetComponent<NavMeshAgent>();
        thisAnimator = GetComponent<Animator>();
        MaxSpeed = thisNavMeshAgent.speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //thisAnimator.SetBool(animationRunParameter, thisNavMeshAgent.velocity.magnitude > MaxSpeed);
        thisAnimator.SetFloat(animationSpeedParameter, thisNavMeshAgent.velocity.magnitude / MaxSpeed);
    }
}
