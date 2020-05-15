using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWithinDistance : NavMeshMover
{

    public string TagToTrack = "Player";
    GameObject trackerPlayer;
    public float trackingDistance = 2;


    void Start()
    {

        trackerPlayer = GameObject.FindGameObjectWithTag(TagToTrack);

        base.Start();
        
    }


    void Update()
    {

        if(trackerPlayer != null)
        {
            if (Vector3.Distance(transform.position, trackerPlayer.transform.position) <= trackingDistance)
            {
                Resume();
                MoveTo(trackerPlayer);
            }
            else
            {
                MoveTo(transform.position);
                Stop();
            }
    
        }
        
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = DebugLineColor;
        Gizmos.DrawWireSphere(transform.position, trackingDistance);
        
        base.OnDrawGizmos();
    }
}
