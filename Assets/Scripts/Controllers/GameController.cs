using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public bool gameIsRunning { get; set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void StartGame() {
        gameIsRunning = true;
    }

    public void EndGame() {
        gameIsRunning = false;
    }
}
