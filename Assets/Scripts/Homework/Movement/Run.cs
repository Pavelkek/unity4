using System;
using UnityEngine;

namespace Homework.Movement
{
    /**
     * TODO:
     * 1. Реализовать этот тип перемещения по аналогии с Walk, но отличающийся от него,
     * например, пусть перемещение будет по окружности заданного радиуса. +
     * 2. Заменить передвижение у HappyDog и/или SadDog этим типом. Убедиться, что он работает. +
     */
    public class Run : Move
    {
        private readonly float _minY;
        private readonly float _maxY;
        private readonly float _speed;
        private readonly Action _doWoof;
        private int _direction = 1;


        public Run(MonoBehaviour owner) : base(owner)
        {
        }

        public Run(MonoBehaviour owner, float minY, float maxY, float speed, Action action) : base(owner)
        {
            _minY = minY;
            _maxY = maxY;
            _speed = speed;
            _doWoof = action;
        }

        public override void Execute()
        {
            var newPosition = Owner.transform.position;
            newPosition.y += _direction * Time.deltaTime * _speed;

            Owner.transform.position = newPosition;

            if (newPosition.y > _maxY)
            {
                _direction = -1;
                _doWoof?.Invoke();
            }
            else if (newPosition.y < _minY)
            {
                _direction = 1;
                _doWoof?.Invoke();
            }
        }
    }
}