using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class MouseManager : Singleton<MouseManager>
{
    public Texture2D ground;
    public Texture2D defaultcursor;
    public event Action<Vector3> OnClickMouse;

    Mouse mouse = Mouse.current;

    private RaycastHit hit;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        SetCursor();
        OnClick();
    }

    void SetCursor()
    {
        //Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //设定指针图标
            if (hit.transform.CompareTag("Ground"))
                Cursor.SetCursor(ground,new Vector2(12f,12f), CursorMode.Auto);
            else
                Cursor.SetCursor(defaultcursor, new Vector2(12f, 12f), CursorMode.Auto);

        }
    }
    void OnClick()
    {
        if (hit.transform != null && Input.GetMouseButton(0)&&!EventSystem.current.IsPointerOverGameObject())
        {
            if (hit.transform.CompareTag("Ground"))
                OnClickMouse?.Invoke(hit.point);
        }
    }
}
