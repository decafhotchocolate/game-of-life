using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenerationManager : MonoBehaviour
{

    public int fieldWidth;
    public int fieldHeight;
    public GameObject cellPrefab;
    private MouseControls controls;
    public int currentGeneration = 1;
    public bool generationsPlaying = false;

    private void Awake()
    {
        controls = new MouseControls();
        controls.Mouse.MoveGeneration.performed += ctx => IncrementGeneration();  
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    public void PlayPause() {
        generationsPlaying = !generationsPlaying;

        switch(generationsPlaying) {
            case true:
                InvokeRepeating("IncrementGeneration", 0.25f, 0.25f);
                break;
            case false:
                CancelInvoke("IncrementGeneration");
                break;
        }

    }
    

    void Start()
    {
        for (int x = 0; x < fieldHeight; x++) // generate x
        {
            for (int y = 0; y < fieldWidth; y++) // generate y
            {
                GameObject generatedCell = Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);
                generatedCell.transform.parent = transform;
                generatedCell.name = "Cell (" + (x + 1) + ", " + (y + 1) + ")";
            }
        }
    }

    public void IncrementGeneration()
    {
        StartCoroutine(NextGeneration());    
        foreach(Transform child in transform) {
            child.GetComponent<CellManager>().StatusCheck();
        }
        currentGeneration++;
    }

    public IEnumerator NextGeneration()
    {
        foreach(Transform child in transform)
        {
            int aliveNeighbors = 0;
            GameObject cell = child.gameObject;
            Rigidbody2D cellRigidBody = GetComponent<Rigidbody2D>();
            CellManager cellManager = cell.GetComponent<CellManager>();

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    RaycastHit2D ray = Physics2D.Raycast(cell.transform.position, new Vector2(x, y), 1f);
                    if (ray.collider != null && ray.collider.GetComponent<CellManager>().isAlive)
                        aliveNeighbors++;
                }
            }
 
            cellManager.aliveNeighbors = aliveNeighbors;
        }
        yield return null;
    }
}
