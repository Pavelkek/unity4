using System;
using Homework.Common;
using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * 1. Добавить всем собакам способность гавкать: достаточно метода, пишущего в Unity-консоль строку с сообщение. +
     * 2. HappyDog должен гавкать более радостно. +
     * 3. (сложно) Пусть собаки гавкают только тогда, когда меняют направление движения. +
     */
    public abstract class Dog : MonoBehaviour, IColorChangeable
    {
        public abstract void ChangeColor();
        protected abstract void Woof();
        protected Move Move;
        private SpriteRenderer _spriteRenderer;
        protected void Start()
        {
            InputController.Instance.OnColorChanged += OnColorChanged;
        }

        protected void Update()
        {
            Move.Execute();
        }

        private void OnDestroy()
        {
            InputController.Instance.OnColorChanged -= OnColorChanged;
        }

        private void OnColorChanged()
        {
            ChangeColor();
        }
        
        protected SpriteRenderer GetSpriteRenderer()
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            return _spriteRenderer;
        }
    }
}