using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPathFollower : NavMeshMover
{
    public Pathnode CurrrentNode;


  
   public override void Start()
    {
        base.Start();
        MoveToPathNode();
    }

    private void MoveToPathNode()
    {
        if (CurrrentNode != null)
            MoveTo(CurrrentNode.gameObject);
    }

    public void MoveToPathNode(Pathnode node)
    {
        CurrrentNode = node;
        MoveTo(CurrrentNode.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pathnode") && other.gameObject.name == CurrrentNode.name)
        {
            Pathnode node;
            

            //if(other.TryGetComponent<Pathnode>(out node))
            //{
            //    CurrrentNode = node.nextnode;
            //    MoveToPathNode();
            //}
        }

        
    }


}
