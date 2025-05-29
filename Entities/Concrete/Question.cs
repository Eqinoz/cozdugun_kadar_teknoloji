using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Question:IEntity
    {
        public string QuestionText{ get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
