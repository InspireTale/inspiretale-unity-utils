using UnityEngine;
using InspireTaleFramework;

public class InputClickHandler : MonoSingleton<InputClickHandler>
{
    public delegate void _FuncWithVector2Params(Vector2 vector2);
    public event _FuncWithVector2Params OnClickBegan;
    public event _FuncWithVector2Params OnDragMoved;
    public event _FuncWithVector2Params OnClickEnded;

    private bool isDrag = false;
    private float timeDragCount_s = 0f;
    private float clickThreshold_s = 0.25f;
    private Touch targetTouch = new Touch();

    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        this.HandleTouch();

#else
        this.HandleMouseClick();

#endif
    }

    private void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            isDrag = true;
            timeDragCount_s = Time.time + clickThreshold_s;
            OnClickBegan.Invoke(Input.mousePosition);
        }

        if (isDrag && Input.GetMouseButton((int)MouseButton.Left))
        {
            if (timeDragCount_s < Time.time)
            {
                OnDragMoved.Invoke(Input.mousePosition);
            }
        }

        if (Input.GetMouseButtonUp((int)MouseButton.Left))
        {
            isDrag = false;
            OnClickEnded.Invoke(Input.mousePosition);
        }
    }

    private void HandleTouch()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        targetTouch = Input.GetTouch(0);

        switch (targetTouch.phase)
        {
            case TouchPhase.Began:
                OnClickBegan.Invoke(targetTouch.position);
                break;

            case TouchPhase.Moved:
                OnDragMoved.Invoke(targetTouch.position);
                break;

            case TouchPhase.Canceled:
                OnClickEnded.Invoke(targetTouch.position);
                break;
        }
    }
}
