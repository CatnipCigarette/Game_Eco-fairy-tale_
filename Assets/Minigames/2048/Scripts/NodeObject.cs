using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NodeObject : MonoBehaviour
{
    [NonSerialized] public Node from = null;
    [NonSerialized] public Node target = null; 
    public bool combine = false;
    private int m_value;


    public Sprite image; // Add this variable to hold the image sprite
    public Sprite[] valueSprites; // An array of sprites for different cell values
    public int value
    {
        get => m_value;
        set
        {
            this.m_value = value;
        }
    }

    public Image blockImage;
    public TextMeshProUGUI valueText;

    public void InitializeFirstValue()
    {
        int[] v = new int[] {2, 4}; 
        this.value = v[Random.Range(0, v.Length)];
    }  
    public void MoveToNode(Node from, Node to)
    {
        combine = false;
        this.from = from;
        this.target = to;
    }

    public void CombineToNode(Node from, Node to)
    {
        combine = true;
        this.from = from;
        this.target = to; 
    }
    public void OnEndMove()
    {
        if (target != null)
        {
            if (combine)
            {
                target.realNodeObj.value = value * 2;
                var t = target.realNodeObj.transform.DOPunchScale(new Vector3(.25f, .25f, .25f), 0.15f, 3);
                this.gameObject.SetActive(false);
                t.onComplete += () =>
                {
                    this.needDestroy = true;
                    this.target = null; 
                    this.from = null; 
                }; 
            }
            else
            {  
                this.from = null;
                this.target = null;
            }
        } 
    } 
    public bool needDestroy= false;

    public void StartMoveAnimation()
    {
        if (target != null)
        {
            this.name = target.point.ToString(); 
            var tween = this.blockImage.rectTransform.DOLocalMove(target.position, 0.1f);
            tween.onComplete += () =>
            {
                OnEndMove();  
            };
        }
        
    }
    public void UpdateMoveAnimation()
    {
        if (target != null)
        {
            this.name = target.point.ToString();
            var p = Vector2.Lerp(this.transform.localPosition, target.position, 0.35f);
            this.transform.localPosition = p;
            if (Vector2.Distance(this.transform.localPosition, target.position) < 0.25f)
            {
                OnEndMove();  
            }
        }
    }

    public void UpdateImage(int value)
    {
        // Проверяем значение и обновляем отображаемую картинку в зависимости от него
        if (value == 2)
        {
            blockImage.sprite = valueSprites[0];
        }
        else if (value == 4)
        {
            blockImage.sprite = valueSprites[1];
        }
        else if (value == 8)
        {
            blockImage.sprite = valueSprites[2];
        }
        else if (value == 16)
        {
            blockImage.sprite = valueSprites[3];
        }
        else if (value == 32)
        {
            blockImage.sprite = valueSprites[4];
        }
        else if (value == 64)
        {
            blockImage.sprite = valueSprites[5];
        }
        else if (value == 128)
        {
            blockImage.sprite = valueSprites[6];
        }
        else if (value == 256)
        {
            blockImage.sprite = valueSprites[7];
        }
        else if (value == 512)
        {
            blockImage.sprite = valueSprites[8];
        }
        else if (value == 1024)
        {
            blockImage.sprite = valueSprites[9];
        }
        else if (value == 2048)
        {
            blockImage.sprite = valueSprites[10];
            Time.timeScale = 0f;
        }
    }
}
