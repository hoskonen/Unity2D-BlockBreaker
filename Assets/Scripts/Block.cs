using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Camera.main)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}