using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;

public class Collectible : MonoBehaviour, IColliderEventHoverEnterHandler
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
        if (other.gameObject.tag == "Ground")
        {
            bouncingSound.Play();
        }
    }

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        gameController.PlayerCollected(gameObject);
    }
}
