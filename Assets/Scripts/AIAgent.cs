using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour {

    public Vector3 force;
    public Vector3 velocity;

    private SteeringBeaviour[] behaviours;

	// Use this for initialization
	void Start () {
        behaviours = GetComponents<SteeringBeaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        ComputeForces();
        ApplyVelocity();
	}

    void ComputeForces()
    {
        /*
        // SET force to zero
        Vector3 force = 0;
        // FOR i = 0 to behaviours count
        for (i = 0) {
            // IF behaviour is enabled
            if (behaviour = true) {
            // Continue
            }
        }
        // SET force to force + behaviour's force

        force = force + behaviours.force();

        // IF force is greater than maxVelocity
        if (force > maxVelocity) {
            // SET force to normalized x maxVelocity
            force = normalized * maxVelocity();
            // BREAK
            Break;
        }
        */
    }

    void ApplyVelocity()
    {
        /*
        // SET velocity to velocity + force x delta time
        velocity = velocity + force * Time.delta.time();
        // IF velocity is greater than maxVelocity
        if (velocity > maxVelocity)
        {
            // SET velocity to velocity normalized x maxVelocity
            velocity = velocity.normalized * maxVelocity;
        }
        // IF velocity is greater than zero
        if (velocity > 0)
        {
            // SET position to position + velocity x delta time
            transform.position = transform.position + velocity * delta.time;
            // SET rotation to Quaternion.LookRotation velocity
            transform.rotation = Quaternion.LookRotation.velocity;
        }
        */
    }
}
