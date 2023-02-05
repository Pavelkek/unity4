using System;
using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    public class HappyDog : Dog
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            WofAction = Woof;
            Move = new Walk(this, -4f, 4f, 1f, WofAction);
        }

        protected override void Woof()
        {
            Debug.Log("Happy woof!");
        }

        private SpriteRenderer GetSpriteRenderer()
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            return _spriteRenderer;
        }

        public override void ChangeColor()
        {
            var random = new System.Random();
            var red = (float)random.NextDouble();
            GetSpriteRenderer().color = new Color(0.5f + red / 2, 0.1f, 0.1f);
        }
    }
}