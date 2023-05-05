using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    private Rigidbody PlayerRb;
    public float gravityModifier = 1.0f;
    public bool isOnground = true;
    public bool gameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        // it's the same thing as 
        //Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnground)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnground = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnground = true;
        }else if (collision.gameObject.CompareTag("obstacle"))
        {
            gameOver=true;
            Debug.Log("Game Over !");
        }
    }
}
