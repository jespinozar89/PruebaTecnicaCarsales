using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string OriginName { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime Created { get; set; }

    
    }
}