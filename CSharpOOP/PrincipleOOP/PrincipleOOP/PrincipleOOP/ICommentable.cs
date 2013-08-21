using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP
{
    interface ICommentable
    {
        List<string> Comments { get; set; }
        void AddComment(string comment);
    }
}
