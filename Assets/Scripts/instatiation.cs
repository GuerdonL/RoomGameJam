using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiation : MonoBehaviour
{
    public GameObject tablePrefab;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }


    // Update is called once per frame
    public void zzzzzz()
    {
        Debug.Log("Test");
    }

  public void spawn()
    {
        Debug.Log("spawned");
        GameObject a=Instantiate(tablePrefab) as GameObject;
        a.transform.position=(new Vector2(0,0));
    }


}
