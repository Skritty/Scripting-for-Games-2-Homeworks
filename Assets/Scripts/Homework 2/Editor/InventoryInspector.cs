using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Inventory))]
public class InventoryInspector : Editor
{
    readonly string[] names = { "Zip Zap", "Queen of Cats", "Flavortown's Masterwork" , "Skjaldotterson", "Loreweave", "Bobbert", "Treasure of Ratlantis", "Skullinator", "Multigator" };
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Inventory inv = (Inventory)target;

        GUILayout.BeginHorizontal();
        GUILayout.Label("Buttons Yey");
        if(GUILayout.Button("Equip New Item"))
        {
            inv.CurrentlyEquipped.Add(new Equipment(inv.NewEqipment));
        }
        if(GUILayout.Button("Randomize New Item"))
        {
            inv.NewEqipment.Name = names[Random.Range(0, names.Length - 1)];
            inv.NewEqipment.Value = (int)Random.Range(-99, 99);
            inv.NewEqipment.Rarity = (EquipmentRarity)System.Enum.GetValues(typeof(EquipmentRarity)).GetValue(Random.Range(0, System.Enum.GetValues(typeof(EquipmentRarity)).Length)-1);
            inv.NewEqipment.Slot = (EquipmentSlot)System.Enum.GetValues(typeof(EquipmentSlot)).GetValue(Random.Range(0, System.Enum.GetValues(typeof(EquipmentSlot)).Length) - 1);
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.HelpBox("The randomizer picks between a list of set names. Values can be between -99 and 99. Rarity and Slot are determined at random as well.", MessageType.Info);
    }
}
