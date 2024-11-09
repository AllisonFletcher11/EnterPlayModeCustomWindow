using UnityEngine;
using UnityEditor;
public class EnterPlayModeCustomWindowForUnity6 : EditorWindow
{
    //Unity6LTS以降では再生モードの設定方法が少しだけ変わっています

    [MenuItem("再生モード開始時設定/設定用ウィンドウv2")]
    public static void ShowMyEditor()
    {
        EditorWindow wnd = GetWindow<EnterPlayModeCustomWindowForUnity6>();
        wnd.titleContent = new GUIContent("再生モード開始時設定");
    }

    void OnGUI()
    {
        const string SettingsAssetPath = "ProjectSettings/EditorSettings.asset";
        SerializedObject settingsManager = new SerializedObject(UnityEditor.AssetDatabase.LoadAllAssetsAtPath(SettingsAssetPath)[0]);
        //SerializedProperty m_EnterPlayModeOptionsEnabled = settingsManager.FindProperty("m_EnterPlayModeOptionsEnabled");//Unity6LTSからこの項目がなくなりました
        SerializedProperty m_EnterPlayModeOptions = settingsManager.FindProperty("m_EnterPlayModeOptions");

        EditorGUILayout.BeginVertical("BOX");
        if (GUILayout.Button("シーンとドメインを再ロードする(再生を高速化しない)  :  " + (m_EnterPlayModeOptions.intValue == 0 ? "有効" : "無効")))
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

        if (GUILayout.Button("シーンもドメインも再ロードしない  :  " + (m_EnterPlayModeOptions.intValue == 3 ? "有効" : "無効")))
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

        if (GUILayout.Button("シーンのみ再ロードする  :  " + (m_EnterPlayModeOptions.intValue == 1 ? "有効" : "無効")))
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

        if (GUILayout.Button("ドメインのみ再ロードする  :  " + (m_EnterPlayModeOptions.intValue == 2 ? "有効" : "無効")))
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
