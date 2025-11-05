using UnityEngine;
using UnityEngine.SceneManagement;

public class EXITGAME : MonoBehaviour
{
    public void EXIT()
    {
        Application.Quit();
    }
    public void reStart()
    {
        SceneManager.LoadScene(0);
    }
}
