using System;
using System.Collections.Generic;

namespace WebAppDbFirstSettings.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = null!;
        public string PlayerRole { get; set; } = null!;
        public int? TeamName { get; set; }

        public virtual Team? TeamNameNavigation { get; set; }
    }
}
