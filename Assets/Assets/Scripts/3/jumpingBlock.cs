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

    enum State {onGround, inTheAir};

    State myState = State.ground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yBegin = Block.transform.position.y;

        velocity = maxJumpingHeight;
    }

    // Update is called once per frame
    void Update()
    {
    if( == State.ground)
    {
        velocity = Vector3.zero;

        gravity = Vector3.zero;

        if(Input.GetKeyUp(KeyCode.Space))
        {
            myState = State.inTheAir;

            velocity = velocityBegin;
            gravity = gravityBegin;
            myState = State.airborne;
        }   
    }
    
    if(myState == State.inTheAir)
     {
        if(Block.position.y < 0)
        {

            velocity = Vector3.zero;
             gravity = Vector3.zero;

            myState = State.ground;
        }
        
     }
        velocity += gravity * Time.deltaTime;
        
        Block.position += velocity * Time.deltaTime;   
    }
}
