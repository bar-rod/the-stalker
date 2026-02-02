using UnityEngine;

public class keyTC : Item
{

    void Awake()
    {
        if (Application.isPlaying)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public override bool UseItem()
    {
        return true;
    }
}
