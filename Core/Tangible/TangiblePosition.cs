﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TofuCore.Tangible
{
    public class TangiblePosition : ITangible
    {
        private readonly Vector3 _position;
        float x => _position.x;
        float y => _position.y;
        float z => _position.z;


        public TangiblePosition(Vector3 position, float radius = 0f)
        {
            _position = position;
            _sizeRadius = radius;
        }

        public Vector3 Position => _position;
        public bool Active => true;
        public float SizeRadius => _sizeRadius;
        private float _sizeRadius;
    }

}