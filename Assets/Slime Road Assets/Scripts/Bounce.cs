using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    Rigidbody rigidbodyOfThePlayer;

    public bool isPlayerHitARing = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform") && !BallManager.Instance.isThePlayerHitARing)
        {
            rigidbodyOfThePlayer = gameObject.GetComponent<Rigidbody>();
            rigidbodyOfThePlayer.velocity = new Vector3(0f, 15.5f, 0f);
        }
    }
}
