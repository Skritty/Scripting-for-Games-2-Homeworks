using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Equipment> CurrentlyEquipped = new List<Equipment>();
    [Space]
    [Header("Add New Equipment to Currently Equipped")]
    public Equipment NewEqipment;
}
