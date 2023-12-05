using ReadingClub.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingClub.utils.shared
{
    enum OperationStatus
    {
        SUCCESS,
        ERROR
    }
    class AuthActionResult
    {
        public OperationStatus Status { get; set; }
        public string Message { get; set; }
        public User user { get; set; }
    }
}
