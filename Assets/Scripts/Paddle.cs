using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16;
    [SerializeField] private float minXPosition = 1f;
    [SerializeField] private float maxXPosition = 15f;

    // Update is called once per frame
    void Update()
    {
        /*
         * mouse location : Input.mousePosition.x
         * screen width : Screen.width
         * camera width : 16 (check from the camera object inspector: size)
         */

        float mousePositionInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnit, minXPosition, maxXPosition);
        transform.position = paddlePosition;
    }
}