using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform uiInventory;
    [SerializeField] private TMP_Text treasureText;
    [SerializeField] private TMP_Text tunaText;
    [SerializeField] private IntSO tunaSO;
    [SerializeField] private IntSO treasureSO;

    private void Awake()
    {
        treasureText.text = "" + treasureSO.Value;
        tunaText.text = "" + tunaSO.Value;
    }

    public void IncrementTuna(int number)
    {
        tunaSO.Value += number;
        tunaText.text = "" + tunaSO.Value;
    }
    public void IncrementTreasures(int number)
    {
        treasureSO.Value += number;
        treasureText.text = "" + treasureSO.Value;
    }

    public void ResetTreasures()
    {
        treasureSO.Value = 0;
    }

    public int GetNumberOfTuna()
    {
        return tunaSO.Value;
    }

    public int GetNumberOfTreasures()
    {
        return treasureSO.Value;
    }
}
