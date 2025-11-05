using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class FirstQTESiquns : MonoBehaviour
{
    public QTEButton _QTEButton;
    public PlayableDirector successCutScene;
    public PlayableDirector failCutScene;

    public KeyCode keyValue;

    public void QTE()
    {
        Debug.Log("dlskfjs");
        _QTEButton.gameObject.SetActive(true);
        StartCoroutine(QTEChoice());
    }

    IEnumerator QTEChoice()
    {
        while (_QTEButton.gameObject.activeSelf)
        {
            yield return null;
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(keyValue))
                {
                    successCutScene.Play();
                    HideButton();
                    yield break;
                }
                break;
            }
        }
        HideButton();
        failCutScene.Play();
    }
    void HideButton()
    {
        _QTEButton.gameObject.SetActive(false);
        GetComponent<TimerManager>().enabled = false;
    }
}
