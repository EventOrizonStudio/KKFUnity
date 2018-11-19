using UnityEngine;
using System.Collections;

public class clickManager : MonoBehaviour
{
    [SerializeField]
    private string gameObjectName;

    void OnMouseDown()
    {
        Debug.Log("click sur : " + gameObject.name);
        GameObject ihm = GameObject.Find(gameObjectName);
        if (ihm != null)
        {
            Datas datas = GetComponent<Datas>();
            ihm.BroadcastMessage("updatePanel", datas); //les données sont maintenant transmises
        }
    }
}