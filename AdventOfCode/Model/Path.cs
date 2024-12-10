﻿namespace AdventOfCode.Model
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Location> NextSteps { get; set; } = [];
    }
}
