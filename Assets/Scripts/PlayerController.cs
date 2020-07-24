using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;

    private Rigidbody rb;

    private AudioSource bouncingSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bouncingSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Border")
        {
            bouncingSound.Play();
        }
    }

}
