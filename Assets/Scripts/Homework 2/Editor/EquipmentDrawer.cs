using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Equipment))]
public class EquipmentDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        float currentX = position.x;
        Rect nameRect = new Rect(currentX += 0, position.y, (Screen.width - position.x) * (2/10f), position.height);
        Rect valueRect = new Rect(currentX += (Screen.width - position.x) * (2 / 10f), position.y, (Screen.width - position.x) * (1/10f), position.height);
        Rect rarityRect = new Rect(currentX += (Screen.width - position.x) * (1 / 10f), position.y, (Screen.width - position.x) * (2 / 10f), position.height);
        Rect slotRect = new Rect(currentX += (Screen.width - position.x) * (2 / 10f), position.y, (Screen.width - position.x) * (2 / 10f), position.height);

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("Name"), GUIContent.none);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("Value"), GUIContent.none);
        EditorGUI.PropertyField(rarityRect, property.FindPropertyRelative("Rarity"), GUIContent.none);
        EditorGUI.PropertyField(slotRect, property.FindPropertyRelative("Slot"), GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}

