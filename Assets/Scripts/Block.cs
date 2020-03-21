using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockParticleVFX;

    // Cached reference
    private Level level;
    private GameSession gameSession;

    private void Start()
    {
        CountBreakableBlocks();

        gameSession = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (CompareTag("Breakable"))
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Camera.main)
        {
            if (CompareTag("Breakable"))
            {
                DestroyBlock();
                gameSession.AddToScore();
            }
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        if (CompareTag("Breakable"))
        {
            TriggerParticleVfx();
            level.BlockDestroyed();
            Destroy(gameObject);
        }
    }

    private void TriggerParticleVfx()
    {
        if (CompareTag("Breakable"))
        {
            GameObject particle = Instantiate(blockParticleVFX, transform.position, transform.rotation);
            Destroy(particle, 2f);
        }
    }
}