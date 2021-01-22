using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityMultiplier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticleSystem;
    public ParticleSystem dirtSplatterParticleSystem;
    public AudioClip jumpAudioClip;
    public AudioClip crashAudioClip;

    private new Rigidbody rigidbody;
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirtSplatterParticleSystem.Stop();
            audioSource.PlayOneShot(jumpAudioClip);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtSplatterParticleSystem.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosionParticleSystem.Play();
            dirtSplatterParticleSystem.Stop();
            audioSource.PlayOneShot(crashAudioClip);
        }
    }
}
