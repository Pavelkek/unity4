using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * 1. Реализовать этот тип по аналогии с HappyDog. +
     * 2. Грустная собака должна перекрашиваться в оттенки синего. +
     * 3. (сложно) Перенести метод GetSpriteRenderer в более подходящее место. +
     */
    public class SadDog : Dog
    {
        protected override void Woof()
        {
            Debug.Log("Sad woof(");
        }

        private void Awake()
        {
            Move = new Run(this, -4f, 4f, 0.5f, Woof);
        }

        public override void ChangeColor()
        {
            var random = new System.Random();
            var blue = (float)random.NextDouble();
            GetSpriteRenderer().color = new Color(0.1f, 0.1f, 0.5f + blue / 2);
        }
    }
}