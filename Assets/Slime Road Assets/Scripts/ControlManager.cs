using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour {

    Transform playerTransform;

    Controls controls;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("player").transform;

        controls = gameObject.AddComponent<Controls>();
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (!BallManager.Instance.isThePlayerHitARing)
        {
            controls.ControlWithKeyboard(playerTransform);
        }
        #endif

        #if UNITY_IOS
        if(!BallManager.Instance.isThePlayerHitARing)
        {
            controls.ControlByTouching(playerTransform);
        }
        #endif

        #if UNITY_ANDROID
        if (!BallManager.Instance.isThePlayerHitARing)
        {
            controls.ControlByTouching(playerTransform);
        }
        #endif
    }
}
