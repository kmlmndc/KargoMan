using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 1, 0, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 1.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You hit something...");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("The Package was picked");
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
        }
        

        if (other.tag == "Customer" && hasPackage){
            Debug.Log("The Package was delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            
        }
    }
}
