using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float bumpSpeed = 5f;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Boost"){
                moveSpeed = boostSpeed;
                
            }
            if (other.tag == "Bump"){
                moveSpeed = bumpSpeed;
                
            }
        }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);

        
    }
}
