using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameBarrier : MonoBehaviour
{
    [SerializeField] private string nextLevel = "";

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            Debug.Log("Exit reached.");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
