using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class infosController : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToControl; //le  panel à contrôler

    [SerializeField]
    private Text textToUpdate; //le composant Text à contrôler

    [SerializeField]
    private Text descTextToUpdate; //pour la description

    void updatePanel(Datas datas)
    {
        panelToControl.SetActive(true);
        textToUpdate.text = datas.getName();
        descTextToUpdate.text = datas.getDesc();

    }

    public void closePanel(){
        panelToControl.SetActive(false);
    }
}