using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        weapon pickableItem = other.gameObject.GetComponent<weapon>();
        if(pickableItem){
            Debug.Log("Collision PLayer avec "+pickableItem.getWeaponName());
            //notify weaponManager
            GetComponent<AllWeaponsManagerImproved>().setActiveWeapon(pickableItem.getWeaponID());
            //pickableItem.gameObject.SetActive(false);

            Destroy(pickableItem.gameObject);
        }
        else{
            Debug.Log("This Go dont have a weapon component on it ");
        }
       

       
    }
}
