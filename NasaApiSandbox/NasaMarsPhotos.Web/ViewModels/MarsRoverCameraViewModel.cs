﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasaMarsPhotos.Web.ViewModels
{
    public class MarsRoverCameraViewModel
    {
        public MarsRoverCameraViewModel()
        {

        }
        public MarsRoverCameraViewModel(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}