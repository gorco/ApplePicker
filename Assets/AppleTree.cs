using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {
    
    // Prefab for instantiating apples
    public GameObject applePrefab;
    
    // Speed at which the AppleTree moves in meters/second
    public float speed = 1f;
    
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    
    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;
    
    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    public Sprite appareance1;

    public Sprite appareance2;

    public Sprite appareance3;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = appareance1;
        // Dropping apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        // Changing Direction Randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Change direction
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    public void lostHeal()
    {
        Sprite current = GetComponent<SpriteRenderer>().sprite;
        if(current == appareance1)
        {
            GetComponent<SpriteRenderer>().sprite = appareance2;
        } else if (current == appareance2)
        {
            GetComponent<SpriteRenderer>().sprite = appareance3;
        }
    }
}