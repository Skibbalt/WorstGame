using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class AddManager : MonoBehaviour
{
    public GameObject[] images; // Array to hold your 5 different image prefabs
    public Transform canvasTransform; // Reference to the Canvas transform

    private void Start()
    {
        if (images.Length != 5)
        {
            UnityEngine.Debug.LogError("Please assign exactly 5 image prefabs to the UIManager.");
        }
    }

    public void SpawnRandomImage()
    {
        if (images.Length == 5)
        {
            int randomIndex = UnityEngine.Random.Range(0, images.Length);
            GameObject image = Instantiate(images[randomIndex], canvasTransform);
            image.GetComponent<RectTransform>().anchoredPosition = GetRandomPosition();
        }
    }

    private Vector2 GetRandomPosition()
    {
        // Adjust the random position logic as needed to fit your UI layout
        float x = UnityEngine.Random.Range(-canvasTransform.GetComponent<RectTransform>().rect.width / 2, canvasTransform.GetComponent<RectTransform>().rect.width / 2);
        float y = UnityEngine.Random.Range(-canvasTransform.GetComponent<RectTransform>().rect.height / 2, canvasTransform.GetComponent<RectTransform>().rect.height / 2);
        return new Vector2(x, y);
    }
}
