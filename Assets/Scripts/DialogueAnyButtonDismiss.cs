using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnyButtonDismiss : MonoBehaviour
{
    public GameObject nextText;
    void Update()
    {
        if(Input.anyKeyDown){
            gameObject.SetActive(false);
            try{
                nextText.SetActive(true);
            }catch{}
        }
    }
}
