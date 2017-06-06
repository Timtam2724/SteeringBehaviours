using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class PathFollowing : SteeringBeaviour {

    public Transform target;
    // Distance to current node
    public float nodeRadius = 5f;
    // Distance to end node
    public float targetRadius = 3f;
    private Graph graph;
    private int currentNode = 0;
    private bool isAtTarget = false;
    private List<Node> path;

	// Use this for initialization
	void Start ()
    {
        // SET graph to FindObjectOfType Graph
        graph = FindObjectOfType<Graph>();
        // IF graph is null
        if (graph = null)
        {
            // CALL Debug.LogError() and pass an Error message
            Debug.LogError("Error!");
            // CALL Debug.Break() (pauses the editor)
            Debug.Break();
        }
	}
    // Updates list of nodes for Path Following
    public void UpdatePath()
    {
        // SET path to graph.FindPath() and pass transform's position, target's positon
        path = graph.FindPath(transform.position, target.position);
        // SET currentNode to zero
        currentNode = 0;
    }

    #region SEEK
    // Special version of Seek that takes into account the node radius & target radius
    Vector3 Seek(Vector3 target)
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // SET desiredForce to target - transform's position
        Vector3 desiredForce = target - transform.position;
        // SET desiredForce.y to zero
        desiredForce.y = 0;
        // SET distance to zero
        float distance = 0;
        // IF isAtTarget is true   // HINT: This needs to be done in a ternary operator
        if (isAtTarget == true)
        {
            // SET distance to targetRadius
            distance = targetRadius;
            // ElSE
        } else {
            // SET distance to nodeRadius
            distance = nodeRadius;
        }
        // IF desiredForce's length is greater than distance
        if (desiredForce.magnitude > distance)
        {
            // SET desiredForce to desiredForce.normalized * weighting
            desiredForce = desiredForce.normalized * weighting;
            // SET force to desiredForce - owner's velocity
            force = desiredForce - owner.velocity;
        }
        // RETURN force
        return force;
    }
    #endregion

    #region GetForce
    // Calculates force for behaviour
    public override Vector3 GetForce()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // IF path is not null AND path Count is greater than zero
        if(path != null && path.Count > 0){
            // SET currentPos to current path[currentNode] position
            Vector3 currentPos = path[currentNode].position;
            // IF distance between transform's position and currentPos is less than or equal to nodeRadius
            if (Vector3.Distance(transform.position, currentPos) <= nodeRadius)
            {
                // Increment currentNode
                currentNode++;
                // IF currentNode is greater than or equal to path.Count
                if(currentNode >= path.Count)
                {
                    // SET currentNode to path.Count - 1
                    currentNode = path.Count - 1;
                }
            }
            // SET force to Seek() and pass currentPos
            force = Seek(currentPos);
          }

        #region GIZMOS
        // SET prevposition to path[0].position
        var prevposition = path[0].position;
        // FOREACH node in path
        foreach (var node in path)
        {
            // CALL GizmosGL.AddSphere() and pass node's position, graph's nodeRadius, identity, any color
            GizmosGL.AddSphere(node.position, graph.nodeRadius, transform.rotation, Color.black);
            // CALL GizmosGL.AddLine() and pass node's position
            GizmosGL.AddLine(prevposition,node.position);
            // SET prev to node's position
            prevposition = node.position;
        }    
        #endregion

        // Return force
        return force;
    }
    #endregion
}
