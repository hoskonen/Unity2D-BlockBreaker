using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI blockLeft;
    public Level level;

    // Start is called before the first frame update
    void Start()
    {
        blockLeft = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        blockLeft.text = $"Blocks left: {level.blockCount}";
    }
}