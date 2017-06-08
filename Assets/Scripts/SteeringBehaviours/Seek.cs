using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBeaviour {

    public Transform target;
    public float stoppingDistance = 5f;

    public override Vector3 GetForce()
        {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // IF target is null
        if (target == null)
        {
            // Return force
            return force;
        }

        // Set desiredForce to direction from target to owner's position
        Vector3 desiredForce = target.position - owner.transform.position;
        //Set desiredForce y to zero
        desiredForce.y = 0f;

        // If desiredForce is greater than stoppingDistance
        if (desiredForce.magnitude > stoppingDistance)
        {
            // Set desiredForce to desiredForce normalized x weighting
            desiredForce = desiredForce.normalized * weighting;
            // Set force to desiredForce - owner's velocity
            force = desiredForce - owner.velocity;
        }
        // Return force
        return force;
        }
}


