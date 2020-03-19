using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;

    private Vector2 paddleToBallVector;
    private bool isLaunched = false;

    // Cached component referenced
    private AudioSource myAudioSource;

    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
            isLaunched = true;
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLaunched)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}