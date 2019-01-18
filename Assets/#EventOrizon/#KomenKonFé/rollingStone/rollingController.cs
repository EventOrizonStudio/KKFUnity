using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class rollingController : MonoBehaviour {
    
    [SerializeField]
    private float desiredMass = 1000f;

    private Rigidbody rigidBody;
    public float vel;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.maxAngularVelocity = 20f;
        rigidBody.mass = desiredMass;
	}
	
	// Update is called once per frame
	void Update () {
        vel = rigidBody.velocity.magnitude;
	}

	private void OnCollisionEnter(Collision other)
	{
        if(other.gameObject.CompareTag("Destructible")){
            other.gameObject.GetComponent<skelettonController>().launchDie();
            //Destroy(other.gameObject);
        }
	}
}
