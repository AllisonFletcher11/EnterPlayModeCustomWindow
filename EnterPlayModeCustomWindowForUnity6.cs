using UnityEngine;
using UnityEditor;
public class EnterPlayModeCustomWindowForUnity6 : EditorWindow
{
    //Unity6LTS�ȍ~�ł͍Đ����[�h�̐ݒ���@�����������ς���Ă��܂�

    [MenuItem("�Đ����[�h�J�n���ݒ�/�ݒ�p�E�B���h�Ev2")]
    public static void ShowMyEditor()
    {
        EditorWindow wnd = GetWindow<EnterPlayModeCustomWindowForUnity6>();
        wnd.titleContent = new GUIContent("�Đ����[�h�J�n���ݒ�");
    }

    void OnGUI()
    {
        const string SettingsAssetPath = "ProjectSettings/EditorSettings.asset";
        SerializedObject settingsManager = new SerializedObject(UnityEditor.AssetDatabase.LoadAllAssetsAtPath(SettingsAssetPath)[0]);
        //SerializedProperty m_EnterPlayModeOptionsEnabled = settingsManager.FindProperty("m_EnterPlayModeOptionsEnabled");//Unity6LTS���炱�̍��ڂ��Ȃ��Ȃ�܂���
        SerializedProperty m_EnterPlayModeOptions = settingsManager.FindProperty("m_EnterPlayModeOptions");

        EditorGUILayout.BeginVertical("BOX");
        if (GUILayout.Button("�V�[���ƃh���C�����ă��[�h����(�Đ������������Ȃ�)  :  " + (m_EnterPlayModeOptions.intValue == 0 ? "�L��" : "����")))
        {
            m_EnterPlayModeOptions.intValue = 0;
            settingsManager.ApplyModifiedProperties();
        }
        Rect r = GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptions.intValue == 0)
        {
            EditorGUI.DrawRect(r, new Color(0f, 1f, 0f, 0.15f));
        }
        else
        {
            EditorGUI.DrawRect(r, new Color(1f, 0f, 0f, 0.15f));
        }
        EditorGUILayout.Space(10);

        if (GUILayout.Button("�V�[�����h���C�����ă��[�h���Ȃ�  :  " + (m_EnterPlayModeOptions.intValue == 3 ? "�L��" : "����")))
        {
            m_EnterPlayModeOptions.intValue = 3;
            settingsManager.ApplyModifiedProperties();
        }
        Rect r4 = GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptions.intValue == 3)
        {
            EditorGUI.DrawRect(r4, new Color(0f, 1f, 0f, 0.15f));
        }
        else
        {
            EditorGUI.DrawRect(r4, new Color(1f, 0f, 0f, 0.15f));
        }
        EditorGUILayout.Space(5);

        if (GUILayout.Button("�V�[���̂ݍă��[�h����  :  " + (m_EnterPlayModeOptions.intValue == 1 ? "�L��" : "����")))
        {
            m_EnterPlayModeOptions.intValue = 1;
            settingsManager.ApplyModifiedProperties();
        }
        Rect r2 = GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptions.intValue == 1)
        {
            EditorGUI.DrawRect(r2, new Color(0f, 1f, 0f, 0.15f));
        }
        else
        {
            EditorGUI.DrawRect(r2, new Color(1f, 0f, 0f, 0.15f));
        }
        EditorGUILayout.Space(5);

        if (GUILayout.Button("�h���C���̂ݍă��[�h����  :  " + (m_EnterPlayModeOptions.intValue == 2 ? "�L��" : "����")))
        {
            m_EnterPlayModeOptions.intValue = 2;
            settingsManager.ApplyModifiedProperties();
        }
        Rect r3 = GUILayoutUtility.GetLastRect();
        if (m_EnterPlayModeOptions.intValue == 2)
        {
            EditorGUI.DrawRect(r3, new Color(0f, 1f, 0f, 0.15f));
        }
        else
        {
            EditorGUI.DrawRect(r3, new Color(1f, 0f, 0f, 0.15f));
        }
        EditorGUILayout.Space(5);
        EditorGUILayout.EndVertical();
    }
}
