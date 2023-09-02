using UnityEngine;

public class SoundSystemUser : MonoBehaviour
{
    private static SoundSystemUser instance;
    public static SoundSystemUser Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
