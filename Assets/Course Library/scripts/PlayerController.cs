using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier = 10;
    private bool isStay = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerRB.AddForce(Vector3.up * 500);
        Physics.gravity *= gravityModifier;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isStay == true )
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isStay = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isStay = true;
    }
}
