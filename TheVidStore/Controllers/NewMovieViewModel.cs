using System.Collections.Generic;
using TheVidStore.Models;

namespace TheVidStore.Controllers
{
    internal class NewMovieViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }
        public object Movie { get; set; }
    }
}