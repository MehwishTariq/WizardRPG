using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Attacks))]
public class AttackType : Editor
{
    Attacks atk;
    SerializedProperty m_type, w_type;

    private void OnEnable()
    {
        atk = (Attacks)target;
        m_type = serializedObject.FindProperty("magicType");
        w_type = serializedObject.FindProperty("weaponType");
    }

    public override void OnInspectorGUI()
    {
        atk.type = (Utility.AttackTypes)EditorGUILayout.EnumPopup("AttackType", atk.type);
        serializedObject.Update();

        if (atk.type == Utility.AttackTypes.Weapon)
            EditorGUILayout.PropertyField(w_type);

        if (atk.type == Utility.AttackTypes.Magic)
            EditorGUILayout.PropertyField(m_type);

        atk.damageVal = EditorGUILayout.FloatField("DamageValue", atk.damageVal);
        atk.healingVal = EditorGUILayout.FloatField("HealingValue", atk.healingVal);
        atk.canHeal = EditorGUILayout.Toggle("CanHeal", atk.canHeal);
        atk.hasParticleFx = EditorGUILayout.Toggle("HasParticleFx", atk.hasParticleFx);
        serializedObject.ApplyModifiedProperties();
    }
}
