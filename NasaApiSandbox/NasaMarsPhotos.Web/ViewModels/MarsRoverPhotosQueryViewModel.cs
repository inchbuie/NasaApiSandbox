using NasaMarsPhotos.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasaMarsPhotos.Web.ViewModels
{
    public class MarsRoverPhotosQueryViewModel
    {
        private readonly List<MarsRoverViewModel> _roverChoices = new List<MarsRoverViewModel>();
        private readonly List<MarsRoverCameraViewModel> _cameraChoices = new List<MarsRoverCameraViewModel>();

        public MarsRoverPhotosQueryViewModel()
        {
            PopulateDropDownLists();

            //populate some default values
            Page = 1;
            MissionSol = 100;
        }
        
        [Display(Name = "Rover")]
        public int SelectedRoverId { get; set; }

        [Display(Name = "Camera")]
        public int SelectedCameraId { get; set; }
        
        public int Page { get; set; }

        public int? MissionSol { get; set; }

        public DateTime? EarthDate { get; set; }

        public IEnumerable<SelectListItem> RoverChoices
        {
            get
            {
                var selectList = new SelectList(_roverChoices, "Id", "Name");
                return selectList;
            }
        }

        public IEnumerable<SelectListItem> CameraChoices
        {
            get
            {
                var selectList = new SelectList(_cameraChoices, "Id", "Name");
                return selectList;
            }
        }
        protected void PopulateDropDownLists()
        {
            foreach (var rover in Enum.GetValues(typeof(MarsRoverEnum)))
            {
                _roverChoices.Add(new MarsRoverViewModel((int)rover, rover.ToString()));
            }
            foreach (var cam in Enum.GetValues(typeof(MarsRoverCameraEnum)))
            {
                _cameraChoices.Add(new MarsRoverCameraViewModel((int)cam, cam.ToString()));
            }
        }
    }
}