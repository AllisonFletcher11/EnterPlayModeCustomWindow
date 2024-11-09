using UnityEngine;
using UnityEditor;

public class EnterPlayModeCustomWindow : EditorWindow
{
    [MenuItem("再生モード開始時設定/設定用ウィンドウ")]
    public static void ShowMyEditor()
    {
        EditorWindow wnd = GetWindow<EnterPlayModeCustomWindow>();
        wnd.titleContent = new GUIContent("再生モード開始時設定");
    }

    //ウィンドウの中身
    void OnGUI()
    {
        const string SettingsAssetPath = "ProjectSettings/EditorSettings.asset";
        SerializedObject settingsManager = new SerializedObject(UnityEditor.AssetDatabase.LoadAllAssetsAtPath(SettingsAssetPath)[0]);
        SerializedProperty m_EnterPlayModeOptionsEnabled = settingsManager.FindProperty("m_EnterPlayModeOptionsEnabled");
        SerializedProperty m_EnterPlayModeOptions = settingsManager.FindProperty("m_EnterPlayModeOptions");

        EditorGUILayout.BeginVertical("BOX");
        if (GUILayout.Button("再生モードの開始時オプション  :  " + (m_EnterPlayModeOptionsEnabled.boolValue ? "有効" : "無効")))
        {
            if (m_EnterPlayModeOptionsEnabled.boolValue == false)
            {
                m_EnterPlayModeOptionsEnabled.boolValue = true;
                settingsManager.ApplyModifiedProperties();
                //Debug.Log("<color=yellow>【再生モード開始時設定】</color>再生モードの開始時オプションを<color=green>有効</color>にしました");
            }
            else if (m_EnterPlayModeOptionsEnabled.boolValue == true)
            {
                m_EnterPlayModeOptionsEnabled.boolValue = false;
                settingsManager.ApplyModifiedProperties();
                //Debug.Log("<color=yellow>【再生モード開始時設定】</color>再生モードの開始時オプションを<color=red>無効</color>にしました");
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

        //ドメインの再ロード
        if (GUILayout.Button("ドメインを再ロード  :  " + (m_EnterPlayModeOptions.intValue == 0 ? "有効" : (m_EnterPlayModeOptions.intValue == 2) ? "有効" : "無効")))
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

        //シーンを再ロード
        if (GUILayout.Button("シーンを再ロード  :  " + (m_EnterPlayModeOptions.intValue == 0 ? "有効" : (m_EnterPlayModeOptions.intValue == 1) ? "有効" : "無効")))
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
