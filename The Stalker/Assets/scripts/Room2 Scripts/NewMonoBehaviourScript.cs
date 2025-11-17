using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookShelfManager : MonoBehaviour
{
    private GameObject[] allBooks;
    private List<GameObject> solution;
    private List<GameObject> selected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allBooks = GameObject.FindGameObjectsWithTag("book");
        solution = new List<GameObject>();
        selected = new List<GameObject>();

        foreach (var c in allBooks)
            if (c.GetComponent<UnityEngine.UI.Toggle>().GetComponent<BookShelf>().isSolutionBook)
                solution.Add(c);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        solution.Clear();

        // this might not be efficient
        foreach (var c in allBooks)
            if(c.GetComponent<UnityEngine.UI.Toggle>().isOn)
                selected.Add(c);

        if (selected.Count == solution.Count)
        {
            solution.Sort();
            selected.Sort();
            if(solution.Equals(selected))
            {
                // set new sprite to book case
                GameObject.Find("BookShelf").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/art assets/room2artassets/Pulled Bookshelf.PNG");

                // set bool to true for trap door
                GameObject.Find("Carpet").GetComponent<CarpetController>().SetSolved();

            }
        }
    }


}
