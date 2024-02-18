using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory inv;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "Treasure":
                    inv.IncrementTreasures(1);
                    break;
                case "Tuna":
                    inv.IncrementTuna(1);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
