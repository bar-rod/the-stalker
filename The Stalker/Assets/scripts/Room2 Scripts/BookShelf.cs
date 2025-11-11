using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Book : MonoBehaviour
{
    private bool isSolutionBook;
    private UnityEngine.UI.Toggle isSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class BookShelf : MonoBehaviour
{
    // 2D array.
    

    Array shelves = Array.CreateInstance(typeof(Array), 3);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //int bookCount = get
        Array allBooks = Array.CreateInstance(typeof(Book), 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
