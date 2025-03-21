using UnityEngine;

public class Interactive : MonoBehaviour
{
    [Header("Animation")]
    [Tooltip("Should the object have an animation?? " +
            "\n\tyes = true, no = false")]
    public bool hasAnimation = false;

    [Tooltip("Set an animation to move from the current scene to the next one")]
    public AnimationClip clickAnimationClip;

    [Tooltip("Set an animator with your animation clip")]
    public Animator animator;

    [Space(10)]
    [Header("Sounds")]
    public AudioClip audioClip;

    [Space(10)]
    [Header("Particle System")]
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        if (hasAnimation)
        {
            if (clickAnimationClip == null) Debug.LogError("Missing {loadNextSceneClip}!");
            if (animator == null) Debug.LogError("Missing animator!");
        }
    }

    private void OnMouseDown()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(clickAnimationClip.name))
        {
            animator.Play(clickAnimationClip.name);
            particles?.Play();
            foreach (AudioSource source in AudioManager.S.sources)
            {
                if (source.clip.name == audioClip.name)
                {
                    source.Play();
                }
            }
        }
    }
}