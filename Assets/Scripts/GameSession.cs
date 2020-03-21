using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    [SerializeField] public TextMeshProUGUI scoreText;

    // State variables
    [SerializeField] public static int currentPlayerScore = 0;

    //
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // Don't destroy GameStatus gameObject when we load another scene!
            DontDestroyOnLoad(gameObject);
            Debug.Log(gameObject.GetInstanceID());
        }
    }

    private void Start()
    {
        scoreText.text = currentPlayerScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentPlayerScore += pointsPerBlockDestroyed;
        scoreText.text = currentPlayerScore.ToString();
    }

    public void ResetScore()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        currentPlayerScore = 0;
        Debug.Log(gameObject.GetInstanceID());
    }
}