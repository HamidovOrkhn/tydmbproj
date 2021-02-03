﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;

namespace TCYDMWebApp.ViewModels
{
    public class OnlineQueryViewModel
    {

        [Required(ErrorMessage = "Please select service")]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Please select service attend date")]
        public DateTime ServiceDate { get; set; }

        [MaxLength(256,ErrorMessage = "Max lenght is 256")]
        [Display(Prompt = "Comment")]

        public string Info { get; set; }
        public UserDataDTO UserData { get; set; }
        public List<OurServicesDTO> Services { get; set; }

    }
}
