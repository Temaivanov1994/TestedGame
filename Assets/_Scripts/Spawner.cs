using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Obstacle obstacle;
    public Transform lastObstacle;
    public float spawnDistance = 2;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    public int obstacleSpeed = 3;


    private void Awake()
    {
        enabled = false;
    }


    private void OnEnable()
    {
        Spawn();
    }
    private void Update()
    {
        if (lastObstacle != null)
        {
            if (Vector3.Distance(transform.position, lastObstacle.position) > spawnDistance)
            {
                Spawn();
            }
        }

    }

    private void Spawn()
    {
        Obstacle _obstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
        lastObstacle = _obstacle.transform;
        _obstacle.speed = obstacleSpeed;
        _obstacle.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }

    public void SetDifficulty(int hardest)
    {
        obstacleSpeed = hardest;
    }



}