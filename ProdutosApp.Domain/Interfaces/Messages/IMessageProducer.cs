﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Messages
{
    public interface IMessageProducer
    {
        void Send(string message);
    }
}
