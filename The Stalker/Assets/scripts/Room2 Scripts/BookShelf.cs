using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Book : MonoBehaviour
{
    private bool isSolutionBook;
    private UnityEngine.UI.Toggle isSelected; // TODO: Learn prefabs

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
};

public class BookShelf : MonoBehaviour
{
    // load pngs stored at Assets/art assets/room2artassets/books into an array
    private Array pngs;
    private Array allBooks;
    private Array shelves;
    private const int totalShelves = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pngs = Addressables.LoadAssetsAsync<Array>("Assets/art assets/room2artassets/books").WaitForCompletion().ToArrayPooled();
        allBooks = Array.CreateInstance(typeof(Book), pngs.Length);
        shelves = Array.CreateInstance(typeof(Book*), totalShelves);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
};
