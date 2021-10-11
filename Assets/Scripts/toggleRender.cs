using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleRender : MonoBehaviour
{
    // Start is called before the first frame update
  public void ToggleVisibility()
  {
   Renderer rend = gameObject.GetComponent<Renderer>();
   if (rend.enabled)
   rend.enabled=false;
   else
   rend.enabled=true;
  }
}
