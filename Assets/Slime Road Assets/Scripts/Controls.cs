using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    //For Keyboard controls
    float movementAmount = 0.1f;

    //For Touch Controls
    float drag;
    bool isStationary;

    //If the game is opened on the editor, it can be played by using Keyboard
    public void ControlWithKeyboard(Transform playerTransform)
    {    
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Translate(Vector3.left * movementAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Translate(Vector3.right * movementAmount);
        }       
    }

    //If the game is opened environment of android or iphone, it can be played by touching
    public void ControlByTouching(Transform playerTransform)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    drag += touch.deltaPosition.x;
                    isStationary = false;
                    break;

                case TouchPhase.Stationary:
                    isStationary = true;
                    break;
            }

            if (!isStationary)
            {
                playerTransform.position = new Vector3(drag * 0.01f,playerTransform.position.y,playerTransform.position.z);
            }
        }
    }
}
