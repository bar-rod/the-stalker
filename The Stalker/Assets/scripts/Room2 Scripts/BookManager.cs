using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookShelfManager : MonoBehaviour
{
    private GameObject[] allBooks;
    private HashSet<GameObject> solution;
    private HashSet<GameObject> selected;
    [SerializeField] private Sprite completed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        solution = new HashSet<GameObject>();
        selected = new HashSet<GameObject>();

        allBooks = GameObject.FindGameObjectsWithTag("book");

        foreach (var c in allBooks)
        {
            var tog = c.GetComponentInChildren<Toggle>();
            if (tog == null)
            {
                Debug.Log("No toggle found.");
            }

            if (tog.GetComponent<BookShelf>().isSolutionBook)
                solution.Add(c);
        }
    }
        // Update is called once per frame
        void Update()
        {
            selected.Clear();

            // this might not be efficient
            foreach (var c in allBooks)
                if (c.GetComponentInChildren<Toggle>().isOn)
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
