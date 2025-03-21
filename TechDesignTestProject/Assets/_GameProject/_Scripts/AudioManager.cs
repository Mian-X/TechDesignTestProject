using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sources;
    public static AudioManager S;

    // Start is called before the first frame update
    void Awake()
    {
        if (S == null) S = this;
    }

}