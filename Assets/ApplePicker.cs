using UnityEngine;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;

    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    private float currentBaskets;

    private GameObject basket;

    void Start()
    {
        basket = Instantiate(basketPrefab) as GameObject;
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY;
        basket.transform.position = pos;
        currentBaskets = numBaskets;      
    }

    public void AppleDestroyed()
    {
        //// Destroy all of the falling Apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        currentBaskets--;
        if (currentBaskets == numBaskets / 3 * 2 || currentBaskets == numBaskets / 3) {
            GameObject.Find("Tree").GetComponent<AppleTree>().lostHeal();
        }
        

        // Restart the game, which doesn't affect HighScore.Score
        if (currentBaskets == 0)
        {
            Application.LoadLevel("scene2");
            basket.GetComponent<Basket>().saveScore();
        }
    }
}