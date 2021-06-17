using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{

    public GameObject sex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        
        Synerge.angelcount = 7;
        Synerge.demoncount = 5;
        Synerge.humancount = 3;
        Synerge.spritcount = 1;
        Synerge.oraclecount = 1;
        sex.GetComponent<Synerge>().change();
    }

    private void OnMouseExit()
    {
        

    }
}
