using UnityEngine;

public class point : MonoBehaviour
{
    public float x;
    public float y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, y, 0);
    }
}
