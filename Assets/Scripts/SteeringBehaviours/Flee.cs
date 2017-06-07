using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBeaviour
{

    /*   public Transform target;
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
           //Set desiredForece y to zero
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
       }*/

    // Make the character flee
    // Flee from the target
    public GameObject target;
    // How far away from target
    public float distanceFromTarget;
    // Flee to shed
    // float dist


    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        if (target == null)
        {
            return force;
        }
        Vector3 desiredForce = target.transform.position - transform.position;
        desiredForce.y = 0f;
        desiredForce *= -1;
        if (desiredForce.magnitude > 0 && distanceFromTarget <10)
        {
            desiredForce = desiredForce.normalized * weighting;
            force = desiredForce - owner.velocity;
            Debug.Log(force.ToString());
        }
        else { Debug.Log("Failed magnatuds"); }
        return force;
    }
    void Update()
    {
        Distance();

    }
    void Distance()
    {
        distanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
    }
}
