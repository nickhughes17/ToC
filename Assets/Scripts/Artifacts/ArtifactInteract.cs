using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArtifactInteract : MonoBehaviour
{

    private bool isInRange { get; set; }
    private bool hasInteracted { get; set; }
    private bool artifactHasDropped { get; set; }
    private int dungeonLevel { get; set; }
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent inRangeAction;
    [SerializeField] private UnityEvent postInteractAction;
    [SerializeField] private UnityEvent artifactPickedUp;

    void Update()
    {
        if (isInRange && !hasInteracted)
        {
            inRangeAction.Invoke();
            if (Input.GetKeyDown(interactKey))
            {
                hasInteracted = true;
                artifactPickedUp.Invoke();
            }
        }
        else if (isInRange && hasInteracted && !artifactHasDropped)
        {
            postInteractAction.Invoke();
            DropArtifact();
            artifactHasDropped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            postInteractAction.Invoke();
        }
    }

    private void DropArtifact()
    {
        Debug.Log("Artifact Dropped!");
    }
}
