using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sdetail : MonoBehaviour
{
    public GameObject detailtextbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        
        detailtextbox.SetActive(true);
         
    }

    private void OnMouseExit()
    {
        detailtextbox.SetActive(true);

    }
}
