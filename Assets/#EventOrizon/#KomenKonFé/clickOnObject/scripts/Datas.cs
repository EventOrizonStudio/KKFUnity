using UnityEngine;
using System.Collections;

public class Datas : MonoBehaviour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private string description;

    public string getName()
    {
        return name;
    }

    public string getDesc()
    {
        return description;
    }
}