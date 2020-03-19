using UnityEngine;

public class Block : MonoBehaviour
{
    public Level level;
    [SerializeField] private AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Camera.main)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            level.RemoveBlockFromCount();
            Destroy(gameObject);
        }
    }
}