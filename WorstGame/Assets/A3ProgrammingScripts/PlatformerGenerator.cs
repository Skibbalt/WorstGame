using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private Transform genPoint;
    [SerializeField] private float minPlatSpacing;
    [SerializeField] private float maxPlatSpacing;
    [SerializeField] private float minY;              
    [SerializeField] private float maxY;              

    private float platWidth;

    void Start()
    {
        platWidth = platforms[0].GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < genPoint.position.x)
        {
           
            GameObject selectedPlatform = platforms[UnityEngine.Random.Range(0, platforms.Length)];

           
            float spacing = UnityEngine.Random.Range(minPlatSpacing, maxPlatSpacing);
            float newY = UnityEngine.Random.Range(minY, maxY);

          
            transform.position = new Vector3(transform.position.x + platWidth + spacing, newY, 1f);

           
            Instantiate(selectedPlatform, transform.position, Quaternion.identity);
        }
    }
}
