using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("Delay (in seconds) before loading the scene")]
    public float delay;

    [Tooltip("Set an animation to move from the current scene to the next one")]
    public AnimationClip loadNextSceneClip;

    [Tooltip("Set an animator with your animation clip")]
    public Animator animator;

    private void Start()
    {
        if (loadNextSceneClip == null) Debug.LogError("Missing {loadNextSceneClip}!");
        if (animator == null) Debug.LogError("Missing animator!");
    }

    public void LoadSceneWithDelay(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    // Load Scene by index with delay
    private IEnumerator LoadScene(int index)
    {
        animator.Play(loadNextSceneClip.name);

        // Wait {delay} seconds before loading scene
        yield return new WaitForSeconds(delay);

        // Load scene
        SceneManager.LoadScene(index);
    }

    public void QuitGameWithDelay()
    {
        StartCoroutine(QuitGame());
    }

    private IEnumerator QuitGame()
    {
        animator.Play(loadNextSceneClip.name);

        yield return new WaitForSeconds(delay);

        Application.Quit();
    }
}