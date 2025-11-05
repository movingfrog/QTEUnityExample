using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI Text;

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
            this.enabled = false;
        }
        if (timer < 5) Text.color = Color.red;
        Text.text = timer.ToString("0.00");
    }
}
