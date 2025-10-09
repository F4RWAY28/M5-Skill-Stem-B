using UnityEngine;

public class endlessRunner : MonoBehaviour
{
    [SerializeField] float vBegin = 10;
    [SerializeField] float g;

    Animator animator;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    enum State {running, jumping}

    State myState = State.running;

    [SerializeField] float tMax = 0.867f;

    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.running)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                t = 0;

                myState = State.jumping;

                animator.Play("Jump");

                velocity = new Vector3(0, vBegin, 0);

                g = -2 * vBegin / tMax;

                acceleration = new Vector3(0, g, 0);

                
            }
        }

        if (myState == State.jumping)
        {
            t += Time.deltaTime;

            if(t > tMax)
            {
                myState = State.running;

                velocity = Vector3.zero;
                
                acceleration = Vector3.zero;

                
            }

        }

        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }
}
