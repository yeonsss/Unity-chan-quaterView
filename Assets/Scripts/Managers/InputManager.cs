using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    // 액션을 enum으로 종류를 정해줄수있다.


    bool _pressed = false;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.anyKey && KeyAction != null)
        {
            // 매니저에 입력이벤트가 발생했기에 실행
            KeyAction.Invoke();
        }

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if(_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                }
                _pressed = false;
            }
        }

    }
}
