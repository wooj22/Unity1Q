using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TestUI : MonoBehaviour
{
    public Text title;
    public Button button;
    public Toggle toggle;
    public Slider slider;
    public TextMeshProUGUI input;

    void Start()
    {
        // 이벤트 함수 등록 (에디터에서 직접 등록하지 않아도 됨)
        button.onClick.AddListener(OnClick_Button);
        toggle.onValueChanged.AddListener(delegate { OnValueChanged_toggle();} );
        slider.onValueChanged.AddListener(delegate { OnValueChanged_slider();} );
        input.onCullStateChanged.AddListener(delegate { OnValueChanged_input();} );

        // 여러개를 한번에 등록하고 싶을 때
        toggle.onValueChanged.AddListener(delegate
        {
            OnValueChanged_toggle();
            OnValueChanged_toggle();
        });

    }

    private void Update()
    {
        // UI 클릭시에 게임오브젝트 마우스 처리 막기
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                //클릭 처리
            }
        }
    }

    public void OnClick_Button() {
        title.text = input.text;
        input.text = "";
        Debug.Log("User Name Set"); 
    }

    public void OnValueChanged_toggle() { Debug.Log(toggle.onValueChanged); }
    public void OnValueChanged_slider() { Debug.Log(slider.value); }
    public void OnValueChanged_input() { Debug.Log(input.text); }

    public void OnPointerClick(PointerEventData eventData) {
        // 더블클릭
        if (eventData.clickCount == 2) { 
        
        }
    }

    // 드래그 앤 드랍
    /*드래그 앤 드랍
    컴포넌트 사용하기 
    EventTrigger 컴포넌트를 추가하고 
    BeginDrag, EndDrag, Drag 세 개의 이벤트를 등록

    스크립트로 사용하기
    IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler 상속 후
    public void OnBeginDrag(PointerEventData eventData) 등 함수 에 코딩
    */
}
