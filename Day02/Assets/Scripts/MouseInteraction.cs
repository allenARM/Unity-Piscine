using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    public List<Entity> Heroes = new List<Entity>();
    private bool _ctrlPressed = false;
    private void LeftMouseRayCast()
    {
        RaycastHit2D _hit;
        _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.2f);
        
        if (_hit.collider.CompareTag("Tile") && Heroes.Count > 0)
        {
            for (int i = 0; i < Heroes.Count; i++)
            {
                Heroes[i].Move(_hit.point);
            }
        }
        if (_hit.collider.GetComponent<Entity>())
        {
            if (!_ctrlPressed)
                Heroes.Clear();

            Heroes.Add(_hit.collider.GetComponent<Entity>());
        }
    }
    private void InputManagment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _ctrlPressed = true;
        else
            _ctrlPressed = false;

        if(Input.GetMouseButtonDown(0))
        {
            LeftMouseRayCast();
        }
        if (Input.GetMouseButtonDown(1))
            Heroes.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagment();
    }
}
