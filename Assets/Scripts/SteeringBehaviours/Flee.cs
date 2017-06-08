using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBeaviour
{
    // Make the character flee
    // Flee from the target
    public GameObject target;
    // How far away from target
    public float distanceFromTarget;
    // Flee to shed
    // float dist


    public override Vector3 GetForce()
    {
        // Start with the force equal to 0
        Vector3 force = Vector3.zero;
        // When there is no target
        if (target == null)
        {
            // Restarts the force when the function finishes
            return force;
        }
        Vector3 desiredForce = target.transform.position - transform.position;
        desiredForce.y = 0f;
        // By times the desiredforce by -1 it reverses the seek to flee
        desiredForce *= -1;
        // Activates the target fleeing if the fox is close enough to the cube
        if (desiredForce.magnitude > 0 && distanceFromTarget <10)
        {
            desiredForce = desiredForce.normalized * weighting;
            force = desiredForce - owner.velocity;
            Debug.Log(force.ToString());
        }
        // Sends message if the first script fails 
        else { Debug.Log("Failed magnitudes"); }
        // After the function, the force will return to zero
        return force;
    }
    void Update()
    {
        // Activates the Distance script
        Distance();
    }
    void Distance()
    {
        // Measures how far away the target is from the fox
        distanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
    }
}
