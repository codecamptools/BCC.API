using System;
using System.Collections.Generic;
using System.Text;

namespace Bcc.Business.Commands
{

    public class CreateConferenceCommand : CommandBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
