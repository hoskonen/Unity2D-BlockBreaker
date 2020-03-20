using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;

    // Cached reference
    private Level level;
    private GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Camera.main)
        {
            DestroyBlock();
            gameStatus.AddToScore();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        Destroy(gameObject);
    }
}