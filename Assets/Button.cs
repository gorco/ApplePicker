using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public void ChangeScene(string newScene)
    {
        Application.LoadLevel(newScene);
    }
}
