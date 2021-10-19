using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    public Camera cam;
    public float mouseWheight;
    public GameObject aimer;

    public SpriteRenderer spriteRenderer;
    public Sprite lookingRight;
    public Sprite lookingLeft;
    public Sprite lookingBack;
    public Sprite lookingForwards;
    private float camZ;

    private void Start() {
        camZ = cam.transform.position.z;
    }
    void Update()
    {
        Vector3 mousePosition=GetMouseWorldPosition();
        Vector3 characterPosition = gameObject.transform.position;
        Vector3 characterRotation = gameObject.transform.eulerAngles;
        Vector3 relationVector = new Vector3(mousePosition.x-characterPosition.x, mousePosition.y-characterPosition.y, 0);

        cam.transform.position = characterPosition+(mouseWheight*relationVector)+(new Vector3(0,0,camZ));

        float vecSin = (mousePosition.y-characterPosition.y);
        float vecCos = (mousePosition.x-characterPosition.x);
        //|sin| > |cos| && sin is positive && cos is - + or 0 ==> look back
        //|sin| > |cos| && sin is negative && cos is - + or 0 ==> look forward
        //|cos| > |sin| && cos is negative && sin is - + or 0 ==> look left
        //|cos| > |sin| && cos is positive && sin is - + or 0 ==> look right
        if (Mathf.Abs(vecSin/vecCos)<1){
            if(vecCos>0){
                //look right
                spriteRenderer.sprite = lookingRight;
            }
            else {
                //look left
                spriteRenderer.sprite = lookingLeft;

            }
        }
        else{
            if(vecSin>0){
                //look back
                spriteRenderer.sprite = lookingBack;
            }
            else{
                //look forward
                //default case!
                spriteRenderer.sprite = lookingForwards;
            }
        }

        aimer.transform.right = new Vector3((mousePosition.x - aimer.transform.position.x),(mousePosition.y - aimer.transform.position.y),0);

    }

    public Vector3 GetMouseWorldPosition(){
        Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        return temp;
    }
}
