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
        private List<MarsRoverViewModel> _roverChoices = new List<MarsRoverViewModel>();
        private List<MarsRoverCameraViewModel> _cameraChoices = new List<MarsRoverCameraViewModel>();

        public MarsRoverPhotosQueryViewModel()
        {
            PopulateRoverDropDownList();
            this.SelectedRoverId = (int)MarsRoverEnum.Curiosity;
            PopulateRoverCamDropDownList();

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
            set
            {
                _cameraChoices = value
                    .Select(x => new MarsRoverCameraViewModel(int.Parse(x.Value), x.Text))
                    .ToList();
            }
        }

        protected void PopulateRoverDropDownList()
        {
            foreach (var rover in Enum.GetValues(typeof(MarsRoverEnum)))
            {
                _roverChoices.Add(new MarsRoverViewModel((int)rover, rover.ToString()));
            }
        }
        protected void PopulateRoverCamDropDownList()
        {
            foreach (var roverCam in Enum.GetValues(typeof(MarsRoverCameraEnum)))
            {
                _cameraChoices.Add(new MarsRoverCameraViewModel((int)roverCam, roverCam.ToString()));
            }
        }
    }
}