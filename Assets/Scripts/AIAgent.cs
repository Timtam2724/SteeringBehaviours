using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour {

    public Vector3 force;
    public Vector3 velocity;
    public float maxVelocity = 100f;

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
        force = Vector3.zero; // When you creare a variable in a function, it only exists within that function.
        
        for(int i=0; i < behaviours.Length; i++)
        {
            SteeringBeaviour behaviour = behaviours[i];
            if (!behaviour.enabled)
            {
                continue;
            }
            force += behaviour.GetForce();

            if(force.magnitude > maxVelocity)
            {
                force = force.normalized * maxVelocity;

                break;
            }
        }
    }

    void ApplyVelocity()
    {
        velocity += force * Time.deltaTime;

        if(velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }

        if(velocity != Vector3.zero)
        {
            transform.position += velocity * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}
