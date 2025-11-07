using UnityEngine;

public class Screw : MonoBehaviour
{
    private int screw_clicks;
    private bool unscrewed;
    public void OnButtonClick()
    {
        //rotate screw
        screw_clicks++;
        transform.rotate(0,0,45);
        if(screw_clicks == 3){
            unscrewed==true;
        }
    }
}
