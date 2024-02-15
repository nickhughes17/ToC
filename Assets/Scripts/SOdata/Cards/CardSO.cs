using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardSO : ScriptableObject
{
   public new string name;
   public string description;
   public Sprite artwork;
   public Sprite directionIcon;
   public Sprite attributeIcon;
   public string attributeToAffect;
   public int amountToAffect;
}
