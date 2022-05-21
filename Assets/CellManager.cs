using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellManager : MonoBehaviour, IPointerDownHandler
{
    private SpriteRenderer sprite;
    public bool isAlive;
    public int aliveNeighbors;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();    
    }

    public void StatusCheck()
    {
        if (isAlive)
        {
            switch(aliveNeighbors)
            {
                case <2:
                    KillCell();
                    break;
                case >3:
                    KillCell();
                    break;
            }
        } else {
            if (aliveNeighbors == 3) {
                BirthCell();
            }
        }
    }

    void Update()
    {
        switch(isAlive)
        {
            case true:
                sprite.color = Color.white;
                break;
                
            case false:
                sprite.color = Color.black;
                break;
        }   
    }

    public void BirthCell()
    {
        isAlive = true;
    }
    
    public void KillCell()
    {
        isAlive = false;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            isAlive = !isAlive;
    }
}
