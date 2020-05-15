using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveOnTrigger : NavMeshMover
{
    public string TagToTrack = "Player";
    GameObject trackerPlayer;
    bool shouldMove;

    public override void Start()
    {
        trackerPlayer = GameObject.FindGameObjectWithTag(TagToTrack);
        base.Start();
    }

    public void SetShouldMove(bool value)
    {
        shouldMove = value;

        if (trackerPlayer != null)
        {
            if (shouldMove)
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
}
