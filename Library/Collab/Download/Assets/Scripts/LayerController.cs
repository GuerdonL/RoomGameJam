using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class LayerController : MonoBehaviour
{
    public float colorChangeSpeed;
    public List<Tilemap> tiemaps;
    //0-BR
    //1-BR
    //2-R
    //3-R
    //4-RG
    //5-RG
    //6-G
    //7-G
    //8-BG
    //9-BG
    //10-B
    //11-B
    public List<int> loweringAlphas;
    public List<int> raisingAlphas;
    public List<Color> tilemapColors;
    public GameObject player;
    public float transitionSpeed;
   // public GameObject floor1;
   // public GameObject floor2;

    public GameObject blueRed;
    public GameObject redGreen;
    public GameObject greenBlue;
    public GameObject red;
    public GameObject redCol;
    public GameObject green;
    public GameObject greenCol;
    public GameObject blue;
    public GameObject blueCol;
    public enum layer
    {
        red,
        green,
        blue
    };
    public layer layerSelected;

    private List<GameObject> raisedLayers;
     private List<GameObject> loweredLayers;
    private List<GameObject> disbaledLayers;
    private bool changing;
    //private GameObject transitionLayer; dont need to edit transition layer?
    private GameObject toDisableTransitionLayer;
    private GameObject oldLayer;
    private GameObject oldLayerCollider;
    private Vector3 playerPausedPosition;
    private GameObject newTransitionLayer;
    private GameObject newLayer;
    private GameObject newLayerCollider;
    private float realTime;
    private void Start() {
        tilemapColors = new List<Color>();
        foreach(Tilemap tm in tiemaps){
            tilemapColors.Add(tm.color);
        }
        realTime = transitionSpeed;
        transitionSpeed = 0.01f;
        bool done = TransitionLayers(layer.green);
        while(changing){}
        done = TransitionLayers(layer.blue);
        while(changing){}
        done = TransitionLayers(layer.red);

    }
    public void TransitionByNum(int num){
        switch(num){
            case 0:
                TransitionLayers(layer.red);
                break;
            case 1:
                TransitionLayers(layer.green);
                break;
            default:
                TransitionLayers(layer.blue);
                break;
        }
    }
    public bool TransitionLayers(layer target){
        changing = true;
        player.GetComponent<Player>().enabled =false;


        switch(target){
            case layer.red:
                Debug.Log("well its here at least");
                newLayer = red;
                newLayerCollider = redCol;                                     
                toDisableTransitionLayer = greenBlue;


                switch(layerSelected){
                    case layer.green:
                        oldLayer = green;
                        oldLayerCollider = greenCol;
                        Debug.Log("assigned tho...");
                        newTransitionLayer = blueRed;
                        raisingAlphas = new List<int>{2,3,0,1};
                        loweringAlphas = new List<int>{6,7,8,9};
                        
                        break;

                    case layer.blue:
                        oldLayer = blue;
                        oldLayerCollider = blueCol;
                        newTransitionLayer = redGreen;
                        raisingAlphas = new List<int>{2,3,4,5};
                        loweringAlphas = new List<int>{10,11,8,9};

                        break;

                    default:
                            Debug.Log(layerSelected);
                        break;
                }
                break;
            
            case layer.green:
                newLayer = green;
                newLayerCollider = greenCol;                                        
                toDisableTransitionLayer = blueRed;

                switch(layerSelected){
                    case layer.red:
                        oldLayer = red;
                        oldLayerCollider = redCol;
                        newTransitionLayer = greenBlue;
                        raisingAlphas = new List<int>{6,7,8,9};
                        loweringAlphas = new List<int>{2,3,0,1};
                        break;
                    case layer.blue:
                        oldLayer = blue;
                        oldLayerCollider = blueCol;
                        newTransitionLayer = redGreen;
                        raisingAlphas = new List<int>{6,7,4,5};
                        loweringAlphas = new List<int>{0,1,10,11};
                        break;
                    default:
                        break;
                }
                break;
            
            case layer.blue:
                newLayer = blue;
                newLayerCollider = blueCol;                                        
                toDisableTransitionLayer = redGreen;

                switch(layerSelected){
                    case layer.red:
                        oldLayer = red;
                        oldLayerCollider = redCol;
                        newTransitionLayer = greenBlue;
                        raisingAlphas = new List<int>{10,11,8,9};
                        loweringAlphas = new List<int>{4,5,2,3};
                        break;
                    case layer.green:
                        oldLayer = green;
                        oldLayerCollider = greenCol;
                        newTransitionLayer = blueRed;
                        raisingAlphas = new List<int>{10,11,0,1};
                        loweringAlphas = new List<int>{4,5,6,7};
                        break;
                    default:
                        break;
                }
                break;

            default:
                break;
        }
        //rg, gb, and g are up all else is dimmed. g collidor is on.
        //freeze player, disable g collidor
        oldLayerCollider.SetActive(false);
        layerSelected = target;
        //reset z on gb and g to 0
        //gb and g are at (0,-1, 0). rg is at (0,0,-5)
        //disable gb
        //set rb and r to (0,-1,-5)
        //begin raising rb and r to (0,0,-5) brighten as they rise
        //enable red collidor, unfreeze player.
        return true;
    }
    private void ChangeOpacity(List<int> indeces, GameObject layer){
        foreach(int index in indeces){
                    Color trueColor = tilemapColors[index];
                    //y is somewhere between -1 and 0. add 1 to normalize. divide by 2, [0,.5] add .5. rearranged, gets the below.
                    float correctedPos = (layer.transform.localPosition.y)/2 +1;
                    float r = trueColor.r*(correctedPos);
                    float g = trueColor.g*(correctedPos);
                    float b = trueColor.b*(correctedPos);
                    float a = trueColor.a;//correctedPos;
                    //tiemaps[index].color = new Color(trueColor.r,trueColor.g,trueColor.b,a);
                    tiemaps[index].color = new Color(r,g,b,a);
                    Debug.Log(a);
                }
    }
    private void Update() {
        if(changing){

            float movementSpeed = (1/transitionSpeed)*Time.deltaTime;

            //gb, and g go down 
            if(!(oldLayer.transform.localPosition.y<=-1)){
                Vector3 decrement = new Vector3(0, movementSpeed,0);
                float positionY = (oldLayer.transform.localPosition-=decrement).y;
                toDisableTransitionLayer.transform.localPosition-=decrement;

                //dimming as they do
                ChangeOpacity(loweringAlphas, oldLayer);


                if(positionY<-1){
                    //reset z on gb and g to 0
                    oldLayer.transform.localPosition =  new Vector3  (0,-1,0);
                    toDisableTransitionLayer.transform.localPosition = new Vector3(0,-1,0);
                    //disable gb
                    toDisableTransitionLayer.SetActive(false);
                    //reenable transition layer
                    newTransitionLayer.SetActive(true);
            
                    //set rb and r to (0,-1,-5)
                    newTransitionLayer.transform.localPosition=new Vector3(0,-1,-5);
                    newLayer.transform.localPosition = new Vector3(0,-1,-5);
                    Debug.Log(newLayer.transform.localPosition);
                }
            }
            //begin raising rb and r to (0,0,-5)
            else if(newLayer.transform.localPosition.y<=0){
                Vector3 increment = new Vector3(0,movementSpeed,0);
                float positionY = (newLayer.transform.localPosition+=increment).y;
                newTransitionLayer.transform.localPosition+=increment;

                //brighten as they rise
                ChangeOpacity(raisingAlphas,newLayer);


                if(newLayer.transform.localPosition.y>=0){
                    //ensure correct position
                    newLayer.transform.localPosition =  new Vector3  (0,0,-5);
                    newTransitionLayer.transform.localPosition = new Vector3(0,0,-5);
                    newLayerCollider.SetActive(true);
                    changing = false;
                    player.GetComponent<Player>().enabled = true;
                    Debug.Log(changing);


                }

            }
        }
            Debug.Log(changing);

    }
}