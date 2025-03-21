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

    // Return true if animation clip in animator states found, return false if is not
    private bool HasAnimationClip(string name)
    {
        var controller = animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

        if (controller == null)
        {
            Debug.Log("AnimatorController not found");
            return false;
        }

        foreach (var layer in controller.layers)
        {
            var stateMachine = layer.stateMachine;
            foreach (var state in stateMachine.states)
            {
                if (state.state.name == name) return true;
            }
        }
        return false;
    }

    public void LoadSceneWithDelay(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    // Load Scene by index with delay
    private IEnumerator LoadScene(int index)
    {
        if (HasAnimationClip(loadNextSceneClip.name) == true) animator.Play(loadNextSceneClip.name);

        // Wait {delay} seconds before loading scene
        yield return new WaitForSeconds(delay);

        // Load scene
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}