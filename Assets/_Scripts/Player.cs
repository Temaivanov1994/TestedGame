using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float upForce = 5f;
    [SerializeField] private float gravityScaleDuration = 15;
    public float gravity = -9.81f;
    private float gravityScaleElapsed;

    private Vector3 direction;

    private void Start()
    {
        gravityScaleElapsed = 0;
    }

 
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * upForce;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        GravityScaleTimer();
    }

    private void GravityScaleTimer()
    {
        if (gravityScaleDuration <= gravityScaleElapsed)
        {
            gravity--;
            Debug.Log(gravity);
            gravityScaleElapsed = 0;
        }
        else
        {
            gravityScaleElapsed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

}