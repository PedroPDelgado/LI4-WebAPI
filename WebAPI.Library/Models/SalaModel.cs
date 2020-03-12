using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Library.Models
{
    class SalaModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Estado { get; set; }
        public int PlaylistId { get; set; }
    }
}
