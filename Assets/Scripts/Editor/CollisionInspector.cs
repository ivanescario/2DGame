using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Collisions))]
public class CollisionInspector : Editor
{
    static bool stateFoldout;
    static bool drawDefaultInspector;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); // Si se deja escrito, no afecta. Se visualiza de manera normal la información en el inspector.
        Collisions col = (Collisions)target;

        GUIStyle booleanText = new GUIStyle();

        EditorGUILayout.Space();

        EditorGUI.indentLevel = 1; // La posición en X que desplaza el botón
        stateFoldout = EditorGUILayout.Foldout(stateFoldout, "State", true, EditorStyles.toolbarDropDown);

        if(stateFoldout)
        {
            EditorGUILayout.Space(); // Aplica un espacio entre el texto anterior escrito y el siguiente.
            EditorGUILayout.BeginVertical(EditorStyles.textArea);

            EditorGUI.indentLevel = 2; // La posición en X que desplaza el texto 

            if(col.isGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Grounded", booleanText);
            if(col.wasGroundedLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Was Grounded Last Frame", booleanText);
            if(col.justGotGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Got Grounded", booleanText);
            if(col.justNOTGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just NOT Grounded", booleanText);
            if(col.isFalling) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Falling", booleanText);
            if(col.isWall) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Wall", booleanText);
            if (col.wasWallLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Was Wall Last Frame", booleanText);
            if (col.justGotWall) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Got Wall", booleanText);
            if (col.justNotWall) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Not Wall", booleanText);
            if (col.isCeil) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Ceil", booleanText);
            if (col.wasCeilLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Was Ceil Last Frame", booleanText);
            if (col.justGotCeil) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Got Ceil", booleanText);
            if (col.justNotCeil) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just NOT Ceil", booleanText);

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();

        EditorGUI.indentLevel = 1;

        drawDefaultInspector = EditorGUILayout.Foldout(drawDefaultInspector, "Default Inspector", true, EditorStyles.toolbarDropDown);

        if(drawDefaultInspector)
        {
            EditorGUILayout.Space();

            EditorGUI.indentLevel = 2;
            EditorGUILayout.Space();
        }
    }
}
