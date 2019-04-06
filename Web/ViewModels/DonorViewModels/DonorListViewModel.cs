using System;
using System.Collections.Generic;
using BancoDeSangre.Enums;
using BancoDeSangre.Interfaces;
using BancoDeSangre.Models;

namespace BancoDeSangre.ViewModels.DonorViewModels
{
    public class DonorListViewModel
    {
        public List<Donor> Donors { get; set; }
    }
}