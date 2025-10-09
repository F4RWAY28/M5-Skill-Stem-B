using UnityEngine;

public class ballBounce : MonoBehaviour
{
    Vector3 velocity;
    [SerializeField] Vector3 direction = new Vector3(1, 1, 0);
    public float speed = 2;
    Vector2 min, max;
    private Camera cam;

    [SerializeField] Vector3 gravity = new Vector3(0, -9.81f, 0); // Gravity vector
    [SerializeField] float damping = 0.8f; // Energy loss on bounce

    void Start()
    {
        direction = direction.normalized;
        velocity = direction * speed;
        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        cam = Camera.main;
    }

    void Update()
    {
        // Apply gravity
        velocity += gravity * Time.deltaTime;

        // Move object
        transform.position += velocity * Time.deltaTime;

        // Bounce off bottom
        if (transform.position.y < min.y)
        {
            transform.position = new Vector3(transform.position.x, min.y, transform.position.z);
            velocity.y = -velocity.y + damping;
        }

        // Bounce off top
        if (transform.position.y > max.y)
        {
            transform.position = new Vector3(transform.position.x, max.y, transform.position.z);
            velocity.y = -velocity.y - damping;
        }

        // Bounce off left and right
        if (transform.position.x > max.x)
        {
            transform.position = new Vector3(max.x, transform.position.y, transform.position.z);
            velocity.x = -velocity.x - damping;
        }

        if (transform.position.x < min.x)
        {
            transform.position = new Vector3(min.x, transform.position.y, transform.position.z);
            velocity.x = -velocity.x + damping;
        }

        // Optional: Gradually increase horizontal speed (based on original logic)
        for (int i = 0; i < 1; i++)
        {
            speed += 1f * Time.deltaTime;
        }
    }
}
