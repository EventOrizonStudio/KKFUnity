using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWeaponsManagerImproved : MonoBehaviour
{
    [SerializeField]
    private Transform leftRoot;
    [SerializeField]
    private Transform rightRoot;

    //second version with componenet
    [SerializeField]
    private GameObject playerRoot;



    [SerializeField]
    private List<GameObject> weapons;

    [SerializeField]
    private int currentWeaponID = 0; //exposed only for debug

    [SerializeField]
    private bool isChildMode;

    // Start is called before the first frame update
    void Start()
    {
        if(isChildMode){
            fillWeaponsListFromRoots();
        }
        else{
            fillWeaponsListFromComponents();
        }
        //keep old activatino process
        resetWeapons();
        weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            changeToNextWeapon();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            resetWeapons();
        }
    }

//https://docs.unity3d.com/ScriptReference/GameObject.html
    //https://docs.unity3d.com/ScriptReference/GameObject.GetComponents.html
    private void fillWeaponsListFromComponents(){
        weapon[] weaponsCompoList;

        weaponsCompoList = playerRoot.GetComponentsInChildren<weapon>();//GetComponents(typeof(weapon));

        foreach(weapon item in weaponsCompoList){
            weapons.Add(item.gameObject);
        }
    }

    private void fillWeaponsListFromRoots(){
        foreach(Transform child in leftRoot){
            weapons.Add(child.gameObject);
        }
        foreach(Transform child in rightRoot){
            weapons.Add(child.gameObject);
        }
    }

    private void resetWeapons(){
        foreach(GameObject weapon in weapons){
            weapon.SetActive(false);
        }
    }

    private void changeToNextWeapon(){
        currentWeaponID++;
        currentWeaponID = Mathf.Clamp(currentWeaponID,0,weapons.Count-1);
        if(currentWeaponID == weapons.Count-1)
            currentWeaponID = 0;
        resetWeapons();
        weapons[currentWeaponID].SetActive(true);
    }

    
    //upgrade for picking items 
    public void setActiveWeapon(int weaponID){
        resetWeapons();
        if(weaponID > weapons.Count-1){
            Debug.LogError("Pas possible ... cet Id n'existe pas dans la scène");
            return;
        }

        currentWeaponID = weaponID;
        weapons[currentWeaponID].SetActive(true);
    }
}
