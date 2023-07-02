using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pointAt : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    private Vector2 moveVector;
    private Vector3 startPos;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        startPos= new Vector3(0,2,11);
        rb.gameObject.transform.position = startPos;
    }

    public void MoveTarget(InputAction.CallbackContext context){
        moveVector = context.ReadValue<Vector2>();
        //moveVector = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveVector * moveSpeed *Time.deltaTime;
        //target.position = moveVector;
        transform.LookAt(target, Vector3.up);
    }
}
