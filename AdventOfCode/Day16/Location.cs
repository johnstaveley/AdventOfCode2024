﻿namespace AdventOfCode.Day16
{
    public class Location
    {
        public Int64 X { get; set; }
        public Int64 Y { get; set; }
        public override string ToString()
        {
            return $"{X+1}:{Y+1}";
        }
    }
}
