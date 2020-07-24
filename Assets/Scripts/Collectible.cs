using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource bouncingSound;
    private GameController gameController;

    void Start()
    {
        bouncingSound = GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.PlayerCollected(gameObject);
        }
        else if (other.gameObject.tag == "Ground")
        {
            bouncingSound.Play();
        }
    }
}
