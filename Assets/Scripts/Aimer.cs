using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    public Camera cam;
    public float mouseWheight;
    private float oppOverAdj;

    

    void Update()
    {
        Vector3 mousePosition=GetMouseWorldPosition();
        Vector3 characterPosition = gameObject.transform.position;
        Vector3 characterRotation = gameObject.transform.eulerAngles;
        Vector3 relationVector = new Vector3(mousePosition.x-characterPosition.x, mousePosition.y-characterPosition.y, 0);
        cam.transform.position = characterPosition+(mouseWheight*relationVector)+(new Vector3(0,0,-10));
        oppOverAdj = (mousePosition.y-characterPosition.y)/(mousePosition.x-characterPosition.x);
        float relationalAngle = characterRotation.z-Mathf.Atan(oppOverAdj);
        Vector3 relationalRotation = new Vector3(0,0,relationalAngle);
        gameObject.transform.right = (new Vector3(mousePosition.x,mousePosition.y,0)) - characterPosition;
    }

    public Vector3 GetMouseWorldPosition(){
        Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        return temp;
    }
}
