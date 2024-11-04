using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float zBound = 15.0f;
    private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPos();
    }

    private void MovePlayer() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void ConstrainPlayerPos() {
        if (transform.position.z > zBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        } else if (transform.position.z < -zBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }
}
