using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform trans;
    public float moveSpeed = 5f;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent(Transform);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate() {
        
    }
}
