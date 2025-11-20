using UnityEngine;

public class PocketWatch : Item
{
    [SerializeField] private Timer timer;
    private const float BONUS_TIME = 30f;
    public override bool UseItem()
    {
        timer.time += BONUS_TIME;

        // maybe a message popup, just so the player knows what happened when they used the item?

        return true;
    }
}
