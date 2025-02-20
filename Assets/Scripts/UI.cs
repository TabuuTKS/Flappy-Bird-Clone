using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public void Replay()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
