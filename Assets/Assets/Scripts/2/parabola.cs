using Unity.VisualScripting;
using UnityEngine;

public class parabola : MonoBehaviour
{
    Vector2 minScreen, maxScreen;
    
    [SerializeField] private int numberOfPoints = 100;

    [SerializeField] point point;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float dx = (maxScreen.x - minScreen.x) / numberOfPoints;

        for(int i = 0; i <= numberOfPoints; i++)
        {
            
            point pointCopy = Instantiate(point);

            pointCopy.x = minScreen.x + i * dx;
            pointCopy.y = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
