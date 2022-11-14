/***
 * Author: Andrew Nguyen
 * Created: 11-14-22
 * Modified: 11-14-22
 * Description: Makes AI move to destination
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent ThisAgent;
    public Transform Destination;
    
    private void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisAgent.SetDestination(Destination.position); //This is a proprty of the agent and it will go there
    }
}
