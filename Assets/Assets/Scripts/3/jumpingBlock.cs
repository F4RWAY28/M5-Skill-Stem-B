using Unity.VisualScripting;
using UnityEngine;

public class jumpingBlock : MonoBehaviour
{
    [SerializeField] Transform Block;

    [SerializeField] Vector3 gravityBegin = new Vector3(0, -1, 0);

    [SerializeField] Vector3 maxJumpingHeight = new Vector3(0, 3, 0);

    private float yBegin;

    private Vector3 velocity;

    private Vector3 gravity;

    [SerializeField] private float t;

    enum State {onGround, inTheAir};

    State myState = State.onGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yBegin = Block.transform.position.y;

        velocity = maxJumpingHeight;
    }

    // Update is called once per frame
    void Update()
    {
    if(myState == State.onGround)
    {
        velocity = Vector3.zero;

        gravity = Vector3.zero;

        if(Input.GetKeyUp(KeyCode.Space))
        {
            myState = State.inTheAir;

            velocity = maxJumpingHeight;
            gravity = gravityBegin;
            myState = State.inTheAir;
        }   
    }
    
    if(myState == State.inTheAir)
     {
            
        t += Time.deltaTime;

       if (Block.position.y < yBegin)
        {

            velocity = Vector3.zero;
             gravity = Vector3.zero;

            myState = State.onGround;
        }
        
     }
        velocity += gravity * Time.deltaTime;
        
        Block.position += velocity * Time.deltaTime;   
    }
}
