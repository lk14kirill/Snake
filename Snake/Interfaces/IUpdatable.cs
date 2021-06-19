﻿using SFML.System;
using System.Collections.Generic;

namespace Snake
{
    public interface IUpdatable
    {
        void Update(Vector2f playerDirection, List<Food> food, float time,Player player);
    }
}
