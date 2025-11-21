using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class BookShelfManager : MonoBehaviour
{
    private GameObject[] allBooks;
    private HashSet<GameObject> solution;
    private HashSet<GameObject> selected;
    [SerializeField] private Sprite  completed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        solution = new HashSet<GameObject>();
        selected = new HashSet<GameObject>();

        allBooks = GameObject.FindGameObjectsWithTag("book");
        
        foreach (var c in allBooks)
            if (c.GetComponent<UnityEngine.UI.Toggle>().GetComponent<BookShelf>().isSolutionBook)
                solution.Add(c);


        Debug.Log("All Books: " + allBooks.Length);
        Debug.Log("Solution Books: " + solution.Count);
    }

    void populate()
    {
        allBooks = GameObject.FindGameObjectsWithTag("book");   

        foreach (var c in allBooks)
            if (c.GetComponent<UnityEngine.UI.Toggle>().GetComponent<BookShelf>().isSolutionBook)
                solution.Add(c);

        Debug.Log("All Books: " + allBooks.Length);
        Debug.Log("Solution Books: " + solution.Count);
    }

    // Update is called once per frame
    void Update()
    {

        if(solution == null || solution.Count == 0)
            populate();

        selected.Clear();

        // this might not be efficient
        foreach (var c in allBooks)
            if(c.GetComponent<UnityEngine.UI.Toggle>().isOn)
                selected.Add(c);

        if (solution != null && solution.Count > 0 && selected.SetEquals(solution))
        {
          
                Debug.Log("Puzzle Solved!");

            // set new sprite to book case
            GameObject.Find("BookShelf").GetComponent<SpriteRenderer>().sprite = completed;

            // set bool to true for trap door
            GameObject.Find("Carpet").GetComponent<CarpetController>().SetSolved();

         
        }
    }


}
