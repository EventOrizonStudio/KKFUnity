using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField]
    private int weaponID;
     [SerializeField]
    private string weaponName;

     [SerializeField]
    private float  speed = 5f;

    // Start is called before the first frame update
    void Update ()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    public int getWeaponID(){
        return weaponID;
    }
     public string getWeaponName(){
        return weaponName;
    }
}
