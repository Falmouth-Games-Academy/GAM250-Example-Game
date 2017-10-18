using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(GameBounds))]
public class GameBoundsPropertyDrawer : PropertyDrawer {

    float controlSize = 80.0f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect topRect = new Rect(position.x + (position.width / 2), position.y, 50, 20);
        Rect leftRect = new Rect(position.x, position.y+40, 50, 20);
        Rect rightRect = new Rect(position.width-30, position.y+40, 50, 20);
        Rect bottomRect = new Rect(position.x + (position.width / 2), position.y+80, 50, 20);

        EditorGUI.PropertyField(topRect, property.FindPropertyRelative("topScreenBounds"), GUIContent.none);
        EditorGUI.PropertyField(bottomRect, property.FindPropertyRelative("bottomScreenBounds"), GUIContent.none);
        EditorGUI.PropertyField(leftRect, property.FindPropertyRelative("leftScreenBounds"), GUIContent.none);
        EditorGUI.PropertyField(rightRect, property.FindPropertyRelative("rightScreenBounds"), GUIContent.none);
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }

    //This needs to be there to control the height of the control!
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label)+ controlSize;
    }
}
