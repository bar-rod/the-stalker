using UnityEngine;

public class Screw : MonoBehaviour
{
    public int screw_clicks;
    public bool unscrewed;
    [SerializeField ]public bool screwdriver_equipped;
    public void OnButtonClick()
    {
        if(screwdriver_equipped){
        //rotate screw
        screw_clicks++;
        Vector3 rotation = new Vector3(0f,0f,45f);
        gameObject.transform.Rotate(rotation);
        if(screw_clicks == 3){
            gameObject.SetActive(false);
            unscrewed=true;
        }
    }
    }
}
