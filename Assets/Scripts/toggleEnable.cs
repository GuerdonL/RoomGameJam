using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleEnable : MonoBehaviour
{
    public GameObject objectToEnable;
    public static bool disabled=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        objectToEnable.SetActive(false);
        else
        objectToEnable.SetActive(true);
    }
     public void Disable()
    {
        objectToEnable.SetActive(false);
        
        
    }
       public void Enable()
    {
        objectToEnable.SetActive(true);
        
        
    }
}
