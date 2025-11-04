#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class QTEManager : MonoBehaviour
{
    public static QTEManager Instance;
#if UNITY_EDITOR
    [Tooltip("원하는 씬 파일을 드로그 앤 드롭 하세요")]
    public SceneAsset[] Scenes;
#endif
    [HideInInspector]
    public string[] sceneName;
    public int QTECount;

    private void OnValidate()
    {
#if UNITY_EDITOR
        if(Scenes == null || Scenes.Length == 0)
        {
            sceneName = new string[0];
            return;
        }

        if(sceneName != null || Scenes.Length != sceneName.Length)
        {
            sceneName = new string[Scenes.Length];
        }
        for(int i = 0; i < Scenes.Length; i++)
        {
            if (Scenes[i] != null)
            {
                sceneName[i] = Scenes[i].name;
            }
            else
            {
                sceneName[i] = "";
            }
        }
#endif
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
