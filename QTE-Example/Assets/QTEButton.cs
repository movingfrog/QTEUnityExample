using UnityEngine;
using UnityEngine.UI;

public class QTEButton : MonoBehaviour
{
    public Image timerBar;
    public float MaxTime;
    float setTime;

    private void OnEnable()
    {
        timerBar.fillAmount = setTime / MaxTime;
        setTime = MaxTime;
    }

    private void Update()
    {
        if(setTime >= 0)
        {
            setTime -= Time.deltaTime;
            timerBar.fillAmount = setTime / MaxTime;
        }
        else gameObject.SetActive(false);
    }
}
