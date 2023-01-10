using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;

    [SerializeField] private Text tryCountText;
    [SerializeField] private Text playTimeText;
    private float lastTryPlayTime;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOver;
    private bool play;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Application.targetFrameRate = 60;


    }



    private void Update()
    {
        if (play)
        {
            lastTryPlayTime += Time.deltaTime;
        }
    }

    public void Play()
    {
        play = true;
        ClearBoard();
        lastTryPlayTime = 0;
        Instantiate(player, transform.position, Quaternion.identity, null);
        spawner.enabled = true;
        SaveTryCount();

        mainMenu.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1;

    }

    private static void SaveTryCount()
    {
        if (!PlayerPrefs.HasKey("TryCount"))
        {
            PlayerPrefs.SetInt("TryCount", 0);
        }
        else
        {
            PlayerPrefs.SetInt("TryCount", PlayerPrefs.GetInt("TryCount") + 1);
        }
    }

    private static void ClearBoard()
    {
        Obstacle[] pipes = FindObjectsOfType<Obstacle>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        play = false;
        spawner.enabled = false;
        gameOver.SetActive(true);
        tryCountText.text = "TryCount:  " + PlayerPrefs.GetInt("TryCount").ToString();
        playTimeText.text = "PlayTime:  " + lastTryPlayTime.ToString("F1") + "sec";
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        ClearBoard();
        gameOver.SetActive(false);
        mainMenu.SetActive(true);
    }






}