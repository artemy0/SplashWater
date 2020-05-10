using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player Player;

    private float screenWidth;

    private Vector2 previousPos, currentPos;

    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        screenWidth = camera.pixelWidth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;

            //свайп по свему экрану = 1
            float xDelta = currentPos.x - previousPos.x;
            float normalizedXDelta = xDelta / screenWidth;

            previousPos = currentPos;

            //Действия над игроком
            Player.SideMovement(normalizedXDelta);
        }
    }
}
