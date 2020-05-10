using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MaxSideDisplacement = 3f; //максимальное смещение на которое капля может 

    [SerializeField] private float ForwardSpeed, SideSpeed;

    [SerializeField] private CircleCollider2D LeftCollider, RightCollider; //по колайдеру на правую и левую каплю

    private float sideOffset;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SideMovement(float normalizedValue)
    {
        //получение нормализованного смещения в сторону
        sideOffset += normalizedValue * SideSpeed;
        sideOffset = Mathf.Clamp(sideOffset, 0f, MaxSideDisplacement);

        Debug.Log("playerSideOffset: " + sideOffset);

        //Использования смещения
        //transform.position = transform.right * sideOffset;
        LeftCollider.offset = new Vector2(-1 * sideOffset, 0);
        RightCollider.offset = new Vector2(1 * sideOffset, 0);

        animator.SetFloat("Offset", sideOffset);
    }
}
