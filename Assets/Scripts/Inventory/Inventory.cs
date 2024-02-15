using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform uiInventory;
    [SerializeField] private TMP_Text treasureText;
    [SerializeField] private TMP_Text tunaText;
    [SerializeField] private FloatSO tunaSO;
    [SerializeField] private FloatSO treasureSO;

    private void Awake()
    {
        treasureText.text = "" + treasureSO.Value;
        tunaText.text = "" + tunaSO.Value;
    }

    public void IncrementTuna(float number)
    {
        tunaSO.Value += number;
        tunaText.text = "" + tunaSO.Value;
    }
    public void IncrementTreasures(float number)
    {
        treasureSO.Value += number;
        treasureText.text = "" + treasureSO.Value;
    }

}
