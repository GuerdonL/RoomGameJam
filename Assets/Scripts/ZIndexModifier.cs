using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZIndexModifier : MonoBehaviour
{
    private Transform trans;
    public Transform bounds;
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform;
        //col = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = new Vector3(trans.position.x,trans.position.y,bounds.position.y);
    }
}
