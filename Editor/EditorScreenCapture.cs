using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.EditorCoroutines.Editor;

public class EditorScreenCapture : EditorWindow
{
    private Texture2D screenshot;

    [MenuItem("Extra/EditorScreenCapture")]
    public static void Create()
    {
        EditorWindow wnd = GetWindow<EditorScreenCapture>();
        wnd.titleContent = new GUIContent("EditorScreenCapture");
    }

    #region Graphic

    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if( EditorApplication.isPlaying )
        {
            if( GUILayout.Button( "Screen Shot" ) )
            {
                 this.StartCoroutine( ScreenShotProcess() );
            }
        }
        else
        {

            GUILayout.Label( "The simulator is not starting." );
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if( screenshot != null )
        {
            EditorGUILayout.LabelField(new GUIContent(screenshot), GUILayout.Height(512), GUILayout.Width(512));
            if( GUILayout.Button( "Clip Board" ) )
            {
                // クリップボードに保存する処理をかく.
            }
        }
    }

    #endregion

    #region Coroutine.

    private IEnumerator ScreenShotProcess()
    {
        yield return new WaitForEndOfFrame();
        screenshot = ScreenCapture.CaptureScreenshotAsTexture();
    }

    #endregion
}
