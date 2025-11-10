using UnityEngine;

public class Vent_Controller : MonoBehaviour
{
    [SerializeField] private Screw[] screws;
    private bool all_unscrewed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        all_unscrewed = true;
        for (int i =0;i<screws.Length;i++){
            if(!screws[i].unscrewed){
                all_unscrewed =false;

            }

        }
        if(all_unscrewed){
            gameObject.SetActive(false);
        }
    }
}
