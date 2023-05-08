using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    public float gravityModifier = 1.0f;
    public bool isOnground = true;
    public bool gameOver = false;
    public float jumpForce = 10;
    public AudioClip jumpSound = null;
    public AudioClip crashSound = null;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        // it's the same thing as 
        //Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnground && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnground = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {
            isOnground = true;
            if (gameOver == false) { dirtParticle.Play(); }

        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over !");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1.0f);

        }
    }
}
