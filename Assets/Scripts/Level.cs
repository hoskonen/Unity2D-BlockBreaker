using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int blockCount;

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
    }
}