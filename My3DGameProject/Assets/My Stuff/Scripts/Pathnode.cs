using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathnode : MonoBehaviour
{
    public Pathnode nextnode;
    public Color debugColor = Color.red;

    private void OnDrawGizmos()
    {
        if(nextnode != null)
        {
            Gizmos.color = debugColor;
            Gizmos.DrawLine(transform.position, nextnode.transform.position);

            Vector3 direction = nextnode.transform.position - transform.position;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (transform.position + direction * 0.5f));
        }            
    }
}
