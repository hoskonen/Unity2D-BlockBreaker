using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int blockCount;

    private GameObject[] levelBlocks;

    private void Start()
    {
        GetAllLevelBlocks();
    }

    int GetAllLevelBlocks()
    {
        levelBlocks = GameObject.FindGameObjectsWithTag("Block");
        blockCount = levelBlocks.Length;
        return blockCount;
    }

    public void RemoveBlockFromCount()
    {
        blockCount -= 1;

        if (blockCount == 0)
        {
        }
    }
}