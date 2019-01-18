using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject stonePrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spawningAltitude;


    [SerializeField]
    private bool useRayCast;
    [SerializeField]
    private Camera camera;

    private Vector3 hitPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("SPACE");
            spawnStone();
        }

        if (useRayCast)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f))//, layerMask
            {
                //Transform objectHit = hit.transform; //always return (0,0,0)
                hitPoint = hit.point;

                //debug
                //Debug.DrawRay(camera.transform.position, camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");

                // Do something with the object that was hit by the raycast.
                if (Input.GetMouseButtonDown(0))
                {
                    spawnStone();
                }
            }
        }

	}

    private void spawnStone(){
        Debug.Log("Lâcher d'une pierre !!");
        if(useRayCast){
            Debug.Log("hitpoint en  :"+hitPoint);
            spawnPoint.position = new Vector3(hitPoint.x, hitPoint.y+spawningAltitude, hitPoint.z);
        }
        else{
            spawnPoint.position = new Vector3(spawnPoint.position.x, spawningAltitude, spawnPoint.position.z);
        }

        Instantiate(stonePrefab, spawnPoint.position, Quaternion.identity);
    }
}
