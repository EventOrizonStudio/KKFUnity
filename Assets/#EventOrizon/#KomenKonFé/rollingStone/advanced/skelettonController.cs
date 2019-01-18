using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class skelettonController : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void launchDie(){
        BoxCollider collider = GetComponent<BoxCollider>();
        //collider.isTrigger = true;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        collider.size = new Vector3(0.001f, 0.001f, 0.001f);

        anim.SetTrigger("die");
        //Destroy(this.gameObject, 2f);
    }
}
