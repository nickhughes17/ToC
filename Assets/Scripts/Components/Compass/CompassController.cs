using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompassTargeting : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private GameObject player;

    [SerializeField] private TMP_Text interactText;

    [SerializeField] private GameObject compass;

    void Start()
    {
        interactText.gameObject.SetActive(false);
    }
    void Update()
    {
        var dir = target.transform.position - player.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        compass.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    public void ShowInteractText()
    {
        interactText.gameObject.SetActive(true);
    }

    public void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }

    public void ChangeTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
