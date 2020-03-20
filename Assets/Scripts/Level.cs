using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] public int blockCount;

    // cached reference
    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        blockCount++;
    }

    public void BlockDestroyed()
    {
        blockCount--;

        if (blockCount <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void RemoveBlockFromCount()
    {
        blockCount -= 1;
    }
}