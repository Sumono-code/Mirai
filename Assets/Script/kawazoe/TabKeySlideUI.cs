using UnityEngine;

public class TabKeySlideUI : MonoBehaviour
{
    public RectTransform panel;  // �Ώۂ�UI Panel
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
        // Tab�L�[�Ńg�O��
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
        }

        // �X���C�h�A�j���[�V����
        Vector2 targetPosition = isOpen ? openPosition : closedPosition;
        panel.anchoredPosition = Vector2.MoveTowards(panel.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
    }
}
