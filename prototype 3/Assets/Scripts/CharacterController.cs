using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //anim
    private Animator playerAnimator;
    // physics
    private Rigidbody rb;
    public float force = 10;
    public float gravityChanger = 1 ;
    // bools
    private bool isGrounded = true;
    public bool gameOver = false;
    //sounds
    public AudioClip jump;
    public AudioClip crash;
    private AudioSource source;
    // particle systems
    public ParticleSystem smokeExplosion;
    public ParticleSystem splatter;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityChanger;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
       
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump_trig");
            splatter.Stop();
            source.PlayOneShot(jump);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            splatter.Play();
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            smokeExplosion.Play();
            splatter.Stop();
            source.PlayOneShot(crash);
        }
    }
}
