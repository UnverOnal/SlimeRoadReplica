using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    private static BallManager instance;
    public static BallManager Instance {
        get
        {
            if (instance == null)
            {
                GameObject ballManager = new GameObject(typeof(BallManager).Name);
                instance = ballManager.AddComponent<BallManager>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<BallManager>();  
        }
        else if (instance == null)
        {
            instance = this as BallManager;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private float speed = 7.25f;
    public bool isThePlayerHitARing = false;

    private void Update()
    {
        if (!isThePlayerHitARing)
        {
            //Creates movement towards ahead
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //Constraints ball's movement on x axis so that ball always be on the platform
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-1.5f,1.5f),transform.position.y,transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the player hits a ring stops the game
        if (collision.gameObject.CompareTag("ring"))
        {
            isThePlayerHitARing = true;
        }

        //If the player hits a diamond...
        if (collision.gameObject.CompareTag("diamond"))
        {
            Destroy(collision.gameObject);
        }
    }
}
