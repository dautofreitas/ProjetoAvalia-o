using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeaWebMVC.Utils
{
    public class MessageReturn
    {
        public List<string> MessagesError;
        public bool IsValid ;

        public MessageReturn()
        {
            MessagesError = new List<string>();
            IsValid = true;
        }
        

        public void AddError(string erro)
        {
            MessagesError.Add(erro);
            this.IsValid = false;
        }

        public void Clean()
        {
            MessagesError.Clear();
        }

    }
}