using UnityEngine;
using UnityEditor;

public class EnterPlayModeCustomWindow : EditorWindow
{
    [MenuItem("�Đ����[�h�J�n���ݒ�/�ݒ�p�E�B���h�E")]
    public static void ShowMyEditor()
    {
        EditorWindow wnd = GetWindow<EnterPlayModeCustomWindow>();
        wnd.titleContent = new GUIContent("�Đ����[�h�J�n���ݒ�");
    }

    //�E�B���h�E�̒��g
    void OnGUI()
    {
        const string SettingsAssetPath = "ProjectSettings/EditorSettings.asset";
        SerializedObject settingsManager = new SerializedObject(UnityEditor.AssetDatabase.LoadAllAssetsAtPath(SettingsAssetPath)[0]);
        SerializedProperty m_EnterPlayModeOptionsEnabled = settingsManager.FindProperty("m_EnterPlayModeOptionsEnabled");
        SerializedProperty m_EnterPlayModeOptions = settingsManager.FindProperty("m_EnterPlayModeOptions");

        EditorGUILayout.BeginVertical("BOX");
        if (GUILayout.Button("�Đ����[�h�̊J�n���I�v�V����  :  " + (m_EnterPlayModeOptionsEnabled.boolValue ? "�L��" : "����")))
        {
            if (m_EnterPlayModeOptionsEnabled.boolValue == false)
            {
                m_EnterPlayModeOptionsEnabled.boolValue = true;
                settingsManager.ApplyModifiedProperties();
                //Debug.Log("<color=yellow>�y�Đ����[�h�J�n���ݒ�z</color>�Đ����[�h�̊J�n���I�v�V������<color=green>�L��</color>�ɂ��܂���");
            }
            else if (m_EnterPlayModeOptionsEnabled.boolValue == true)
            {
                m_EnterPlayModeOptionsEnabled.boolValue = false;
                settingsManager.ApplyModifiedProperties();
                //Debug.Log("<color=yellow>�y�Đ����[�h�J�n���ݒ�z</color>�Đ����[�h�̊J�n���I�v�V������<color=red>����</color>�ɂ��܂���");
            }
        }

        Rect r = GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptionsEnabled.boolValue)
        {
            EditorGUI.DrawRect(r, new Color(0f, 1f, 0f, 0.15f));
        }
        else
        {
            EditorGUI.DrawRect(r, new Color(1f, 0f, 0f, 0.15f));
        }

        EditorGUILayout.Space(10);
        EditorGUI.BeginDisabledGroup(!m_EnterPlayModeOptionsEnabled.boolValue);

        //�h���C���̍ă��[�h
        if (GUILayout.Button("�h���C�����ă��[�h  :  " + (m_EnterPlayModeOptions.intValue == 0 ? "�L��" : (m_EnterPlayModeOptions.intValue == 2) ? "�L��" : "����")))
        {
            if (m_EnterPlayModeOptions.intValue == 0)
            {
                m_EnterPlayModeOptions.intValue = 1;
                settingsManager.ApplyModifiedProperties();
            }
            else if (m_EnterPlayModeOptions.intValue == 1)
            {
                m_EnterPlayModeOptions.intValue = 0;
                settingsManager.ApplyModifiedProperties();
            }
            else if (m_EnterPlayModeOptions.intValue == 2)
            {
                m_EnterPlayModeOptions.intValue = 3;
                settingsManager.ApplyModifiedProperties();
            }
            else if (m_EnterPlayModeOptions.intValue == 3)
            {
                m_EnterPlayModeOptions.intValue = 2;
                settingsManager.ApplyModifiedProperties();
            }
        }

        Rect r2 = (Rect)GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptions.intValue == 2 || m_EnterPlayModeOptions.intValue == 0)
        {
            EditorGUI.DrawRect(r2, new Color(0f, 1f, 0f, 0.05f));
        }
        else
        {
            EditorGUI.DrawRect(r2, new Color(1f, 0f, 0f, 0.05f));
        }

        //�V�[�����ă��[�h
        if (GUILayout.Button("�V�[�����ă��[�h  :  " + (m_EnterPlayModeOptions.intValue == 0 ? "�L��" : (m_EnterPlayModeOptions.intValue == 1) ? "�L��" : "����")))
        {
            if (m_EnterPlayModeOptions.intValue == 0)
            {
                m_EnterPlayModeOptions.intValue = 2;
                settingsManager.ApplyModifiedProperties();
            }
            else if (m_EnterPlayModeOptions.intValue == 1)
            {
                m_EnterPlayModeOptions.intValue = 3;
                settingsManager.ApplyModifiedProperties();
            }
            else if (m_EnterPlayModeOptions.intValue == 2)
            {
                m_EnterPlayModeOptions.intValue = 0;
                settingsManager.ApplyModifiedProperties();
            }
            else if (m_EnterPlayModeOptions.intValue == 3)
            {
                m_EnterPlayModeOptions.intValue = 1;
                settingsManager.ApplyModifiedProperties();
            }
        }

        Rect r3 = (Rect)GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptions.intValue == 1 || m_EnterPlayModeOptions.intValue == 0)
        {
            EditorGUI.DrawRect(r3, new Color(0f, 1f, 0f, 0.05f));
        }
        else
        {
            EditorGUI.DrawRect(r3, new Color(1f, 0f, 0f, 0.05f));
        }
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndVertical();
    }
}
