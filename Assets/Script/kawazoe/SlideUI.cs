using UnityEngine;
using UnityEngine.EventSystems;

public class SlideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform panel;  // �Ώۂ�UI Panel
    public GameObject uiTrigger;  // �g���K�[�ƂȂ�UI�v�f�i��\���ɂ���j
    public float slideSpeed = 500f;  // �X���C�h���x
    private bool isOpen = false;  // �p�l�����J���Ă��邩
    private Vector2 closedPosition;  // �����Ƃ��̈ʒu
    private Vector2 openPosition;  // �J�����Ƃ��̈ʒu

    void Start()
    {
        // �����ʒu�ݒ�
        closedPosition = panel.anchoredPosition;
        openPosition = closedPosition + new Vector2(panel.rect.width, 0); // �������ړ�
    }

    void Update()
    {
        // �X���C�h�A�j���[�V����
        Vector2 targetPosition = isOpen ? openPosition : closedPosition;
        panel.anchoredPosition = Vector2.MoveTowards(panel.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
    }

    // �}�E�X��UI�g���K�[�ɓ������Ƃ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;  // �p�l�����J��
        uiTrigger.SetActive(false);  // �g���K�[UI���\��
    }

    // �}�E�X��UI�g���K�[����o���Ƃ�
    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;  // �p�l�������
        uiTrigger.SetActive(true);  // �g���K�[UI��\��
    }
}
