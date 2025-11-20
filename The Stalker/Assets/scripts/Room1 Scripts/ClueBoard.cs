using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaperClueBoard : MonoBehaviour,
IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private AudioSource _paperSound;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        randomizeCluePos();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("onDrag");
        //When an item gets dragged, it moves along with the mouse to the scale of the canvas screen
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        if (this.name == "EscapePhoto")
        {
            //Debug.Log("clicked on photo");
            LocatorDialogue.Instance.DialogueScript.ShowElisaText("That picture… Why does he have that?");
        }
    }
        
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }

    //last one

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
       _paperSound.Play();
    }

    // If this breaks, it's probably tag related or you changed a gameobject name
    void randomizeCluePos()
    {
        GameObject[] clues = GameObject.FindGameObjectsWithTag("Clue");
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("Spawn");
        // Debug.Log("Found " + clues.Length + " clues to position.");

        //uses the Fisher-Yates method of shuffling
        Array tempArr = Array.CreateInstance(typeof(int), spawnPoint.Length);
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            tempArr.SetValue(i, i); 
        }

        Array shuffled = Array.CreateInstance(typeof(int), tempArr.Length);
        var randomness = new System.Random();

        // this removes elements from tempArr as they are added to shuffled 
        Debug.Log("Shuffling spawn points...");
        for (int i = tempArr.Length - 1; i >= 0; --i)
        {   
            int rand = randomness.Next(tempArr.Length);
            shuffled.SetValue(tempArr.GetValue(rand), i);
            var index = rand;
            if (index < tempArr.Length && tempArr.Length > 0)
            {
                Array tempTempArr = Array.CreateInstance(typeof(int), tempArr.Length - 1);
                for (int j = 0; j < index; j++)
                { tempTempArr.SetValue(tempArr.GetValue(j), j); }
                for (int j = index; j < tempTempArr.Length; j++)
                { tempTempArr.SetValue(tempArr.GetValue(j + 1), j); }

                tempArr = tempTempArr;
            }
        }

        for (int i = 0; i < clues.Length; i++)
        {
            clues[i].GetComponent<RectTransform>().position = spawnPoint[(int)shuffled.GetValue(i)].GetComponent<RectTransform>().position;
            clues[i].GetComponent<RectTransform>().Rotate(0, 0, UnityEngine.Random.Range(-10f, 10));
        }

    }

}


