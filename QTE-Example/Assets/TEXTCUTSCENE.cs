using KoreanTyper;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TEXTCUTSCENE : MonoBehaviour
{
    public Text lineText;
    public string[] texts;
    public Coroutine currentCoroutine;
    string currentText;
    int stringCount;
    bool isTyping;


    private void Awake()
    {
        stringCount = 0;
        showLine(texts[stringCount]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopCoroutine(currentCoroutine);
                lineText.text = currentText;
                isTyping = false;
            }
            else
            {
                if(stringCount < texts.Length)
                {
                    showLine(texts[stringCount]);
                }
                else
                {
                    Skip();
                }
            }
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene(1);
    }

    void showLine(string line)
    {
        currentText = line;
        
        if(currentCoroutine != null) StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(typeLine(line));
        stringCount++;
    }

    IEnumerator typeLine(string line)
    {
        isTyping = true;
        lineText.text = "";
        
        float percent = 0;
        while(percent < 1)
        {
            percent += Time.deltaTime;
            lineText.text = line.Typing(percent);
            yield return null;
        }

        isTyping = false;
    }
}
