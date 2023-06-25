using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
    }
}
