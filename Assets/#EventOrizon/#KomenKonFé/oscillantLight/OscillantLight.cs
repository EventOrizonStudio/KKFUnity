using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Light))]
public class OscillantLight : MonoBehaviour {

    [Header ("Paramètres généraux")]
    [SerializeField]
    private float minIntensity = 0; // min intensity
    [SerializeField]
    private float maxIntensity = 4; // max intensity
    [SerializeField]
    private float maxFrequency = 0.1f; // intensity frequency change
    [SerializeField]
    private float minFrequency = 0.01f; 

    private Light light;
    private bool isEffectOn;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();

        if(light != null){
            isEffectOn = true;
            StartCoroutine(changeIntensity());
        }
	}

	private void Update()
	{
        //only for test and tuto purpose
        if(Input.GetKeyDown(KeyCode.Space)){
            isEffectOn = !isEffectOn;
            if(isEffectOn){
                StartCoroutine(changeIntensity());
            }
        }
	}


	IEnumerator changeIntensity(){
        while(isEffectOn){
            //random intensity
            float randomIntensity = Random.Range(minIntensity,maxIntensity);
            //random waiting time
            float randomTime = Random.Range(minFrequency, maxFrequency);

            light.intensity = randomIntensity;
            yield return new WaitForSeconds(randomTime);
        }
        //debug control for stoping coroutine
        Debug.Log("arret de la couroutine");
    }
}
